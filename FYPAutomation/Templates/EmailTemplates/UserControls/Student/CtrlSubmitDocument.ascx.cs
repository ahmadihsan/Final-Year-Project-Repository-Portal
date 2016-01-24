using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlSubmitDocument : System.Web.UI.UserControl
    {
        public readonly string UploadDoc = ConfigurationManager.AppSettings["AllUploads"] + "\\StudentUploads\\";
        public readonly string UploadDocUrl = ConfigurationManager.AppSettings["AllUploadsUrl"];
        private const string ImageUrl = "/AllUserImages/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMileStones();
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

        protected void SumbitDocClick(object sender, EventArgs e)
        {
            using (var fypEntities=new FYPEntities())
            {
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                int msId = Convert.ToInt32(ddlMileStone.SelectedValue);
                fypEntities.SP_SubmitDocumentByStudent(msId, uId, Session[FilePath].ToString());
            }
        }

        protected void AsyUploadDocUploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                string uniqueStr = FYPUtilities.FYPDate.UniqueStringFromDate();
                string saveAs = UploadDoc + uniqueStr;
                string saveUrl = UploadDocUrl + uniqueStr;
                if (!Directory.Exists(UploadDoc))
                {
                    Directory.CreateDirectory(UploadDoc);
                }
                asyUploadDoc.SaveAs(saveAs);
                Session[FilePath] = saveUrl;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}