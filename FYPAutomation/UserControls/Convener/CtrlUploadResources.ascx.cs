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
    public partial class CtrlUploadResources : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.UrlReferrer != null && Request.UrlReferrer.ToString().ToLower().IndexOf("resources.aspx")!=-1)
                {
                   if(Request.QueryString["mid"]!=null && Request.QueryString["mid"]=="true")
                       FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Template Uploaded Successfully" }, this.Page, true);
                }
                PopulateSessionsSearch();
                PopulateGridForAnnouncemnts();
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
        private void PopulateGridForAnnouncemnts()
        {
            using (var fypEntities = new FYPEntities())
            {
                long psid = fypEntities.ProjectSessions.Max(p => p.PSId);
                GvdDeadline.DataSource = fypEntities.TemplateDocuments.Where(ps=>ps.PSId==psid).ToList();
                GvdDeadline.DataBind();
            }
        }

        protected void GvdDeadlineRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GvdDeadline.DataKeys[((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    int tdid = Convert.ToInt32(dataKey.Values["TDId"].ToString());
                    using (var fypEntities = new FYPEntities())
                    {
                        var entity = fypEntities.TemplateDocuments.FirstOrDefault(td => td.TDId == tdid);
                        fypEntities.TemplateDocuments.Remove(entity);
                        if (fypEntities.SaveChanges() > 0)
                        {
                            PopulateGridForAnnouncemnts();
                            FYPMessage.ShowPopUpMessage("Success",new List<string>(){"Template Document Removed Successfully"},this.Page,true);                            
                        }
                            
                    }
                }
            }
        }

        protected void AddDedLineClick(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("AddDeadLine", this.Page, true);
        }


        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp=new FYPEntities())
            {
                if(ddlSessionSearch.SelectedIndex!=0)
                {
                    long psid = Convert.ToInt64(ddlSessionSearch.SelectedValue);
                    var data = fyp.TemplateDocuments.Where(td => td.PSId == psid).ToList();
                    GvdDeadline.DataSource = data;
                    GvdDeadline.DataBind();
                }
                else
                {
                    long psid = fyp.ProjectSessions.Max(p => p.PSId);
                    GvdDeadline.DataSource = fyp.TemplateDocuments.Where(ps => ps.PSId == psid).ToList();
                    GvdDeadline.DataBind();
                }
            }
        }
    }
}