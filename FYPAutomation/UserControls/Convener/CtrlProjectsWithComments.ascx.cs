using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Convener
{
    public partial class CtrlProjectsWithComments : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMileStone();
                PopulateSessions();
                PopulateGridAssignedProjects();
            }
        }

        private void PopulateMileStone()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select Milestone");
            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.Where(ps=>ps.Status==true).ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateGridAssignedProjects()
        {
            using (var fyp = new FYPEntities())
            {
                var psId = fyp.ProjectSessions.Max(pss => pss.PSId);
                GvdAssignedProjects.DataSource = fyp.Projects.Where(x=>x.ProjectSessionId==psId && x.Status==2).ToList();
                GvdAssignedProjects.DataBind();
            }
        }

        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {

            using (var fyp = new FYPEntities())
            {

                if (ddlSession.SelectedIndex == 0)
                {
                    PopulateGridAssignedProjects();
                }
                else
                {
                    long psid = Convert.ToInt64(ddlSession.SelectedValue);
                    GvdAssignedProjects.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                    GvdAssignedProjects.DataBind();
                }

            }
        }

        protected void GvdAssignedProjectsSelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey dk = GvdAssignedProjects.DataKeys[GvdAssignedProjects.SelectedIndex];
            if (dk != null && dk.Values != null)
            {
                long pid = Convert.ToInt64(dk.Values["PId"]);
                Response.Redirect("~/Pages/Convener/CommentsByPC.aspx?PId=" + pid);
            }
        }

        protected void BtnCommentsClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid, pmsid;
                if(long.TryParse(ddlSession.SelectedValue,out  psid) && long.TryParse(ddlMileStone.SelectedValue,out pmsid))
                {
                    fyp.SP_MakeCommentsVisibleToStudent(psid, pmsid);
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Done successfully" }, this.Page, true);
                }
                else
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Warning",new List<string>(){"Please select milestone and session"},this.Page,true );
                }

            }
        }

        //protected void MileStoneSearchSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    using (var fyp = new FYPEntities())
        //    {
        //        if (ddlMileStone.SelectedIndex == 0)
        //        {
        //            PopulateGridAssignedProjects();
        //        }
        //        else
        //        {
        //            GvdAssignedProjects.DataSource = null;
        //            long pmid;
        //            if (long.TryParse(ddlMileStone.SelectedValue, out pmid))
        //            {
        //                GvdAssignedProjects.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psId && x.Status == 2).ToList();
        //                GvdAssignedProjects.DataBind();
        //            }
        //        }
        //    }
        //}
    }
}