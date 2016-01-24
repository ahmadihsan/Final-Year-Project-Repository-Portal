using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlArchiveRecords : FYPBaseUserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "ProjectDirectory\\";
        private const string StudentDocUrl = "/ProjectDirectory/";
        private const string FilePath = "filePath";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateActiveSessions();

            }

        }


        private void PopulateActiveSessions()
        {
            using (var fyp = new FYPEntities())
            {
                ddlSession.DataSource = fyp.ProjectSessions.Where(sess => sess.Status == true).ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "--Select Session--");
            }

        }

        protected void SubmitDocument(object sender, EventArgs e)
        {
           using (var fypEntities = new FYPEntities())
           {
            var projectDir = new ProjectDirectory();
            projectDir.psId = Convert.ToInt32(ddlSession.SelectedValue);
            projectDir.ProjectId = Convert.ToInt64(ddlProjects.SelectedValue);
            projectDir.Description = txtComment.Text;
            projectDir.UploadedFile = Session[FilePath].ToString();

            fypEntities.ProjectDirectories.Add(projectDir);
            if (fypEntities.SaveChanges() > 0)
            {
                FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project Archive submitted successfully" }, this.Page, true);
                
                ClearAllFields();
            }
            else
            {
                FYPUtilities.FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Some error occured! Could not be saved." }, this.Page, true);
               
            }

           }
        }
          
           
        
        private void ClearAllFields()
        {

            ddlSession.SelectedIndex = 0;
            ddlProjects.SelectedIndex = 0;
            txtComment.Text = string.Empty;
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


        protected void DdlSessionChanged(object sender, EventArgs e)
        {
            ddlProjects.Enabled = true;
            long uId = FYPSession.GetLoggedUser().UserId;
            long psId = 0;
            if (long.TryParse(ddlSession.SelectedValue, out psId))
            {
                using (var fypEntities = new FYPEntities())
                {
                    ddlProjects.DataSource = fypEntities.Projects.Where(pr => pr.ProjectSessionId == psId && pr.Status == 2 && pr.ProposedBy == uId).ToList();
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, "--Select Project--");
                }
            }
        }


    }
}