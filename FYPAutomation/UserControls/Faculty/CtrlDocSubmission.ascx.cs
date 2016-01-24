using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using DotNetOpenAuth.AspNet.Clients;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.Faculty
{
    public partial class CtrlDocSubmission : FYPBaseUserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var fyp = new FYPEntities())
                {
                    string rName = FYPSession.GetLoggedUser().RoleName;
                    string url = string.Empty;
                    var deadLines = fyp.ProjectMileStoneDeadLines.ToList();
                    TimeSpan take = DateTime.Now.TimeOfDay;

                    //-------------

                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                    DateTime newDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
                    var check = from dataToShow in deadLines
                                where
                                    (dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) > 0) || ((dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) == 0) && (dataToShow.TimeSpan.CompareTo(newDateTime.TimeOfDay) > 0))
                                select dataToShow;
                    //var check = from dl in deadLines
                    //            where
                    //                (dl.DeadLine.Date.CompareTo(DateTime.Now.Date) > 0) ||
                    //                ((dl.DeadLine.Date.CompareTo(DateTime.Now.Date) == 0) && (dl.TimeSpan.CompareTo(take) > 0))
                    //            select dl;

                    if (!check.Any())
                    {
                        switch (rName.ToLower())
                        {
                            case "convener": url = "~/Pages/Convener/Notify.aspx"; break;
                            case "admin": url = "~/Pages/Admin/Notify.aspx"; break;
                            case "pcmember": url = "~/Pages/PCMember/Notify.aspx"; break;
                            case "faculty": url = "~/Pages/Faculty/Notify.aspx"; break;
                            //case "student": url = "~/Pages/Student/SubmitDocs.aspx"; break;
                        }
                        Response.Redirect(url);
                    }
                    
                }


                PopulateActiveSessions();
                PopulateMileStones();
                PopulateGrid();
                PopulateSessionsForGrid();
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

        protected void SubmitDocument(object sender, EventArgs e)
        {
            long pId = 0;
            int msId = 0;
            long uId = FYPSession.GetLoggedUser().UserId;
            if (long.TryParse(ddlProjects.SelectedValue, out pId) && int.TryParse(ddlMileStone.SelectedValue, out msId))
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
                        FYPMessage.ShowPopUpMessage("Sorry", new List<string>() { "Only supervisor of this project can submit document" }, this.Page, true);
                    }
                }
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Sorry", new List<string>() { "Form Values are Changed" }, this.Page, true);
            }
            PopulateGrid();
            ClearAllFields();
        }

        /// <summary>
        /// Clear All fields of the current page
        /// </summary>
        private void ClearAllFields()
        {
            ddlMileStone.SelectedIndex = 0;
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


        /// <summary>
        /// Populate Session for Grid
        /// </summary>

        private void PopulateSessionsForGrid()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionGrid.DataSource = fypEntities.ProjectSessions.Where(x => x.Status == true).ToList();
                ddlSessionGrid.DataBind();
                ddlSessionGrid.Items.Insert(0, "Select Session");
            }
        }
        private void PopulateGrid()
        {
            using (var fyp = new FYPEntities())
            {
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                long sid = fyp.ProjectSessions.Max(x => x.PSId);
                GvdViewDocumentSumbitted.DataSource = (from docs in fyp.SP_GetDataForGridSupervisor(uId)
                                                       where docs.ReadStatus == false && docs.PSId == sid
                                                       select new
                                                       {
                                                           docs.Name,
                                                           docs.SubmittedDate,
                                                           docs.UMSDId,
                                                           docs.ProjectId,
                                                           docs.InCustody,
                                                           docs.ReadStatus,
                                                           docs.EvalStatus,
                                                           docs.UploadedFile,
                                                           docs.Tiltle,
                                                           docs.PSId
                                                       }).ToList();
                GvdViewDocumentSumbitted.DataBind();
            }
        }

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
                    FYPMessage.ShowPopUpMessage("Already Submitted", new List<string>() { "To re submit it please contact admin" }, this.Page, true);
                    asyUploadFile.Enabled = false;
                    btnSumbitDoc.Enabled = false;
                    PopulateGrid();
                }
                else
                {
                    btnSumbitDoc.Enabled = true;
                    asyUploadFile.Enabled = true;
                }
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
                    ddlProjects.DataSource = fypEntities.Projects.Where(pr => pr.ProjectSessionId == psId && pr.ProposedBy == uId && pr.Status == 2).ToList();
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, "--Select Project--");
                }
            }
        }

        protected void GvdViewDocumentSubmittedRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GvdViewDocumentSumbitted.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey == null || dataKey.Values == null)
                    return;
                long umsdid = Convert.ToInt64(dataKey.Values["UMSDId"]);
                using (var fypEntities = new FYPEntities())
                {
                    var entity1 = fypEntities.UploadedMileStoneDocs.FirstOrDefault(up => up.UMSDId == umsdid);
                    if (entity1 == null)
                        return;
                    var umsid = entity1.UMSId;
                    fypEntities.UploadedMileStoneDocs.Remove(entity1);
                    if (fypEntities.SaveChanges() <= 0)
                        return;
                    var entity2 = fypEntities.UploadedMileStones.FirstOrDefault(uu => (long?)uu.UMSId == umsid);
                    if (entity2 == null)
                        return;
                    fypEntities.UploadedMileStones.Remove(entity2);
                    if (fypEntities.SaveChanges() <= 0)
                        return;
                    PopulateGrid();
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Document removed successfully" }, this.Page, true);
                }
            }
        }

        /// <summary>
        /// Selected index changed event for populating grid
        /// </summary>
        protected void SessionGridSelectedIndexChanged(object sender, EventArgs e)
        {
            long sid;
            if (long.TryParse(ddlSessionGrid.SelectedValue, out sid))
            {
                using (var fyp = new FYPEntities())
                {
                    long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                    GvdViewDocumentSumbitted.DataSource = (from docs in fyp.SP_GetDataForGridSupervisor(uId)
                                                           where docs.ReadStatus == false && docs.PSId == sid
                                                           select new
                                                           {
                                                               docs.Name,
                                                               docs.SubmittedDate,
                                                               docs.UMSDId,
                                                               docs.ProjectId,
                                                               docs.InCustody,
                                                               docs.ReadStatus,
                                                               docs.EvalStatus,
                                                               docs.UploadedFile,
                                                               docs.Tiltle
                                                           }).ToList();
                    GvdViewDocumentSumbitted.DataBind();
                }
            }
            else
            {
                PopulateGrid();
            }
        }
    }
}