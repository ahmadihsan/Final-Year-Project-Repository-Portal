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
    public partial class CtrlCommentsToSupervisor : FYPBaseUserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateMileStone();
                PopulateProjects();
                //PopulateList();
            }
        }

        private void PopulateList()
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var data = from p in fyp.Projects
                           join sb in fyp.SupervisodBies on p.PId equals sb.ProjectId
                           join mse in fyp.MileStoneEvaluations on sb.ProjectId equals mse.ProjectId
                           join pms in fyp.ProjectMileStones on mse.PMSId equals pms.PMSId
                           where sb.SupervisodBy1 == uid && mse.IsVisibletToStudent==true
                           select new
                                      {
                                          p.PId,
                                          p.Tiltle,
                                          mse.CommentByHead,
                                          mse.CommentBySupervisor,
                                          mse.CommentByPC,
                                          mse.ObtainMarks,
                                          mse.CommentByExternal,
                                          mse.CommentedByPCHead,
                                          pms.Name
                                      };
                lstComments.DataSource = data.Distinct().ToList();
                lstComments.DataBind();
            }
        }

        private void PopulateMileStone()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }

        private void PopulateProjects()
        {
            using (var fypEntities = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var query = fypEntities.SupervisodBies.Where(sb => sb.SupervisodBy1 == uid).Select(ss=>ss.ProjectId);
                var data = from p in fypEntities.Projects
                           where query.Contains(p.PId)
                           select new
                                      {
                                          p.Tiltle,
                                          p.PId
                                      };
                
                ddlProjects.DataSource = data.ToList();
                ddlProjects.DataBind();
                ddlProjects.Items.Insert(0, "Select Project");
            }
        }


        protected void MileStoneSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                long pid = 0;
                if(ddlProjects.SelectedIndex != 0)
                 pid = Convert.ToInt32( ddlProjects.SelectedValue);
                long pmsid;
                if (long.TryParse(ddlMileStone.SelectedValue, out pmsid))
                {
                    
                    var data = from p in fyp.Projects
                               join sb in fyp.SupervisodBies on p.PId equals sb.ProjectId
                               join mse in fyp.MileStoneEvaluations on sb.ProjectId equals mse.ProjectId
                               join u in fyp.Users on mse.CommentedBy equals u.UId
                               join r in fyp.Roles on u.RoleId equals r.Rid
                               join pms in fyp.ProjectMileStones on mse.PMSId equals pms.PMSId
                               where sb.SupervisodBy1 == uid && mse.PMSId == pmsid && mse.ProjectId == pid
                               select new
                               {
                                   p.PId,
                                   p.Tiltle,
                                   u.Name,
                                   mse.CommentedByPCHead,
                                   mse.CommentByHead,
                                   mse.CommentBySupervisor,
                                   mse.CommentByPC,
                                   mse.CommentByExternal,
                                   mse.ObtainMarks,
                                   mse.CommentByPcAboutProject,
                                   projectMileName = pms.Name,
                                   RoleName = r.Name
                               };
                    lstComments.DataSource = data.Distinct().ToList();
                    lstComments.DataBind();
                }
               
            }
        }

        protected void ProjectSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                long pid;
                long pmsid = 0;
                if(ddlMileStone.SelectedIndex != 0)
                 pmsid= Convert.ToInt64(ddlMileStone.SelectedValue);
                if(long.TryParse(ddlProjects.SelectedValue,out pid))
                {
                    var data = from p in fyp.Projects
                               join sb in fyp.SupervisodBies on p.PId equals sb.ProjectId
                               join mse in fyp.MileStoneEvaluations on sb.ProjectId equals mse.ProjectId
                               join u in fyp.Users on mse.CommentedBy equals u.UId
                               join r in fyp.Roles on u.RoleId equals r.Rid
                               join pms in fyp.ProjectMileStones on mse.PMSId equals pms.PMSId
                               where sb.SupervisodBy1 == uid && sb.ProjectId == pid && mse.PMSId == pmsid
                               select new
                               {
                                   p.PId,
                                   p.Tiltle,
                                   u.Name,
                                   mse.CommentedByPCHead,
                                   mse.CommentByHead,
                                   mse.CommentBySupervisor,
                                   mse.CommentByPC,
                                   mse.CommentByExternal,
                                   mse.CommentByPcAboutProject,
                                   projectMileName = pms.Name,
                                   RoleName = r.Name
                               };
                    lstComments.DataSource = data.Distinct().ToList();
                    lstComments.DataBind();
                }
               
            }
        }

    }
}