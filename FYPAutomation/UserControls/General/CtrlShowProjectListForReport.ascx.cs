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
    public partial class CtrlShowProjectListForReport : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSessions();
                PopulateGridForReports();
            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSearch.DataSource = fypEntities.ProjectSessions.Where(x => x.Status == true).ToList();
                ddlSessionSearch.DataBind();
                ddlSessionSearch.Items.Insert(0, "Search By Session");
            }
        }

        private void PopulateGridForReports()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = fyp.ProjectSessions.Max(y => y.PSId);
                GvdViewReports.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                GvdViewReports.DataBind();
            }
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string prName = txtByProjectName.Text;
                GvdViewReports.DataSource = fypEntities.Projects.Where(pr => pr.Tiltle.Contains(prName)).ToList();
                GvdViewReports.DataBind();
            }
        }

        protected void GvdViewReportsSelectedIndexChanged(object sender, EventArgs e)
        {
            long pId = -1;
            GridViewRow gvr = GvdViewReports.SelectedRow;
            DataKey dk = GvdViewReports.DataKeys[gvr.RowIndex];
            if (dk != null && dk.Values != null)
            {
                pId = Convert.ToInt64(dk.Values["PId"]);
            }
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "convener")
            {
                Response.Redirect("~/Pages/Convener/DetailedReport.aspx?pId=" + pId);
            }
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
            {
                Response.Redirect("~/Pages/Admin/DetailedReport.aspx?pId=" + pId);
            }
            //FYPUtilities.FYPMessage.ShowBootStrapPopUp("weeklyReportDetail", this.Page, true);
        }

        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid;
                if (long.TryParse(ddlSessionSearch.SelectedValue, out psid))
                {
                    GvdViewReports.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                    GvdViewReports.DataBind();
                }
                else
                {
                    psid = fyp.ProjectSessions.Max(y => y.PSId);
                    GvdViewReports.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                    GvdViewReports.DataBind();
                }
            }
        }
    }
}