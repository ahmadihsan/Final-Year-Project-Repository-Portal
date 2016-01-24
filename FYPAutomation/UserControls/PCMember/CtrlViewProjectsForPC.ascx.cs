using System;
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
    public partial class CtrlViewProjectsForPC : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectForm();
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
            dPagerProjects.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateProjectForm();
        }

        protected void MileStoneSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                if (ddlSession.SelectedIndex == 0)
                {
                    PopulateProjectForm();
                }
                else
                {
                    long psid = Convert.ToInt64(ddlSession.SelectedValue);
                    lstProjects.DataSource = (from proj in fypEntities.Projects
                                              join usr in fypEntities.Users on proj.ProposedBy equals usr.UId
                                              where proj.ProjectSessionId == psid
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
                                          where uid.Contains(proj.ProposedBy)
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
                                          where proj.Tiltle == prName
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