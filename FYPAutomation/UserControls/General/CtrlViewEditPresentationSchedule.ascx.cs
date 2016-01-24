using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlViewEditPresentationSchedule : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMileStonesSearch();
                PopulateSessionsSearch();
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
        /// Populating Project sessions to search dropdownlist
        /// </summary>
        private void PopulateSessionsSearch()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSearch.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSearch.DataBind();
                ddlSessionSearch.Items.Insert(0, "Select Session");
            }
        }

        /// <summary>
        /// Load Grid for Projects
        /// </summary>
        private void LoadGridData()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = fyp.ProjectSessions.Max(p => p.PSId);

                var data = fyp.SP_GetPresentationSchedule(psid, null);
                GvdPresentationSchedule.DataSource = data.ToList();
                GvdPresentationSchedule.DataBind();
            }
        }

        /// <summary>
        /// Available time of student and faculty with suggested time is implemented 
        /// </summary>
        protected void GvdPresentationDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataKey dk = GvdPresentationSchedule.DataKeys[e.Row.RowIndex];
            //    var gvrSuggestedTime = e.Row.FindControl("gvdSuggestedTimes") as GridView;
            //    //var ddlroom = e.Row.FindControl("ddlRoom") as DropDownList;
            //    if (dk != null && dk.Values != null && gvrSuggestedTime != null)//&& ddlroom != null
            //    {
            //        long pid = Convert.ToInt64(dk.Values["PId"]);
            //        using (var fyp = new FYPEntities())
            //        {
            //            //ddlroom.DataSource = fyp.RoomsForPresentations.ToList();
            //            //ddlroom.DataBind();
            //            //ddlroom.Items.Insert(0, "Select Room");
            //            //gvrStudent.DataSource = fyp.SP_GetAvailableTimeOfStudent(pid);
            //            //gvrStudent.DataBind();
            //            //gvrFaculty.DataSource = fyp.SP_GetAvailableTimeOfFaculty(pid);
            //            //gvrFaculty.DataBind();
            //            var data = from dat in fyp.SP_GetMatchingFreeTime(pid)
            //                       where dat.MatchingCount > 1
            //                       select dat;
            //            gvrSuggestedTime.DataSource = data;
            //            gvrSuggestedTime.DataBind();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Edit Presentation Timings
        /// </summary>
        protected void LinkEditClicked(object sender, EventArgs e)
        {
            var lnkEdit11 = sender as LinkButton;
            if (lnkEdit11 != null)
            {
                int row = ((GridViewRow)lnkEdit11.NamingContainer).RowIndex;
                GvdPresentationSchedule.EditIndex = row;
                LoadGridData();
                var txtStartTime = GvdPresentationSchedule.Rows[row].Cells[3].FindControl("txtStartTimeEdit") as TextBox;
                var txtEndTime = GvdPresentationSchedule.Rows[row].Cells[3].FindControl("txtEndTimeEdit") as TextBox;
                var ddlroom = GvdPresentationSchedule.Rows[row].Cells[4].FindControl("ddlRoomEdit") as DropDownList;

                if (txtStartTime != null && txtEndTime != null && ddlroom != null)
                {
                    using (var fyp = new FYPEntities())
                    {
                        ddlroom.DataSource = fyp.RoomsForPresentations.ToList();
                        ddlroom.DataBind();
                        ddlroom.Items.Insert(0, "Select Room");
                        DataKey dk = GvdPresentationSchedule.DataKeys[row];
                        if (dk != null && dk.Values != null)
                        {
                            long pscrid = Convert.ToInt64(dk.Values["PRSCId"]);
                            PresentationSchedule prsc = fyp.PresentationSchedules.FirstOrDefault(psc => psc.PRSCId == pscrid);
                            if (prsc != null)
                            {
                                txtStartTime.Text = prsc.TimeFrom.ToString();
                                txtEndTime.Text = prsc.TimeTo.ToString();
                                ddlroom.SelectedIndex = ddlroom.Items.IndexOf(ddlroom.Items.FindByValue(prsc.RoomNumber.ToString()));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Update Presentation Timings
        /// </summary>
        protected void LnkUpdateClicked(object sender, EventArgs e)
        {
            var lnkUpdate = sender as LinkButton;
            if (lnkUpdate != null)
            {
                int row = ((GridViewRow)lnkUpdate.NamingContainer).RowIndex;
                DataKey dk = GvdPresentationSchedule.DataKeys[row];
                if (dk != null && dk.Values != null)
                {
                    long pscrid = Convert.ToInt64(dk.Values["PRSCId"]);
                    using (var fyp = new FYPEntities())
                    {
                        var txtStartTime = GvdPresentationSchedule.Rows[row].FindControl("txtStartTimeEdit") as TextBox;
                        var txtEndTime = GvdPresentationSchedule.Rows[row].FindControl("txtEndTimeEdit") as TextBox;
                        var txtDate = GvdPresentationSchedule.Rows[row].FindControl("txtSelectDate") as TextBox;
                        var ddlroom = GvdPresentationSchedule.Rows[row].FindControl("ddlRoomEdit") as DropDownList;
                        if (txtStartTime != null && txtEndTime != null && ddlroom != null &&txtDate!=null)
                        {
                            PresentationSchedule prsc = fyp.PresentationSchedules.FirstOrDefault(psc => psc.PRSCId == pscrid);
                            if (prsc != null)
                            {
                                prsc.TimeFrom = FrequentAccesses.FormatTime(txtStartTime.Text);
                                prsc.TimeTo = FrequentAccesses.FormatTime(txtEndTime.Text);
                                prsc.RoomNumber = Convert.ToInt32(ddlroom.SelectedValue);
                                prsc.PresentationDate = Convert.ToDateTime(txtDate.Text);
                                if (fyp.SaveChanges() > 0)
                                {
                                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Presentation Schedule Updated successfully" }, this.Page, true);
                                    GvdPresentationSchedule.EditIndex = -1;
                                    LoadGridData();
                                }
                                else
                                {
                                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Some error occured while updating information" }, this.Page, true);
                                    GvdPresentationSchedule.EditIndex = -1;
                                    LoadGridData();
                                }
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Check Conflicts of presentation timing
        /// </summary>      
        protected void BtnCheckConflictClicked(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
            {
                gvr.BackColor = Color.Transparent;
            }

            var initialTimes = new List<string>();
            var conflictedTimes = new List<string>();
            foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
            {
                var lblStartTime = gvr.FindControl("lblTimeFrom") as Label;
                if (lblStartTime != null)
                {
                    initialTimes.Add(lblStartTime.Text);
                }
            }
            var txtStartTime = GvdPresentationSchedule.Rows[GvdPresentationSchedule.EditIndex].Cells[3].FindControl("txtStartTimeEdit") as TextBox;
            
            if (txtStartTime != null)
            {
                for (int i = 0; i < initialTimes.Count; i++)
                {
                    if (initialTimes[i].Replace(" ", "") == txtStartTime.Text.ToUpper().Replace(" ",""))
                    {
                        conflictedTimes.Add(initialTimes[i]);
                    }
                }
            }

            for (int i = 0; i < conflictedTimes.Count; i++)
            {
                foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
                {
                    var lblStartTime = gvr.FindControl("lblTimeFrom") as Label;
                    if (lblStartTime != null)
                    {
                        if (conflictedTimes[i].Replace(" ", "") == lblStartTime.Text.ToUpper().Replace(" ", ""))
                        {
                            gvr.BackColor = Color.Red;
                        }
                    }
                }
            }
            if(conflictedTimes.Count>0)
            {
                GvdPresentationSchedule.Rows[GvdPresentationSchedule.EditIndex].BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Search By Project Session
        /// </summary>
        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid,pmsid;
                if (ddlMileStonesSearch.SelectedIndex!=0 && ddlSessionSearch.SelectedIndex!=0)
                {
                    psid = Convert.ToInt64(ddlSessionSearch.SelectedValue);
                    pmsid = Convert.ToInt64(ddlMileStonesSearch.SelectedValue);
                    var projects = fyp.SP_GetPresentationSchedule(psid, pmsid);
                    GvdPresentationSchedule.DataSource = projects.ToList(); 
                    GvdPresentationSchedule.DataBind();
                }
                else if (ddlMileStonesSearch.SelectedIndex == 0 && ddlSessionSearch.SelectedIndex != 0)
                {
                    psid = Convert.ToInt64(ddlSessionSearch.SelectedValue);
                    var projects = fyp.SP_GetPresentationSchedule(psid, null);
                    GvdPresentationSchedule.DataSource = projects.ToList();
                    GvdPresentationSchedule.DataBind();
                }
                else
                {
                    LoadGridData();
                }
            }
        }

        /// <summary>
        /// Search By Project Milestone
        /// </summary>
        protected void MilestoneSearchIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid, pmsid;
                if (ddlMileStonesSearch.SelectedIndex != 0 && ddlSessionSearch.SelectedIndex != 0)
                {
                    psid = Convert.ToInt64(ddlSessionSearch.SelectedValue);
                    pmsid = Convert.ToInt64(ddlMileStonesSearch.SelectedValue);
                    var projects = fyp.SP_GetPresentationSchedule(psid, pmsid);
                    GvdPresentationSchedule.DataSource = projects.ToList();
                    GvdPresentationSchedule.DataBind();
                }
                else if (ddlMileStonesSearch.SelectedIndex != 0 && ddlSessionSearch.SelectedIndex == 0)
                {
                    pmsid = Convert.ToInt64(ddlMileStonesSearch.SelectedValue);
                    var projects = fyp.SP_GetPresentationSchedule(null, pmsid);
                    GvdPresentationSchedule.DataSource = projects.ToList();
                    GvdPresentationSchedule.DataBind();
                }
                else
                {
                    LoadGridData();
                }
            }
        }

        /// <summary>
        /// Presentation Schedule updation cancellation : cancel clicked
        /// </summary>
        protected void LnkCancelClicked(object sender, EventArgs e)
        {
            GvdPresentationSchedule.EditIndex = -1;
            LoadGridData();
        }

        /// <summary>
        /// Add new presetnation schedule : redirect page according to Role
        /// </summary>
        protected void AddPresentationScheduleClicked(object sender, EventArgs e)
        {
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "convener")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Convener/PresentationSchedule.aspx"));
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Admin/PresentationSchedule.aspx"));
            }
        }

        
    }
}