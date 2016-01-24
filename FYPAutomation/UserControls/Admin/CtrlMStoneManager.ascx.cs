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
    public partial class CtrlMStoneManager : FYPBaseUserControl
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
                GvdViewSessions.DataSource = (from sess in fypEntities.ProjectMileStones
                                              select new
                                                         {
                                                             sess.PMSId,
                                                             sess.Name,
                                                             sess.Description
                                                         }).ToList();
                GvdViewSessions.DataBind();

            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSearchMS.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlSearchMS.DataBind();
                ddlSearchMS.Items.Insert(0, "Select MileStone");
            }
        }

        protected void SearchSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                int projMS = Convert.ToInt32(ddlSearchMS.SelectedValue);
                GvdViewSessions.DataSource = (from sess in fypEntities.ProjectMileStones
                                              where sess.PMSId==projMS
                                              select new
                                              {
                                                  sess.PMSId,
                                                  sess.Name,
                                                  sess.Description
                                              }).ToList();
                GvdViewSessions.DataBind();
            }
        }

        protected void AddSessionClick(object sender, EventArgs e)
        {
            if (hdnPsid.Value != null) hdnPsid.Value = string.Empty;
            btnAddEditSession.Text = "Add MileStone";
            FYPUtilities.FYPMessage.ShowBootStrapPopUp("AddEditMS", this.Page, true);
        }

        protected void BtnAddEditSession(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                if (!string.IsNullOrEmpty(hdnPsid.Value))
                {
                    int pmsId = Convert.ToInt32(hdnPsid.Value);
                    hdnPsid.Value = string.Empty;
                    var prs = fypEntities.ProjectMileStones.FirstOrDefault(psi => psi.PMSId == pmsId);
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
                    var prs = new ProjectMileStone
                                {
                                    Name = txtSessionName.Text,
                                    Description = txtDescription.Text,
                                };
                    fypEntities.ProjectMileStones.Add(prs);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "MileStone added succesfully" }, this.Page, true);
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
                    psId = dk.Values["PMSId"].ToString();
                    txtSessionName.Text = dk.Values["Name"].ToString();
                    txtDescription.Text = dk.Values["Description"].ToString();
                }
            }
            hdnPsid.Value = psId;
            btnAddEditSession.Text = "Update";
            FYPMessage.ShowBootStrapPopUp("AddEditMS", this.Page, true);
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


        protected void GvdViewSessionsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                DataKey dk = GvdViewSessions.DataKeys[rowIndex];
                if (dk != null && dk.Values != null)
                {
                    int rId = Convert.ToInt32(dk.Values["PMSId"]);
                    using (var fypEntities = new FYPEntities())
                    {
                        var rgToDelete = fypEntities.ProjectMileStones.FirstOrDefault(rg => rg.PMSId == rId);
                        fypEntities.ProjectMileStones.Remove(rgToDelete);
                        if (fypEntities.SaveChanges() > 0)
                        {
                            PopulateGridForSession();
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "MileStone Deleted Successfully" }, this.Page, true);

                        }
                    }
                }
            }
        }
    }
}