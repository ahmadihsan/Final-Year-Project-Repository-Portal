﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Faculty
{
    public partial class CtrlEvaluatePresentationFac : System.Web.UI.UserControl
    {
        private long _pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(hfEvaludateClicked.Value) && hfEvaludateClicked.Value != "0")
                {
                    CreateControls(Convert.ToInt64(hfEvaludateClicked.Value));
                }
            }
            if (!IsPostBack)
            {

                PopulateDropList();
                PopulateGrid();
               
                hfEvaludateClicked.Value = "0";
            }
        }

        private void PopulateDropList()
        {
            ddlEvalType.Items.Insert(0, "Select Evaluation Type");
            ddlEvalType.Items.Insert(1, "Individual");
            ddlEvalType.Items.Insert(1, "Grouped");
        }

       

        private void ClearFields(IEnumerable<TextBox> lst)
        {
            foreach (var textBox in lst)
            {
                textBox.Text = string.Empty;
            }
            txtByProjectName.Text = string.Empty;
            ddlMileStone.SelectedIndex = 0;
        }

        private bool CreateControls(long pId)
        {
            bool studentExists = false;
            using (var fyp = new FYPEntities())
            {
                var lstStudents = fyp.SP_GetProjectStudentsWithId(pId).ToList();
                studentExists = lstStudents.Count != 0;
                for (int i = 0; i < lstStudents.Count; i++)
                {
                    var tr = new TableRow();
                    if (i == 0)
                    {
                        tr.Attributes.CssStyle.Add("border-top", "1px solid #C1DAD7");
                    }
                    var tc1 = new TableCell();
                    var tc2 = new TableCell();
                    var lblName = new Label { ID = "lblName" + i, Text = lstStudents[i].Name, };
                    var txtComment = new TextBox { ID = "txtComment" + lstStudents[i].UId, TextMode = TextBoxMode.MultiLine, Width = 350 };
                    txtComment.Attributes.Add("style", "resize:none");
                    txtComment.Width = 800;
                    txtComment.Height = 100;
                    tc1.Controls.Add(lblName);
                    tc2.Controls.Add(txtComment);
                    tr.Cells.Add(tc1);
                    tr.Cells.Add(tc2);
                    tblStudents.Rows.Add(tr);
                }
                var trPro = new TableRow();
                var tc1Pro = new TableCell();
                var tc2Pro = new TableCell();
                tc1Pro.Controls.Add(new Label() { Text = "About Project" });
                var txtCommentProj = new TextBox
                {
                    ID = "txtCommentProj",
                    TextMode = TextBoxMode.MultiLine,
                    Width = 800,
                    Height = 100
                };
                tc2Pro.Controls.Add(txtCommentProj);
                trPro.Cells.Add(tc1Pro);
                trPro.Cells.Add(tc2Pro);
                tblStudents.Rows.Add(trPro);
            }
            return studentExists;

        }


        private void PopulateGrid()
        {
            long uid = FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
               
                var data = (from proc in fyp.Projects
                            join supervisor in fyp.Users
                            on proc.ProposedBy equals supervisor.UId
                            where proc.Status == 2 && proc.ProposedBy == uid
                            select new { 
                                proc.Tiltle,
                                supervisor.Name,
                                proc.PId  
                            }).ToList();
                GvdViewAllDocs.DataSource = data;
                GvdViewAllDocs.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtByProjectName.Text;
                GvdViewAllDocs.DataSource =
                    fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName) && std.Status == 2).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        protected void GvdViewAllDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            DataKey dk = GvdViewAllDocs.DataKeys[GvdViewAllDocs.SelectedRow.RowIndex];
            if (dk != null && dk.Values != null)
            {
                _pid = Convert.ToInt64(dk.Values["PId"]);
                ViewState["pId"] = _pid;
                using (var fyp = new FYPEntities())
                {
                    var noOfStudente = fyp.SP_GetProjectStudentsWithReg(_pid).ToList();
                    foreach (var item in noOfStudente)
                    {
                        i++;
                    }
                }
            }

            if (_pid > 0)
            {
                if (ddlEvalType.SelectedValue == "Select Evaluation Type")
                {
                    FYPMessage.ShowMessageAndHidePopup("Notice!", new List<string>() { "Please Select Evaluation type!" }, this.Page, true);
                }
                else
                {
                     
                         if (FYPSession.GetLoggedUser().RoleName == "Faculty" && ddlEvalType.SelectedValue == "Grouped")
                         {
                             long uid = FYPSession.GetLoggedUser().UserId;
                             using (var fyp = new FYPEntities())
                             {
                                 var data = (from proc in fyp.Projects
                                             join supervisor in fyp.Users
                                             on proc.ProposedBy equals supervisor.UId
                                             join custody in fyp.UploadedMileStoneDocs
                                             on supervisor.UId equals custody.InCustody
                                             join ums in fyp.UploadedMileStones
                                             on custody.UMSId equals ums.UMSId
                                             join milename in fyp.ProjectMileStones
                                             on ums.PMSId equals milename.PMSId
                                             where proc.Status == 2 && proc.ProposedBy == uid && custody.InCustody == uid
                                             select new
                                             {
                                                 proc.Tiltle,
                                                 supervisor.Name,
                                                 proc.PId,
                                                 MileStoneName = milename.Name
                                             }).ToList();
                                 string d = data.FirstOrDefault().MileStoneName;
                                 Response.Redirect("~/Pages/Faculty/EvaluateDocumentFac.aspx?PId=" + _pid + "&MileName=" + d);
                             }

                             
                         }
                         else if (FYPSession.GetLoggedUser().RoleName == "Faculty" && ddlEvalType.SelectedValue == "Individual")
                         {
                             long uid = FYPSession.GetLoggedUser().UserId;
                             using (var fyp = new FYPEntities())
                             {
                                 var data = (from proc in fyp.Projects
                                             join supervisor in fyp.Users
                                             on proc.ProposedBy equals supervisor.UId
                                             join custody in fyp.UploadedMileStoneDocs
                                             on supervisor.UId equals custody.InCustody
                                             join ums in fyp.UploadedMileStones
                                             on custody.UMSId equals ums.UMSId
                                             join milename in fyp.ProjectMileStones
                                             on ums.PMSId equals milename.PMSId
                                             where proc.Status == 2 && proc.ProposedBy == uid && custody.InCustody == uid
                                             select new
                                             {
                                                 proc.Tiltle,
                                                 supervisor.Name,
                                                 proc.PId,
                                                 MileStoneName = milename.Name
                                             }).ToList();
                                 if (data != null)
                                 {
                                     string d = data.FirstOrDefault().MileStoneName;
                                     Response.Redirect("~/Pages/Faculty/EvalDocFacIndi.aspx?PId=" + _pid + "&MileName=" + d);
                                 }
                                 else
                                 {

                                 }
                             }
                         }
                     
                }
            }
        }



        protected void SubmitComments_Click(object sender, EventArgs e)
        {
            var lstb = new List<TextBox>();
            if (_pid < 0 && hfEvaludateClicked.Value == "1")
            {
                FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Project Could't be selected properly" }, this.Page, true);
                return;
            }

            using (var fyp = new FYPEntities())
            {
                if (ViewState["pId"] != null)
                {
                    long pid = Convert.ToInt64(ViewState["pId"]);
                    var lstStudents = fyp.SP_GetProjectStudentsWithId(pid).ToList();
                    var lstMse = new List<MileStoneEvaluation>();
                    var txtboxProj = this.tblStudents.FindControl("txtCommentProj") as TextBox;
                    foreach (var lstStd in lstStudents)
                    {
                        var txtbox = this.tblStudents.FindControl("txtComment" + lstStd.UId) as TextBox;
                        lstb.Add(txtbox);
                        if (txtbox != null)
                        {
                            var mse = new MileStoneEvaluation();
                            mse.ComentedDate = DateTime.Now;
                            mse.CommentByPC = txtbox.Text;
                            mse.CommentedBy = FYPSession.GetLoggedUser().UserId;
                            mse.StudentId = lstStd.UId;
                            mse.PMSId = Convert.ToInt32(ddlMileStone.SelectedValue);
                            mse.ProjectId = pid;
                            if (txtboxProj != null) mse.CommentByPcAboutProject = txtboxProj.Text;
                            mse.IsVisibletToStudent = false;
                            lstMse.Add(mse);
                        }
                    }
                    lstb.Add(txtboxProj);
                    if (lstMse.Count != 0)
                    {
                        fyp.MileStoneEvaluations.AddRange(lstMse);
                        int check = fyp.SaveChanges();
                        if (check > 0)
                        {
                            FYPMessage.ShowMessageAndHidePopup("Success", new List<string>() { "Comments uploaded successfully" }, this.Page, true);
                            ViewState["pId"] = null;
                            hfEvaludateClicked.Value = "0";
                            ClearFields(lstb);
                            PopulateGrid();
                        }
                    }
                }
            }
        }

        protected void GvdViewAllDocs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            long projectId = -1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey dk = GvdViewAllDocs.DataKeys[e.Row.RowIndex];
                if (dk != null && dk.Values != null)
                {
                    projectId = Convert.ToInt64(dk.Values["PId"]);
                }
                var gvStudents = e.Row.FindControl("gdvStudents") as GridView;
                if (gvStudents != null && projectId > 0)
                {
                    using (var fypEntities = new FYPEntities())
                    {
                        gvStudents.DataSource = fypEntities.SP_GetProjectStudentsWithReg(projectId).ToList();
                        gvStudents.DataBind();
                    }
                }
            }
        }

       
    }
}