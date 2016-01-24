using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYPAutomation.Pages
{
    public partial class ziagetFolderLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            
            DateTime newDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            Response.Write("Local Time : "+DateTime.Now);

            Response.Write("<br><br>Time Zone : " +timeZoneInfo);
            Response.Write("<br>New Time :" +newDateTime);
        }
    }
}