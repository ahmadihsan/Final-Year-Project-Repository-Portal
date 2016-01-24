using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlUnassignedProjects : FYPBaseUserControl
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
                                          where proj.Status == 1
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
        protected void CancelClick(object sender, EventArgs e)
        {
            var lnkButton = sender as LinkButton;
            using (var fypEntities = new FYPEntities())
            {
                var projId = new int();
                if (lnkButton != null)
                {
                    projId = Convert.ToInt32(lnkButton.CommandArgument);
                }
                Project projectToCancel = fypEntities.Projects.FirstOrDefault(proj => proj.PId == projId);
                if (projectToCancel != null)
                {
                    fypEntities.Projects.Remove(projectToCancel);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project Removed Successfully" }, this.Page, true);
                        PopulateProjectForm();
                    }
                }
            }
        }
        protected void BtnFacultySearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtByFaculty.Text;
                List<User> user = fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId != 4).ToList();
                var uid = new List<long?>();
                foreach (User usr in user)
                {
                    uid.Add(usr.UId);
                }
                //lstProjects.DataSource = fypEntities.Projects.Where(std =>uid.Contains(std.ProposedBy)).ToList();
                lstProjects.DataSource = (from proj in fypEntities.Projects
                                          join usr in fypEntities.Users on proj.ProposedBy equals usr.UId
                                          where uid.Contains(proj.ProposedBy) && proj.Status==1
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

        protected void BtnProjectSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string prName = txtByProjectName.Text;
                lstProjects.DataSource = (from proj in fypEntities.Projects
                                          join usr in fypEntities.Users on proj.ProposedBy equals usr.UId
                                          where proj.Tiltle == prName && proj.Status == 1
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
    }
}