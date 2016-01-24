﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlEvaluatePresentation : FYPBaseUserControl
    {
        private long _pid;

        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["EvalSt"] != null)
                {
                    message = Request.QueryString["EvalSt"].ToString();
                }
                if (message == "1" || message == "True" )
                {
                    ddlEvalType.Enabled = false;
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Comments Added Successfully" }, this.Page, true);
                }
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

        //private bool CreateControls(long pId)
        //{
        //    bool studentExists = false;
        //    using (var fyp = new FYPEntities())
        //    {
        //        var lstStudents = fyp.SP_GetProjectStudentsWithId(pId).ToList();
        //        studentExists = lstStudents.Count != 0;
        //        for (int i = 0; i < lstStudents.Count; i++)
        //        {
        //            var tr = new TableRow();
        //            if (i == 0)
        //            {
        //                tr.Attributes.CssStyle.Add("border-top", "1px solid #C1DAD7");
        //            }
        //            var tc1 = new TableCell();
        //            var tc2 = new TableCell();
        //            var lblName = new Label { ID = "lblName" + i, Text = lstStudents[i].Name, };
        //            var txtComment = new TextBox { ID = "txtComment" + lstStudents[i].UId, TextMode = TextBoxMode.MultiLine, Width = 350 };
        //            txtComment.Attributes.Add("style", "resize:none");
        //            txtComment.Width = 800;
        //            txtComment.Height = 100;
        //            tc1.Controls.Add(lblName);
        //            tc2.Controls.Add(txtComment);
        //            tr.Cells.Add(tc1);
        //            tr.Cells.Add(tc2);
        //            tblStudents.Rows.Add(tr);
        //        }
        //        var trPro = new TableRow();
        //        var tc1Pro = new TableCell();
        //        var tc2Pro = new TableCell();
        //        tc1Pro.Controls.Add(new Label() { Text = "About Project" });
        //        var txtCommentProj = new TextBox
        //        {
        //            ID = "txtCommentProj",
        //            TextMode = TextBoxMode.MultiLine,
        //            Width = 800,
        //            Height = 100
        //        };
        //        tc2Pro.Controls.Add(txtCommentProj);
        //        trPro.Cells.Add(tc1Pro);
        //        trPro.Cells.Add(tc2Pro);
        //        tblStudents.Rows.Add(trPro);
        //    }
        //    return studentExists;

        //}


        private void PopulateGrid()
        {
            long uid = FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                long sid = fyp.ProjectSessions.Max(p => p.PSId);
                var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(sid, 0)
                            where dc.InCustody == uid 
                            select new
                            {
                                dc.ToAdmin,
                                dc.ReadStatus,
                                dc.InCustody,
                                dc.MileStoneName,
                                dc.Name,
                                dc.ProjectId,
                                dc.UId,
                                dc.UMSDId,
                                dc.UMSId,
                                dc.UploadedFile,
                                dc.Tiltle,
                                dc.SubmittedDate,
                                dc.StatusComment,
                                dc.PMSId,
                                dc.EvalStatus,
                                dc.FromStudent,
                                dc.FromPc
                            }).ToList();

                GvdViewAllDocs.DataSource = data;
                GvdViewAllDocs.DataBind();
               if(message == null)
               {
                   long umsd = 0;
                   
                   if (data.Count != 0)
                   {
                       ddlEvalType.Enabled = false;
                       umsd = data.FirstOrDefault().UMSId;

                       long umsid = fyp.UploadedMileStoneDocs.Where(p => p.UMSId == umsd && p.ToAdmin == null).FirstOrDefault().UMSDId;
                       Session[message] = fyp.UploadedMileStoneDocs.Where(q => q.UMSDId == umsid).FirstOrDefault().EvalStatus.ToString();
                   }
                   else
                   {
                       Session[message] = "false";
                   }
                    
               }
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
            
            DataKey dk = GvdViewAllDocs.DataKeys[GvdViewAllDocs.SelectedRow.RowIndex];
            if (dk != null && dk.Values != null)
            {
                _pid = Convert.ToInt64(dk.Values["ProjectId"]);
                ViewState["pId"] = _pid;
               
            }

            if (_pid > 0)
            {
                string pname = string.Empty;
                if (ddlEvalType.SelectedValue == "Select Evaluation Type" && message == "False" )
                {
                    FYPMessage.ShowMessageAndHidePopup("Notice!", new List<string>() { "Please Select Evaluation type!" }, this.Page, true);
                }
                else
                {
                    if(message == null)
                    {
                        message = Session[message].ToString(); 
                    }
                    if (message == "1" || message == "True")
                    {
                         long uid = FYPSession.GetLoggedUser().UserId;
                       
                        using (var fyp = new FYPEntities())
                        {
                            var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                        where dc.InCustody == uid
                                        select new
                                        {
                                            dc.MileStoneName
                                        });
                            pname = fyp.Projects.Where(p => p.PId == _pid).FirstOrDefault().Tiltle;
                            Response.Redirect("~/Pages/Admin/UpdateDocEvalAdmin.aspx?project=" + pname + "&Doc=" + data.FirstOrDefault().MileStoneName);
                        }
         
                    }
                    else if (FYPSession.GetLoggedUser().RoleName == "admin" && ddlEvalType.SelectedValue == "Grouped")
                    {
                        long uid = FYPSession.GetLoggedUser().UserId;
                        string evaltype = "Grouped";
                        using (var fyp = new FYPEntities())
                        {
                            var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                        where dc.InCustody == uid
                                        select new
                                        {
                                            dc.MileStoneName
                                        });
                            if (message == "0" || message == "False")
                            {
                                Response.Redirect("~/Pages/Admin/EvaluateDocument.aspx?PId=" + _pid + "&MileName=" + data.FirstOrDefault().MileStoneName + "&EvalType=" + evaltype);
                            }
                        }
                    }
                    else if(FYPSession.GetLoggedUser().RoleName == "admin" && ddlEvalType.SelectedValue == "Individual")
                    {
                        long uid = FYPSession.GetLoggedUser().UserId;
                        string evaltype = "Individual";
                        using (var fyp = new FYPEntities())
                        {
                            var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                        where dc.InCustody == uid
                                        select new
                                        {
                                            dc.MileStoneName
                                        });
                            if (message == "0" || message == "False")
                            {
                                Response.Redirect("~/Pages/Admin/EvalDocConIndiAdmin.aspx?PId=" + _pid + "&MileName=" + data.FirstOrDefault().MileStoneName + "&EvalType=" + evaltype);
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
                    projectId = Convert.ToInt64(dk.Values["ProjectId"]);
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