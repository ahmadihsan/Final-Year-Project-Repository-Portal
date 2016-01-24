using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlViewExternal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForExternal();
            }
        
        }
        private void PopulateGridForExternal()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllExternal.DataSource = fypEntities.Users.Where(std => std.RoleId == 8 && std.IsGrouped == false).ToList();
                GvdViewAllExternal.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByName.Text;
                GvdViewAllExternal.DataSource = fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId == 8).ToList();
                GvdViewAllExternal.DataBind();
            }  
        }

        protected void GvdViewAllExternal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllExternal.PageIndex = e.NewPageIndex;
            PopulateGridForExternal();
        }

        protected void GvdViewAllExternal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey =
                    GvdViewAllExternal.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
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
                                PopulateGridForExternal();
                            }
                            else
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "User could not be removed" }, this.Page, true);
                                PopulateGridForExternal();
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "Detail")
            {
                DataKey dataKey =
                    GvdViewAllExternal.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
                    string roleName = FrequentAccesses.GetRoleNameById(rid);
                    if (roleName.ToString().ToLower() == "admin")
                    {
                        Response.Redirect("~/Pages/Admin/ExternalDetail.aspx?Uid=" + uId);
                    }
                    else if (roleName.ToString().ToLower() == "convener")
                    {
                        Response.Redirect("~/Pages/Convener/ExternalDetail.aspx?Uid=" + uId);
                    }
                }
            }
        }

    }
}