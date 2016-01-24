using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAddMileStone : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddMileStoneGroupClick(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var projMileStone = new ProjectMileStone()
                {
                     Name= txtName.Text,
                     Description = txtDescription.Text
                };
                fypEntities.ProjectMileStones.Add(projMileStone);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPUtilities.FYPMessage.ShowMessage(ref lblMessage, true, "Milestone added successfully");
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
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}