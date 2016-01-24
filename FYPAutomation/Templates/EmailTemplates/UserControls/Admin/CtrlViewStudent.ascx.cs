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
            
        }
        protected void GvdViewAllStudentSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GvdViewAllStudent.SelectedRow;
            var dataKey = GvdViewAllStudent.DataKeys[gridViewRow.RowIndex];
            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    int uId = Convert.ToInt32(dataKey.Values["UId"].ToString());
                    Response.Redirect("~/Pages/Admin/StudentDetail.aspx?Uid=" + uId);
                }
            }
        }

        protected void GvdViewAllStudentPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvdViewAllStudent.PageIndex = e.NewPageIndex;
            GvdViewAllStudent.DataBind();
        }

    }
}