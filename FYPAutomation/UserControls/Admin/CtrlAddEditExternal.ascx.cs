using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlAddEditExternal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateDepartments();
                PopulateRoles();
                PopulateDesignations();
            }
        }
        private void PopulateDesignations()                                     // populate all designation in dropdownlist
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlDesignation.DataSource = FrequentAccesses.ListOfDesignations();
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "Select Designation");
            }
        }


        private void PopulateRoles()                                             // populate all roles in dropdownlist
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlRole.DataSource = fypEntities.Roles.ToList();
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "Select Role");
            }
        }
        private void PopulateDepartments()                                       // populate all departments in dropdownlist
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlDep.DataSource = fypEntities.Departments.ToList();
                ddlDep.DataBind();
                ddlDep.Items.Insert(0, "Select Department");
            }
        }

        protected void AddExternal(object sender, EventArgs e)
        {
            var status = FYPBoolean.FromZeroOrOne(rbStatus.SelectedValue);
            using (var fypEntities = new FYPEntities())
            {

                List<User> usr = fypEntities.Users.Where(x => x.Email == txtemail.Text).ToList();    //to check any other user at same email id, if same show error message
                if (usr.Count > 0)
                {
                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Your request could not processed" }, this.Page, true);
                    return;
                }

                var External = new User();
                //add attribute values in user's table
                External.DepartmentId = int.Parse(ddlDep.SelectedValue);
                External.RoleId = short.Parse(ddlRole.SelectedValue);
                External.Email = txtemail.Text;
                External.Name = txtEName.Text;
                External.Designation = ddlDesignation.SelectedValue;
                External.MobileNumber = txtEMobile.Text;
                External.E_Office = txtEPhone.Text;
                External.E_Specialization = txtESpecial.Text;
                External.E_CNIC = txtECnic.Text;
                External.E_ContactAddresss = txtEContAdrs.Text;
                External.Status = status;
                External.IsGrouped = false;
                External.Password = FYPPasswordManager.Encrypt("evaluate");   //  password of external user is "evaluate" later it can be changed

                fypEntities.Users.Add(External);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "External Added Successfully" }, this.Page, true);

                    ClearAllFields();
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Your request could not processed" }, this.Page, true);

                }

            }
        }
        private void ClearAllFields()
        {
            txtemail.Text = string.Empty;
            txtEName.Text = string.Empty;
            txtEMobile.Text = string.Empty;
            txtEPhone.Text = string.Empty;
            txtEContAdrs.Text = string.Empty;
            txtESpecial.Text = string.Empty;
            txtECnic.Text = string.Empty;
            ddlDesignation.SelectedIndex = 0;
            ddlDep.SelectedIndex = 0;
            ddlRole.SelectedIndex = 0;
            rbStatus.ClearSelection();
        }
    }
}