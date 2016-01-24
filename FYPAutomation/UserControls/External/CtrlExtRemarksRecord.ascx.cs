using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlExtRemarksRecord : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateList();
            }
        }


        private void PopulateList()
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPSession.GetLoggedUser().UserId;



                var data = from p in fyp.Projects
                           join pg in fyp.ProjectGroups on p.PId equals pg.ProjectId
                           join mse in fyp.MileStoneEvaluations on pg.ProjectId equals mse.ProjectId
                           join u in fyp.Users on mse.CommentedBy equals u.UId
                           join r in fyp.Roles on u.RoleId equals r.Rid
                           join pms in fyp.ProjectMileStones on mse.PMSId equals pms.PMSId
                           where u.UId == uid

                           select new
                           {
                               p.PId,
                               u.Name,
                               p.Tiltle,
                               mse.CommentByExternal,
                               mse.CommentByPcAboutProject,
                               mse.ObtainMarks,
                               projectMileName = pms.Name,
                               RoleName = r.Name

                           };
                lstComments.DataSource = data.Distinct().ToList();
                lstComments.DataBind();
            }
        }

       
    }
}