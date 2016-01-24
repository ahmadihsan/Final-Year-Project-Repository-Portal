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
    public partial class CtrlWeeklyMeetingGeneralView : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjects();
                PopulateList();
            }
        }

        private void PopulateProjects()
        {
            long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            using (var fypEntities = new FYPEntities())
            {
                ddlProjects.DataSource =
                    fypEntities.Projects.Where(pr => pr.ProposedBy == uId && pr.Status == 2).Where(
                        p => p.ProjectSession.Status == true).ToList();
                ddlProjects.DataBind();
                ddlProjects.Items.Insert(0, "--Select Project--");
            }
        }

        private void PopulateList()
        {
            using (var fyp = new FYPEntities())
            {
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var data = (from wm in fyp.WeeklyMeetings
                            join sb in fyp.SupervisodBies on wm.ProjectId equals sb.ProjectId
                            join pr in fyp.Projects on wm.ProjectId equals pr.PId
                            where sb.SupervisodBy1 == uId
                            select new
                            {
                                wm.Title,
                                wm.Description,
                                wm.MeetingDate,
                                wm.CommentBySupervisor,
                                pr.Tiltle,
                                pr.PId
                            }).ToList();
                lstWeeklyMeetings.DataSource = data;
                lstWeeklyMeetings.DataBind();
            }
        }

        protected void DddlProjectChanged(object sender, EventArgs e)
        {
            long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                long pId;
                if (long.TryParse(ddlProjects.SelectedValue, out pId))
                {
                    var data =
                        (from wm in fyp.WeeklyMeetings
                         join sb in fyp.SupervisodBies on wm.ProjectId equals sb.ProjectId
                         join pr in fyp.Projects on wm.ProjectId equals pr.PId
                         where sb.ProjectId == pId
                         select new
                                    {
                                        wm.Title,
                                        wm.Description,
                                        wm.MeetingDate,
                                        wm.CommentBySupervisor,
                                        pr.Tiltle,
                                        pr.PId
                                    }).ToList();
                    lstWeeklyMeetings.DataSource = data;
                    lstWeeklyMeetings.DataBind();
                }
                else
                {
                    PopulateList();
                }
            }
        }

        protected void WeeklyMeetingClicked(object sender, EventArgs e)
        {
            long pId;
            var lnk = sender as LinkButton;
            if (lnk != null && long.TryParse(lnk.CommandArgument, out pId))
            {
                if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "convener")
                {
                    Response.Redirect("~/Pages/Convener/WeeklyMeetings.aspx?pId=" + pId);
                }
                if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
                {
                    Response.Redirect("~/Pages/Admin/WeeklyMeetings.aspx?pId=" + pId);
                }
                if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "faculty")
                {
                    Response.Redirect("~/Pages/Faculty/WeeklyMeetings.aspx?pId=" + pId);
                }
                if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "pcmember")
                {
                    Response.Redirect("~/Pages/PCMember/WeeklyMeetings.aspx?pId=" + pId);
                }
            }
            else
            {
                FYPUtilities.FYPMessage.ShowPopUpMessage("Sorry", new List<string>() { "Value could't be converted" }, this.Page, true);
            }
        }
    }
}
