using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlGenerateReport : FYPBaseUserControl
    {
        private int _noOfColumns;
        private int _sNo = 1;
        private int _student;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvReportGenerator.ActiveViewIndex = 0;
                PopulateSession();
                PopulateMileStones();
                //ColumnsToAdd();
                //GenarateColumns();
                //ReportGrid();
            }
        }

        private void PopulateSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSelection.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSelection.DataBind();
                ddlSessionSelection.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateMileStones()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMilestoneSelection.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMilestoneSelection.DataBind();
                ddlMilestoneSelection.Items.Insert(0, "Select MileStone");
            }
        }


        private void ColumnsToAdd()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = Convert.ToInt64(ddlSessionSelection.SelectedValue);
                int noOfPc = fyp.Users.Count(ur => ur.RoleId == 5 || ur.RoleId == 1 || ur.RoleId == 2);
                var studentList = (from project in fyp.Projects
                    join projectGroup in fyp.ProjectGroups on project.PId equals projectGroup.ProjectId
                    where project.ProjectSessionId == psid
                    group projectGroup by projectGroup.ProjectId
                    into data
                    select new
                    {
                        pid=data.Key,
                        maxVal=data.Count()
                    }).ToList();
                _student = studentList.Max(x=>x.maxVal);
                _noOfColumns = noOfPc + 5 + _student;
                ViewState["cols"] = _noOfColumns;
                ViewState["student"] = _student;
            }
        }

        private void GenarateColumns()
        {
            var dt = new DataTable();
            dt.Columns.Add("S.No");
            dt.Columns.Add("Project");
            for (int i = 0; i < _student; i++)
            {
                dt.Columns.Add("Student" + (i + 1));
            }
            dt.Columns.Add("Supervisor");
            dt.Columns.Add("Research Group");

            //Get names of pc members

            using (var fyp = new FYPEntities())
            {
                var pcNames = fyp.Users.Where(ur => ur.RoleId == 5 || ur.RoleId == 1 || ur.RoleId == 2).ToList();
                int colStart = 5 + _student;
                for (int i = colStart; i < _noOfColumns - 1; i++)
                {
                    dt.Columns.Add(pcNames[i - colStart].Name);
                }

                dt.Columns.Add("Status");

                long psid = Convert.ToInt64(ddlSessionSelection.SelectedValue);

                var projs = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                for (int i = 0; i < projs.Count; i++)
                {
                    long pid = projs[i].PId;
                    var studentNames = new string[_student];
                    var studentNamesList = (from pg in fyp.ProjectGroups
                                            join us in fyp.Users on pg.StudentId equals us.UId
                                            where pg.ProjectId == pid
                                            select new
                                                       {
                                                           NameandReg = us.Name + "(" + us.RegistrationNo + ")"
                                                       }).ToList();
                    if (studentNamesList.Count > 0)
                    {
                        for (int j = 0; j < studentNamesList.Count; j++)
                        {
                            studentNames[j] = studentNamesList[j].NameandReg;
                        }
                    }
                    //studentNames = studentNamesList.Aggregate(studentNames, (current, std) => current + std.NameandReg);
                    var supervisorName = (from pr in fyp.Projects
                                          join usr in fyp.Users on pr.ProposedBy equals usr.UId
                                          where pr.PId == pid
                                          select new
                                                     {
                                                         usr.Name
                                                     }).ToList();
                    var researchName = (from pr in fyp.Projects
                                        join re in fyp.ResearchGroups on pr.researchGroupId equals re.ResearchId
                                        where pr.PId == pid
                                        select new
                                        {
                                            re.Title
                                        }).ToList();

                    int pmsid = Convert.ToInt32(ddlMilestoneSelection.SelectedValue);
                    var comments = (from mse in fyp.MileStoneEvaluations
                                    join usr in fyp.Users on mse.CommentedBy equals usr.UId
                                    where mse.ProjectId == pid && mse.PMSId == pmsid
                                    select new
                                               {
                                                   mse.CommentByPC,
                                                   usr.Name
                                               }).ToList();

                    //Add row to data table
                    var dr = dt.NewRow();
                    foreach (var comment in comments)
                    {
                        if (dt.Columns.Contains(comment.Name))
                        {
                            dr[comment.Name] = comment.CommentByPC;
                        }
                    }
                    for (int j = 0; j < _noOfColumns - 1; j++)
                    {
                        if (j == 0)
                            dr[j] = _sNo++;
                        if (j == 1)
                        {
                            dr[j] = projs[i].Tiltle;
                        }
                        if (j == 2)
                        {
                            for (int k = 0; k < _student; k++)
                            {
                                dr[j] = studentNames[k];
                                j++;
                            }
                        }
                        if (j > 2 && j== 2 + _student)
                        {
                            dr[j] = supervisorName[0].Name;
                        }
                        if (j > 2 && j == 2 + _student + 1)
                        {
                            dr[j] = researchName.Count == 0 ? "No Research Group" : researchName[0].Title;
                        }
                        //if (j == 4)
                        //{
                        //    dr[j] = researchName.Count == 0 ? "No Research Group" : researchName[0].Title;
                        //}

                    }
                    dt.Rows.Add(dr);
                }

                gvdReports.DataSource = dt;
                gvdReports.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            foreach (GridViewRow gr in gvdReports.Rows)
            {
                for (int i = 0; i < gr.Cells.Count; i++)
                {
                    gr.Cells[i].Text = HttpUtility.HtmlDecode(gr.Cells[i].Text);
                }
            }
        }

        protected void BtnExportToExcelClicked(object sender, EventArgs e)
        {
            if (ViewState["cols"] != null && ViewState["student"]!=null)
            {
                _noOfColumns = Convert.ToInt32(ViewState["cols"]);
                _student=Convert.ToInt32(ViewState["student"]);
            }

            var dt = new DataTable();
            dt.Columns.Add("S.No");
            dt.Columns.Add("Project");
            for (int i = 0; i < _student; i++)
            {
                dt.Columns.Add("Student" + (i + 1));
            }
            dt.Columns.Add("Supervisor");
            dt.Columns.Add("Research Group");

            //Get names of pc members

            using (var fyp = new FYPEntities())
            {
                var pcNames = fyp.Users.Where(ur => ur.RoleId == 5 || ur.RoleId == 1 || ur.RoleId == 2).ToList();
                int colStart = 5 + _student;
                for (int i = colStart; i < _noOfColumns - 1; i++)
                {
                    dt.Columns.Add(pcNames[i - colStart].Name);
                }

                dt.Columns.Add("Status");
            }

            foreach (var row in gvdReports.Rows.Cast<GridViewRow>())
            {
                var dRow = dt.NewRow();

                for (int i = 0; i < _noOfColumns-1; i++)
                {
                    dRow[i] = row.Cells[i].Text;
                }
                dt.Rows.Add(dRow);
            }
            Session["ReportExcel"] = dt;

            FYPUtilities.FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/General/ExcelDownload.aspx"), true, this.Page);
        }

        protected void BtnGoToStep2Clicked(object sender, EventArgs e)
        {
            mvReportGenerator.ActiveViewIndex = 1;
            ColumnsToAdd();
            GenarateColumns();
        }
    }
}