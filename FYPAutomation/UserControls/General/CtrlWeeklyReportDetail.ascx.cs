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
    public partial class CtrlWeeklyReportDetail : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateReportDetailGrid();
            }
        }

        private void PopulateReportDetailGrid()
        {
            long pId = Convert.ToInt64(Request.QueryString["pId"]);
            using (var fyp = new FYPEntities())
            {
                var query = from projectIds in fyp.WeeklyMeetings
                            where projectIds.ProjectId == pId
                            select projectIds.MId;

                GvdReportDetail.DataSource = (from lst in fyp.WeeklyMeetings
                                              where query.Contains(lst.MId)
                                              select lst).ToList();
                GvdReportDetail.DataBind();
            }
        }
    }
}