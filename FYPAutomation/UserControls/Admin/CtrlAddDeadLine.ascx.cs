using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using eWorld.UI;
using FYPAutomation.App_Start;
namespace FYPAutomation.UserControls
{
    public partial class CtrlAddDeadLine : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSession();
                PopulateMileStones();
            }
        }


        private void PopulateSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
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
                var projectMileStoneDeadLine = new ProjectMileStoneDeadLine
                                                 {
                                                     PMSId = Convert.ToInt32(ddlMileStone.SelectedValue.ToString()),
                                                     PSId = Convert.ToInt32(ddlSession.SelectedValue.ToString()),
                                                     DeadLine =
                                                         Convert.ToDateTime(cldCalender.Text),
                                                     Description = txtDescription.Text,
                                                     TimeSpan = FrequentAccesses.FormatTime(txtTimeSpan.Text)
                                                 };
                fypEntities.ProjectMileStoneDeadLines.Add(projectMileStoneDeadLine);
                if (fypEntities.SaveChanges() > 0)
                {
                    string url = Request.RawUrl;
                    if (url.IndexOf("?", System.StringComparison.Ordinal) != -1)
                    {
                        url = url.Substring(0, url.IndexOf("?") + 1) + "mid=true";
                    }
                    else
                    {
                        url = url + "?mid=true";
                    }
                    FYPMessage.RedirectToUrl(url, true, this.Page);
                }
            }
        }
    }
}