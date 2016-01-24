using System;
using System.Data;
using System.Web.UI;
using FYPAutomation.App_Start;

namespace FYPAutomation.Pages.General
{
    public partial class ExcelDownload : Page
    {
        public DataTable Dt;
        public string ExcelName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentExcelInvalidData"] != null)
            {
               Dt = Session["StudentExcelInvalidData"] as DataTable;
                ExcelName = "Invalid Data.xls";
            }
            else if(Session["AssignProject"]!=null)
            {
                Dt = Session["AssignProject"] as DataTable;
                ExcelName = "Assigned Project.xls";
            }
            else if (Session["ReportExcel"] != null)
            {
                Dt = Session["ReportExcel"] as DataTable;
                ExcelName = "Comments.xls";
            }

            if(Dt!=null)
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            gdvExcelExport.DataSource = Dt;
            gdvExcelExport.DataBind();
            if(gdvExcelExport.Rows.Count==0)
                return;
            string filename = ExcelName;
            var tw = new System.IO.StringWriter();
            var hw = new System.Web.UI.HtmlTextWriter(tw);
           //Get the HTML for the control.
            gdvExcelExport.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        } 
    }
}