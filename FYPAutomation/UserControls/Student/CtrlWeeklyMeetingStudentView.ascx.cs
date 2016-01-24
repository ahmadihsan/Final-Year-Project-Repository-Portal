using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlWeeklyMeetingStudentView : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateList();
            }
        }

        private void PopulateList()
        {
            using (var fyp = new FYPEntities())
            {
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                long pId = Convert.ToInt64(Request.QueryString["pId"]);
                var data = (from wm in fyp.WeeklyMeetings
                            join prj in fyp.Projects on wm.ProjectId equals prj.PId
                            join pg in fyp.ProjectGroups on prj.PId equals pg.ProjectId
                            where pg.StudentId == uId
                            select new
                                       {
                                           wm.Title,
                                           wm.Description,
                                           wm.MeetingDate,
                                           wm.CommentBySupervisor
                                       }).ToList();
                lstWeeklyMeetings.DataSource = data;
                lstWeeklyMeetings.DataBind();
            }
        }
    }
}
