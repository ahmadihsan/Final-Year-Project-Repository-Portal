using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAddSession : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDepartment();
            }
        }

        private void PopulateDepartment()
        {
            using (var fypEntities=new FYPEntities())
            {
                ddlDep.DataSource = fypEntities.Departments.ToList();
                ddlDep.DataBind();
                ddlDep.Items.Insert(0,"Select Department");
            }
        }

        protected void BtnAddSessionClick(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var projectSession = new ProjectSession()
                {
                    Name = txtSessionName.Text,
                    Description = txtDescription.Text,
                    Status = FYPDAL.FrequentAccesses.GetBooleanFrom10(1),
                    CreatedBy = FYPUtilities.FYPSession.GetLoggedUser().UserId,
                    CreatedDate = DateTime.Now,
                    DepartmentId = int.Parse(ddlDep.SelectedValue)

                };
                fypEntities.ProjectSessions.Add(projectSession);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPUtilities.FYPMessage.ShowMessage(ref lblMessage, true, "Session added successfully");
                    ClearAllFields();
                }
                else
                {
                    FYPUtilities.FYPMessage.ShowMessage(ref lblMessage, false, "Some error occurd");
                    ClearAllFields();
                }
            }
        }
        private void ClearAllFields()
        {
            txtSessionName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}