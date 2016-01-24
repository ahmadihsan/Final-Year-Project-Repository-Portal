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

namespace FYPAutomation.UserControls
{
    public partial class CtrlFacultyDetail : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDetailOfFaculty();
            }
        }

        private void PopulateDetailOfFaculty()
        {
            using (var fypEntities=new FYPEntities())
            {
                int userId = int.Parse(Request.QueryString["UId"]);
                var user = fypEntities.Users.Where(std => std.UId == userId).ToList();
                FVFacultyDetail.DataSource = user;
                FVFacultyDetail.DataBind();
            }
        }

        protected void FvFacultyDetailModeChanging(object sender, FormViewModeEventArgs e)
        {
            if(e.CancelingEdit)
            {
                FVFacultyDetail.ChangeMode(FormViewMode.ReadOnly);
                PopulateDetailOfFaculty();
                lblMessage.Visible = false;
                return;
            }
            FVFacultyDetail.ChangeMode(FormViewMode.Edit);
            int fId = int.Parse(Request.QueryString["UId"]);
            using (var fypEntities=new FYPEntities())
            {
                var user = fypEntities.Users.Where(std => std.UId == fId).ToList();
                FVFacultyDetail.DataSource = user;
                FVFacultyDetail.DataBind();
                if(user.Count != 0)
                {
                  var ddlDesignation =  FVFacultyDetail.Row.FindControl("ddlDesignation") as DropDownList;
                  if (ddlDesignation != null)
                      ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(user[0].Designation));
                  var ddlRole = FVFacultyDetail.Row.FindControl("ddlRole") as DropDownList;
                  if (ddlRole != null)
                      ddlRole.SelectedIndex = ddlRole.Items.IndexOf(ddlRole.Items.FindByValue(user[0].RoleId.ToString()));
                  var ddlDep = FVFacultyDetail.Row.FindControl("ddlDep") as DropDownList;
                  if (ddlDep != null)
                      ddlDep.SelectedIndex = ddlDep.Items.IndexOf(ddlDep.Items.FindByValue(user[0].DepartmentId.ToString()));
                  var ddlRGroup = FVFacultyDetail.Row.FindControl("ddlResearchGroup") as DropDownList;
                  if (ddlRGroup != null)
                      ddlRGroup.SelectedIndex = ddlRGroup.Items.IndexOf(ddlRGroup.Items.FindByValue(user[0].ResearchId.ToString()));
                  var ddlStatus = FVFacultyDetail.Row.FindControl("ddlStatus") as DropDownList;
                  if (ddlStatus != null)
                      ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(FrequentAccesses.Get10FromBoolean(user[0].Status)));
                }
            }
        }

        protected void RoleBound(object sender, EventArgs e)
        {
            var ddlRole = sender as DropDownList;
            if (ddlRole != null) ddlRole.Items.Insert(0,"Select Role");
        }


        protected void BoundDepartments(object sender, EventArgs e)
        {
            var ddlDep = sender as DropDownList;
            if (ddlDep != null) ddlDep.Items.Insert(0, "Select Department");
        }

        protected void BoundResearchGroup(object sender, EventArgs e)
        {
            var ddlRGroup = sender as DropDownList;
            if (ddlRGroup != null) ddlRGroup.Items.Insert(0, "Select Research Group");
        }

        protected void BoundStatus(object sender, EventArgs e)
        {
            var ddlStatus = sender as DropDownList;
            if (ddlStatus != null) ddlStatus.Items.Insert(0, "Select Status");
        }

        protected void FvFacultyDetailItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            var uId = Convert.ToInt32(Request.QueryString["Uid"]);
            using (var fypEntities = new FYPEntities())
            {
                User user = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
                if (user != null)
                {
                    var nameTextBox = FVFacultyDetail.Row.FindControl("NameTextBox") as TextBox;
                    var emailTextBox = FVFacultyDetail.Row.FindControl("EmailTextBox") as TextBox;
                    var txtExt = FVFacultyDetail.Row.FindControl("txtExt") as NumericBox;
                    var txtMobile = FVFacultyDetail.Row.FindControl("txtMobile") as NumericBox;
                    var ddlDesignation = FVFacultyDetail.Row.FindControl("ddlDesignation") as DropDownList;
                    var ddlResearchGroup = FVFacultyDetail.Row.FindControl("ddlResearchGroup") as DropDownList;
                    var ddlDep = FVFacultyDetail.Row.FindControl("ddlDep") as DropDownList;
                    var ddlRole = FVFacultyDetail.Row.FindControl("ddlRole") as DropDownList;
                    var ddlStatus = FVFacultyDetail.Row.FindControl("ddlStatus") as DropDownList;

                    if (nameTextBox != null) user.Name = nameTextBox.Text;
                    if (emailTextBox != null) user.Email = emailTextBox.Text;
                    if (txtExt != null) user.CiitExtension = txtExt.Text;
                    if (txtMobile != null) user.MobileNumber = txtMobile.Text;
                    if (ddlDesignation != null && ddlDesignation.SelectedIndex!=0) user.Designation = ddlDesignation.SelectedValue;
                    if (ddlResearchGroup != null && ddlResearchGroup.SelectedIndex != 0)
                        user.ResearchId = Convert.ToInt32(ddlResearchGroup.SelectedValue.ToString());
                    if (ddlDep != null && ddlDep.SelectedIndex!=0) user.DepartmentId = Convert.ToInt32(ddlDep.SelectedValue.ToString());
                    if (ddlRole != null && ddlRole.SelectedIndex!=0) user.RoleId = Convert.ToInt16(ddlRole.SelectedValue.ToString());
                    if (ddlStatus != null && ddlStatus.SelectedIndex!=0) user.Status = FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(ddlStatus.SelectedValue));
                    int test = fypEntities.SaveChanges();
                    if (test > 0)
                    {
                        FVFacultyDetail.ChangeMode(FormViewMode.ReadOnly);
                        PopulateDetailOfFaculty();
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Faculty Details Updated Successfully" }, this.Page, true);
                        //FYPMessage.ShowMessage(ref lblMessage, true, "Faculty Details Updated Successfully");
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Faculty Details Updation Failed! Contact Administrator For Assistance" }, this.Page, true);
                        //FYPMessage.ShowMessage(ref lblMessage, false, "Faculty Details Updation Failed! Contact Administrator For Assistance");
                    }
                      
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Faculty Details Updation Failed! Contact Administrator For Assistance" }, this.Page, true);
                    //FYPMessage.ShowMessage(ref lblMessage, false, "Faculty Details Updation Failed! Contact Administrator For Assistance");
                }
                  
            }
        }

        protected void FvFacultyDetailDataBound(object sender, EventArgs e)
        {
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "admin" && FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "convener")
            {
                var linkButton = FVFacultyDetail.FindControl("EditButton") as LinkButton;
                if (linkButton != null)
                    linkButton.Visible = false;
            }
        }

        protected void BoundDesignation(object sender, EventArgs e)
        {
            var ddlDesig = sender as DropDownList;
            if (ddlDesig != null) ddlDesig.Items.Insert(0,"Select Designation");
        }
    }
}