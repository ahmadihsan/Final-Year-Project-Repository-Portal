using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlAdminAccordian : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateAccordian();
            }

        }

        private void PopulateAccordian()
        {
            using (var fypEntities=new FYPEntities())
            {
                rptAccordian.DataSource = (from pms in fypEntities.ProjectMileStones
                                           join pmsd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                               pmsd.PMSId
                                           join ps in fypEntities.ProjectSessions on pmsd.PSId equals ps.PSId
                                           where pmsd.DeadLine >= DateTime.Now
                                           select new
                                                      {
                                                          pms.PMSId,
                                                          mileStoneName=pms.Name,
                                                          pmsd.DeadLine,
                                                          pmsd.PMSDId,
                                                          ps.PSId,
                                                          sessionName=ps.Name
                                                      }).ToList();
                rptAccordian.DataBind();
            }
        }
    }
}