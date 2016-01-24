using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlAnnouncments : FYPBaseUserControl
    {
        private const string AnnId = "annId";
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "AnnouncementUploads\\";
        private const string StudentDocUrl = "/AnnouncementUploads/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null &&
                    Request.UrlReferrer.ToString().ToLower().IndexOf("announcment.aspx") != -1)
                {
                    if (Request.QueryString["mid"] != null && Request.QueryString["mid"] == "true")
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "DeadLine Added Successfully" }, this.Page, true);

                    }
                    else if (Request.QueryString["mid"] != null && Request.QueryString["mid"] == "trueupdated")
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "DeadLine Updated Successfully" }, this.Page, true);
                    }
                }

                PopulateSessionsSearch();
                PopulateGridData();
                PopulateSessionsForPopUp();
            }
        }

        private void PopulateSessionsForPopUp()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }


        private void PopulateSessionsSearch()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSearch.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSearch.DataBind();
                ddlSessionSearch.Items.Insert(0, "FYP-I/FYP-II");
                ddlSessionSearch.Items.Insert(0, "Select Session");
            }
        }


        /// <summary>
        /// Add Announcment popup here 
        /// </summary>
        protected void AddAnnouncmentClick(object sender, EventArgs e)
        {
            var query = HttpUtility.ParseQueryString(Request.Url.Query);
            query["mid"] = null;

            using (var fyp = new FYPEntities())
            {
                if (cbxBothSession.Checked)
                {
                    var ann = new Announcment()
                    {
                        PSId = null,
                        Title = txtTitle.Text,
                        Description = txtDesc.Text,
                        CreatedDate = DateTime.Now,
                        Upload = Session[FilePath] != null ? Session[FilePath].ToString() : null,
                        IsVisibleToBothSessions = cbxBothSession.Checked
                    };
                    fyp.Announcments.Add(ann);
                }
                else
                {
                    long psid;
                    if (long.TryParse(ddlSession.SelectedValue, out psid))
                    {
                        var ann = new Announcment()
                        {
                            PSId = Convert.ToInt64(ddlSession.SelectedValue),
                            Title = txtTitle.Text,
                            Description = txtDesc.Text,
                            CreatedDate = DateTime.Now,
                            Upload = Session[FilePath] != null ? Session[FilePath].ToString() : null,
                            IsVisibleToBothSessions = null
                        };
                        fyp.Announcments.Add(ann);
                    }
                    else
                    {
                        FYPMessage.ShowMessageAndHidePopup("Erroe", new List<string>() { "Please either select session or tick the checkbox" }, this.Page, true);
                    }
                }

                if (fyp.SaveChanges() > 0)
                {
                    string url = Request.RawUrl;
                    if (url.IndexOf("?", StringComparison.Ordinal) != -1)
                    {
                        url = url.Substring(0, url.IndexOf("?") + 1) + "mid=true";
                    }
                    else
                    {
                        url = url + "?mid=true";
                    }
                    FYPMessage.RedirectToUrl(url, true, this.Page);
                    //FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Announcment Added successfully" }, this.Page, true);
                }
                else
                {
                    FYPMessage.ShowMessageAndHidePopup("Error", new List<string>() { "Announcment could not be added due to some error" }, this.Page, true);
                }
            }
        }

        /// <summary>
        /// Populate Grid for Announcment Data Here 
        /// </summary>
        private void PopulateGridData()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = fyp.ProjectSessions.Max(ps => ps.PSId);
                var data = fyp.Announcments.Where(ann => ann.PSId == psid).ToList();
                GvdAnnouncment.DataSource = data;
                GvdAnnouncment.DataBind();
            }
        }


        protected void GvdGvdAnnouncmentRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "xd", "CbxSelectionBothChanged()", true);
                int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
                DataKey dk = GvdAnnouncment.DataKeys[rowIndex];

                if (dk != null && dk.Values != null)
                {
                    long annId = Convert.ToInt64(dk.Values["AnnId"]);
                    ViewState[AnnId] = annId;
                    using (var fyp = new FYPEntities())
                    {
                        btnUpdate.Visible = true;
                        btnCancel.Visible = true;
                        btnAddAnn.Visible = false;
                        Announcment ann = fyp.Announcments.FirstOrDefault(an => an.AnnId == annId);
                        if (ann != null)
                        {
                            if (ann.PSId != null)
                            {
                                //firstRow.Visible = true;
                                cbxBothSession.Checked = Convert.ToBoolean(ann.IsVisibleToBothSessions);
                                ddlSession.SelectedValue = ann.PSId.ToString();
                                txtTitle.Text = ann.Title;
                                txtDesc.Text = ann.Description;
                                FYPMessage.ShowBootStrapPopUp("AddAnnouncment", this.Page, true);
                            }
                            else if (ann.PSId == null)
                            {
                                //firstRow.Visible = true;
                                cbxBothSession.Checked = Convert.ToBoolean(ann.IsVisibleToBothSessions);
                                ddlSession.SelectedIndex = 0;
                                txtTitle.Text = ann.Title;
                                txtDesc.Text = ann.Description;
                                FYPMessage.ShowBootStrapPopUp("AddAnnouncment", this.Page, true);
                            }
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "xd", "CbxSelectionBothChanged()", true);
                        }
                    }
                }
            }
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
                DataKey dk = GvdAnnouncment.DataKeys[rowIndex];

                if (dk != null && dk.Values != null)
                {
                    long annId = Convert.ToInt64(dk.Values["AnnId"]);
                    ViewState[AnnId] = annId;
                    using (var fyp = new FYPEntities())
                    {
                        Announcment ann = fyp.Announcments.FirstOrDefault(an => an.AnnId == annId);
                        fyp.Announcments.Remove(ann);
                        if (fyp.SaveChanges() > 0)
                        {
                            PopulateGridData();
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Announcment deleted successfully" }, this.Page, true);
                            ViewState[AnnId] = null;
                        }
                        else
                        {
                            PopulateGridData();
                            FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Announcment could not be deleted due to some error" }, this.Page, true);
                            ViewState[AnnId] = null;

                        }
                    }
                }
            }
        }

        protected void UpdateAnnouncmentClick(object sender, EventArgs e)
        {
            var query = HttpUtility.ParseQueryString(Request.Url.Query);
            query["mid"] = null;

            using (var fyp = new FYPEntities())
            {
                long anId = Convert.ToInt64(ViewState[AnnId]);
                Announcment ann = fyp.Announcments.FirstOrDefault(an => an.AnnId == anId);
                if (ann != null)
                {
                    long psid;
                    if (long.TryParse(ddlSession.SelectedValue, out psid))
                    {
                        ann.PSId = Convert.ToInt64(ddlSession.SelectedValue);
                        ann.Title = txtTitle.Text;
                        ann.Description = txtDesc.Text;
                        ann.Upload = Session[FilePath] != null ? Session[FilePath].ToString() : null;
                        ann.IsVisibleToBothSessions = null;
                    }
                    else
                    {
                        if (cbxBothSession.Checked)
                        {
                            ann.PSId = null;
                            ann.IsVisibleToBothSessions = cbxBothSession.Checked;
                            ann.Title = txtTitle.Text;
                            ann.Description = txtDesc.Text;
                            ann.Upload = Session[FilePath] != null ? Session[FilePath].ToString() : null;
                        }
                        else
                        {
                            FYPMessage.ShowMessageAndHidePopup("Error", new List<string>() { "Please either select session or tick the checkbox" }, this.Page, true);
                        }
                    }

                    if (fyp.SaveChanges() > 0)
                    {
                        string url = Request.RawUrl;
                        if (url.IndexOf("?", StringComparison.Ordinal) != -1)
                        {
                            url = url.Substring(0, url.IndexOf("?") + 1) + "mid=trueupdated";
                        }
                        else
                        {
                            url = url + "?mid=trueupdated";
                        }
                        FYPMessage.RedirectToUrl(url, true, this.Page);

                        //FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Announcment Updated successfully" }, this.Page, true);
                        ViewState[AnnId] = null;
                    }
                    else
                    {
                        FYPMessage.ShowMessageAndHidePopup("Error", new List<string>() { "Announcment could not be updated due to some error" }, this.Page, true);
                        ViewState[AnnId] = null;

                    }
                }
            }
        }

        protected void CancelAnnouncmentClick(object sender, EventArgs e)
        {
            FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/Convener/Announcment.aspx"), true, this.Page);
        }

        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid;
                if (long.TryParse(ddlSessionSearch.SelectedValue, out psid))
                {
                    var data = fyp.Announcments.Where(an => an.PSId == psid).ToList();
                    GvdAnnouncment.DataSource = data;
                    GvdAnnouncment.DataBind();
                }
                else if (ddlSessionSearch.SelectedValue.ToString().ToLower() == "select session")
                {
                    psid = fyp.ProjectSessions.Max(pss => pss.PSId);
                    var data = fyp.Announcments.Where(an => an.PSId == psid).ToList();
                    GvdAnnouncment.DataSource = data;
                    GvdAnnouncment.DataBind();
                }
                else if (ddlSessionSearch.SelectedValue.ToString() == "FYP-I/FYP-II")
                {
                    var data = fyp.Announcments.Where(an => an.IsVisibleToBothSessions == true).ToList();
                    GvdAnnouncment.DataSource = data;
                    GvdAnnouncment.DataBind();
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Dropdwon value could't be parsed" }, this.Page, true);
                }
            }
        }

        protected void AddAnnouenmentPopUpClicked(object sender, EventArgs e)
        {
            ClearFields();
            FYPMessage.ShowBootStrapPopUp("AddAnnouncment", this.Page, true);
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        private void ClearFields()
        {
            cbxBothSession.Checked = false;
            ddlSession.SelectedIndex = 0;
            txtTitle.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }
        protected void AsyncDocumentUpload(object sender, AjaxFileUploadEventArgs e)
        {
            try
            {
                string uniqeString = FYPDate.UniqueStringFromDate() + e.FileName;
                string saveAs = _studentDoc + uniqeString;
                string savedUrl = StudentDocUrl + uniqeString;
                if (!Directory.Exists(_studentDoc))
                {
                    Directory.CreateDirectory(_studentDoc);
                }
                asyUploadFile.SaveAs(saveAs);
                Session[FilePath] = savedUrl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            secondRow.Attributes.Add("rules", "all");
            secondRow.Attributes.Add("style", "border:1px solid #c1dad7");
            base.OnPreRender(e);
        }

    }
}