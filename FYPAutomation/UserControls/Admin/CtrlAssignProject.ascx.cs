using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAssignProject : FYPBaseUserControl
    {
        private Dictionary<int, string> _dictionary = new Dictionary<int, string>();
        private const string SelectedStudents = "SelectedStudents";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProject();
            }
            if (ViewState[SelectedStudents] != null)
            {
                var tempDic = ViewState[SelectedStudents] as Dictionary<int, string>;
                if (tempDic != null)
                    _dictionary = tempDic;

            }
        }

        private void PopulateProject()
        {
            PopulateProjectTitleAndDescription();
            PopulateProjectSession();
            PopulateValues();
        }

        private void PopulateValues()
        {
            int pId = Convert.ToInt32(Request.QueryString["PId"]);
            using (var fypEntities = new FYPEntities())
            {
                List<string> studentNames = fypEntities.SP_GetProjectStudents(pId).ToList();
                if (studentNames.Count != 0)
                {
                    sessionTD.Visible = false;
                    lblAssignedOrNot.Visible = true;
                    btnAssignProject.Visible = false;
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
            StudentMarkedToAssignProject();
            GvdViewAllStudent.PageIndex = e.NewPageIndex;
            PopulateGridForStudent();
            GvdViewAllStudent.DataBind();
        }

        private void StudentMarkedToAssignProject()
        {
            foreach (var row in GvdViewAllStudent.Rows.Cast<GridViewRow>())
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    var dataKey = GvdViewAllStudent.DataKeys[row.RowIndex];
                    if (dataKey != null && dataKey.Values != null)
                    {
                        var checkBox = row.Cells[0].FindControl("cboxSelection") as CheckBox;
                        int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                        string name = dataKey.Values["Name"].ToString();
                        if (checkBox != null && checkBox.Checked)
                        {
                            if (!_dictionary.ContainsKey(uId))
                                _dictionary.Add(uId, name);
                        }
                        else
                        {
                            if (_dictionary.ContainsKey(uId))
                                _dictionary.Remove(uId);
                        }
                    }
                }
            }
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
                    
                    if (FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
                    {
                        Response.Redirect("~/Pages/Admin/StudentDetail.aspx?Uid=" + uId);
                    }
                    else if (FYPSession.GetLoggedUser().RoleName.ToLower() == "convener")
                    {
                        Response.Redirect("~/Pages/Convener/StudentDetail.aspx?Uid=" + uId);
                    }
                    else if (FYPSession.GetLoggedUser().RoleName.ToLower() == "faculty")
                    {
                        Response.Redirect("~/Pages/Faculty/StudentDetail.aspx?Uid=" + uId);
                    }
                    else if (FYPSession.GetLoggedUser().RoleName.ToLower() == "pcmember")
                    {
                        Response.Redirect("~/Pages/PCMember/StudentDetail.aspx?Uid=" + uId);
                    }
                  
                }
            }
        }

        protected void AssignProjectClick(object sender, EventArgs e)
        {
            StudentMarkedToAssignProject();
            long? proposedBy = -1;
            if (_dictionary.Count == 0)
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Please Select Students" }, this.Page, true);
                return;
            }
            int projectId = Convert.ToInt32(Request.QueryString["PId"].ToString());
            using (var fypEntities = new FYPEntities())
            {
                var projectGroup = new ProjectGroup();
                foreach (KeyValuePair<int, string> dictionaryEntry in _dictionary)
                {
                    int uId = dictionaryEntry.Key;
                    projectGroup.StudentId = uId;
                    projectGroup.ProjectId = projectId;
                    fypEntities.ProjectGroups.Add(projectGroup);
                    fypEntities.SaveChanges();
                }

                Project project = fypEntities.Projects.FirstOrDefault(proj => proj.PId == projectId);
                //latest changes by zia
                if (project != null)
                {
                    project.Status = 2;
                    proposedBy = project.ProposedBy;
                }

                if (proposedBy != -1)
                {
                    var sby = new SupervisodBy { ProjectId = projectId, SupervisodBy1 = proposedBy };
                    fypEntities.SupervisodBies.Add(sby);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project Assiged Sucessfull" }, this.Page, true);
                    }
                    GvdViewAllStudent.DataSource = null;
                    GvdViewAllStudent.DataBind();
                    PopulateProject();
                }

            }
        }

        protected void UnAssignProjectClick(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(Request.QueryString["PId"].ToString());
            using (var fypEntities = new FYPEntities())
            {
                List<ProjectGroup> projectGroup = fypEntities.ProjectGroups.Where(pro => pro.ProjectId == pId).ToList();
                foreach (var group in projectGroup)
                {
                    fypEntities.ProjectGroups.Remove(group);
                }

                Project project = fypEntities.Projects.FirstOrDefault(proj => proj.PId == pId);
                if (project != null) { project.Status = 1; }
                SupervisodBy sby=fypEntities.SupervisodBies.FirstOrDefault(sb => sb.ProjectId == pId);
                if(sby!=null)
                {
                    fypEntities.SupervisodBies.Remove(sby);
                }
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project Unassiged Sucessfull" }, this.Page, true);
                    PopulateProject();
                }

            }
            btnUnAssignProject.Visible = false;
            lblAssignedOrNot.Visible = false;
            sessionTD.Visible = true;
            PopulateProject();
        }

        protected void DdlSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            _dictionary.Clear();
            PopulateGridForStudent();
            //tblSearchByName.Visible = true;
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
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (_dictionary != null && _dictionary.Count != 0)
            {
                ViewState[SelectedStudents] = _dictionary;
                lblShowNames.Visible = true;
                lblShowNames.Text = "";
                int i = 0;
                foreach (KeyValuePair<int, string> keyValuePair in _dictionary)
                {
                    if (i == 0)
                    {
                        lblShowNames.Text = "You Have Selected : <b>" + keyValuePair.Value + "</b>";
                        ++i;
                    }
                    else
                        lblShowNames.Text += string.Format(" & <b>{0}</b> ", keyValuePair.Value);
                }
            }
            else
            {
                lblShowNames.Visible = false;
                ViewState[SelectedStudents] = null;
            }

        }

        //protected void BtnSearchClicked(object sender, EventArgs e)
        //{
        //    StudentMarkedToAssignProject();
        //    using (var fypEntities = new FYPEntities())
        //    {
        //        string stdName = txtSearchByName.Text;
        //        GvdViewAllStudent.DataSource =
        //            fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId == 4).ToList();
        //        GvdViewAllStudent.DataBind();
        //    }
        //}
    }
}