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
    public partial class CtrlSessionManager : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSessions();
                PopulateGridForSession();
            }
        }

        private void PopulateGridForSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewSessions.DataSource = (from sess in fypEntities.ProjectSessions
                                              where sess.Status == true
                                              select new
                                                         {
                                                             sess.PSId,
                                                             sess.Name,
                                                             sess.Status,
                                                             sess.Description
                                                         }).ToList();
                GvdViewSessions.DataBind();

            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSearchSession.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSearchSession.DataBind();
                ddlSearchSession.Items.Insert(0, "Select Session");
            }
        }

        protected void SearchSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                int projSession = Convert.ToInt32(ddlSearchSession.SelectedValue);
                GvdViewSessions.DataSource = (from sess in fypEntities.ProjectSessions
                                              where sess.PSId == projSession
                                              select new
                                                         {
                                                             sess.PSId,
                                                             sess.Name,
                                                             sess.Status,
                                                             sess.Description
                                                         }).ToList();
                GvdViewSessions.DataBind();
            }
        }

        protected void AddSessionClick(object sender, EventArgs e)
        {
            if (hdnPsid.Value != null) hdnPsid.Value = string.Empty;
            btnAddEditSession.Text = "Add Session";
            FYPUtilities.FYPMessage.ShowBootStrapPopUp("AddEditSession", this.Page, true);
        }

        protected void BtnAddEditSession(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                if (!string.IsNullOrEmpty(hdnPsid.Value))
                {
                    int psId = Convert.ToInt32(hdnPsid.Value);
                    hdnPsid.Value = string.Empty;
                    var prs = fypEntities.ProjectSessions.FirstOrDefault(psi => psi.PSId == psId);
                    if (prs != null)
                    {
                        prs.Name = txtSessionName.Text;
                        prs.Description = txtDescription.Text;
                    }
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Information updated successfully" }, this.Page, true);
                    }
                    ClearAllFields();
                }
                else
                {
                    var prs = new ProjectSession
                                {
                                    Name = txtSessionName.Text,
                                    Description = txtDescription.Text,
                                    Status = true
                                };
                    fypEntities.ProjectSessions.Add(prs);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Session added succesfully" }, this.Page, true);
                    }
                }
            }
            PopulateGridForSession();
        }

        protected void GvdViewSessionsSelectedIndexChanged(object sender, EventArgs e)
        {
            string psId = string.Empty;
            var gvrRow = GvdViewSessions.SelectedRow;
            int rowIndex = gvrRow.RowIndex;
            DataKey dk = GvdViewSessions.DataKeys[rowIndex];
            if (dk != null)
            {
                if (dk.Values != null)
                {
                    psId = dk.Values["PSId"].ToString();
                    txtSessionName.Text = dk.Values["Name"].ToString();
                    txtDescription.Text = dk.Values["Description"].ToString();
                }
            }
            hdnPsid.Value = psId;
            btnAddEditSession.Text = "Update";
            FYPMessage.ShowBootStrapPopUp("AddEditSession", this.Page, true);
        }

        private void ClearAllFields()
        {
            txtSessionName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }


        protected void GvdViewSessionsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewSessions.PageIndex = e.NewPageIndex;
            PopulateGridForSession();
            GvdViewSessions.DataBind();
        }
    }
}