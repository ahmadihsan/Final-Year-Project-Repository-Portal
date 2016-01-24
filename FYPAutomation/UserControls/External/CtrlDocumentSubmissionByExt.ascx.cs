using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
namespace FYPAutomation.UserControls.General
{
    public partial class CtrlDocumentSubmissionByExt : System.Web.UI.UserControl
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByProjectName.Text;
                GvdViewAllDocs.DataSource =
                    fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName) && std.Status == 2).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        protected void GvdViewAllDocs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void asyUploadFile_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {

        }

        protected void btnSumbitDocByExt_Click(object sender, EventArgs e)
        {

        }
    }
}