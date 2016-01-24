using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

using FYPAutomation.App_Start;
using FYPDAL;
using eWorld.UI;
using LinkButton = System.Web.UI.WebControls.LinkButton;

namespace FYPAutomation.UserControls
{
    public partial class CtrlUserProfileMini : FYPBaseUserControl
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
                    if (user[0].RoleId == 1 || user[0].RoleId == 2 || user[0].RoleId == 3 || user[0].RoleId == 5)
                    {
                        //FVStudent.Visible = false;
                        FVFacProfile.Visible = true;
                        FVFacProfile.DataSource = user;
                        FVFacProfile.DataBind();
                    }
                    else if (user[0].RoleId == 4)
                    {
                        FVFacProfile.Visible = false;
                        //FVStudent.Visible = true;
                        //FVStudent.DataSource = user;
                        //FVStudent.DataBind();
                    }

                }
            }
        }

        //protected void FvFacProfileModeChanging(object sender, FormViewModeEventArgs e)
        //{
        //    if (e.CancelingEdit)
        //    {
        //        FVFacProfile.ChangeMode(FormViewMode.ReadOnly);
        //        PopulateUserInformation();
        //        return;
        //    }
        //    FVFacProfile.ChangeMode(FormViewMode.Edit);
        //    int fId = int.Parse(Request.QueryString["UId"]);
        //    using (var fypEntities = new FYPEntities())
        //    {
        //        var user = fypEntities.Users.Where(std => std.UId == fId).ToList();
        //        FVFacProfile.DataSource = user;
        //        FVFacProfile.DataBind();
        //        if (user.Count != 0)
        //        {
        //            var ddlDesignation = FVFacProfile.Row.FindControl("ddlDesignation") as DropDownList;
        //            if (ddlDesignation != null)
        //                ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(user[0].Designation));
                   
        //            var ddlRGroup = FVFacProfile.Row.FindControl("ddlResearchGroup") as DropDownList;
        //            if (ddlRGroup != null)
        //                ddlRGroup.SelectedIndex = ddlRGroup.Items.IndexOf(ddlRGroup.Items.FindByValue(user[0].ResearchId.ToString()));
        //        }
        //    }
        //}

        //protected void FvFacProfileItemUpdating(object sender, FormViewUpdateEventArgs e)
        //{
        //    var uId = Convert.ToInt32(Request.QueryString["Uid"]);
        //    using (var fypEntities = new FYPEntities())
        //    {
        //        User user = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
        //        if (user != null)
        //        {
        //            var nameTextBox = FVFacProfile.Row.FindControl("NameTextBox") as TextBox;
        //            var emailTextBox = FVFacProfile.Row.FindControl("EmailTextBox") as TextBox;
        //            var txtExt = FVFacProfile.Row.FindControl("txtExt") as NumericBox;
        //            var txtMobile = FVFacProfile.Row.FindControl("txtMobile") as NumericBox;
        //            var ddlDesignation = FVFacProfile.Row.FindControl("ddlDesignation") as DropDownList;
        //            var ddlResearchGroup = FVFacProfile.Row.FindControl("ddlResearchGroup") as DropDownList;

        //            if (Session[FilePath] != null) user.UploadImage = Session[FilePath].ToString();
        //            if (nameTextBox != null) user.Name = nameTextBox.Text;
        //            if (emailTextBox != null) user.Email = emailTextBox.Text;
        //            if (txtExt != null) user.CiitExtension = txtExt.Text;
        //            if (txtMobile != null) user.MobileNumber = txtMobile.Text;
        //            if (ddlDesignation != null) user.Designation = ddlDesignation.SelectedValue;
        //            if (ddlResearchGroup != null)
        //                user.ResearchId = Convert.ToInt32(ddlResearchGroup.SelectedValue.ToString());
                    

        //            if (fypEntities.SaveChanges() > 0)
        //            {
        //                FVFacProfile.ChangeMode(FormViewMode.ReadOnly);
        //                PopulateUserInformation();
        //               // X.Msg.Alert("Updated Successfully", "Information has been Updated Successfully").Show();
        //            }
        //            else
        //            {
        //                // X.Msg.Alert("Updation Failed","Information Updation Failed! Contact Administrator For Assistance").Show();
        //            }
                       
        //        }
        //        else
        //        {
        //            // X.Msg.Alert("Updation Failed", "Information Updation Failed! Contact Administrator For Assistance").Show();
        //        }
                   
        //    }
        //}

        //protected void BoundResearchGroup(object sender, EventArgs e)
        //{
        //    var ddlRGroup = sender as DropDownList;
        //    if (ddlRGroup != null) ddlRGroup.Items.Insert(0, "Select Research Group");
        //}

        //protected void FvFacProfileDataBound(object sender, EventArgs e)
        //{
        //    if(FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()!="admin")
        //    {
        //        var linkButton = FVFacProfile.FindControl("EditButton") as LinkButton;
        //        if (linkButton != null)
        //            linkButton.Visible = false;
        //    }
        //}

        //protected void BoundDesignation(object sender, EventArgs e)
        //{
        //    var ddlDesig = sender as DropDownList;
        //    if (ddlDesig != null) ddlDesig.Items.Insert(0, "Select Designation");
        //}

        //protected void AsFImageFacultyUploadedComplete(object sender, AsyncFileUploadEventArgs e)
        //{
        //    try
        //    {
        //        string uniqeString = FYPUtilities.FYPDate.UniqueStringFromDate()+e.FileName;
        //        string saveAs = UploadImage + uniqeString;
        //        string savedUrl = ImageUrl + uniqeString;
        //        if (!System.IO.Directory.Exists(UploadImage))
        //        {
        //            System.IO.Directory.CreateDirectory(UploadImage);
        //        }
        //        var ajaxFileUploader = sender as AsyncFileUpload;
        //        if (ajaxFileUploader != null) ajaxFileUploader.SaveAs(saveAs);
        //        Session[FilePath] = savedUrl;
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        ////================================profile of student======================================
        //protected void FvStudentProfileModeChanging(object sender, FormViewModeEventArgs e)
        //{
        //    if (e.CancelingEdit)
        //    {
        //        FVStudent.ChangeMode(FormViewMode.ReadOnly);
        //        PopulateUserInformation();
        //        return;
        //    }
        //    FVStudent.ChangeMode(FormViewMode.Edit);
        //    int fId = int.Parse(Request.QueryString["UId"]);
        //    using (var fypEntities = new FYPEntities())
        //    {
        //        var user = fypEntities.Users.Where(std => std.UId == fId).ToList();
        //        FVStudent.DataSource = user;
        //        FVStudent.DataBind();
        //    }
        //}

        //protected void FvStudentProfileItemUpdating(object sender, FormViewUpdateEventArgs e)
        //{
        //    var uId = Convert.ToInt32(Request.QueryString["Uid"]);
        //    using (var fypEntities = new FYPEntities())
        //    {
        //        User user = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
        //        if (user != null)
        //        {
        //            var nameTextBox = FVStudent.Row.FindControl("NameTextBox") as TextBox;
        //            var emailTextBox = FVStudent.Row.FindControl("EmailTextBox") as TextBox;
        //            var txtRegNum = FVStudent.Row.FindControl("RegistrationNoTextBox") as NumericBox;
        //            var txtMobile = FVStudent.Row.FindControl("txtMobile") as NumericBox;

        //            if (Session[FilePath] != null) user.UploadImage = Session[FilePath].ToString();
        //            if (nameTextBox != null) user.Name = nameTextBox.Text;
        //            if (emailTextBox != null) user.Email = emailTextBox.Text;
        //            if (txtRegNum != null) user.CiitExtension = txtRegNum.Text;
        //            if (txtMobile != null) user.MobileNumber = txtMobile.Text;

        //            if (fypEntities.SaveChanges() > 0)
        //            {
        //                FVStudent.ChangeMode(FormViewMode.ReadOnly);
        //                PopulateUserInformation();
        //               // X.Msg.Alert("Updated Successfully", "Student Details Updated Successfully").Show();
        //            }
        //            else
        //            {

        //                // X.Msg.Alert("Updation Failed","Student Details Updation Failed! Contact Administrator For Assistance").Show();
        //            }
        //        }
        //        else
        //        {
        //            // X.Msg.Alert("Updation Failed", "Student Details Updation Failed! Contact Administrator For Assistance").Show(); 
        //        }
                   
        //    }
        //}

        //protected void FvStudentProfileDataBound(object sender, EventArgs e)
        //{
        //    int uId = Convert.ToInt32(Request.QueryString["UId"]);
        //    if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "admin" && FYPUtilities.FYPSession.GetLoggedUser().UserId!=uId)
        //    {
        //        var linkButton = FVStudent.FindControl("EditButton") as LinkButton;
        //        if (linkButton != null)
        //            linkButton.Visible = false;
        //    }
        //}        
    }
}