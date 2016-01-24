using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.PCMembers
{
    public partial class CtrlPCMemberComments : FYPBaseUserControl
    {

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
                    var tc1 = new TableCell();
                    var tc2 = new TableCell();
                    var lblName = new Label { ID = "lblName" + i, Text = lstStudents[i].Name, };
                    var txtComment = new TextBox { ID = "txtComment" + lstStudents[i].UId, TextMode = TextBoxMode.MultiLine, Width = 350 };
                    txtComment.Attributes.Add("style", "resize:none");
                    txtComment.Width = 800;
                    txtComment.Height = 150;
                    tc1.Controls.Add(lblName);
                    tc2.Controls.Add(txtComment);
                    tr.Cells.Add(tc1);
                    tr.Cells.Add(tc2);
                    tblStudents.Rows.Add(tr);
                }
                var trPro = new TableRow();
                var tc1Pro = new TableCell();
                var tc2Pro = new TableCell();
                tc1Pro.Controls.Add(new Label(){Text = "About Project"});
                var txtCommentProj = new TextBox
                                         {
                                             ID = "txtCommentProj",
                                             TextMode = TextBoxMode.MultiLine,
                                             Width = 800,
                                             Height = 150
                                         };
                tc2Pro.Controls.Add(txtCommentProj);
                trPro.Cells.Add(tc1Pro);
                trPro.Cells.Add(tc2Pro);
                tblStudents.Rows.Add(trPro);
            }
            return studentExists;

        }
        private void RemoveDynamicControls()
        {
            foreach (TableRow tr in tblStudents.Rows)
            {
               tblStudents.Rows.Remove(tr);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtProj.Visible = false;
            if (txtByProjectName.Text!=string.Empty && hfEvaludateClicked.Value == "1")
            {
                long pId;
                if (long.TryParse(FrequentAccesses.GetProjectIdByName(txtByProjectName.Text), out pId))
                {
                    if (pId != 0)
                        CreateControls(pId);
                }
            }
            if (!IsPostBack)
            {
                PopulateSession();
                PopulateMilestone();
                hfEvaludateClicked.Value = "0";
            }

        }
        private void PopulateMilestone()
        {
            using (var fyp = new FYPEntities())
            {
                ddlMileStone.DataSource = fyp.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }
        private void PopulateSession()
        {
            using (var fyp = new FYPEntities())
            {
                ddlSession.DataSource = fyp.ProjectSessions.ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }
        //protected void DdlSessionSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    long sid = Convert.ToInt64(ddlSession.SelectedValue);
        //    using (var fyp = new FYPEntities())
        //    {
        //        var data = fyp.Projects.Where(pr => pr.ProjectSessionId == sid).ToList();
        //        //ddlProject.DataSource = data;
        //        //ddlProject.DataBind();
        //        //ddlProject.Items.Insert(0, new ListItem("Select Project", "0"));
        //        hfEvaludateClicked.Value = "0";
        //    }
        //}
        protected void EvaluationClicked(object sender, EventArgs e)
        {
            long pId;
            RemoveDynamicControls();
            ////txtProj.Visible = true;
            if (long.TryParse(FrequentAccesses.GetProjectIdByName(txtByProjectName.Text), out pId))
            {
                if (pId != 0)
                {
                    if (CreateControls(pId))
                        hfEvaludateClicked.Value = "1";
                }
            }

        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            SubmittComments.Enabled = hfEvaludateClicked.Value == "1";
        }
        protected void SubmitClicked(object sender, EventArgs e)
        {
            var lstb = new List<TextBox>();
            long pId;
            if (!long.TryParse(FrequentAccesses.GetProjectIdByName(txtByProjectName.Text), out pId) && hfEvaludateClicked.Value == "1")
            {
                FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Project value from DropDown Changed" }, this.Page, true);
                return;
            }

            using (var fyp = new FYPEntities())
            {
                var lstStudents = fyp.SP_GetProjectStudentsWithId(pId).ToList();
                var lstMse = new List<MileStoneEvaluation>();
                var txtboxProj = this.FindControl("txtCommentProj") as TextBox;
                foreach (var lstStd in lstStudents)
                {
                    var txtbox = this.FindControl("txtComment" + lstStd.UId) as TextBox;
                    lstb.Add(txtbox);
                    if (txtbox != null)
                    {
                        var mse = new MileStoneEvaluation();
                        mse.ComentedDate = DateTime.Now;
                        mse.CommentByPC = txtbox.Text;
                        mse.CommentedBy = FYPSession.GetLoggedUser().UserId;
                        mse.StudentId = lstStd.UId;
                        mse.PMSId = Convert.ToInt32(ddlMileStone.SelectedValue);
                        mse.ProjectId = pId;
                        if (txtboxProj != null) mse.CommentByPcAboutProject = txtboxProj.Text;
                        lstMse.Add(mse);
                    }
                }
                lstb.Add(txtboxProj);
                if (lstMse.Count != 0)
                {
                    fyp.MileStoneEvaluations.AddRange(lstMse);
                    if (fyp.SaveChanges() > 0)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Comments uploaded successfully" }, this.Page, true);
                        hfEvaludateClicked.Value = "0";
                        ClearFields(lstb);
                    }
                }
            }
        }
        protected void DdlProjectSelectedIndexChanged(object sender, EventArgs e)
        {
            hfEvaludateClicked.Value = "0";
        }

        private void ClearFields(IEnumerable<TextBox> lst)
        {
            foreach (var textBox in lst)
            {
                textBox.Text = string.Empty;
            }
        }
    }
}