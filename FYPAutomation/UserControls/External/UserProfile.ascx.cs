using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Configuration;
using FYPAutomation.App_Start;
using FYPDAL;
using eWorld.UI;

namespace FYPAutomation.UserControls.General
{
    public partial class UserProfile : System.Web.UI.UserControl
    {
        public readonly string UploadImage = ConfigurationManager.AppSettings["AllUploads"] + "\\AllUserImages\\";
        public readonly string UploadImageUrl = ConfigurationManager.AppSettings["AllUploadsUrl"];
        private const string ImageUrl = "/AllUserImages/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateUserInformation();
            }
        }
        private void PopulateUserInformation()
        {
            long uId;
            if (FYPUtilities.FYPQueryString.GetQueryString(Request.QueryString["UId"], out uId))
            {
                using (var fypEntities = new FYPEntities())
                {
                    var user = fypEntities.Users.Where(usr => usr.UId == uId).ToList();
                    if (user[0].RoleId ==8)
                    {
                        FVExternalProfile.Visible = true;
                        FVExternalProfile.DataSource = user;
                        FVExternalProfile.DataBind();
                    }
                    

                }
            }
        }

        protected void AsFImageFaculty_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {

        }

        protected void FVExternalProfile_DataBound(object sender, EventArgs e)
        {

        }

        protected void FVExternalProfile_ModeChanging(object sender, FormViewModeEventArgs e)
        {

        }

        protected void FVExternalProfile_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {

        }

        protected void ddlDesignation_DataBound(object sender, EventArgs e)
        {

        }
    }
}