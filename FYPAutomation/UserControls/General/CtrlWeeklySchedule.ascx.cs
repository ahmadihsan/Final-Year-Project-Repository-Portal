using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlWeeklySchedule : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTimeSlots();
                PopulateMileStones();
                PopulateEvaluators();
                //cblTimeSlots.Style.Add("border-top", "border-top: 1px solid #c1dad7;");
            }
        }

        private void PopulateEvaluators()
        {
            using (var fyp = new FYPEntities())
            {
                ddlEvaluators.DataSource = fyp.Users.Where(p => p.RoleId == 3 || p.RoleId == 5 || p.RoleId == 8).ToList();
                ddlEvaluators.DataBind();
                ddlDocType.Items.Insert(0, "Select Evaluators");
            }
        }

        private void PopulateMileStones()
        {
            using (var fyp = new FYPEntities())
            {
               ddlDocType.DataSource = fyp.ProjectMileStones.ToList();
               ddlDocType.DataBind();
               ddlDocType.Items.Insert(0, "Select MileStone");
            }
        }

        private void PopulateTimeSlots()
        {
            using (var fyp = new FYPEntities())
            {
                var data = from ts in fyp.TimeSlots
                           select new
                                      {
                                          ts.TSId,
                                          time =  ts.Title
                                      };
                
                //cblTimeSlot.DataSource = data.ToList();
                //cblTimeSlot.DataBind();
            }
        }

        protected void AddScheduleClicked(object sender, EventArgs e)
        {
            //using (var fyp = new FYPEntities())
            //{
            //    var role = FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower();

            //    if (role == "student")
            //    {
            //        var uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            //        var firstOrDefault = fyp.ProjectGroups.FirstOrDefault(pg => pg.StudentId == uId);
            //        if (firstOrDefault != null)
            //        {
            //            long projId = firstOrDefault.ProjectId;

            //            foreach (ListItem itms in cblTimeSlot.Items)
            //            {
            //                if (itms.Selected)
            //                {
            //                    var sfs = new ScheduleFacultyStudent()
            //                                  {
            //                                      isStudent = true,
            //                                      isFaculty = false,
            //                                      TSId = Convert.ToInt32(itms.Value),
            //                                      ProjectId = projId,
            //                                      UserId = uId,
            //                                      Day = ddlDays.SelectedValue
            //                                  };
            //                    //Check whether this data already exist or not? 
            //                    var checkExitance = new ObjectParameter("CheckExitance", 0);
            //                    fyp.SP_CheckWeeklyScheduleOfFacultyAndStudent(sfs.ProjectId, sfs.Day, sfs.UserId,checkExitance);
            //                    if (!Convert.ToBoolean(checkExitance.Value))
            //                    {
            //                        fyp.ScheduleFacultyStudents.Add(sfs);
            //                    }
            //                }
            //            }
            //            if (fyp.SaveChanges() > 0)
            //            {
            //                FYPUtilities.FYPMessage.ShowPopUpMessage("Success",
            //                                                         new List<string>() { "Scedule added successfully" },
            //                                                         this.Page, true);
            //            }
            //            else
            //            {
            //                FYPUtilities.FYPMessage.ShowPopUpMessage("Error",
            //                                                         new List<string>()
            //                                                             {
            //                                                                 "Scedule Could not be added either the selected timeslot have been already selected or due to some other problem"
            //                                                             }, this.Page, true);
            //            }
            //        }
            //        else
            //        {
            //            FYPUtilities.FYPMessage.ShowPopUpMessage("Warning",
            //                                                     new List<string>() { "Project could't be found" },
            //                                                     this.Page, true);
            //        }
            //    }
            //    else
            //    {
            //        var uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            //        var firstOrDefault = fyp.SupervisodBies.FirstOrDefault(sb => sb.SupervisodBy1 == uId);
            //        if (firstOrDefault != null)
            //        {
            //            long? projId = firstOrDefault.ProjectId;

            //            foreach (ListItem itms in cblTimeSlot.Items)
            //            {
            //                if (itms.Selected)
            //                {
            //                    var sfs = new ScheduleFacultyStudent()
            //                                  {
            //                                      isStudent = false,
            //                                      isFaculty = true,
            //                                      TSId = Convert.ToInt32(itms.Value),
            //                                      ProjectId = projId,
            //                                      UserId = uId,
            //                                      Day = ddlDays.SelectedValue
            //                                  };
            //                    //Check whether this data already exist or not? 
            //                    var checkExitance = new ObjectParameter("CheckExitance", 0);
            //                    fyp.SP_CheckWeeklyScheduleOfFacultyAndStudent(sfs.ProjectId, sfs.Day, sfs.UserId,checkExitance);
            //                    if (!Convert.ToBoolean(checkExitance.Value))
            //                    {
            //                        fyp.ScheduleFacultyStudents.Add(sfs);
            //                    }
            //                }
            //            }
            //            if (fyp.SaveChanges() > 0)
            //            {
            //                FYPUtilities.FYPMessage.ShowPopUpMessage("Success",
            //                                                         new List<string>() { "Scedule added successfully" },
            //                                                         this.Page, true);
            //            }
            //            else
            //            {
            //                FYPUtilities.FYPMessage.ShowPopUpMessage("Error",
            //                                                         new List<string>()
            //                                                             {
            //                                                                 "Scedule Could not be added either the selected timeslot have been already selected or due to some other problem"
            //                                                             }, this.Page, true);
            //            }
            //        }
            //        else
            //        {
            //            FYPUtilities.FYPMessage.ShowPopUpMessage("Warning",
            //                                                     new List<string>() { "Project could't be found" },
            //                                                     this.Page, true);
            //        }
            //    }
            //}

            //ClearAllFields();
        }

        private void ClearAllFields()
        {
            //foreach (ListItem lst in cblTimeSlot.Items)
            //{
            //    lst.Selected = false;
            //}
        }

        protected void ddlDcoType3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        //protected override void OnPreRender(EventArgs e)
        //{
        //    cblTimeSlot.Attributes.Add("rules", "all");
        //    cblTimeSlot.Attributes.Add("style", "border:1px solid #c1dad7");
        //    base.OnPreRender(e);
        //}

        
    }
}