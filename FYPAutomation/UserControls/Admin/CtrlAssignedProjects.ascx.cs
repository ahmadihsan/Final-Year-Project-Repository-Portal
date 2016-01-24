using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
namespace FYPAutomation.UserControls.Admin
{
    public partial class AssignedProjects : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridAssignedProjects();
                PopulateSessions();
            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateGridAssignedProjects()
        {
            using (var fyp = new FYPEntities())
            {
                GvdAssignedProjects.DataSource = (from proj in fyp.Projects
                                                  join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                                  where proj.Status == 2
                                                  select new
                                                             {
                                                                 proj.Tiltle,
                                                                 supervisor.Name,
                                                                 proj.PId
                                                             }).ToList();
                GvdAssignedProjects.DataBind();
            }
        }

        protected void GvdAssignedProjectsRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                long pid = -1;
                var gv = e.Row.FindControl("gdvStudents") as GridView;
                DataKey dk = GvdAssignedProjects.DataKeys[e.Row.RowIndex];
                if (dk != null && dk.Values != null)
                {
                    pid = Convert.ToInt64(dk.Values["PId"]);
                }
                if (gv != null)
                {
                    using (var fyp = new FYPEntities())
                    {
                        gv.DataSource = fyp.SP_GetProjectStudentsWithReg(pid);
                        gv.DataBind();
                    }
                }
            }
        }

        protected void BtnExportClicked(object sender, EventArgs e)
        {
            var dtAssignProject = new DataTable();
            var dcColumns = new DataColumn[4];
            dcColumns[0] = new DataColumn("S.No");
            dcColumns[1] = new DataColumn("Project");
            dcColumns[2] = new DataColumn("Students");
            dcColumns[3] = new DataColumn("Supervisor");
            dtAssignProject.Columns.AddRange(dcColumns);
            foreach (var row in GvdAssignedProjects.Rows.Cast<GridViewRow>())
            {
                var dRow = dtAssignProject.NewRow();
                var label = row.Cells[0].FindControl("Label3") as Label;
                dRow[0] = label != null ? label.Text : "";
                dRow[1] = row.Cells[1].Text;
                var students = new StringBuilder();
                var innderGrd = row.Cells[2].FindControl("gdvStudents") as GridView;
                if (innderGrd != null)
                    foreach (var innerRow in innderGrd.Rows.Cast<GridViewRow>())
                    {
                        var lblStd = innerRow.Cells[0].FindControl("lblStudents") as Label;
                        if (lblStd != null)
                        {
                            students.Append(lblStd.Text + "" + Environment.NewLine);
                        }
                    }
                dRow[2] = students;
                dRow[3] = row.Cells[3].Text;
                dtAssignProject.Rows.Add(dRow);
            }
            Session["AssignProject"] = dtAssignProject;

            FYPUtilities.FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/General/ExcelDownload.aspx"), true, this.Page);
        }

        protected void MileStoneSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                
                if (ddlSession.SelectedIndex == 0)
                {
                    PopulateGridAssignedProjects();
                }
                else
                {
                    long psid = Convert.ToInt64(ddlSession.SelectedValue);
                    GvdAssignedProjects.DataSource = (from proj in fyp.Projects
                                                      join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                                      where proj.Status == 2 && proj.ProjectSessionId == psid
                                                      select new
                                                      {
                                                          proj.Tiltle,
                                                          supervisor.Name,
                                                          proj.PId
                                                      }).ToList();
                    GvdAssignedProjects.DataBind();
                }

            }
        }
    }
}