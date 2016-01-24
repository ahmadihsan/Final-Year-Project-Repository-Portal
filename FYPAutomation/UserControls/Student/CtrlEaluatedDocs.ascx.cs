using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlEaluatedDocs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGrid();
            }
        }

        private void PopulateGrid()
        {
            long id = FYPSession.GetLoggedUser().UserId;
            using(var fyp = new  FYPEntities())
            {
                var pop = from pm in fyp.ProjectMileStones
                          join um in fyp.UploadedMileStones on pm.PMSId equals um.PMSId
                          join umdv in fyp.UploadedMileStoneDocsVersions on um.UMSId equals umdv.UMSId
                          where umdv.UploadedBy == id 
                          select new
                          {
                              pm.Name,
                              umdv.UploadedFile
                          };
               GvdViewAllDocs.DataSource = pop.ToList();
               GvdViewAllDocs.DataBind();
            }
        }
    }
}