using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FYPAutomation.App_Start
{
    public class FYPBasePage : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            var loggedUser = FYPUtilities.FYPSession.GetLoggedUser();
            if (loggedUser != null)
            {
                var roleName = loggedUser.RoleName;
                var rawUrl = Request.RawUrl.ToLower();
                string requestedUrl = rawUrl.Contains("?") ? rawUrl.Substring(0, rawUrl.IndexOf('?')) : rawUrl;
                if (!requestedUrl.Contains(string.Format("/Pages/{0}/", roleName).ToLower()) && !requestedUrl.Contains(string.Format("/Pages/student/").ToLower()) && !requestedUrl.Contains(string.Format("/Pages/convener/").ToLower()) && !requestedUrl.Contains(string.Format("/Pages/PCMember/").ToLower()) && !requestedUrl.Contains(string.Format("/Pages/Supervisor/").ToLower()) && !requestedUrl.Contains(string.Format("/Pages/Faculty/").ToLower()))
                {
                    Response.Redirect("~/Pages/login.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Pages/login.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}