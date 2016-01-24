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
    public partial class CtrlRGManager : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForRGroup();
            }
        }

        private void PopulateGridForRGroup()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewSessions.DataSource = (from sess in fypEntities.ResearchGroups
                                              select new
                                                         {
                                                             sess.ResearchId,
                                                             sess.Title,
                                                             sess.Description
                                                         }).ToList();
                GvdViewSessions.DataBind();

            }
        }

        protected void AddSessionClick(object sender, EventArgs e)
        {
            if (hdnPsid.Value != null) hdnPsid.Value = string.Empty;
            btnAddEditSession.Text = "Add ResearchGroup";
            FYPUtilities.FYPMessage.ShowBootStrapPopUp("AddEditRG", this.Page, true);
        }

        protected void BtnAddEditSession(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                if (!string.IsNullOrEmpty(hdnPsid.Value))
                {
                    int rgId = Convert.ToInt32(hdnPsid.Value);
                    hdnPsid.Value = string.Empty;
                    var prs = fypEntities.ResearchGroups.FirstOrDefault(psi => psi.ResearchId == rgId);
                    if (prs != null)
                    {
                        prs.Title = txtRGName.Text;
                        prs.Description = txtRGDescription.Text;
                    }
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Information updated successfully" }, this.Page, true);
                    }
                    ClearAllFields();
                }
                else
                {
                    var prs = new ResearchGroup
                                {
                                    Title = txtRGName.Text,
                                    Description = txtRGDescription.Text
                                };
                    fypEntities.ResearchGroups.Add(prs);
                    if (fypEntities.SaveChanges() > 0)
                    {
                        FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "ResearchGroup added succesfully" }, this.Page, true);
                    }
                }
            }
            PopulateGridForRGroup();
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
                    psId = dk.Values["ResearchId"].ToString();
                    txtRGName.Text = dk.Values["Title"].ToString();
                    txtRGDescription.Text = dk.Values["Description"].ToString();
                }
            }
            hdnPsid.Value = psId;
            btnAddEditSession.Text = "Update";
            FYPMessage.ShowBootStrapPopUp("AddEditRG", this.Page, true);
        }

        private void ClearAllFields()
        {
            txtRGName.Text = string.Empty;
            txtRGDescription.Text = string.Empty;
        }


        protected void GvdViewSessionsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewSessions.PageIndex = e.NewPageIndex;
            PopulateGridForRGroup();
            GvdViewSessions.DataBind();
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string rgTitle = txtSearch.Text;
                GvdViewSessions.DataSource = (from sess in fypEntities.ResearchGroups
                                              where sess.Title.Contains(rgTitle)
                                              select new
                                              {
                                                  sess.Title,
                                                  sess.Description
                                              }).ToList();
                GvdViewSessions.DataBind();
            }
        }

        protected void GvdViewSessionsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="DeleteRow")
            {
                int rowIndex = ((GridViewRow) ((LinkButton) e.CommandSource).NamingContainer).RowIndex;
                DataKey dk = GvdViewSessions.DataKeys[rowIndex];
                if(dk!=null && dk.Values != null )
                {
                    int rId = Convert.ToInt32(dk.Values["ResearchId"]);
                    using (var fypEntities=new FYPEntities())
                    {
                        ResearchGroup rgToDelete = fypEntities.ResearchGroups.FirstOrDefault(rg => rg.ResearchId == rId);
                        fypEntities.ResearchGroups.Remove(rgToDelete);
                        if(fypEntities.SaveChanges()>0)
                        {
                            PopulateGridForRGroup();
                            FYPMessage.ShowPopUpMessage("Success",new List<string>(){"ResearchGroup Deleted Successfully"},this.Page,true);
                            
                        }
                    }
                }
            }
        }
    }
}