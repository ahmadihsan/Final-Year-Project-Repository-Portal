using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlCommentsToStudent : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMileStone();
               // PopulateList();
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

        protected void MileStoneSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPSession.GetLoggedUser().UserId;
                long pmsid;
                
                if (long.TryParse(ddlMileStone.SelectedValue,out pmsid))
                {
                    var data = from p in fyp.Projects
                               join pg in fyp.ProjectGroups on p.PId equals pg.ProjectId
                               join mse in fyp.MileStoneEvaluations on pg.ProjectId equals mse.ProjectId
                               join u in fyp.Users on mse.CommentedBy equals u.UId
                               join r in fyp.Roles on u.RoleId equals r.Rid
                               join pms in fyp.ProjectMileStones on mse.PMSId equals pms.PMSId
                               where pg.StudentId == uid && mse.IsVisibletToStudent == true && pms.PMSId == pmsid && mse.StudentId == uid
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

                    
                    //var supervisedBy = from sup in fyp.SupervisodBies
                    //               join proj in fyp.ProjectGroups on sup.ProjectId equals proj.ProjectId
                    //               join me in fyp.MileStoneEvaluations on sup.SupervisodBy1 equals me.CommentedBy
                    //               where proj.StudentId == uid && proj.ProjectId == data.FirstOrDefault().PId && me.CommentedBy == sup.SupervisodBy1 
                    //               select new{
                    //                   proj.ProjectId
                    //               };
                    //if(data.FirstOrDefault().RoleName == "PCMember" && data.FirstOrDefault().PId == supervisedBy.FirstOrDefault().ProjectId )
                    //{
                    //    data.Select(r => { r.RoleName = "Supervisor"; return true; }).ToList();
                    //}
                    lstComments.DataSource = data.Distinct().ToList();
                    lstComments.DataBind();
                }
                
               
            }
        }
    }
}