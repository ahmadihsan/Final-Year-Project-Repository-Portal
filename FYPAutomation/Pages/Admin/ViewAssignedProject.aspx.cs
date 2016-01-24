using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;

namespace FYPAutomation.Pages.Admin
{
    public partial class ViewAssignedProject : FYPBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["ToExport"] != null)
                {
                    ExportToExcel();
                }
            }
        }

        private void ExportToExcel()
        {
            if (Session["ToExport"] != null)
            {
                gvdExcelAssignProj.DataSource = Session["ToExport"] as DataTable;
                gvdExcelAssignProj.DataBind();
                if (gvdExcelAssignProj.Rows.Count == 0)
                    return;
                Response.ClearContent();
                const string filename = "ProjectAssigned.xls";
                var tw = new System.IO.StringWriter();
                var hw = new HtmlTextWriter(tw);
                gvdExcelAssignProj.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }

        }
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //} 
    }
}