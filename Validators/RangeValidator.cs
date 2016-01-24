namespace Sample.Web.UI.Compatibility {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;

    [
    AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)
    ]
    public class RangeValidator : System.Web.UI.WebControls.RangeValidator, IBaseCompareValidatorAccessor {
        private bool _scriptManagerChecked;
        private ScriptManager _scriptManager;


        public RangeValidator() {
        }

        internal ScriptManager ScriptManager {
            get {
                if (!_scriptManagerChecked) {
                    _scriptManagerChecked = true;
                    Page page = Page;
                    if (page != null) {
                        _scriptManager = System.Web.UI.ScriptManager.GetCurrent(page);
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
                ValidatorHelper.AddExpandoAttribute(this, id, "evaluationfunction", "RangeValidatorEvaluateIsValid", false);

                string maxValueString = MaximumValue;
                string minValueString = MinimumValue;
                if (CultureInvariantValues) {
                    maxValueString = CompareValidator.ConvertCultureInvariantToCurrentCultureFormat(maxValueString, Type);
                    minValueString = CompareValidator.ConvertCultureInvariantToCurrentCultureFormat(minValueString, Type);
                }
                ValidatorHelper.AddExpandoAttribute(this, id, "maximumvalue", maxValueString);
                ValidatorHelper.AddExpandoAttribute(this, id, "minimumvalue", minValueString);
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

            ValidatorHelper.DoValidatorArrayDeclaration(this, typeof(RangeValidator));
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
