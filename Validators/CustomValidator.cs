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
    public class CustomValidator : System.Web.UI.WebControls.CustomValidator, IBaseValidatorAccessor {
        private ScriptManager _scriptManager;
        private bool _scriptManagerChecked;

        public CustomValidator() {
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

            if (RenderUplevel) {
                string id = ClientID;

                ValidatorHelper.AddExpandoAttribute(this, id, "evaluationfunction", "CustomValidatorEvaluateIsValid", false);
                if (ClientValidationFunction.Length > 0) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "clientvalidationfunction", ClientValidationFunction);
                    if (ValidateEmptyText) {
                        ValidatorHelper.AddExpandoAttribute(this, id, "validateemptytext", "true", false);
                    }
                }
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

            ValidatorHelper.DoValidatorArrayDeclaration(this, typeof(CustomValidator));
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
    }
}
