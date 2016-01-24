using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FYPDAL;
using FYPUtilities;


namespace FYPAutomation.UserControls
{
    public partial class CtrlLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (FYPSession.IsUserLoggedIn())
                        LoggedIn(FYPSession.GetLoggedUser());
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
                    int roleId = Convert.ToInt32(ddlRole.SelectedValue);
                    string pwd = FYPPasswordManager.Encrypt(txtPwd.Text);
                    //string pwd = txtPwd.Text;
                    var user =
                        fypEntities.Users.FirstOrDefault(usr =>usr.Email == txtEmail.Text && usr.Password == pwd && usr.RoleId == roleId);
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
                         
                        }
                    }
                }
            }
        }

        private void LoggedIn(FYPSession loggedUser)
        {
            if (loggedUser.RoleName.ToLower() == "admin")
            {
                Response.Redirect("~/Pages/Admin/Default.aspx");
            }
            else if (loggedUser.RoleName.ToLower() == "convener")
            {
                Response.Redirect("~/Pages/Convener/Default.aspx");
            }
            else if (loggedUser.RoleName.ToLower() == "student")
            {
                Response.Redirect("~/Pages/Student/Default.aspx");
            }
        }
    }
}