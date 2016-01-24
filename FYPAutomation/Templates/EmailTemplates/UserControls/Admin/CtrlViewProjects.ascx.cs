using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlViewProjects : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectForm();
            }
        }

        private void PopulateProjectForm()
        {
            using (var fypEntities = new FYPEntities())
            {
                lstProjects.DataSource = (from proj in fypEntities.Projects
                                            join usr in fypEntities.Users on proj.ProposedBy equals usr.UId
                                            select new
                                                       {
                                                           proj.PId,
                                                           proj.Tiltle,
                                                           proj.Description,
                                                           proj.ProposedBy,
                                                           usr.Name,
                                                           proj.Status
                                                       }).ToList();
                lstProjects.DataBind();
            }
        }

        protected void LstProjectsPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dPagerProjects.SetPageProperties(e.StartRowIndex,e.MaximumRows,false);
            PopulateProjectForm();
        }

        protected void CancelClick(object sender, EventArgs e)
        {
            var lnkButton = sender as LinkButton;
            using (var fypEntities = new FYPEntities())
            {
                var projId=new int();
                if (lnkButton != null)
                {
                    projId = Convert.ToInt32(lnkButton.CommandArgument);
                }
                Project projectToCancel = fypEntities.Projects.FirstOrDefault(proj => proj.PId ==projId);
                if (projectToCancel != null) projectToCancel.Status = 3;
                if(fypEntities.SaveChanges()>0)
                {
                    FYPMessage.ShowMessage(ref lblMessage, true, "Project Cancelled Successfully");
                }
            }
        }

    }
}