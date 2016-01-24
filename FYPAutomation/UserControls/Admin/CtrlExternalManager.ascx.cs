using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlExternalManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForExternal();
                PopulateSession();
                            
            }
        }
        private void PopulateGridForExternal()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllExternal.DataSource = fypEntities.Users.Where(std => std.RoleId == 8).ToList();
                GvdViewAllExternal.DataBind();
            }
        }
      
        private void PopulateSession()
        {
            using (var fyp = new FYPEntities())
            {
                ddlSession.DataSource = fyp.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSession.DataBind();

                ddlSession.Items.Insert(0, "Select Session");

            }
        }

        protected void CreateExternalClick_Click(object sender, EventArgs e)
        {
            var ExtGroup = new ExternalGroup();
           
            if (ddlSession.SelectedValue != "Select Session")
            {
                long psid = Convert.ToInt32(ddlSession.SelectedValue);
                using (var fypEntities = new FYPEntities())
                {
                    
                    int count = 0;
                    int ex1 = 0, ex2 = 0, ex3 = 0;
                    foreach (GridViewRow row in GvdViewAllExternal.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                            if (checkBox != null && checkBox.Checked)
                            {
                                var dataKey = GvdViewAllExternal.DataKeys[row.RowIndex];
                                if (dataKey != null)
                                {
                                    if (dataKey.Values != null)
                                    {
                                        if (count == 0 )
                                        {
                                            ex1 = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                            
                                        }
                                        else if (count == 1 )
                                        {
                                            ex2 = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                            
                                        }
                                        else if (count == 2 )
                                        {
                                            ex3 = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                        }
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                    if (count <= 3)
                    {
                        
                    if(ex1 != 0)
                    ExtGroup.Ext_User1 = ex1;
                    if(ex2 != 0)
                    ExtGroup.Ext_User2 = ex2;
                    if(ex3 != 0)
                    ExtGroup.Ext_user3 = ex3;
                    ExtGroup.ProjectSessionId = psid;
                    fypEntities.ExternalGroups.Add(ExtGroup);
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Error in Group Creation.There can be maximum 3 Members in One Group" }, this.Page, true);
                        count = 0;
                    }
                   
                    if (fypEntities.SaveChanges() > 0 )
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "External(s) Group Created Sucessfull" }, this.Page, true);
                        var chngeusr1_group = fypEntities.SP_UpdateUserWithIsGroupedValue(ex1, true).ToString();
                        var chngeusr2_group = fypEntities.SP_UpdateUserWithIsGroupedValue(ex2, true).ToString();
                        var chngeusr3_group = fypEntities.SP_UpdateUserWithIsGroupedValue(ex3, true).ToString();
                        PopulateGridForExternal();
                        count = 0;
                    }
                    
                }
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Please Select Session " }, this.Page, true);
            }
        }

        protected void btnRemoveExternalr_Click(object sender, EventArgs e)
        {

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

        protected void GvdViewAllExternal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GvdViewAllExternal.SelectedRow;
            var dataKey = GvdViewAllExternal.DataKeys[gridViewRow.RowIndex];
            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    Response.Redirect("~/Pages/Admin/ExternalDetail.aspx?Uid=" + uId);
                }
            }
        }

        protected void GvdViewAllExternal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvdViewAllExternal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllExternal.PageIndex = e.NewPageIndex;
            PopulateGridForExternal();
        }
        //public long checkPI(object id)
        //{
        //    using(var fyp = new FYPEntities())
        //    {
        //        var 
        //    }
        //    return;
        //}
        protected void GridViewExternalGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
              
            
        }

        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

      

              
    }
}