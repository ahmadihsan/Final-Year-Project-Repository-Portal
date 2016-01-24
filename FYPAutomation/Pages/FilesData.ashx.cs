using System;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;
using FYPUtilities;
using FYPDAL;

namespace FYPAutomation.Pages
{
    /// <summary>
    /// Summary description for FilesData
    /// </summary>
    public class FilesData : IHttpHandler
    {

        private string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        
        public void ProcessRequest(HttpContext context)
        {
            object missingType = Type.Missing;
            object readOnly = true;
            object isVisible = true;
            object documentFormat = 8;
            //string randomName = DateTime.Now.Ticks.ToString();

            string Id = "";
            if (context.Request.QueryString["htmlFilePath"] != null)
            {
                Id = (context.Request.QueryString["htmlFilePath"]).ToString();
            }



            //Read the Html File as Byte Array and Display it on browser



            FileInfo info = new FileInfo(Id);
            try
            {
                if (info.Exists)
                {

                    byte[] bytes;
                    using (FileStream fs = new FileStream(Id, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader reader = new BinaryReader(fs);
                        bytes = reader.ReadBytes((int)fs.Length);
                        fs.Close();
                    }
                    context.Response.ContentType = "application/pdf";
                    context.Response.BinaryWrite(bytes);
                    context.Response.Flush();

                }
                else
                {
                    throw new Exception("File not found");
                }
            }
            catch (Exception ex)
            {
                //context.Response.ContentType = "text/plain";
                context.Response.Write(ex.Message);
            }
            finally
            {
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}