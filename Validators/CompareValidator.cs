namespace Sample.Web.UI.Compatibility {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    [
    AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)
    ]
    public class CompareValidator : System.Web.UI.WebControls.CompareValidator, IBaseCompareValidatorAccessor {
        private ScriptManager _scriptManager;
        private bool _scriptManagerChecked;

        public CompareValidator() {
        }

        internal ScriptManager ScriptManager {
            get {
                if (!_scriptManagerChecked) {
                    _scriptManagerChecked = true;
                    Page page = Page;
                    if (page != null) {
                        _scriptManager = ScriptManager.GetCurrent(page);
                    }
                }
                return _scriptManager;
            }
        }


        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.AddAttributesToRender(writer);
                return;
            }

            ValidatorHelper.DoBaseValidatorAddAttributes(this, this, writer);
            ValidatorHelper.DoBaseCompareValidatorAddAttributes(this, this);

            if (RenderUplevel) {
                string id = ClientID;
                ValidatorHelper.AddExpandoAttribute(this, id, "evaluationfunction", "CompareValidatorEvaluateIsValid", false);
                if (ControlToCompare.Length > 0) {
                    string controlToCompareID = GetControlRenderID(ControlToCompare);
                    ValidatorHelper.AddExpandoAttribute(this, id, "controltocompare", controlToCompareID);
                    ValidatorHelper.AddExpandoAttribute(this, id, "controlhookup", controlToCompareID);
                }
                if (ValueToCompare.Length > 0) {

                    string valueToCompareString = ValueToCompare;
                    if (CultureInvariantValues) {
                        valueToCompareString = ConvertCultureInvariantToCurrentCultureFormat(valueToCompareString, Type);
                    }
                    ValidatorHelper.AddExpandoAttribute(this, id, "valuetocompare", valueToCompareString);
                }
                if (Operator != ValidationCompareOperator.Equal) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "operator", PropertyConverter.EnumToString(typeof(ValidationCompareOperator), Operator), false);
                }
            }
        }

        internal static string ConvertCultureInvariantToCurrentCultureFormat(string valueInString,
                                                                      ValidationDataType type) {
            object value;
            Convert(valueInString, type, true, out value);
            if (value is DateTime) {
                return ((DateTime)value).ToShortDateString();
            }
            else {
                return System.Convert.ToString(value, CultureInfo.CurrentCulture);
            }
        }

        protected override void OnInit(EventArgs e) {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.OnInit(e);
                return;
            }

            base.OnInit(e);

            ValidatorHelper.DoInitRegistration(Page);
        }

        protected override void OnPreRender(EventArgs e) {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.OnPreRender(e);
                return;
            }

            base.OnPreRender(e);

            ValidatorHelper.DoPreRenderRegistration(this, this);
        }

        protected override void RegisterValidatorDeclaration() {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.RegisterValidatorDeclaration();
                return;
            }

            ValidatorHelper.DoValidatorArrayDeclaration(this, typeof(CompareValidator));
        }

        #region IBaseValidatorAccessor Members
        bool IBaseValidatorAccessor.RenderUpLevel {
            get {
                return RenderUplevel;
            }
        }

        HtmlTextWriterTag IWebControlAccessor.TagKey {
            get {
                return TagKey;
            }
        }

        void IBaseValidatorAccessor.EnsureID() {
            EnsureID();
        }

        string IBaseValidatorAccessor.GetControlRenderID(string name) {
            return GetControlRenderID(name);
        }
        #endregion

        #region IBaseCompareValidatorAccessor Members
        int IBaseCompareValidatorAccessor.CutoffYear {
            get {
                return CutoffYear;
            }
        }

        string IBaseCompareValidatorAccessor.GetDateElementOrder() {
            return GetDateElementOrder();
        }
        #endregion
    }
}
