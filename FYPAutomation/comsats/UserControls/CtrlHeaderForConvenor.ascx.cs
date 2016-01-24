using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.comsats
{
    public partial class CtrlHeaderForConvenor: System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!FYPUtilities.FYPSession.IsUserLoggedIn())
                CtrlMenuControlForConvenor.Visible = false;
        }
        
    }
}