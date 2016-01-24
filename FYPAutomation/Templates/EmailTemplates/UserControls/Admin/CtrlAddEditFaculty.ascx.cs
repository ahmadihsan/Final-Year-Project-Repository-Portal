using System;
using System.Linq;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAddEditFaculty : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateRoles();
                PopulateDepartments();
                PopulateResearchGroup();
                PopulateDesignations();
            }
        }

        private void PopulateDesignations()
        {
            using (var fypEntities=new FYPEntities())
            {
                ddlDesignation.DataSource = FrequentAccesses.ListOfDesignations();
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0,"Select Designation");
            }
        }


        private void PopulateRoles()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlRole.DataSource = fypEntities.Roles.ToList();
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "Select Role");
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
        private void PopulateResearchGroup()
        {
            using (var fypEntities=new FYPEntities())
            {
                ddlResearchGroup.DataSource = fypEntities.ResearchGroups.ToList();
                ddlResearchGroup.DataBind();
                ddlResearchGroup.Items.Insert(0,"Select ResearchGroup");
            }
        }
        protected void AddFaculty(object sender, EventArgs e)
        {

            var status = FYPBoolean.FromZeroOrOne(rblStatus.SelectedValue);
            using (var fypEntities = new FYPEntities())
            {
                    var faculty = new User();

                    faculty.DepartmentId = int.Parse(ddlDepartment.SelectedValue);
                    faculty.RoleId = short.Parse(ddlRole.SelectedValue);
                    faculty.Email = txtEmail.Text;
                    faculty.Name = txtFirstName.Text;
                    faculty.Designation = ddlDesignation.SelectedValue;
                    faculty.ResearchId = ddlResearchGroup.SelectedIndex!=0? (int?)int.Parse(ddlResearchGroup.SelectedValue):null;
                    faculty.MobileNumber = txtMobile.Text;
                    faculty.CiitExtension = txtPhone.Text;
                    faculty.Status = status;
                    faculty.Password = FYPPasswordManager.CreatePassword();

                    fypEntities.Users.Add(faculty);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessage(ref lblMessage, true, "Faculty Added Successfully");
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
            txtMobile.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ddlDesignation.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlRole.SelectedIndex = 0;
            ddlResearchGroup.SelectedIndex = 0;
            rblStatus.ClearSelection();
        }
    }
}