using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using Microsoft.Reporting.WebForms;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlDetailedReportOfProject : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectDetailReport();
                PopulateProjectGroupMember();
                PopulateDocumentStatuses();
                PopulatePcCommentsToDocs();
                PopulateWeeklyMeetings();
            }

        }

        /// <summary>
        /// Comment by PC Member
        /// </summary>
        private void PopulateWeeklyMeetings()
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                if (long.TryParse(Request.QueryString["pId"],out pid))
                {
                    var dataWmeeting = fyp.SP_GetWeeklyMeetingDetailsForReport(pid);
                    var dsweeklyMeetings = new ReportDataSource("dsWeeklyMeetingDetails", dataWmeeting.ToList());
                    rptProjectDetail.LocalReport.DataSources.Add(dsweeklyMeetings);
                    rptProjectDetail.LocalReport.Refresh();
                }
            }
        }

        /// <summary>
        /// Comment by PC Member
        /// </summary>
        private void PopulatePcCommentsToDocs()
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                if (long.TryParse(Request.QueryString["pId"], out pid))
                {
                    var dataDocComment = fyp.SP_GetUploadedDocsCommentsByPCForReport(pid);
                    var dsDocsComments = new ReportDataSource("dsCommentByPCToDocs", dataDocComment.ToList());
                    rptProjectDetail.LocalReport.DataSources.Add(dsDocsComments);
                    rptProjectDetail.LocalReport.Refresh();
                }
            }
        }

        /// <summary>
        /// Check milestone document status about the project  
        /// </summary>
        private void PopulateDocumentStatuses()
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                if (long.TryParse(Request.QueryString["pId"], out pid))
                {
                    var dataDocStatuses = fyp.SP_GetSubmittedMileStonesList(pid);
                    var dsProjDocs = new ReportDataSource("dsGeneral", dataDocStatuses.ToList());
                    rptProjectDetail.LocalReport.DataSources.Add(dsProjDocs);
                    rptProjectDetail.LocalReport.Refresh();
                }
            }
        }

        /// <summary>
        /// information related to Project
        /// </summary>
        private void PopulateProjectDetailReport()
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                if (long.TryParse(Request.QueryString["pId"], out pid))
                {
                    var dataProjInfo = fyp.SP_GetProjectDetailForReport(pid);
                    var dsProjInfo = new ReportDataSource("dsProjectInfo", dataProjInfo.ToList());
                    rptProjectDetail.LocalReport.DataSources.Add(dsProjInfo);
                    rptProjectDetail.LocalReport.Refresh();
                }
            }
        }

        /// <summary>
        /// Group members who have taken this project
        /// </summary>
        private void PopulateProjectGroupMember()
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                if (long.TryParse(Request.QueryString["pId"], out pid))
                {
                    var dataProjGroup = fyp.SP_GetProjectStudentsForReport(pid);
                    var dsProjGroup = new ReportDataSource("dsProjGroupMembers", dataProjGroup.ToList());
                    rptProjectDetail.LocalReport.DataSources.Add(dsProjGroup);
                    rptProjectDetail.LocalReport.Refresh();
                }
            }
        }
    }
}