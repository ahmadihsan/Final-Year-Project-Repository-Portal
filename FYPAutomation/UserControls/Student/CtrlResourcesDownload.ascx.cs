using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlResourcesDownload : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridForAnnouncemnts();
        }

        private void PopulateGridForAnnouncemnts()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdDeadline.DataSource = fypEntities.TemplateDocuments.ToList();
                GvdDeadline.DataBind();
            }
        }
    }
}