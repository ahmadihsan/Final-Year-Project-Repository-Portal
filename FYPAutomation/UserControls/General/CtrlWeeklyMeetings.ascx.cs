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
    public partial class CtrlWeeklyMeetings : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                long pId;
                if (long.TryParse(Request.QueryString["PId"], out pId))
                {
                    using (var fyp = new FYPEntities())
                    {
                        var firstOrDefault = fyp.Projects.FirstOrDefault(p => p.PId == pId);
                        if (firstOrDefault != null)
                            lblTitleProj.Text = firstOrDefault.Tiltle;
                    }
                    PopulateList();
                }
            }
        }

        private void PopulateList()
        {
            using (var fyp = new FYPEntities())
            {
                long pId = Convert.ToInt64(Request.QueryString["pId"]);
                lstWeeklyMeetings.DataSource = fyp.WeeklyMeetings.Where(pr=>pr.ProjectId==pId).ToList();
                lstWeeklyMeetings.DataBind();
            }
        }

        protected void SubmitCommentClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long pId = Convert.ToInt64(Request.QueryString["pId"]);
                WeeklyMeeting wm =
                    fyp.WeeklyMeetings.OrderByDescending(w => w.MId).FirstOrDefault(ww => ww.ProjectId == pId);
                if (wm != null) wm.CommentBySupervisor = txtComment.Text;
                if(fyp.SaveChanges()>0)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Comment added successfully" }, this.Page, true);
                    txtComment.Text = string.Empty;
                    PopulateList();
                }
            }
        }

        protected void AddMeetingClicked(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("AddWeeklyMeeting",this.Page,true);
        }

        protected void AddMeetingSubmitClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long proId = Convert.ToInt64(Request.QueryString["pId"]);
                var wm = new WeeklyMeeting { MeetingDate = DateTime.Now, Title = txtTilte.Text, Description = txtDescription.Text,ProjectId = proId};
                fyp.WeeklyMeetings.Add(wm);
                if (fyp.SaveChanges() > 0)
                {
                    FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Weekly tasks added successfully" }, this.Page, true);
                    PopulateList();
                }
            }
        }
    }
}