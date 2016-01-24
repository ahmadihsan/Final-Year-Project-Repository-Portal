using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlUploadResourceDoc : System.Web.UI.UserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSession();
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

        protected void SubmitDocument(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var td=new TemplateDocument
                           {
                               Title = txtTitle.Text,
                               UploadedDate = DateTime.Now,
                               UploadedFile = Session[FilePath].ToString(),
                               PSId = Convert.ToInt64(ddlSession.SelectedValue)
                           };
                fypEntities.TemplateDocuments.Add(td);
                if(fypEntities.SaveChanges()>0)
                {
                    string url = Request.RawUrl;
                    if (url.IndexOf("?", System.StringComparison.Ordinal) != -1)
                    {
                        url = url.Substring(0, url.IndexOf("?")+1) + "mid=true";
                    }
                    else
                    {
                        url = url + "?mid=true";
                    }
                    FYPMessage.RedirectToUrl(url, true, this.Page);
                    
                }
            }
        }

        protected void AsyncDocumentUpload(object sender, AjaxFileUploadEventArgs e)
        {
            try
            {
                string uniqeString = FYPUtilities.FYPDate.UniqueStringFromDate() + e.FileName;
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
    }
}