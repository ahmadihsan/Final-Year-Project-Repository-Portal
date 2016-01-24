using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace FYPAutomation.UserControls
{
    public partial class CtrlLogin : System.Web.UI.UserControl
    {
        private readonly string _emailTemplate = ConfigurationManager.AppSettings["EmailTemplates"] + "PasswordReset.html";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (FYPSession.IsUserLoggedIn())
                    {
                        LoggedIn(FYPSession.GetLoggedUser());
                        LoggedInFac(FYPSession.GetLoggedUser());   
                    }

                }
                catch
                {
                    Response.Redirect("~/pages/login?cmd=logout");
                }

            }


        }

        protected void LoginClicked(object sender, EventArgs e)
        {
            this.Page.Validate("vgLogin");
           
            if (Page.IsValid)
            {
                using (var fypEntities = new FYPEntities())
                {

                    User user = null;
                    
                    string pwd = FYPPasswordManager.Encrypt(txtPwd.Text);
  
                    user = fypEntities.Users.FirstOrDefault(usr => (usr.RegistrationNo.Equals(txtEmail.Text)) && usr.Password.Equals(pwd));

                    

                    if (user != null)
                    {
                        var loggedUser = new FYPSession
                        {
                            UserId = user.UId,
                            Email = user.Email,
                            Name = user.Name,
                            RoleId = user.RoleId,
                            RoleName = user.Role.Name,
                            ResearchId = user.ResearchId

                        };
                        if (loggedUser.CreateSession())
                        {
                            LoggedIn(loggedUser);
                            //other users code will be here
                        }
                        else
                        {
                            FYPUtilities.FYPMessage.ShowPopUpMessage("Message", new List<string>() { "Message that User state could not be managed due to some error" }, this.Page, true);
                        }
                    }
                    else
                    {
                        FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Invalid User name or password" }, this.Page, true);
                    }
                }
            }
        }

        private void LoggedIn(FYPSession loggedUser)
        {
            if (loggedUser.RoleName.ToLower() == "student")
            {
                Response.Redirect("~/Pages/Student/Default.aspx");
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Invalid Login:", new List<string>() { "No user exist with provided Registration ID.\nGo to other Login Page." }, this.Page, true);
            }

        }

        private void LoggedInFac(FYPSession loggedFac)
        {
            if (loggedFac.RoleName.ToLower() == "faculty")
            {
                Response.Redirect("~/Pages/Faculty/Default.aspx");
            }
            else if (loggedFac.RoleName.ToLower() == "convener")
            {
                Response.Redirect("~/Pages/Convener/Default.aspx");
            }
            else if (loggedFac.RoleName.ToLower() == "pcmember")
            {
                Response.Redirect("~/Pages/PCMember/Default.aspx");
            }
            else if (loggedFac.RoleName.ToLower() == "external")
            {
                Response.Redirect("~/Pages/External/Default.aspx");
            }
            else if (loggedFac.RoleName.ToLower() == "admin")
            {
                Response.Redirect("~/Pages/Admin/Default.aspx");
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Invalid Login:", new List<string>() { "No user exist with provided email\nGo to other Login Page." }, this.Page, true);
            }
        }


        protected void BtnSubmitRestPwdClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                User usr = fyp.Users.FirstOrDefault(us => us.Email == txtResetEmail.Text);
                if (usr != null)
                {
                    string body = FYPEmailManager.PopulateBody(usr.Name, "www.ciitfyp.com", string.Format("Your Credentials for FYP Portal are given below : <br /><b>  User Name : {0} <br /> Password :{1}</b>", usr.Email, FYPPasswordManager.Decrypt(usr.Password)), _emailTemplate);
                    FYPEmailManager.SendHtmlFormattedEmail(usr.Email, "FYP Portal Password Reset", body);
                    lblMessage.Text = "An Email has been sent to you on your email.";
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error", new List<string>() { "No user exist with provided email" }, this.Page, true);
                }
            }

        }

        protected void LnkForgotPasswordClicked(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("forgotPwd", this.Page, true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            firstRow.Attributes.Add("rules", "all");
            firstRow.Attributes.Add("style", "border:1px solid #c1dad7");
            base.OnPreRender(e);
        }

        protected void btnLoginFac_Click(object sender, EventArgs e)
        {
            this.Page.Validate("vgLoginFac");
        
            if (Page.IsValid)
            {
                using (var fypEntities = new FYPEntities())
                {

                    User fac = null;

                    string pwdfac = FYPPasswordManager.Encrypt(txtBoxPwdFac.Text);

                    fac = fypEntities.Users.FirstOrDefault(usr => (usr.Email.Equals(txtboxEmailFac.Text)) && usr.Password.Equals(pwdfac));



                    if (fac != null)
                    {
                        var loggedFac = new FYPSession
                        {
                            UserId = fac.UId,
                            Email = fac.Email,
                            Name = fac.Name,
                            RoleId = fac.RoleId,
                            RoleName = fac.Role.Name,
                            ResearchId = fac.ResearchId

                        };
                        if (loggedFac.CreateSession())
                        {
                            LoggedInFac(loggedFac);
                        }
                        else
                        {
                            FYPUtilities.FYPMessage.ShowPopUpMessage("Message", new List<string>() { "Message that User state could not be managed due to some error" }, this.Page, true);
                        }
                    }
                    else
                    {
                        FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Invalid User name or password." }, this.Page, true);
                    }
                }
            }
        }
    }
}
 