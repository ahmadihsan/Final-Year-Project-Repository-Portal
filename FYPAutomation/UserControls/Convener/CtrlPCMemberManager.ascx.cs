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
    public partial class CtrlPCMemberManager : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridForPcMembers();
            }
        }

        private void PopulateGridForPcMembers()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllPC.DataSource = fypEntities.Users.Where(std => std.RoleId == 5).ToList();
                GvdViewAllPC.DataBind();
            }
        }
        protected void GvdViewAllFacultySelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GvdViewAllPC.SelectedRow;
            var dataKey = GvdViewAllPC.DataKeys[gridViewRow.RowIndex];
            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    Response.Redirect("~/Pages/Convener/FacultyDetail.aspx?Uid=" + uId);
                }
            }
        }

        protected void GvdViewAllFacultyPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllPC.PageIndex = e.NewPageIndex;
            PopulateGridForPcMembers();
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = txtSearchByName.Text;
                GvdViewAllPC.DataSource = fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId == 5).ToList();
                GvdViewAllPC.DataBind();
            }
        }

        protected void AddPcClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Convener/AddPCMember.aspx");
        }

        protected void DeletePcClick(object sender, EventArgs e)
        {
            bool check = false;
            if (!CheckStudentsInGridView())
            {
                FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Please Select PC Member" }, this.Page, true);
                return;
            }
            using (var fypEntities = new FYPEntities())
            {
                var projectGroup = new ProjectGroup();
                foreach (GridViewRow row in GvdViewAllPC.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                        if (checkBox != null && checkBox.Checked)
                        {
                            var dataKey = GvdViewAllPC.DataKeys[row.RowIndex];
                            if (dataKey != null)
                            {
                                if (dataKey.Values != null)
                                {
                                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                    var fac = fypEntities.Users.FirstOrDefault(fa => fa.UId == uId);
                                    if (fac != null) fac.RoleId = 3;

                                    if (fypEntities.SaveChanges() > 0)
                                    {
                                        check = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (check)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "PC Member removed Sucessfully" }, this.Page, true);
                    PopulateGridForPcMembers();
                }
            }
        }

        private bool CheckStudentsInGridView()
        {
            foreach (var row in GvdViewAllPC.Rows.Cast<GridViewRow>())
            {
                var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                if (checkBox != null && checkBox.Checked)
                {
                    return true;
                }
            }
            return false;
        }
    }
}