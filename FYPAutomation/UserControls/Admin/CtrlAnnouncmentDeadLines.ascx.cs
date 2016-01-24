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
    public partial class CtrlAnnouncmentDeadLines : FYPBaseUserControl
    {
        private string _pmsdeadlineId = "pmsdid";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().ToLower().IndexOf("deadlines.aspx") != -1)
                {
                    if (Request.QueryString["mid"] != null && Request.QueryString["mid"] == "true")
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "DeadLine Added Successfully" }, this.Page, true);
                    }
                }

                if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().ToLower().IndexOf("milestonedeadline.aspx") != -1)
                {
                    if (Request.QueryString["mid"] != null && Request.QueryString["mid"] == "trueupdate")
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "DeadLine Updated Successfully" }, this.Page, true);
                    }
                }
                PopulateSession();
                PopulateMileStones();
                PopulateMileStoneSearch();
                PopulateSessionsSearch();
                PopulateGridForAnnouncemnts();

            }
        }
        private void PopulateGridForAnnouncemnts()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdDeadline.DataSource = (from pms in fypEntities.ProjectMileStones
                                          join pmd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                              pmd.PMSId
                                          join ps in fypEntities.ProjectSessions on pmd.PSId equals ps.PSId
                                          select new
                                                     {
                                                         pmd.PMSDId,
                                                         pms.PMSId,
                                                         ps.PSId,
                                                         mileStoneName = pms.Name,
                                                         pmd.DeadLine,
                                                         sessName = ps.Name
                                                     }).ToList();
                GvdDeadline.DataBind();
            }
        }

        protected void GvdDeadlineRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
                DataKey dataKey = this.GvdDeadline.DataKeys[rowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long pmsdid = Convert.ToInt64(dataKey.Values["PMSDId"]);
                    ViewState[_pmsdeadlineId] = pmsdid;
                    using (var fyp = new FYPEntities())
                    {
                        ProjectMileStoneDeadLine p = fyp.ProjectMileStoneDeadLines.FirstOrDefault(pp => pp.PMSDId == pmsdid);
                        if (p != null)
                        {
                            ddlSession11.SelectedIndex = ddlSession11.Items.IndexOf(ddlSession11.Items.FindByValue(p.PSId.ToString()));
                            ddlMileStone11.SelectedIndex = ddlMileStone11.Items.IndexOf(ddlMileStone11.Items.FindByValue(p.PMSId.ToString()));
                            cldCalender11.Text = p.DeadLine.ToString();
                            txtTimeSpan11.Text = p.TimeSpan.ToString();
                            txtDescription11.Text = p.Description;
                            FYPMessage.ShowBootStrapPopUp("EditDeadLine", this.Page, true);
                        }
                    }
                }
            }
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GvdDeadline.DataKeys[((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    int pmsdid = Convert.ToInt32(dataKey.Values[(object)"PMSDId"].ToString());
                    using (var fypEntities = new FYPEntities())
                    {
                        var entity = fypEntities.ProjectMileStoneDeadLines.FirstOrDefault(pr => pr.PMSDId == pmsdid);
                        fypEntities.ProjectMileStoneDeadLines.Remove(entity);
                        if (fypEntities.SaveChanges() > 0)
                        {
                            PopulateGridForAnnouncemnts();
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "DeadLine Removed Successfully" }, this.Page, true);
                        }
                    }
                }
            }

            if (e.CommandName == "DetailRow")
            {
                int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
                DataKey dataKey = this.GvdDeadline.DataKeys[rowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long pmsdid = Convert.ToInt64(dataKey.Values["PMSDId"]);
                    ViewState[_pmsdeadlineId] = pmsdid;
                    using (var fyp = new FYPEntities())
                    {
                        ProjectMileStoneDeadLine p = fyp.ProjectMileStoneDeadLines.FirstOrDefault(pp => pp.PMSDId == pmsdid);
                        if (p != null)
                        {
                            lblSession.Text = p.ProjectSession.Name;
                            lblMilestone.Text = p.ProjectMileStone.Name;
                            string t = p.TimeSpan.ToString();
                            lblDeadline.Text = Convert.ToDateTime(p.DeadLine).ToString("dddd, MMMM d, yyyy") + " <h3>(" + t.ToString() + ")</h3>";
                            lblDescr.Text = p.Description;
                            FYPMessage.ShowBootStrapPopUp("DetailDeadLine", this.Page, true);
                        }
                    }
                }
            }
        }

        protected void AddDedLineClick(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("AddDeadLine", this.Page, true);
        }

        protected void MileStoneSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                long pmsId;
                if (long.TryParse(ddlMileStoneSearch.SelectedValue, out pmsId))
                {
                    GvdDeadline.DataSource = (from pms in fypEntities.ProjectMileStones
                                              join pmd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                                  pmd.PMSId
                                              join ps in fypEntities.ProjectSessions on pmd.PSId equals ps.PSId
                                              where pms.PMSId == pmsId
                                              select new
                                                         {
                                                             pmd.PMSDId,
                                                             pms.PMSId,
                                                             ps.PSId,
                                                             mileStoneName = pms.Name,
                                                             pmd.DeadLine,
                                                             sessName = ps.Name
                                                         }).ToList();
                    GvdDeadline.DataBind();
                }
                else
                {
                    GvdDeadline.DataSource = (from pms in fypEntities.ProjectMileStones
                                              join pmd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                                  pmd.PMSId
                                              join ps in fypEntities.ProjectSessions on pmd.PSId equals ps.PSId
                                              select new
                                              {
                                                  pmd.PMSDId,
                                                  pms.PMSId,
                                                  ps.PSId,
                                                  mileStoneName = pms.Name,
                                                  pmd.DeadLine,
                                                  sessName = ps.Name
                                              }).ToList();
                    GvdDeadline.DataBind();
                }
            }
        }

        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                long psId;
                if (long.TryParse(ddlSessionSearch.SelectedValue, out psId))
                {
                    GvdDeadline.DataSource = (from pms in fypEntities.ProjectMileStones
                                              join pmd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                                  pmd.PMSId
                                              join ps in fypEntities.ProjectSessions on pmd.PSId equals ps.PSId
                                              where ps.PSId == psId
                                              select new
                                                         {
                                                             pmd.PMSDId,
                                                             pms.PMSId,
                                                             ps.PSId,
                                                             mileStoneName = pms.Name,
                                                             pmd.DeadLine,
                                                             sessName = ps.Name
                                                         }).ToList();
                    GvdDeadline.DataBind();
                }
                else
                {
                    psId = fypEntities.ProjectSessions.Max(ps=>ps.PSId);
                    GvdDeadline.DataSource = (from pms in fypEntities.ProjectMileStones
                                              join pmd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                                  pmd.PMSId
                                              join ps in fypEntities.ProjectSessions on pmd.PSId equals ps.PSId
                                              where ps.PSId == psId
                                              select new
                                              {
                                                  pmd.PMSDId,
                                                  pms.PMSId,
                                                  ps.PSId,
                                                  mileStoneName = pms.Name,
                                                  pmd.DeadLine,
                                                  sessName = ps.Name
                                              }).ToList();
                    GvdDeadline.DataBind();
                }
            }
        }

        private void PopulateSessionsSearch()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSearch.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSearch.DataBind();
                ddlSessionSearch.Items.Insert(0, "Select Session");
            }
        }
        private void PopulateMileStoneSearch()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStoneSearch.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStoneSearch.DataBind();
                ddlMileStoneSearch.Items.Insert(0, "Select MileStone");
            }
        }

        protected void GvdDeadlinePageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdDeadline.PageIndex = e.NewPageIndex;
            PopulateGridForAnnouncemnts();
        }

        //Detail of deadlines

        private void PopulateSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession11.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSession11.DataBind();
                ddlSession11.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateMileStones()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone11.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone11.DataBind();
                ddlMileStone11.Items.Insert(0, "Select MileStone");
            }
        }


        protected void UpdateDeadLineClick(object sender, EventArgs e)
        {
            long pmsdid = Convert.ToInt64(ViewState[_pmsdeadlineId]);
            using (var fyp = new FYPEntities())
            {
                ProjectMileStoneDeadLine p = fyp.ProjectMileStoneDeadLines.FirstOrDefault(pp => pp.PMSDId == pmsdid);
                if (p != null)
                {
                    p.PSId = Convert.ToInt64(ddlSession11.SelectedValue);
                    p.PMSId = Convert.ToInt64(ddlMileStone11.SelectedValue);
                    p.DeadLine = Convert.ToDateTime(cldCalender11.Text);
                    p.TimeSpan = FrequentAccesses.FormatTime(txtTimeSpan11.Text);
                    p.Description = txtDescription11.Text;
                    if (fyp.SaveChanges() > 0)
                    {
                        string url = Request.RawUrl;
                        if (url.IndexOf("?", System.StringComparison.Ordinal) != -1)
                        {
                            url = url.Substring(0, url.IndexOf("?") + 1) + "mid=trueupdate";
                        }
                        else
                        {
                            url = url + "?mid=trueupdate";
                        }
                        FYPMessage.RedirectToUrl(url, true, this.Page);
                        ViewState[_pmsdeadlineId] = null;
                    }
                    else
                    {
                        FYPMessage.ShowMessageAndHidePopup("Error", new List<string>() { "Deadline could't be updated due to some error" }, this.Page, true);
                        ViewState[_pmsdeadlineId] = null;
                    }
                }
            }
        }

        protected void CancelDeadLineClick(object sender, EventArgs e)
        {
            FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/Convener/MileStoneDeadline.aspx"), true, this.Page);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lbll.Attributes.Add("rules", "all");
            lbll.Attributes.Add("style", "border:1px solid #c1dad7");
            base.OnPreRender(e);
        }
    }
}