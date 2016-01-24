using System;
using System.Collections.Generic;
using System.Linq;
using FYPDAL;
using FYPUtilities;


namespace FYPAutomation.UserControls
{
    public partial class CtrlAddEditStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDepartments();
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


        private void PopulateDepartments()
        {
            using (var fypEntities = new FYPEntities())
            {

                ddlDepartment.DataSource = fypEntities.Departments.ToList();
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select Department");
            }
        }
        protected void AddStudent(object sender, EventArgs e)
        {
            var status = FYPBoolean.FromZeroOrOne(rblStatus.SelectedValue);
            using (var fypEntities = new FYPEntities())
            {
                int index1 = 0, inex2 = 0;
                if (txtRegNo.Text.Contains("CIIT/"))
                {
                    index1 = txtRegNo.Text.IndexOf("CIIT/");
                    string x = txtRegNo.Text.Substring(0, "CIIT/".Length);
                    index1 = x.Length;
                }
                if (txtRegNo.Text.Contains("/ISB"))
                {
                    inex2 = txtRegNo.Text.IndexOf("/ISB");
                    string x = txtRegNo.Text.Substring(inex2, "/ISB".Length);
                    inex2 = x.Length;
                }
                string regNum = txtRegNo.Text.Substring(index1, txtRegNo.Text.Length - (index1+inex2));
                //string regNum;
                //if(txtRegNo.Text.IndexOf("CIIT/")!=-1 && txtRegNo.Text.IndexOf("/ISB")!=-1)
                //{
                //    regNum = txtRegNo.Text;
                //}
                //if (txtRegNo.Text.IndexOf("CIIT/") == -1 && txtRegNo.Text.IndexOf("/ISB") != -1)
                //{
                //    regNum = "CIIT/"+txtRegNo.Text;
                //}

                //if (txtRegNo.Text.IndexOf("CIIT/") != -1 && txtRegNo.Text.IndexOf("/ISB") == -1)
                //{
                //    regNum = txtRegNo.Text+"/ISB";
                //}
                //if (txtRegNo.Text.IndexOf("CIIT/") == -1 && txtRegNo.Text.IndexOf("/ISB") == -1)
                //{
                //    regNum = "CIIT/"+txtRegNo.Text+"/ISB";
                //}

                List<User> usr = fypEntities.Users.Where(x => x.RegistrationNo.Contains(regNum)).ToList();
                if (usr.Count>0)
                {
                    FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Student with same registration number already exists" }, this.Page, true);
                    return;
                }
                var student = new User();

                if (ddlDepartment.SelectedIndex != 0 && ddlDepartment.SelectedValue != null) student.DepartmentId = int.Parse(ddlDepartment.SelectedValue);
                student.RoleId = 4;
                student.Email = txtEmail.Text;
                student.Name = txtFirstName.Text;
                student.MobileNumber = txtMobile.Text;
                student.RegistrationNo = txtRegNo.Text;
                student.ProjectSessionId = Convert.ToInt64(ddlSession.SelectedValue);
                if (!string.IsNullOrWhiteSpace(txtCgpa.Text)) { student.Cgpa = float.Parse(txtCgpa.Text); }
                if (ddlSemester.SelectedIndex != 0 && ddlSemester.SelectedValue != null) student.Semester = int.Parse(ddlSemester.SelectedValue);
                student.Status = status;
                student.Password = FYPUtilities.FYPPasswordManager.Encrypt("ciit");//for late it will be changed

                fypEntities.Users.Add(student);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Student Added Successfully" }, this.Page, true);
                    ClearAllFields();
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Your request couldn't processed." }, this.Page, true);
                }
            }
        }
        private void ClearAllFields()
        {
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtRegNo.Text = string.Empty;
            txtCgpa.Text = string.Empty;
            txtMobile.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;
            rblStatus.ClearSelection();
        }
    }
}