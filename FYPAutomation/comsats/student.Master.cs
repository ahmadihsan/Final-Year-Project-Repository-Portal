using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.comsats
{
    public partial class student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!FYPUtilities.FYPSession.IsUserLoggedIn())
            {
                dvQuickLunch.Visible = false;
                dvContent.Attributes.Add("class", "span6 offset3  well clearfix");
            }
            else
            {
                lblOnlineUsers.Text = "Current Online Users" + Application["sessionCount"].ToString();
            }
        }
    }
}