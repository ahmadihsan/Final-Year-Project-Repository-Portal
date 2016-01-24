using System;
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
    public partial class CtrlViewExtGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForExternalWithGroup();
            }
        }

        private void PopulateGridForExternalWithGroup()
        {
            using (var fyp = new FYPEntities())
            {
                //long psid = fyp.ProjectSessions.Max(pss => pss.PSId);


                var query = from Egid in fyp.ExternalGroups
                            join u in fyp.Users
                               on Egid.Ext_User1 equals u.UId
                               where u.IsGrouped == true
                            select new
                            {
                                Egid.Ext_User1

                            };
                GridViewExternalGroup.DataSource = query.ToList();
                GridViewExternalGroup.DataBind();
            }


        }

        private void viewgroup(GridViewRowEventArgs e)
        {
            long uId = -1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey dk = GridViewExternalGroup.DataKeys[e.Row.RowIndex];
                if (dk != null && dk.Values != null)
                {
                    uId = Convert.ToInt64(dk.Values["Ext_User1"]);

                }
                var ExternalName = e.Row.FindControl("ExternalName") as GridView;
                if (ExternalName != null && uId > 0)
                {
                    using (var fypEntities = new FYPEntities())
                    {
                        ExternalName.DataSource = fypEntities.SP_GetNamesOfExternalGroupMember(uId);
                        ExternalName.DataBind();
                    }
                }

            }
        }

        protected void GridViewExternalGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            viewgroup(e);
        }

        protected void GridViewExternalGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GridViewExternalGroup.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long uId = Convert.ToInt64(dataKey.Values["Ext_User1"]);

                    using (var fyp = new FYPEntities())
                    {
                        long uId2 = Convert.ToInt64(fyp.ExternalGroups.Where(q => q.Ext_User1 == uId).Select(p => p.Ext_User2).FirstOrDefault().Value);
                        long uId3 = Convert.ToInt64(fyp.ExternalGroups.Where(q => q.Ext_User1 == uId).Select(p => p.Ext_user3).FirstOrDefault().Value);
                        var usr = fyp.ExternalGroups.Where(x => x.Ext_User1 == uId).Select(p => p.EGId).FirstOrDefault();
                        fyp.SP_ChangeIsGroupedbyId(uId, false);
                        fyp.SP_ChangeIsGroupedbyId(uId2, false);
                        fyp.SP_ChangeIsGroupedbyId(uId3, false);
                        fyp.SP_RemoveExtGroupByFirstUserId(usr);
                        if (fyp.SaveChanges() >= 0)
                        {
                            
                            FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "External Group is removed successfully" }, this.Page, true);
                            PopulateGridForExternalWithGroup();
                           
                        }
                        else
                        {
                            FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "External Group could not be removed" }, this.Page, true);

                        }

                    }
                }
            }
            //if (e.CommandName == "Detail")
            //{
            //    DataKey dataKey = GridViewExternalGroup.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
            //    if (dataKey != null && dataKey.Values != null)
            //    {

            //        long uId = Convert.ToInt32(dataKey.Values["Ext_User1"].ToString());


            //        int rid = FrequentAccesses.GetRoleIdByUserId(FYPUtilities.FYPSession.GetLoggedUser().UserId);
            //        string roleName = FrequentAccesses.GetRoleNameById(rid);
            //        if (roleName.ToString().ToLower() == "admin")
            //        {
            //            Response.Redirect("~/Pages/Admin/ExternalDetail.aspx?Uid=" + uId);
            //        }
            //        else if (roleName.ToString().ToLower() == "convener")
            //        {
            //            Response.Redirect("~/Pages/Convener/ExternalDetail.aspx?Uid=" + uId);
            //        }
            //    }
            //}
        }

       
    }
}