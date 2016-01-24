using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlAddProject : System.Web.UI.UserControl
    {
        private readonly string _projectDoc = ConfigurationManager.AppSettings["AllUploads"] + "ProjectDescription\\";
        private const string ProjectDocUrl = "/ProjectDescription/";
        private const string FilePath = "filePath";
         private string SupName = FYPSession.GetLoggedUser().Name.ToString();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectSession();
                PopulateResearchGroup();
                SupervisorName.Text = SupName.ToString();
            }
        }
        private void PopulateProjectSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlProjectSession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlProjectSession.DataBind();
                ddlProjectSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateResearchGroup()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlResearchGroup.DataSource = fypEntities.ResearchGroups.ToList();
                ddlResearchGroup.DataBind();
                ddlResearchGroup.Items.Insert(0, "Select ResearchGroup");
            }
        }

        protected void AfuProjectDoc_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {

                string uniqueStr = FYPDate.UniqueStringFromDate() + e.FileName;
                string saveAs = _projectDoc + uniqueStr;
                string savedUrl = ProjectDocUrl + uniqueStr;
                if (!Directory.Exists(_projectDoc))
                {
                    Directory.CreateDirectory(_projectDoc);
                }
                AfuProjectDoc.SaveAs(saveAs);
                Session[FilePath] = savedUrl;

            }
            catch (Exception)
            {
                FYPUtilities.FYPMessage.ShowPopUpMessage("Exception", new List<string>() { "Error in Uploading Files" }, this.Page, true);
                   

            }
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            long proposedby = FYPSession.GetLoggedUser().UserId;
            using (var fypEntities = new FYPEntities())
            {
                var project = new Project();
                project.Tiltle = txtTitle.Text;
                project.ProposedBy = proposedby;
                project.KeyFeatures = txtKeyFeatures.Text;
                project.Complexity = short.Parse(ddlComplexity.SelectedValue);
                project.Description = txtDescription.Text;
                project.Domain = txtDomain.Text;
                project.EffortsRequired = txtEffortsRequired.Text;
                project.RequiredToolsAndTech = txtReqAndTech.Text;
                project.Status = 1;
                project.researchGroupId = Convert.ToInt32(ddlResearchGroup.SelectedValue);
                project.SpecialCharactersRequired = txtSpecialCharReq.Text;
                project.UploadedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                project.UploadedBy = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                if (Session[FilePath] != null) project.UploadedFile = Session[FilePath].ToString();
                project.ProjectSessionId = Convert.ToInt32(ddlProjectSession.SelectedValue);

                fypEntities.Projects.Add(project);
                if (fypEntities.SaveChanges() > 0)
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project has been added successfully" }, this.Page, true);
                    ResetSession();
                    ClearAllFields();
                }
                else
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Some error occured" }, this.Page, true);
                    ResetSession();
                }
            }
        }
        private void ClearAllFields()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtDomain.Text = string.Empty;
            txtEffortsRequired.Text = string.Empty;
            txtKeyFeatures.Text = string.Empty;
            txtReqAndTech.Text = string.Empty;
            txtSpecialCharReq.Text = string.Empty;
            ddlComplexity.SelectedValue = null;
            ddlProjectSession.SelectedValue = null;
            ddlResearchGroup.SelectedValue = null;
        }

        private void ResetSession()
        {
            Session[FilePath] = null;
        }
    }
}