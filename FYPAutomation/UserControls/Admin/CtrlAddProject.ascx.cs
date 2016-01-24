using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls
{
    public partial class CtrlAddProject : System.Web.UI.UserControl
    {
        private readonly string _projectDoc = ConfigurationManager.AppSettings["AllUploads"] + "ProjectDescription\\";
        private const string ProjectDocUrl = "/ProjectDescription/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectSession();
                PopulateFaculty();
                PopulateResearchGroup();
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

        private void PopulateFaculty()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlProposedBy.DataSource =
                    fypEntities.Users.OrderBy(fac=>fac.Name).Where(fac => fac.RoleId == 1 || fac.RoleId == 2 || fac.RoleId == 3 || fac.RoleId == 5).ToList();
                ddlProposedBy.DataBind();
                ddlProposedBy.Items.Insert(0, "Select Faculty");
            }
        }

        protected void BtnAddProjectClick(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var project = new Project();
                project.Tiltle = txtTitle.Text;
                project.ProposedBy = int.Parse(ddlProposedBy.SelectedValue);
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
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Success",new List<string>(){"Project has been added successfully"},this.Page,true );
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
            ddlProposedBy.SelectedValue = null;
            ddlResearchGroup.SelectedValue = null;
        }

        private void ResetSession()
        {
            Session[FilePath] = null;
        }

        protected void AfuProjectDocUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
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


            }
        }
    }
}