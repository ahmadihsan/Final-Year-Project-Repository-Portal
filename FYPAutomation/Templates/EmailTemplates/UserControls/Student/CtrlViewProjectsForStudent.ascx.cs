using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls
{
    public partial class CtrlViewProjectsForStudent : System.Web.UI.UserControl
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
                                                           usr.Name,
                                                           proj.Status,
                                                           proj.ProposedBy
                                                       }).ToList();
                lstProjects.DataBind();
            }
        }
       
    }
}