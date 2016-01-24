using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls
{
    public partial class CtrlAddResearchGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddResearchGroupClick(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var researchGroup = new ResearchGroup 
                { 
                    Title = txtTitle.Text, 
                    Description = txtDescription.Text 
                };
                fypEntities.ResearchGroups.Add(researchGroup);
                if(fypEntities.SaveChanges()>0)
                {
                    FYPUtilities.FYPMessage.ShowMessage(ref lblMessage,true,"Research group added successfully");
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
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}