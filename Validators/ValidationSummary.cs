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
    public class ValidationSummary : System.Web.UI.WebControls.ValidationSummary, IWebControlAccessor {
        private bool _scriptManagerChecked;
        private ScriptManager _scriptManager;
        private Page _page;


        public ValidationSummary() {
        }

        internal ValidationSummary(ScriptManager scriptManager, Page page) {
            _scriptManager = scriptManager;
            _page = page;
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

        private bool RenderUpLevel {
            get {
                if (Page != null) {
                    return
                        (EnableClientScript &&
                        (Page.Request.Browser.W3CDomVersion.Major >= 1) &&
                        (Page.Request.Browser.EcmaScriptVersion.CompareTo(new Version(1, 2)) >= 0));
                }
                return false;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.AddAttributesToRender(writer);
                return;
            }

            if (RenderUpLevel) {
                EnsureID();
                string id = ClientID;

                if (HeaderText.Length > 0) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "headertext", HeaderText, true);
                }
                if (ShowMessageBox) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "showmessagebox", "True", false);
                }
                if (!ShowSummary) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "showsummary", "False", false);
                }
                if (DisplayMode != ValidationSummaryDisplayMode.BulletList) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "displaymode", PropertyConverter.EnumToString(typeof(ValidationSummaryDisplayMode), DisplayMode), false);
                }
                if (ValidationGroup.Length > 0) {
                    ValidatorHelper.AddExpandoAttribute(this, id, "validationGroup", ValidationGroup, true);
                }
            }

            ValidatorHelper.DoWebControlAddAttributes(this, this, writer);
        }

        protected override void OnPreRender(EventArgs e) {
            if (ScriptManager == null || !ScriptManager.SupportsPartialRendering) {
                base.OnPreRender(e);
                return;
            }

            base.OnPreRender(e);

            if (!Enabled) {
                return;
            }

            if (RenderUpLevel) {
                if (ScriptManager.IsInAsyncPostBack) {
                    string element = "document.getElementById(\"" + ClientID + "\")";
                    System.Web.UI.ScriptManager.RegisterArrayDeclaration(this, "Page_ValidationSummaries", element);
                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(ValidationSummary), ClientID + "_DisposeScript",
                    String.Format(
                        CultureInfo.InvariantCulture,
                        @"
document.getElementById('{0}').dispose = function() {{
    Array.remove(Page_ValidationSummaries, document.getElementById('{0}'));
}}
",
                        ClientID), true);

            }
        }

        #region IWebControlAccessor Members
        HtmlTextWriterTag IWebControlAccessor.TagKey {
            get {
                return TagKey;
            }
        }
        #endregion
    }
}
