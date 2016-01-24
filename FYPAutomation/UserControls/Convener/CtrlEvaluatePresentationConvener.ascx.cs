using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Convener
{
    public partial class CtrlEvaluatePresentationConvener : System.Web.UI.UserControl
    {
        private long _pid;
        private long _Status;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    if (!string.IsNullOrWhiteSpace(hfEvaludateClicked.Value) && hfEvaludateClicked.Value != "0")
            //    {
            //        CreateControls(Convert.ToInt64(hfEvaludateClicked.Value));
                    
            //    }
            //}
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

      


        private void PopulateGrid()
        {
            long uid = FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
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
                _pid = Convert.ToInt64(dk.Values["ProjectId"]);
                _Status = Convert.ToInt64(dk.Values["EvalStatus"]);
                ViewState["pId"] = _pid;
            }

            if (_pid > 0)
            {
                if(_Status == 0)
                {
                    if (ddlEvalType.SelectedValue == "Select Evaluation Type")
                    {
                        FYPMessage.ShowMessageAndHidePopup("Notice!", new List<string>() { "Please Select Evaluation type!" }, this.Page, true);
                    }
                    else
                    {
                        if (FYPSession.GetLoggedUser().RoleName == "Convener" && ddlEvalType.SelectedValue == "Grouped")
                        {
                            long uid = FYPSession.GetLoggedUser().UserId;
                            using (var fyp = new FYPEntities())
                            {
                                var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                            where dc.InCustody == uid
                                            select new
                                            {

                                                dc.MileStoneName,

                                            }).ToList();
                                string d = data.FirstOrDefault().MileStoneName;
                                Response.Redirect("~/Pages/Convener/EvaluateDocumentConvener.aspx?PId=" + _pid + "&MileName=" + d);
                            }
                        }
                        else if (FYPSession.GetLoggedUser().RoleName == "Convener" && ddlEvalType.SelectedValue == "Individual")
                        {
                            long uid = FYPSession.GetLoggedUser().UserId;
                            using (var fyp = new FYPEntities())
                            {
                                var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                            where dc.InCustody == uid
                                            select new
                                            {

                                                dc.MileStoneName,

                                            }).ToList();
                                string d = data.Max().MileStoneName;
                                Response.Redirect(string.Format("~/Pages/Convener/EvalDocConIndi.aspx?PId={0}&MileName={1}", _pid, d));
                            }
                        }
                    }
                }
                else if (_Status == 1)
                {
                    string pname = string.Empty;
                    if (FYPSession.GetLoggedUser().RoleName == "Convener" && ddlEvalType.SelectedValue == "Grouped")
                    {
                        long uid = FYPSession.GetLoggedUser().UserId;
                        using (var fyp = new FYPEntities())
                        {
                            var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                        where dc.InCustody == uid
                                        select new
                                        {

                                            dc.MileStoneName,

                                        }).ToList();
                            string d = data.FirstOrDefault().MileStoneName;
                             pname = fyp.Projects.Where(p => p.PId == _pid).FirstOrDefault().Tiltle;
                            Response.Redirect("~/Pages/Convener/UpdateDocEvalCon.aspx?project=" + pname + "&Doc=" + d);
                        }
                    }
                    else if (FYPSession.GetLoggedUser().RoleName == "Convener" && ddlEvalType.SelectedValue == "Individual")
                    {
                        long uid = FYPSession.GetLoggedUser().UserId;
                        using (var fyp = new FYPEntities())
                        {
                            var data = (from dc in fyp.SP_GetAssignedDocumentsForGrid(0, 0)
                                        where dc.InCustody == uid
                                        select new
                                        {

                                            dc.MileStoneName,

                                        }).ToList();
                            string d = data.Max().MileStoneName;
                            pname = fyp.Projects.Where(p => p.PId == _pid).FirstOrDefault().Tiltle;
                            Response.Redirect(string.Format("~/Pages/Convener/UpdateDocEvalCon.aspx?project={0}&Doc={1}", pname, d));
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