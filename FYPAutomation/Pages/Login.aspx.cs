using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYPAutomation.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cmd"] != null && Request.QueryString["cmd"] == "logout")
                FYPUtilities.FYPSession.ReleaseSession();
        }
    }
}