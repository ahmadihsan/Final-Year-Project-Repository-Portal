using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlDocSubmissionByAdminForOthers : System.Web.UI.UserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateActiveSessions();
                PopulateMileStones();
                PopulateSupervisor();
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

        private void PopulateMileStones()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }

        private void PopulateSupervisor()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSupervisor.DataSource = fypEntities.Users.Where(x => x.RoleId != 4).ToList();
                ddlSupervisor.DataBind();
                ddlSupervisor.Items.Insert(0, "Select Supervisor");
            }
        }

        protected void AsyncDocumentUpload(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
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


        protected void SubmitDocument(object sender, EventArgs e)
        {
            long pId = 0;
            int msId = 0;
            long uId = 0;
            if (long.TryParse(ddlProjects.SelectedValue, out pId) && int.TryParse(ddlMileStone.SelectedValue, out msId) && long.TryParse(ddlSupervisor.SelectedValue, out uId))
            {
                using (var fypEntities = new FYPEntities())
                {

                    string url = Session[FilePath].ToString();
                    if (fypEntities.SupervisodBies.Any(sup => sup.ProjectId == pId && sup.SupervisodBy1 == uId))
                    {
                        fypEntities.SP_SubmitDocumentByStudent(msId, pId, uId, url, txtComment.Text);
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Milestone Submitted successfully" }, this.Page, true);
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Sorry", new List<string>() { "Project's supervisor selected is not correct" }, this.Page, true);
                    }
                }
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Sorry", new List<string>() { "Form Values are Changed" }, this.Page, true);
            }
            ClearAllFields();
        }

        /// <summary>
        /// Clear All fields of the current page
        /// </summary>
        private void ClearAllFields()
        {
            ddlMileStone.SelectedIndex = 0;
            ddlSession.SelectedIndex = 0;
            ddlSupervisor.SelectedIndex = 0;
            ddlProjects.SelectedIndex = 0;
            txtComment.Text = string.Empty;
        }

        /// <summary>
        /// Check whether the selecte milestone document is selecte or not
        /// </summary>
        protected void DdlMileStoneSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMileStone.SelectedIndex == 0)
                return;
            long pId = Convert.ToInt64(ddlProjects.SelectedValue);
            long msId = Convert.ToInt64(ddlMileStone.SelectedValue);
            var opStatus = new ObjectParameter("Status", 0);
            using (var fyp = new FYPEntities())
            {
                fyp.SP_CheckMileStoneSubmission(pId, msId, opStatus);
                if (Convert.ToBoolean(opStatus.Value))
                {
                    FYPMessage.ShowPopUpMessage("Already Submitted", new List<string>() { " To re submit it please delete it first from Review document Portion" }, this.Page, true);
                    asyUploadFile.Enabled = false;
                    btnSumbitDoc.Enabled = false;
                }
                else
                {
                    btnSumbitDoc.Enabled = true;
                    asyUploadFile.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Populate Projects on the basis of superviosr selected
        /// </summary>
        protected void DdlSupervisorIndexChanged(object sender, EventArgs e)
        {
            ddlProjects.Enabled = true;
            long uId = 0;
            long psId = 0;
            if (long.TryParse(ddlSession.SelectedValue, out psId) && long.TryParse(ddlSupervisor.SelectedValue, out uId))
            {
                using (var fypEntities = new FYPEntities())
                {
                    ddlProjects.DataSource = fypEntities.Projects.Where(pr => pr.ProjectSessionId == psId && pr.ProposedBy == uId && pr.Status == 2).ToList();
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, "--Select Project--");
                }
            }
        }

        /// <summary>
        /// Check values from drop down is are selected or not
        /// </summary>
        protected void DdlProjectsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSession.SelectedIndex != 0 && ddlSupervisor.SelectedIndex != 0 && ddlProjects.SelectedIndex != 0)
            {
                ddlMileStone.Enabled = true;
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Please select values from upper dropdowns first" }, this.Page, true);
            }

        }
    }
}