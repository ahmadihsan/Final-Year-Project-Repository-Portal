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
    public partial class CtrlStudentDetail : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDetailOfStudent();
            }
        }

        private void PopulateDetailOfStudent()
        {
            using (var fypEntities=new FYPEntities())
            {
                int userId = int.Parse(Request.QueryString["UId"]);
                var user = fypEntities.Users.Where(std => std.UId == userId).ToList();
                FVStudentDetail.DataSource = user;
                FVStudentDetail.DataBind();
            }
        }

        protected void FvStudentDetailModeChanging(object sender, FormViewModeEventArgs e)
        {
            if(e.CancelingEdit)
            {
                FVStudentDetail.ChangeMode(FormViewMode.ReadOnly);
                PopulateDetailOfStudent();
                lblMessage.Visible = false;
                return;
            }
            FVStudentDetail.ChangeMode(FormViewMode.Edit);
            int fId = int.Parse(Request.QueryString["UId"]);
            using (var fypEntities=new FYPEntities())
            {
                var user = fypEntities.Users.Where(std => std.UId == fId).ToList();
                FVStudentDetail.DataSource = user;
                FVStudentDetail.DataBind();
                if(user.Count != 0)
                {
                  var ddlDep = FVStudentDetail.Row.FindControl("ddlDep") as DropDownList;
                  if (ddlDep != null)
                      ddlDep.SelectedIndex = ddlDep.Items.IndexOf(ddlDep.Items.FindByValue(user[0].DepartmentId.ToString()));
                  var ddlStatus = FVStudentDetail.Row.FindControl("ddlStatus") as DropDownList;
                  if (ddlStatus != null)
                      ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(FrequentAccesses.Get10FromBoolean(user[0].Status)));
                  var ddlSemester = FVStudentDetail.Row.FindControl("ddlSemester") as DropDownList;
                  if (ddlSemester != null)
                      ddlSemester.SelectedIndex = ddlSemester.Items.IndexOf(ddlSemester.Items.FindByValue(user[0].Semester.ToString()));
                  var ddlSession = FVStudentDetail.Row.FindControl("ddlPSession") as DropDownList;
                  if (ddlSession != null)
                      ddlSession.SelectedIndex = ddlSession.Items.IndexOf(ddlSession.Items.FindByValue(user[0].ProjectSessionId.ToString()));
                }
            }
        }

        protected void BoundDepartments(object sender, EventArgs e)
        {
            var ddlDep = sender as DropDownList;
            if (ddlDep != null) ddlDep.Items.Insert(0, "Select Department");
        }

        protected void FvStudentDetailItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            var uId = Convert.ToInt32(Request.QueryString["Uid"]);
            using (var fypEntities = new FYPEntities())
            {
                User user = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
                if (user != null)
                {
                    var nameTextBox = FVStudentDetail.Row.FindControl("NameTextBox") as TextBox;
                    var emailTextBox = FVStudentDetail.Row.FindControl("EmailTextBox") as TextBox;
                    var txtRegNum = FVStudentDetail.Row.FindControl("RegistrationNoTextBox") as TextBox;
                    var txtMobile = FVStudentDetail.Row.FindControl("txtMobile") as NumericBox;
                    var ddlDep = FVStudentDetail.Row.FindControl("ddlDep") as DropDownList;
                    var ddlStatus = FVStudentDetail.Row.FindControl("ddlStatus") as DropDownList;
                    var ddlSemester = FVStudentDetail.Row.FindControl("ddlSemester") as DropDownList;
                    var ddlPSession = FVStudentDetail.Row.FindControl("ddlPSession") as DropDownList;


                    if (nameTextBox != null) user.Name = nameTextBox.Text;
                    if (emailTextBox != null) user.Email = emailTextBox.Text;
                    if (txtRegNum != null) user.RegistrationNo = txtRegNum.Text;
                    if (txtMobile != null) user.MobileNumber = txtMobile.Text;
                    if (ddlDep != null) user.DepartmentId = Convert.ToInt32(ddlDep.SelectedValue.ToString());
                    if (ddlSemester != null) user.Semester = Convert.ToInt16(ddlSemester.SelectedValue.ToString());
                    if (ddlPSession != null) user.ProjectSessionId = Convert.ToInt64(ddlPSession.SelectedValue.ToString());
                    if (ddlStatus != null) user.Status = FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(ddlStatus.SelectedValue));
                    int test = fypEntities.SaveChanges();
                    if (test > 0)
                    {
                        FVStudentDetail.ChangeMode(FormViewMode.ReadOnly);
                        PopulateDetailOfStudent();
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Student Details Updated Successfully" }, this.Page, true);
                        //FYPMessage.ShowMessage(ref lblMessage, true, "Student Details Updated Successfully");
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Student Details Updation Failed!" }, this.Page, true);
                        //FYPMessage.ShowMessage(ref lblMessage, true, "Student Details Updation Failed!");
                    }
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Failed", new List<string>() { "Student Details Updation Failed!" }, this.Page, true);
                    //FYPMessage.ShowMessage(ref lblMessage, true, "Student Details Updation Failed!");
                }
                   
            }
        }

        protected void FvStudentDetailDataBound(object sender, EventArgs e)
        {
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "admin" && FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "convener")
            {
                var linkButton = FVStudentDetail.FindControl("EditButton") as LinkButton;
                if (linkButton != null)
                    linkButton.Visible = false;
            }
        }

        protected void BoundSemester(object sender, EventArgs e)
        {
            var ddlSemester = sender as DropDownList;
            if (ddlSemester != null) ddlSemester.Items.Insert(0,"Select Semester");
        }
        protected void BoundStatus(object sender, EventArgs e)
        {
            var ddlStatus = sender as DropDownList;
            if (ddlStatus != null) ddlStatus.Items.Insert(0, "Select Status");
        }

        protected void BoundSession(object sender, EventArgs e)
        {
            var ddlStatus = sender as DropDownList;
            if (ddlStatus != null) ddlStatus.Items.Insert(0, "Select Session");
        }
    }
}