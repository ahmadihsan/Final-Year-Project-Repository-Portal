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
    public partial class CtrlAddPcMembers : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForFaculty();
            }
        }

        private void PopulateGridForFaculty()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdViewAllFaculty.DataSource = fypEntities.Users.Where(std => std.RoleId ==3).ToList();
                GvdViewAllFaculty.DataBind();
            }
        }
        protected void GvdViewAllFacultySelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GvdViewAllFaculty.SelectedRow;
            var dataKey = GvdViewAllFaculty.DataKeys[gridViewRow.RowIndex];
            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    Response.Redirect("~/Pages/Admin/FacultyDetail.aspx?Uid=" + uId);
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
                GvdViewAllFaculty.DataSource = fypEntities.Users.Where(std => std.Name.Contains(stdName) && std.RoleId == 3).ToList();
                GvdViewAllFaculty.DataBind();
            }
        }

        protected void AddPcClick(object sender, EventArgs e)
        {
            bool check = false;
            if (!CheckStudentsInGridView())
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Please Select Faculty" }, this.Page, true);
                return;
            }
            using (var fypEntities = new FYPEntities())
            {
                var projectGroup = new ProjectGroup();
                foreach (GridViewRow row in GvdViewAllFaculty.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                        if (checkBox != null && checkBox.Checked)
                        {
                            var dataKey = GvdViewAllFaculty.DataKeys[row.RowIndex];
                            if (dataKey != null)
                            {
                                if (dataKey.Values != null)
                                {
                                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                                    var fac = fypEntities.Users.FirstOrDefault(fa => fa.UId == uId);
                                    if (fac != null) fac.RoleId = 5;
                                    if(fypEntities.SaveChanges()>0)
                                    {
                                        check = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if(check)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "PC Member Added Sucessfull" }, this.Page, true);
                    PopulateGridForFaculty();
                }
            }
        }

        private bool CheckStudentsInGridView()
        {
            foreach (var row in GvdViewAllFaculty.Rows.Cast<GridViewRow>())
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