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
            GvdViewAllFaculty.DataBind();
        }

    }
}