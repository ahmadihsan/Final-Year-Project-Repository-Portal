using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlUnassignDocsFromPc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSession();
                PopulateGridForDocs();
            }

        }

        private void PopulateSession()
        {
            using (var fyp = new FYPEntities())
            {
                ddlStudentSearchBySession.DataSource = fyp.ProjectSessions.ToList();
                ddlStudentSearchBySession.DataBind();
                ddlStudentSearchBySession.Items.Insert(0, "Select Session");
            }
        }

        protected void SearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                int psId = Convert.ToInt32(ddlStudentSearchBySession.SelectedValue);
                GvdViewAllDocs.DataSource = fypEntities.Users.Where(std => std.ProjectSessionId == psId).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByProjectName.Text;
                GvdViewAllDocs.DataSource =
                    fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName) && std.Status == 2).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        private void PopulateGridForDocs()
        {
            using (var fyp = new FYPEntities())
            {
                var data = (from dc in fyp.SP_GetDocumentsSubmittedDataForGrid(null,null,false)
                            where dc.ToAdmin != true
                            select new
                                       {
                                           dc.ToAdmin,
                                           dc.ReadStatus,
                                           dc.InCustody,
                                           dc.MileStoneName,
                                           dc.Name,
                                           dc.ProjectId,
                                           dc.UId,
                                           dc.UMSDId,
                                           dc.UMSId,
                                           dc.UploadedFile,
                                           dc.Tiltle,
                                           dc.SubmittedDate,
                                           dc.StatusComment
                                       }).ToList();
                
                GvdViewAllDocs.DataSource = data;
                GvdViewAllDocs.DataBind();
            }
        }

        protected void GvdViewAllDocsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllDocs.PageIndex = e.NewPageIndex;
            PopulateGridForDocs();
        }

        protected void GvdViewDocumentSumbittedRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dataKey = GvdViewAllDocs.DataKeys[e.Row.RowIndex];
                if (dataKey != null)
                {
                    if (dataKey.Values != null)
                    {
                        long projectId = Convert.ToInt64(dataKey.Values[0].ToString());
                        var gvStudents = e.Row.FindControl("gdvStudents") as GridView;
                        if (gvStudents != null)
                        {
                            using (var fypEntities = new FYPEntities())
                            {
                                gvStudents.DataSource = fypEntities.SP_GetProjectStudentsWithReg(projectId).ToList();
                                gvStudents.DataBind();
                            }

                        }
                    }
                }
            }
        }

    }
}