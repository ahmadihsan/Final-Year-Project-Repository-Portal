using System;
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
                ddlSession.Items.Insert(0,"Select Session");
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
                var student = new User();

                if (ddlDepartment.SelectedIndex != 0 && ddlDepartment.SelectedValue != null) student.DepartmentId = int.Parse(ddlDepartment.SelectedValue);
                student.RoleId = 4;
                student.Email = txtEmail.Text;
                student.Name = txtFirstName.Text;
                student.MobileNumber = txtMobile.Text;
                student.RegistrationNo = txtRegNo.Text;
                if (!string.IsNullOrWhiteSpace(txtCgpa.Text)) { student.Cgpa = float.Parse(txtCgpa.Text); }
                if (ddlSemester.SelectedIndex != 0 && ddlSemester.SelectedValue != null) student.Semester = int.Parse(ddlSemester.SelectedValue);
                if (ddlSession.SelectedIndex != 0 && ddlSession.SelectedValue != null)
                    student.ProjectSessionId = Convert.ToInt32(ddlSession.SelectedValue);
                student.Status = status;
                student.Password = "defaultPassword";

                fypEntities.Users.Add(student);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPMessage.ShowMessage(ref lblMessage, true, "Student Added Successfully");
                    ClearAllFields();
                }
                else
                {
                    FYPMessage.ShowMessage(ref lblMessage, false, "Your request couldn't processed.");
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