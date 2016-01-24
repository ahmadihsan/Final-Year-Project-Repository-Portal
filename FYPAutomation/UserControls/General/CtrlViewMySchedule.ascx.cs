using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using Microsoft.Ajax.Utilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlViewMySchedule : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
        }

        /// <summary>
        /// View Schedule
        /// </summary>
        private void PopulateGrid()
        {
            long uid = FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                var data = fyp.ScheduleFacultyStudents.Where(ff => ff.UserId == uid).DistinctBy(x => x.Day).ToList();
                GvdMySchedule.DataSource = data.ToList();
                GvdMySchedule.DataBind();
            }
        }

        /// <summary>
        /// Add weekly schedule button clicked : redirect according to role
        /// </summary>
        protected void AddWeeklyScheduleClicked(object sender, EventArgs e)
        {
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "convener")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Convener/WeeklySchedule.aspx"));
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Admin/WeeklySchedule.aspx"));
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "faculty")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Faculty/WeeklySchedule.aspx"));
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "student")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/Student/WeeklySchedule.aspx"));
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "pcmember")
            {
                Response.Redirect(VirtualPathUtility.ToAbsolute("~/Pages/PCMember/WeeklySchedule.aspx"));
            }
        }

        /// <summary>
        /// Edi Update weekly schedule
        /// </summary>
        protected void GvdScheduleRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var gvrEdit = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvrEdit.RowIndex;
                GvdMySchedule.EditIndex = rowIndex;
                PopulateGrid();
                //var ddlDays = GvdMySchedule.Rows[rowIndex].Cells[1].FindControl("ddlDays") as DropDownList;
                //var ddlSlot = GvdMySchedule.Rows[rowIndex].Cells[2].FindControl("ddlTimeSlot") as DropDownList;
                //DataKey dk = GvdMySchedule.DataKeys[rowIndex];
                //if (dk != null && dk.Values != null)
                //{
                //    if (ddlSlot != null)//ddlDays != null && 
                //    {
                //        using (var fyp = new FYPEntities())
                //        {
                //            long scId = Convert.ToInt64(dk.Values["ScheduleId"]);
                //            ddlSlot.DataSource = (from sfs in fyp.ScheduleFacultyStudents
                //                                  join ts in fyp.TimeSlots on sfs.TSId equals ts.TSId
                //                                  select new
                //                                             {
                //                                                 sfs.TSId,
                //                                                 FreeSlot =
                //                                      ts.Title + " (" + ts.StartTime + "-" + ts.EndTime + ")",
                //                                             }).ToList();
                //            ddlSlot.DataBind();
                //            var day = fyp.ScheduleFacultyStudents.FirstOrDefault(sc => sc.ScheduleId == scId);
                //            if (day != null)
                //            {
                //                //ddlDays.SelectedIndex = ddlDays.Items.IndexOf(ddlDays.Items.FindByValue(day.Day));
                //                ddlSlot.SelectedIndex =
                //                    ddlSlot.Items.IndexOf(ddlSlot.Items.FindByValue(day.TSId.ToString()));
                //            }
                //        }
                //    }
                //}
            }
            if (e.CommandName == "Update")
            {
                //int rowIndex = ((GridViewRow) lnkEdit.NamingContainer).RowIndex;
                int rowIndex = GvdMySchedule.EditIndex;
                //var ddlDays = GvdMySchedule.Rows[rowIndex].Cells[1].FindControl("ddlDay") as DropDownList;
                var ddlSlot = GvdMySchedule.Rows[rowIndex].Cells[2].FindControl("ddlTimeSlot") as DropDownList;
                DataKey dk = GvdMySchedule.DataKeys[rowIndex];
                if (dk != null && dk.Values != null)
                {
                    long scId = Convert.ToInt64(dk.Values["ScheduleId"]);
                    using (var fyp = new FYPEntities())
                    {
                        var day = fyp.ScheduleFacultyStudents.FirstOrDefault(sc => sc.ScheduleId == scId);
                        if (day != null)
                        {
                            if (ddlSlot != null)//ddlDays != null && 
                            {
                                //day.Day = ddlDays.SelectedValue;
                                day.TSId = Convert.ToInt32(ddlSlot.SelectedValue);
                                if (fyp.SaveChanges() > 0)
                                {
                                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Schedule Updated successfully" }, this.Page, true);
                                    GvdMySchedule.EditIndex = -1;
                                    PopulateGrid();
                                }
                                else
                                {
                                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Some error occured while updating information" }, this.Page, true);
                                    GvdMySchedule.EditIndex = -1;
                                    PopulateGrid();
                                }
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "Cancel")
            {
                GvdMySchedule.EditIndex = -1;
                PopulateGrid();
            }
        }

        /// <summary>
        /// Populating grid of Free slots inside main grid
        /// </summary>
        protected void GvdScheduleRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                long uid = FYPSession.GetLoggedUser().UserId;
                DataKey dk = GvdMySchedule.DataKeys[e.Row.RowIndex];
                if (dk != null && dk.Values != null)
                {
                    int day = Convert.ToInt32(dk.Values["day"]);
                    //int day = Convert.ToInt32(GvdMySchedule.Rows[e.Row.RowIndex].Cells[1].Text);
                    var gvdFreeSlot = e.Row.FindControl("gvdFreeSlots") as GridView;
                    if (gvdFreeSlot != null)
                    {
                        using (var fyp = new FYPEntities())
                        {
                            var data = fyp.SP_GetFreeSlotsDayBased(uid, day);
                            gvdFreeSlot.DataSource = data.ToList();
                            gvdFreeSlot.DataBind();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Row Editing : Time Slots editing
        /// </summary>
        protected void GvdFreeSlotsRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvdFreeSlot = sender as GridView;
            if (gvdFreeSlot != null)
            {
                long uid = FYPSession.GetLoggedUser().UserId;
                gvdFreeSlot.EditIndex = e.NewEditIndex;
                DataKey dk = gvdFreeSlot.DataKeys[e.NewEditIndex];
                if (dk != null && dk.Values != null)
                {
                    int day = Convert.ToInt32(dk.Values["Day"]);
                    int timeSlot = Convert.ToInt32(dk.Values["TSId"]);
                    using (var fyp = new FYPEntities())
                    {
                        var data = fyp.SP_GetFreeSlotsDayBased(uid, day);
                        gvdFreeSlot.DataSource = data.ToList();
                        gvdFreeSlot.DataBind();
                    }

                    var drpFreeSlot = gvdFreeSlot.Rows[e.NewEditIndex].FindControl("ddlFreeSlotInside") as DropDownList;
                    if (drpFreeSlot != null)
                    {
                        using (var fyp = new FYPEntities())
                        {
                            drpFreeSlot.DataSource = (from ts in fyp.TimeSlots
                                                      select new
                                                                 {
                                                                     ts.TSId,
                                                                     FreeSlot = ts.Title + " (" + ts.StartTime + " - " + ts.EndTime + ")"
                                                                 }).ToList();
                            drpFreeSlot.DataBind();
                            drpFreeSlot.Items.Insert(0, "Select FreeSlot");
                            drpFreeSlot.SelectedIndex =
                                drpFreeSlot.Items.IndexOf(drpFreeSlot.Items.FindByValue(timeSlot.ToString()));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Row Editing : Time Slots editing
        /// </summary>
        protected void GvdFreeSlotRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var gvdFreeSlot = sender as GridView;
            if (gvdFreeSlot != null)
            {
                var drpFreeSlot = gvdFreeSlot.Rows[e.RowIndex].FindControl("ddlFreeSlotInside") as DropDownList;
                if (drpFreeSlot != null)
                {
                    DataKey dk = gvdFreeSlot.DataKeys[e.RowIndex];
                    if (dk != null && dk.Values != null)
                    {
                        long scId = Convert.ToInt64(dk.Values["ScheduleId"]);
                        using (var fyp = new FYPEntities())
                        {
                            ScheduleFacultyStudent sc = fyp.ScheduleFacultyStudents.FirstOrDefault(s => s.ScheduleId == scId);
                            if (sc != null)
                            {
                                int tsId = Convert.ToInt32(drpFreeSlot.SelectedValue);
                                sc.TSId = tsId;
                                if(fyp.SaveChanges()>0)
                                {
                                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Schedule Updated successfully" }, this.Page, true);
                                    gvdFreeSlot.EditIndex = -1;
                                    PopulateGrid();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cancel edit mode
        /// </summary>
        protected void GvdFreeSlotRowEditCancelling(object sender, GridViewCancelEditEventArgs e)
        {
            var gvdFreeSlot = sender as GridView;
            if (gvdFreeSlot != null)
            {
                gvdFreeSlot.EditIndex = -1;
                PopulateGrid();
            }
        }

        /// <summary>
        /// Deleting scheduled Free slot
        /// </summary>
        protected void GvdFreeSlotRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var gvdFreeSlot = sender as GridView;
            if (gvdFreeSlot != null)
            {
                DataKey dk = gvdFreeSlot.DataKeys[e.RowIndex];
                if (dk != null && dk.Values != null)
                {
                    long scId = Convert.ToInt64(dk.Values["ScheduleId"]);
                    using (var fyp = new FYPEntities())
                    {
                        ScheduleFacultyStudent sc = fyp.ScheduleFacultyStudents.FirstOrDefault(s => s.ScheduleId == scId);
                        if (sc != null)
                        {
                            fyp.ScheduleFacultyStudents.Remove(sc);
                            if(fyp.SaveChanges()>0)
                            {
                                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Schedule Updated successfully" }, this.Page, true);
                                PopulateGrid();
                            }
                        }
                    }
                }
            }
        }
    }
}