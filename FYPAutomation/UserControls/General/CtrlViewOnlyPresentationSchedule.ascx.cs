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
    public partial class CtrlMyPresentationSchedule_ : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var fyp=new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var usr = fyp.Users.FirstOrDefault(x => x.UId == uid);
                if(usr !=null)
                {
                    lblSession.Text = FrequentAccesses.GetProjectSessionNameById(Convert.ToInt64(usr.ProjectSessionId));
                }
            }
            if (!IsPostBack)
            {
                PopulateMileStonesSearch();
                LoadGridData();
            }
        }
        /// <summary>
        /// Populating milestones to search dropdownlist
        /// </summary>
        private void PopulateMileStonesSearch()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStonesSearch.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStonesSearch.DataBind();
                ddlMileStonesSearch.Items.Insert(0, "Select Milestone");
            }
        }

        /// <summary>
        /// Load Grid for Projects
        /// </summary>
        private void LoadGridData()
        {
            long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            long psid = Convert.ToInt64(FrequentAccesses.GetProjectSessionIdByUserId(uid));
            using (var fyp = new FYPEntities())
            {
                var data = fyp.SP_GetPresentationsToStudent(psid,null);
                GvdMyPresentationSchedule.DataSource = data.ToList();
                GvdMyPresentationSchedule.DataBind();
            }
        }

        /// <summary>
        /// Search By Project Milestone
        /// </summary>
        protected void MilestoneSearchIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                long psid, pmsid;
                if (ddlMileStonesSearch.SelectedIndex != 0)
                {
                    psid = Convert.ToInt64(FrequentAccesses.GetProjectSessionIdByUserId(uid));
                    pmsid = Convert.ToInt64(ddlMileStonesSearch.SelectedValue);
                    var projects = fyp.SP_GetPresentationsToStudent(psid, pmsid);
                    GvdMyPresentationSchedule.DataSource = projects.ToList();
                    GvdMyPresentationSchedule.DataBind();
                }
                else
                {
                    LoadGridData();
                }
            }
        }
    }
}