using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls
{
    public partial class CtrlViewStudent: System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateProjectSession();
                PopulateGridForStudent();
            }
            
        }

        private void PopulateGridForStudent()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllStudent.DataSource =fypEntities.Users.Where(std=>std.RoleId == 4).ToList();
                GvdViewAllStudent.DataBind();
            }
        }

        private void PopulateProjectSession()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlStudentSearchBySession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlStudentSearchBySession.DataBind();
                ddlStudentSearchBySession.Items.Insert(0,"Search By Session");
            }
        }

        //protected void GvdViewAllStudentSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gridViewRow = GvdViewAllStudent.SelectedRow;
        //    var dataKey = GvdViewAllStudent.DataKeys[gridViewRow.RowIndex];
        //    if (dataKey != null)
        //    {
        //        if (dataKey.Values != null)
        //        {
        //            //int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
        //            //Response.Redirect("~/Pages/Admin/StudentDetail.aspx?Uid=" + uId);
        //            long uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
        //            int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
        //            string roleName = FrequentAccesses.GetRoleNameById(rid);
        //            if (roleName.ToString().ToLower() == "admin")
        //            {
        //                Response.Redirect("~/Pages/Admin/StudentDetail.aspx?Uid=" + uId);
        //            }
        //            else if (roleName.ToString().ToLower() == "convener")
        //            {
        //                Response.Redirect("~/Pages/Convener/StudentDetail.aspx?Uid=" + uId);
        //            }
        //        }
        //    }
        //}

        protected void GvdViewAllStudentPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllStudent.PageIndex = e.NewPageIndex;
            PopulateGridForStudent();
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities=new FYPEntities())
            {
                string stdName = txtSearchByName.Text;
                GvdViewAllStudent.DataSource =
                    fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId == 4).ToList();
                GvdViewAllStudent.DataBind();
            }
        }

        protected void StudentSearchBySessionSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities=new FYPEntities())
            {
                int psId = Convert.ToInt32(ddlStudentSearchBySession.SelectedValue);
                GvdViewAllStudent.DataSource = fypEntities.Users.Where(std => std.ProjectSessionId == psId).ToList();
                GvdViewAllStudent.DataBind();
            }
        }

        protected void StudentSearchBySemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                int smster = Convert.ToInt32(ddlSearchBySemester.SelectedValue);
                GvdViewAllStudent.DataSource = fypEntities.Users.Where(std => std.Semester==smster).ToList();
                GvdViewAllStudent.DataBind();
            }
        }

        protected void GvdViewAllStudentRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey =
                    GvdViewAllStudent.DataKeys[((GridViewRow) ((LinkButton) e.CommandSource).NamingContainer).RowIndex];
                if(dataKey!=null && dataKey.Values!=null)
                {
                    long uId = Convert.ToInt64(dataKey.Values["UId"]);
                    using (var fyp=new FYPEntities())
                    {
                        User usr = fyp.Users.FirstOrDefault(x => x.UId == uId);
                        if(usr!=null)
                        {
                            fyp.Users.Remove(usr);
                            if (fyp.SaveChanges()>0)
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Success",new List<string>(){"User removed successfully"},this.Page,true );
                                PopulateGridForStudent();
                            }
                            else
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "User could not be removed" }, this.Page, true);
                                PopulateGridForStudent();
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "Detail")
            {
                DataKey dataKey =
                    GvdViewAllStudent.DataKeys[((GridViewRow) ((LinkButton) e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long uId = Convert.ToInt64(dataKey.Values["UId"]);
                    int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
                    string roleName = FrequentAccesses.GetRoleNameById(rid);
                    if (roleName.ToString().ToLower() == "admin")
                    {
                        Response.Redirect("~/Pages/Admin/StudentDetail.aspx?Uid=" + uId);
                    }
                    else if (roleName.ToString().ToLower() == "convener")
                    {
                        Response.Redirect("~/Pages/Convener/StudentDetail.aspx?Uid=" + uId);
                    }
                }
            }
        }
    }
}