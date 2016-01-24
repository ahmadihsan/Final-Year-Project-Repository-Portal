using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using eWorld.UI;
using LinkButton = System.Web.UI.WebControls.LinkButton;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlExternalDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDetailOfExternal();
                PopulateExternalGroupName();
            }
        }
        private void PopulateExternalGroupName()
        {
            using (var fypEntities = new FYPEntities())
            {
                long id = Convert.ToInt32(Request.QueryString["UId"].ToString());
                var result = fypEntities.SP_GetNamesOfExternalGroupMember(id).ToList();
                var userName = fypEntities.Users.FirstOrDefault(fac => fac.UId == id);
                if (result != null)
                {
                    foreach (var res in result)
                    {
                        if (res.Name != userName.Name)
                        {
                            OtherMembers.Text += res.Name + "<br/>";
                        }
                    }
                }
                else
                {
                    OtherMembers.Text = userName.Name + " have no group members!";
                }
            }
        }
        private void PopulateDetailOfExternal()
        {
            using (var fypEntities = new FYPEntities())
            {
                int userId = int.Parse(Request.QueryString["UId"]);
                var user = fypEntities.Users.Where(std => std.UId == userId).ToList();
                FVExternalDetail.DataSource = user;
                FVExternalDetail.DataBind();
            }
        }
        
        protected void ddlStatus_DataBound(object sender, EventArgs e)
        {
            var ddlStatus = sender as DropDownList;
            if (ddlStatus != null) ddlStatus.Items.Insert(0, "Select Status");
        }
        protected void FVExternalDetail_ModeChanging1(object sender, FormViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                FVExternalDetail.ChangeMode(FormViewMode.ReadOnly);
                PopulateDetailOfExternal();
                lblMessage.Visible = false;
                return;
            }
            FVExternalDetail.ChangeMode(FormViewMode.Edit);
            int eId = int.Parse(Request.QueryString["UId"]);
            using (var fypEntities = new FYPEntities())
            {
                var user = fypEntities.Users.Where(std => std.UId == eId).ToList();
                FVExternalDetail.DataSource = user;
                FVExternalDetail.DataBind();
                if (user.Count != 0)
                {
                    var ddlStatus = FVExternalDetail.Row.FindControl("ddlStatus") as DropDownList;
                    if (ddlStatus != null)
                        ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(FrequentAccesses.Get10FromBoolean(user[0].Status)));
                }
            }
        }

        protected void FVExternalDetail_DataBound1(object sender, EventArgs e)
        {
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "admin" && FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "convener")
            {
                var linkButton = FVExternalDetail.FindControl("EditButton") as LinkButton;
                if (linkButton != null)
                    linkButton.Visible = false;
            }
        }

        protected void FVExternalDetail_ItemUpdating1(object sender, FormViewUpdateEventArgs e)
        {
           
            var uId = Convert.ToInt32(Request.QueryString["Uid"]);
            using (var fypEntities = new FYPEntities())
            {
                User user = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
                if (user != null)
                {
                    var nameTextBox = FVExternalDetail.Row.FindControl("NameTextBox") as TextBox;
                    var emailTextBox = FVExternalDetail.Row.FindControl("EmailTextBox") as TextBox;
                    var txtCnic = FVExternalDetail.Row.FindControl("txtcnic") as NumericBox;
                    var txtSpe = FVExternalDetail.Row.FindControl("txtSpecial") as TextBox;
                    var txtMobile = FVExternalDetail.Row.FindControl("txtMobile") as NumericBox;
                    var txtOffic = FVExternalDetail.Row.FindControl("txtExt") as NumericBox;
                    var txtCont = FVExternalDetail.Row.FindControl("txtContAddres") as TextBox;
                    var ddlStatus = FVExternalDetail.Row.FindControl("ddlStatus") as DropDownList;
                   

                    if (nameTextBox != null) user.Name = nameTextBox.Text;
                    if (emailTextBox != null) user.Email = emailTextBox.Text;
                    if (txtCnic != null) user.E_CNIC = txtCnic.Text;
                    if (txtSpe != null) user.E_Specialization = txtSpe.Text;
                    if (txtMobile != null) user.MobileNumber = txtMobile.Text;
                    if (txtOffic != null) user.E_Office = txtOffic.Text;
                    if (txtCont != null) user.E_ContactAddresss = txtCont.Text;
                    if (ddlStatus != null && ddlStatus.SelectedIndex != 0) user.Status = FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(ddlStatus.SelectedValue));
                    
                    int test = fypEntities.SaveChanges();
                    if (test > 0)
                    {
                        FVExternalDetail.ChangeMode(FormViewMode.ReadOnly);
                        PopulateDetailOfExternal();
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "External Details Updated Successfully" }, this.Page, true);
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "External Details Updation Failed! Contact Administrator For Assistance" }, this.Page, true);

                    }
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "External Details Updation Failed! Contact Administrator For Assistance" }, this.Page, true);
                }

            }
        }
    }

}