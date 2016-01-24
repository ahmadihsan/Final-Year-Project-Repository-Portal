using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAssignProject : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckProjectStatus();
                PopulateProjectTitleAndDescription();
                PopulateProjectSession();
            }
        }

        private void CheckProjectStatus()
        {
            int pId = Convert.ToInt32(Request.QueryString["PId"]);
            using (var fypEntities = new FYPEntities())
            {
                List<string> studentNames = fypEntities.SP_GetProjectStudents(pId).ToList();
                if (studentNames.Count != 0)
                {
                    sessionTD.Visible = false;
                    lblAssignedOrNot.Visible = true;
                    btnUnAssignProject.Visible = true;
                    lblAssignedOrNot.Text = "This Project has already been assigned to ";
                    int i = 0;
                    foreach (var studentName in studentNames)
                    {
                        if (i == 0)
                        {
                            lblAssignedOrNot.Text += "<b>" + studentName + "</b>";
                            ++i;
                        }
                        else
                        {
                            lblAssignedOrNot.Text += string.Format(" & <b>{0}</b> ", studentName);
                        }
                    }
                }
            }
            if (Convert.ToInt32(Request.QueryString["mId"]) == 1)
            {
                FYPMessage.ShowMessage(ref lblMessage, true, "Project Assigned Successfully ");
                GvdViewAllStudent.DataSource = null;
                GvdViewAllStudent.DataBind();
                sessionTD.Visible = false;
            }
            if (Convert.ToInt32(Request.QueryString["mId"]) == 2)
            {
                FYPMessage.ShowMessage(ref lblMessage, true, "Project UnAssigned Successfully ");
            }
        }
        private void PopulateProjectTitleAndDescription()
        {
            using (var fypEntities = new FYPEntities())
            {
                int pId = Convert.ToInt32(Request.QueryString["PId"].ToString());
                Project project = fypEntities.Projects.FirstOrDefault(proj => proj.PId == pId);
                if (project != null)
                {
                    lblTitle.Text = project.Tiltle;
                    lblDescription.Text = project.Description.ToString().Length > 500
                                              ? project.Description.ToString().Substring(0, 350)
                                              : project.Description.ToString();
                }
            }
        }


        private void PopulateProjectSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                bool statusOfProjects = FrequentAccesses.GetBooleanFrom10(1);
                ddlSession.DataSource = fypEntities.ProjectSessions.Where(sess => sess.Status == statusOfProjects).ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateGridForStudent()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllStudent.DataSource = fypEntities.SP_StudentProjectNotAssigned(4, Convert.ToInt32(ddlSession.SelectedValue.ToString()));
                GvdViewAllStudent.DataBind();
            }
        }



        protected void GvdViewAllStudentPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllStudent.PageIndex = e.NewPageIndex;
            PopulateGridForStudent();
            GvdViewAllStudent.DataBind();
        }

        protected void GvdViewAllStudentSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GvdViewAllStudent.SelectedRow;
            DataKey dataKey = GvdViewAllStudent.DataKeys[gridViewRow.RowIndex];
            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    var uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    string script = FYPMessage.RedirectionScript(VirtualPathUtility.ToAbsolute("~/Pages/Admin/StudentDetail.aspx?Uid=") + uId);
                    FYPMessage.RunClientScript(script,true,this.Page);
                }
            }
        }

        protected void AssignProjectClick(object sender, EventArgs e)
        {
            long projectId ;//= Convert.ToInt32(Request.QueryString["PId"].ToString());
            bool status=false;
            int uId;
            if (FYPUtilities.FYPQueryString.GetQueryString(Request.QueryString["PId"], out projectId))
            {
                using (var fypEntities = new FYPEntities())
                {
                    var projectGroup = new ProjectGroup();
                    foreach (GridViewRow row in GvdViewAllStudent.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            var checkBox = row.Cells[0].FindControl("cboxSelection") as CheckBox;
                            if (checkBox != null && checkBox.Checked)
                            {
                                var dataKey = GvdViewAllStudent.DataKeys[row.RowIndex];
                                if (dataKey != null)
                                {
                                    if (dataKey.Values != null)
                                    {
                                            var objTransactionStatus = new ObjectParameter("TransactionStatus",false);
                                            uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                            fypEntities.SP_ProjectAssignment(uId, projectId, objTransactionStatus);
                                            if (Convert.ToBoolean(objTransactionStatus.Value))
                                            {
                                                status = true;
                                            }
                                            else
                                            {
                                                status = false;
                                                break;
                                            }

                                    }
                                }
                            }
                        }
                    }
                    string script = FYPMessage.RedirectionScript(VirtualPathUtility.ToAbsolute("~/Pages/Admin/AssignProject.aspx?PId=") + projectId + "&mId=1");
                    FYPMessage.RunClientScript(script, true, this.Page);
                    
                    
                }
            }
        }

        protected void UnAssignProjectClick(object sender, EventArgs e)
        {
            var pId = Convert.ToInt64(Request.QueryString["PId"].ToString());
            using (var fypEntities = new FYPEntities())
            {
                var objTransactionStatus = new ObjectParameter("TransactionStatus",false);
                fypEntities.SP_ProjectUnAssignment(pId, objTransactionStatus);
                if(Convert.ToBoolean(objTransactionStatus.Value.ToString()))
                {
                    string script = FYPMessage.RedirectionScript(VirtualPathUtility.ToAbsolute("~/Pages/Admin/AssignProject.aspx?PId=") + pId + "&mId=2");
                    FYPMessage.RunClientScript(script, true, this.Page);
                    
                }
               
            }
            
           
        }

        protected void DdlSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGridForStudent();
            using (var fypEntities = new FYPEntities())
            {
                int pId = Convert.ToInt32(Request.QueryString["PId"].ToString());
                Project project = fypEntities.Projects.FirstOrDefault(proj => proj.PId == pId);
                if (project != null)
                {
                    if (project.Status == 1)
                    {
                        btnAssignProject.Visible = true;
                        btnUnAssignProject.Visible = false;
                    }
                    if (project.Status == 2)
                    {
                        btnAssignProject.Visible = false;
                        btnUnAssignProject.Visible = true;
                    }
                }
            }
        }
    }
}