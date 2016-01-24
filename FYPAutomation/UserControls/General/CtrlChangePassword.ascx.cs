using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
namespace FYPAutomation.UserControls.General
{
    public partial class CtrlChangePassword : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!FYPUtilities.FYPSession.IsUserLoggedIn())
            {
                FYPUtilities.FYPMessage.RedirectToUrl("~/Page/Login.aspx?cmd=logout", true, this.Page); 
            }
        }

        protected void SubmitChangePwd(object sender, EventArgs e)
        {
            using (var fypEntites=new FYPEntities())
            {
                string currentPwd=string.Empty;
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var user = fypEntites.Users.FirstOrDefault(usr => usr.UId == uId);
                if (user != null)
                {
                    currentPwd = user.Password;
                }
                if(FYPUtilities.FYPPasswordManager.Decrypt(currentPwd)!=txtCurrentPwd.Text)
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Please enter current password correctly" }, this.Page, true);
                }
                else
                {
                    if(txtNewPwd.Text==txtConfirmPwd.Text)
                    {
                        if (user != null) user.Password = FYPUtilities.FYPPasswordManager.Encrypt(txtNewPwd.Text);
                        if(fypEntites.SaveChanges()>0)
                        {
                            FYPUtilities.FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/Login.aspx?cmd=logout"), true, this.Page);
                            FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Password Changed Successfully" }, this.Page, true);
                        }
                    }
                }
            }
        }
    }
}