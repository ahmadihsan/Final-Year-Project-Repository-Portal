using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Convener
{
    public partial class CtrlViewAndAddComments : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pid;
                long pmsid = 1;
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out pid))
                {
                    using (var fyp = new FYPEntities())
                    {
                        var firstOrDefault = fyp.Projects.FirstOrDefault(p => p.PId == pid );
                        if (firstOrDefault != null)
                            lblProjectName.Text = firstOrDefault.Tiltle;
                    }
                }
                if (ddlMileStone.SelectedIndex==-1)
                {
                    using (var fyp = new FYPEntities())
                    {
                        pmsid = fyp.ProjectMileStones.Min(x => x.PMSId);
                        var projectMileStone = fyp.ProjectMileStones.FirstOrDefault(x=>x.PMSId==pmsid);
                        if (projectMileStone != null)
                            lblMileStoneDoc.Text = projectMileStone.Name;
                    }
                }
                CommentsGrid(pmsid);
                PopulateMileStone();
            }
        }

        private void PopulateMileStone()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }

        private void CommentsGrid(long pmsid)
        {
            var dt = new DataTable();
            using (var fyp = new FYPEntities())
            {
                //user id who is currently logged in
                long pid;
                if (long.TryParse(Request.QueryString["PId"], out pid))
                {
                    //No of columns to be added as there can be a number of group members in each group
                    int noOfCols = fyp.ProjectGroups.Count(pi => pi.ProjectId == pid) + 2;

                    //retrieving student names who has taken this project
                    var studentNames = (from pg in fyp.ProjectGroups
                                        join us in fyp.Users on pg.StudentId equals us.UId
                                        where pg.ProjectId == pid
                                        select new
                                                   {
                                                       us.Name
                                                   }).ToList();

                    dt.Columns.Add("Commented By");
                    for (int i = 1; i < noOfCols-1; i++)
                    {
                        dt.Columns.Add(studentNames[i - 1].Name);
                    }
                    dt.Columns.Add("About Project");
                    //get how many PC Members are
                    var pcMembers = fyp.Users.Where(ur => ur.RoleId == 5 || ur.RoleId == 1 || ur.RoleId == 2).ToList();
                    for (int i = 0; i < pcMembers.Count; i++)
                    {
                        long uid = pcMembers[i].UId;
                        var cmt =
                            fyp.MileStoneEvaluations.Where(mse => mse.CommentedBy == uid && mse.ProjectId == pid && mse.PMSId==pmsid).ToList();
                        var dr = dt.NewRow();
                        for (int j = 0; j < noOfCols-1; j++)
                        {

                            if (j == 0)
                                dr[j] = pcMembers[i].Name;
                            else
                            {
                                if (cmt.Count > j - 1 && cmt[j - 1] != null)
                                {
                                    if (cmt[j - 1].CommentByPC != string.Empty)
                                    {
                                        dr[j] = cmt[j - 1].CommentByPC;
                                    }
                                    else
                                    {
                                        dr[j] = "Not Attended";
                                    }
                                }
                                else
                                {
                                    dr[j] = "Not Attended";
                                }
                            }
                        }
                        if (cmt.Count > 0 && !string.IsNullOrEmpty(cmt[0].CommentByPcAboutProject))
                        {
                            dr[noOfCols - 1] = cmt[0].CommentByPcAboutProject;
                        }
                        else
                        {
                            dr[noOfCols - 1] = "Not Attended";
                        }
                        
                        dt.Rows.Add(dr);
                    }
                }
            }
            gvdComments.DataSource = dt;
            gvdComments.DataBind();
        }

        protected void FinalCommentClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                if (ddlMileStone.SelectedValue.ToString().ToLower() != "select mileStone")
                {
                    long pmsid;
                    long pid;
                    if (long.TryParse(Request.QueryString["PId"], out pid) && long.TryParse(ddlMileStone.SelectedValue,out pmsid))
                    {
                        string comment = txtFinalComment.Text;
                        long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                        fyp.SP_SubmitCommentByPCHead(pid, uid,pmsid,comment);
                        FYPUtilities.FYPMessage.ShowPopUpMessage("Success",
                                                                 new List<string>() {"Comments added successfully"},
                                                                 this.Page, true);
                        txtFinalComment.Text = string.Empty;
                    }
                }
                else
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Comments could not be added. Please select milestone" }, this.Page, true);
                }
            }
        }

        protected void MileStoneSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long pid;
                long pmsid;
                if(long.TryParse(ddlMileStone.SelectedValue,out pmsid) && long.TryParse(Request.QueryString["PId"], out pid))
                {
                    var projectMileStone = fyp.ProjectMileStones.FirstOrDefault(pms => pms.PMSId == pmsid);
                    if (projectMileStone != null)
                        lblMileStoneDoc.Text = projectMileStone.Name;
                    CommentsGrid(pmsid);
                }
            }
        }
    }
}