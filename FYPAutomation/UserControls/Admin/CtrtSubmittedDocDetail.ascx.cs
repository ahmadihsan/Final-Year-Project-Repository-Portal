using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrtSubmittedDocDetail : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDocDetail();
            }
        }

        private void PopulateDocDetail()
        {
            using (var fyp=new FYPEntities())
            {
                
            }
        }
    }
}