﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

using FYPAutomation.App_Start;
using FYPDAL;

using FYPUtilities;
using LinkButton = System.Web.UI.WebControls.LinkButton;


namespace FYPAutomation.UserControls
{
    public partial class CtrlProjectDetail :  FYPBaseUserControl
    {
        private readonly string _projectDoc = ConfigurationManager.AppSettings["AllUploads"] + "ProjectDescription\\";
        private const string ProjectDocUrl = "/ProjectDescription/";
        private const string FilePath = "filePath";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectDetail();
            }
        }

        private void PopulateProjectDetail()
        {
            int pId = Convert.ToInt32(Request.QueryString["PId"]);
            using (var fypEntities = new FYPEntities())
            {
                var project = fypEntities.Projects.Where(pro => pro.PId == pId).ToList();
                FVProjectDetail.DataSource = project;
                FVProjectDetail.DataBind();
            }
        }

        protected void FvProjectDetailModeChanging(object sender, FormViewModeEventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["PId"]);
            if (e.CancelingEdit)
            {
                FVProjectDetail.ChangeMode(FormViewMode.ReadOnly);
                PopulateProjectDetail();
                return;
            }
            FVProjectDetail.ChangeMode(FormViewMode.Edit);

            using (var fypEntities = new FYPEntities())
            {
                var project = fypEntities.Projects.Where(pro => pro.PId == pid).ToList();
                FVProjectDetail.DataSource = project;
                FVProjectDetail.DataBind();
                if (FVProjectDetail.Controls.Count > 0)
                {
                    var drpStatus = FVProjectDetail.Row.FindControl("ddlStatus") as DropDownList;
                    var drpPropose = FVProjectDetail.Row.FindControl("ddlProposedBy") as DropDownList;
                    var drpComplexity = FVProjectDetail.Row.FindControl("ddlComplexity") as DropDownList;
                    if (drpStatus != null)
                    {
                        drpStatus.SelectedIndex =
                            drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(project[0].Status.ToString()));

                    }
                    if (drpPropose != null)
                        drpPropose.SelectedIndex =
                            drpPropose.Items.IndexOf(drpPropose.Items.FindByValue(project[0].ProposedBy.ToString()));
                    if (drpComplexity != null)
                        drpComplexity.SelectedIndex =
                          drpComplexity.Items.IndexOf(drpComplexity.Items.FindByValue(project[0].Complexity.ToString()));

                }
            }


        }
        protected void BindStatuses(object sender, EventArgs e)
        {
            if (sender is DropDownList)
            {
                var drpStatuses = sender as DropDownList;
                drpStatuses.Items.Insert(0, "Select Status");
            }
        }
        protected void BindProposeBy(object sender, EventArgs e)
        {
            if (sender is DropDownList)
            {
                var drpProposedBy = sender as DropDownList;
                drpProposedBy.Items.Insert(0, "Select Proposed By");
            }
        }
        
        protected void BindComplexities(object sender, EventArgs e)
        {
            if (sender is DropDownList)
            {
                var drpComplexities = sender as DropDownList;
                drpComplexities.Items.Insert(0, "Select Complexity");
            }
        }
       

        protected void FvProjectDetailItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["PId"]);
            using (var fypEntities = new FYPEntities())
            {
                var project = fypEntities.Projects.FirstOrDefault(pro => pro.PId == pid);
                if (project != null)
                {
                    var tiltleTextBox = FVProjectDetail.Row.FindControl("TiltleTextBox") as TextBox;
                    var descriptionTextBox = FVProjectDetail.Row.FindControl("DescriptionTextBox") as TextBox;
                    var ddlStatus = FVProjectDetail.Row.FindControl("ddlStatus") as DropDownList;
                    var ddlProposedBy = FVProjectDetail.Row.FindControl("ddlProposedBy") as DropDownList;
                    var keyFeaturesTextBox = FVProjectDetail.Row.FindControl("KeyFeaturesTextBox") as TextBox;
                    var ddlComplexity = FVProjectDetail.Row.FindControl("ddlComplexity") as DropDownList;
                    var effortsRequiredTextBox = FVProjectDetail.Row.FindControl("EffortsRequiredTextBox") as TextBox;
                    var domainTextBox = FVProjectDetail.Row.FindControl("DomainTextBox") as TextBox;
                    var requiredToolsAndTechTextBox =
                        FVProjectDetail.Row.FindControl("RequiredToolsAndTechTextBox") as TextBox;
                    var specialCharactersRequiredTextBox =
                        FVProjectDetail.Row.FindControl("SpecialCharactersRequiredTextBox") as TextBox;


                    if (Session[FilePath] != null) project.UploadedFile = Session[FilePath].ToString();
                    if (tiltleTextBox != null) project.Tiltle = tiltleTextBox.Text;
                    if (descriptionTextBox != null) project.Description = descriptionTextBox.Text;
                    if (ddlStatus != null) project.Status = Convert.ToInt16(ddlStatus.SelectedValue);
                    if (ddlProposedBy != null) project.ProposedBy = Convert.ToInt64(ddlProposedBy.SelectedValue);
                    if (keyFeaturesTextBox != null) project.KeyFeatures = keyFeaturesTextBox.Text;
                    if (ddlComplexity != null) project.Complexity = Convert.ToInt16(ddlComplexity.SelectedValue);
                    if (effortsRequiredTextBox != null) project.EffortsRequired = effortsRequiredTextBox.Text;
                    if (domainTextBox != null) project.Domain = domainTextBox.Text;
                    if (requiredToolsAndTechTextBox != null)
                        project.RequiredToolsAndTech = requiredToolsAndTechTextBox.Text;
                    if (specialCharactersRequiredTextBox != null)
                        project.SpecialCharactersRequired = specialCharactersRequiredTextBox.Text;
                    if (fypEntities.SaveChanges() > 0)
                    {
                       // X.Msg.Alert("Updated Successfully", "Project Details Updated Successfully").Show();
                        FVProjectDetail.ChangeMode(FormViewMode.ReadOnly);
                        PopulateProjectDetail();
                    }
                    else
                    {
                        // X.Msg.Alert("Updation Failed", "Project Details Updation Failed! Contact Administrator For Assistance").Show();
                    }
                       
                }
                else
                {
                    // X.Msg.Alert("Updation Failed", "Project Details Updation Failed! Contact Administrator For Assistance").Show();
                }
                   
            }

        }

        protected void FvProjectDetailDataBound(object sender, EventArgs e)
        {
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() != "admin")
            {
                var linkButton = FVProjectDetail.FindControl("EditButton") as LinkButton;
                var linkButtonAssign = FVProjectDetail.FindControl("lnkAssign") as LinkButton;
                if (linkButton != null && linkButtonAssign!=null)
                {
                    linkButtonAssign.Visible = false;
                    linkButton.Visible = false;
                }
            }
        }

        protected void AfuProjectDocUploaderUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {

                string uniqueStr = FYPDate.UniqueStringFromDate() + e.FileName;
                string saveAs = _projectDoc + uniqueStr;
                string savedUrl = ProjectDocUrl + uniqueStr;
                if (!Directory.Exists(_projectDoc))
                {
                    Directory.CreateDirectory(_projectDoc);
                }
                var ajaxFileUpload = sender as AjaxFileUpload;
                if (ajaxFileUpload != null) ajaxFileUpload.SaveAs(saveAs);
                Session[FilePath] = savedUrl;

            }
            catch (Exception)
            {


            }
        }

        protected void LnkAssignThisProject(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(Request.QueryString["PId"]);
            Response.Redirect(string.Format("~/Pages/Admin/AssignProject.aspx?PId=" + pId ));
        }
    }
}