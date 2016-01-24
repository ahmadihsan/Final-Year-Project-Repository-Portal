using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.Convener
{
    public partial class CtrlPresentationSchedule : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myTableToShow.Visible = false;
                mvPresentation.ActiveViewIndex = 0;
                PopulateSession();
                PopulateMileStones();
                //PopulateSessionsSearch();
                //PopulateMileStonesSearch();
                //LoadRooms();
            }
        }


        private void PopulateSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSelection.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSelection.DataBind();
                ddlSessionSelection.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateMileStones()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMilestoneSelection.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMilestoneSelection.DataBind();
                ddlMilestoneSelection.Items.Insert(0, "Select MileStone");
            }
        }

        /// <summary>
        /// Load Grid for Projects
        /// </summary>
        private void LoadGridData()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = Convert.ToInt64(ddlSessionSelection.SelectedValue);
                long pmsid = Convert.ToInt64(ddlMilestoneSelection.SelectedValue);
                int noofpres = Convert.ToInt32(txtNoPresentation.Text);
                var projects = fyp.SP_GetRecordsForPresentation(psid, pmsid, noofpres);
                GvdPresentationSchedule.DataSource = projects;
                GvdPresentationSchedule.DataBind();
            }
        }
        /// <summary>
        /// Available time of student and faculty with suggested time is implemented 
        /// </summary>
        protected void GvdPresentationDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey dk = GvdPresentationSchedule.DataKeys[e.Row.RowIndex];
                //var gvrStudent = e.Row.FindControl("gvdStudentSlot") as GridView;
                //var gvrFaculty = e.Row.FindControl("gvdSupervisorSlot") as GridView;
                var gvrSuggestedTime = e.Row.FindControl("gvdSuggestedTimes") as GridView;
                var ddlroom = e.Row.FindControl("ddlRoom") as DropDownList;
                if (dk != null && dk.Values != null && gvrSuggestedTime != null && ddlroom != null)
                {
                    long pid = Convert.ToInt64(dk.Values["PId"]);
                    using (var fyp = new FYPEntities())
                    {
                        ddlroom.DataSource = fyp.RoomsForPresentations.ToList();
                        ddlroom.DataBind();
                        ddlroom.Items.Insert(0, "Select Room");
                        //gvrStudent.DataSource = fyp.SP_GetAvailableTimeOfStudent(pid);
                        //gvrStudent.DataBind();
                        //gvrFaculty.DataSource = fyp.SP_GetAvailableTimeOfFaculty(pid);
                        //gvrFaculty.DataBind();
                        var data = from dat in fyp.SP_GetMatchingFreeTime(pid)
                                   where dat.MatchingCount > 1
                                   select dat;
                        gvrSuggestedTime.DataSource = data;
                        gvrSuggestedTime.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// Wizards code : Step 1 button clicked
        /// </summary>
        protected void BtnGoToStep2Clicked(object sender, EventArgs e)
        {
            hfTime.Value = txtDuration.Text;
            mvPresentation.ActiveViewIndex = 1;
            LoadGridData();
            myTableToShow.Visible = true;
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
                var txtStartTime = gvr.FindControl("txtStartTime") as TextBox;
                if (txtStartTime != null)
                {
                    initialTimes.Add(txtStartTime.Text);
                }
            }

            for (int i = 0; i < initialTimes.Count; i++)
            {
                for (int j = i + 1; j < initialTimes.Count; j++)
                {
                    if (initialTimes[i] == initialTimes[j])
                    {
                        conflictedTimes.Add(initialTimes[i]);
                        break;
                    }
                }
            }
            for (int i = 0; i < conflictedTimes.Count; i++)
            {
                foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
                {
                    var txtStartTime = gvr.FindControl("txtStartTime") as TextBox;
                    if (txtStartTime != null)
                    {
                        if (conflictedTimes[i] == txtStartTime.Text)
                        {
                            gvr.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Insert Presentation timing into database
        /// </summary>
        protected void BtnSubmitClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid = Convert.ToInt64(ddlSessionSelection.SelectedValue);
                long pmsid = Convert.ToInt64(ddlMilestoneSelection.SelectedValue);
                var dt = txtDateSelection.Text;
                var x = dt.Split('/')[1] + "/" + dt.Split('/')[0] + "/" + dt.Split('/')[2];
                DateTime dateTime = Convert.ToDateTime(x);
                var isExist = new ObjectParameter("isExistRecord", "0");
                foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
                {
                    var txtFromTime = gvr.FindControl("txtStartTime") as TextBox;
                    var txtEndTime = gvr.FindControl("txtEndTime") as TextBox;
                    var ddlRoom = gvr.FindControl("ddlRoom") as DropDownList;
                    if (txtFromTime != null && txtEndTime != null && ddlRoom != null)
                    {
                        //TimeSpan ts = FrequentAccesses.FormatTime(txtFromTime.Text);
                        //fyp.SP_CheckConflictPresentationTimings(dateTime, psid, pmsid,ts, isExist);
                        //if(!Convert.ToBoolean(isExist.Value))
                        //{
                        DataKey dk = GvdPresentationSchedule.DataKeys[gvr.RowIndex];
                        if (dk != null && dk.Values != null)
                        {
                            long projId = Convert.ToInt64(dk.Values["PId"]);
                            var ps = new PresentationSchedule
                                         {
                                             ProjectId = projId,
                                             TimeFrom = FrequentAccesses.FormatTime(txtFromTime.Text),
                                             TimeTo = FrequentAccesses.FormatTime(txtEndTime.Text),
                                             PresentationDate = dateTime,
                                             PSId = psid,
                                             PMSId = pmsid,
                                             RoomNumber = Convert.ToInt32(ddlRoom.SelectedValue)
                                         };
                            fyp.PresentationSchedules.Add(ps);
                        }
                        //}
                    }
                }
                if (fyp.SaveChanges() > 0)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Presentation Schedule added successfully" }, this.Page, true);
                    ClearAllFields();
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Some error occured while adding presentation schedule" }, this.Page, true);
                    ClearAllFields();
                }
            }
        }
        /// <summary>
        /// Clear All fields after submission
        /// </summary>
        private void ClearAllFields()
        {
            foreach (GridViewRow gvr in GvdPresentationSchedule.Rows)
            {
                var txtFromTime = gvr.FindControl("txtStartTime") as TextBox;
                var txtEndTime = gvr.FindControl("txtEndTime") as TextBox;
                var ddlRoom = gvr.FindControl("ddlRoom") as DropDownList;
                if (txtFromTime != null && txtEndTime != null && ddlRoom != null)
                {
                    txtFromTime.Text = string.Empty;
                    txtEndTime.Text = string.Empty;
                    ddlRoom.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// Check whether any presentation schedule exists on selected date
        /// </summary>
        protected void PresentationDateTextChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid = Convert.ToInt64(ddlSessionSelection.SelectedValue);
                long pmsid = Convert.ToInt64(ddlMilestoneSelection.SelectedValue);
                //DateTime dateTime = Convert.ToDateTime(txtDateSelection.Text);//"28/04/2014"
                var dt = txtDateSelection.Text;
                var x=dt.Split('/')[1]+"/"+dt.Split('/')[0]+"/"+ dt.Split('/')[2];
                DateTime dateTime = Convert.ToDateTime(x);
                //DateTime dateTime = DateTime.ParseExact(txtDateSelection.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat);
                var isExist = new ObjectParameter("isExist", 0);
                fyp.SP_CheckConflictPresentationTimings(dateTime, psid, pmsid, isExist);
                if (Convert.ToBoolean(isExist.Value))
                {
                    FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "A Presentation Schedule is already exist on the selected date<br/>Please select a different date" }, this.Page, true);
                }
            }
        }

        protected void BtnCancelClicked(object sender, EventArgs e)
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