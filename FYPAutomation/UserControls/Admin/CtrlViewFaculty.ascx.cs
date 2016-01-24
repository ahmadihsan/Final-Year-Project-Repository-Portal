using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls
{
    public partial class CtrlViewFaculty : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridForFaculty();
            }
        }

        private void PopulateGridForFaculty()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllFaculty.DataSource = fypEntities.Users.Where(std => std.RoleId != 4).ToList();
                GvdViewAllFaculty.DataBind();
            }
        }
        //protected void GvdViewAllFacultySelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gridViewRow = GvdViewAllFaculty.SelectedRow;
        //    var dataKey = GvdViewAllFaculty.DataKeys[gridViewRow.RowIndex];
        //    if (dataKey != null)
        //    {
        //        if (dataKey.Values != null)
        //        {
        //            long uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
        //            int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
        //            string roleName = FrequentAccesses.GetRoleNameById(rid);
        //            if (roleName.ToString().ToLower() == "admin")
        //            {
        //                Response.Redirect("~/Pages/Admin/FacultyDetail.aspx?Uid=" + uId);
        //            }
        //            else if(roleName.ToString().ToLower()=="convener")
        //            {
        //                Response.Redirect("~/Pages/Convener/FacultyDetail.aspx?Uid=" + uId);
        //            }
        //        }
        //    }
        //}

        protected void GvdViewAllFacultyRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey =
                    GvdViewAllFaculty.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long uId = Convert.ToInt64(dataKey.Values["UId"]);
                    using (var fyp = new FYPEntities())
                    {
                        User usr = fyp.Users.FirstOrDefault(x => x.UId == uId);
                        if (usr != null)
                        {
                            fyp.Users.Remove(usr);
                            if (fyp.SaveChanges() > 0)
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "User removed successfully" }, this.Page, true);
                                PopulateGridForFaculty();
                            }
                            else
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "User could not be removed" }, this.Page, true);
                                PopulateGridForFaculty();
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "Detail")
            {
                DataKey dataKey =
                    GvdViewAllFaculty.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
                    string roleName = FrequentAccesses.GetRoleNameById(rid);
                    if (roleName.ToString().ToLower() == "admin")
                    {
                        Response.Redirect("~/Pages/Admin/FacultyDetail.aspx?Uid=" + uId);
                    }
                    else if (roleName.ToString().ToLower() == "convener")
                    {
                        Response.Redirect("~/Pages/Convener/FacultyDetail.aspx?Uid=" + uId);
                    }
                }
            }
        }

        protected void GvdViewAllFacultyPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllFaculty.PageIndex = e.NewPageIndex;
            PopulateGridForFaculty();
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByName.Text;
                GvdViewAllFaculty.DataSource =fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId!= 4).ToList();
                GvdViewAllFaculty.DataBind();
            }
        }
    }
}