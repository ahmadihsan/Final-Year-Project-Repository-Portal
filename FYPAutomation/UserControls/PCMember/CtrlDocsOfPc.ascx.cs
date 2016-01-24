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

namespace FYPAutomation.UserControls.PCMember
{
    public partial class CtrlDocsOfPc : FYPBaseUserControl
    {
        private long _projId;
        private long _umsId;
        private long _umsdId;
        private long _msId;

        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForDocs();
            }
        }

        
        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByProjectName.Text;
                GvdViewAllDocs.DataSource =
                    fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName) && std.Status == 2).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        private void PopulateGridForDocs()
        {
            long uid = FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                var data = (from dc in fyp.SP_GetDocumentsSubmittedDataForGrid(null, null,false)
                            where dc.InCustody == uid
                            select new
                                       {
                                           dc.ToAdmin,
                                           dc.ReadStatus,
                                           dc.InCustody,
                                           dc.MileStoneName,
                                           dc.Name,
                                           dc.ProjectId,
                                           dc.UId,
                                           dc.UMSDId,
                                           dc.UMSId,
                                           dc.UploadedFile,
                                           dc.Tiltle,
                                           dc.SubmittedDate,
                                           dc.StatusComment,
                                           dc.PMSId,
                                           dc.EvalStatus,
                                           dc.FromStudent,
                                           dc.FromPc
                                       }).ToList();

                GvdViewAllDocs.DataSource = data;
                GvdViewAllDocs.DataBind();
            }
        }

        protected void GvdViewAllDocsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllDocs.PageIndex = e.NewPageIndex;
            PopulateGridForDocs();
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

        protected void SubmitDocumentByPc(object sender, EventArgs e)
        {
            GridViewRow gr = GvdViewAllDocs.SelectedRow;
            DataKey dk = GvdViewAllDocs.DataKeys[gr.RowIndex];
            if (dk != null && dk.Values != null)
            {
                _projId = Convert.ToInt64(dk.Values["ProjectId"]);
                _umsId = Convert.ToInt64(dk.Values["UMSId"]);
                _umsdId = Convert.ToInt64(dk.Values["UMSDId"]);
                _msId = Convert.ToInt64(dk.Values["PMSId"]);
            }

            using (var fypEntities = new FYPEntities())
            {
                long uId = FYPSession.GetLoggedUser().UserId;
                string dstatus = txtStatusComment.Text;
                string url = Session[FilePath].ToString();
                fypEntities.SP_SubmitDocumentByPcMemberAfterCheck(_umsId, url, dstatus, _umsdId, uId);
                PopulateGridForDocs();
                //FYPMessage.ShowPopUpMessage("Success",new List<string>(){"Document Submitted to Admin Successfully"},this.Page,true );
                FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Document Submitted to Admin Successfully" }, this.Page, true);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtStatusComment.Text = string.Empty;
        }

        protected void GvdViewAllDocsSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GvdViewAllDocs.SelectedRow;
            DataKey dk = GvdViewAllDocs.DataKeys[gr.RowIndex];
            if (dk != null && dk.Values != null)
            {
                lblMilestoneName.Text = dk.Values["MileStoneName"].ToString();
                lblProjectName.Text = dk.Values["Tiltle"].ToString();
            }
            FYPMessage.ShowBootStrapPopUp("UploadDoc", this.Page, true);
        }
    }
}