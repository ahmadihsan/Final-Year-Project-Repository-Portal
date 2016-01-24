using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using System.Configuration;
using System.IO;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlViewMail : System.Web.UI.UserControl
    {
        
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MailView();
            }
            
           
        }
        private void MailView()
        {
            long id = Convert.ToInt64(Request.QueryString["COMId"]);
            using(var fyp = new FYPEntities())
            {
                var attach = fyp.Communications.Where(p => p.COMId == id).ToList();
                lblHeaderMailView.Text = attach.FirstOrDefault().EmailSubject;
                lblMailBodyView.Text = attach.FirstOrDefault().Message_Content;
                
            }
            
        }

        //private void download()
        //{
        //    using (var fyp = new FYPEntities())
        //    {
        //        //long id = long.Parse(Request.QueryString["COMId"]); 
        //        //var attach = fyp.Communications.Where(p => p.COMId == id).Select(q => q.File_Attached).ToString();
        //        linkdownload.NavigateUrl = _studentDoc + attach;

        //    }
            
        //}


        protected void lnkDownload_Click1(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(Request.QueryString["COMId"]);

            using (var fyp = new FYPEntities())
            {

                var attach = fyp.Communications.Where(p => p.COMId == id).ToList();
                var file = attach.FirstOrDefault().File_Attached;

                if (file != "")
                {
                    FileInfo fileinfo = new FileInfo(file);
                    if (fileinfo.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileinfo.Name);
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = "application/msword";
                        Response.WriteFile(fileinfo.FullName);
                        Response.End();
                    }
                    else
                    {
                        Response.Write("This file does not exist.");
                    }
                }
            }
            
        }


    }

}