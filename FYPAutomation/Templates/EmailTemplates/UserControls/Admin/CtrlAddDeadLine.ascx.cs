using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using eWorld.UI;
namespace FYPAutomation.UserControls
{
    public partial class CtrlAddDeadLine : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateSession();
                PopulateMileStones();
            }
        }



        private void PopulateSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0,"Select Session");
            }
        }

        private void PopulateMileStones()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }

        protected void AddDeadLineClick(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var projectMileStoneDeadLine=new ProjectMileStoneDeadLine
                                                 {
                                                     PMSId = Convert.ToInt32(ddlMileStone.SelectedValue.ToString()),
                                                     PSId = Convert.ToInt32(ddlSession.SelectedValue.ToString()),
                                                     DeadLine =
                                                         Convert.ToDateTime(cldCalender.Text)
                                                 };
                fypEntities.ProjectMileStoneDeadLines.Add(projectMileStoneDeadLine);
                if(fypEntities.SaveChanges()>0)
                {

                    FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "DeadLine Added Successfully" }, this.Page, true);
                   
                }
            }
        }
    }
}