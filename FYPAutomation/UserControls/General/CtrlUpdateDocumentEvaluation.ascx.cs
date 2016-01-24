using System;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System.Text;
using System.Data;
using FYPAutomation.App_Start;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPDAL;
using FYPUtilities;
using iTextSharp.text;
using iTextSharp.text.pdf;

using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlUpdateDocumentEvaluation : System.Web.UI.UserControl
    {
        private string _studentDoc = ConfigurationManager.AppSettings["AllUploads"];


        object Unknown = Type.Missing;          // For passing Empty values

        public string basepath = "http://localhost:58919/";
        public string Message = string.Empty;           // To store the Error or Message
        private Microsoft.Office.Interop.Word.Application Word;     // The Interop Object for Word
        private const string FilePath = "filepath";
        float xLoc = 100f;
        float yLoc = 200f;
        string empty = "";
        int count = 0;
        public enum StatusType { SUCCESS, FAILED };     // To Specify Success or Failure Types
        public StatusType Status;                       // To know the Current Status


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               PopulateUpadationData();
            }
        }

        private void BindTotal(string milname)
        {
            long midbind = 0;
            using (var fyp = new FYPEntities())
            {
                midbind = Convert.ToInt64(fyp.ProjectMileStones.Where(p => p.Name == milname).FirstOrDefault().MileStoneMarks);
                lbltotal.Text = midbind.ToString();
            }
        }

        private void PopulateUpadationData()
        {
            var mil = Request.QueryString["Doc"].ToString();
            
            var procName = Request.QueryString["project"].ToString();
            
           lblMileStone.Text = mil;
            lblProjectTitle.Text = procName;
            BindTotal(lblMileStone.Text);
            using(var fyp = new FYPEntities())
            {
               
                var pid = fyp.Projects.Where(p => p.Tiltle == procName).Select(q => q.PId).ToList();

                var students =(from proj in fyp.ProjectGroups                                            //join query on projectGroup and Users to et Group of students
                              join student in fyp.Users on proj.StudentId equals student.UId
                               where proj.ProjectId == pid.FirstOrDefault()
                                                  select new
                                                  {
                                                      student.Name
                                                  }).ToList();
                var resultsup = (from proj in fyp.Projects                                                    //join query on project and supervisor to get supervisor name
                                 join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                 where proj.PId == pid.FirstOrDefault()
                                 select new
                                 {
                                     supervisor.Name
                                 });
                for (int i = 0; i < students.Count; i++)                                                  //display all groupmembers name from list
                {
                    lblGroupMembers.Text += students[i].Name + "<br/>";
                }
                string namesup = resultsup.FirstOrDefault().Name;                                               //display of supervisor name
                lblSuperviserName.Text = namesup + "<br />";
                lblSuperviserName.Visible = true;
                lblGroupMembers.Visible = true;
                PopulateDocument();
            }
            
        }

        private void clearfields()
        {
            // ddlDocumentSelection.Items.Clear();
            //ddlMilestoneSelection.Items.Clear();
            ddlDocumentSelection.SelectedIndex = 0;
            rbtnVerdict.SelectedIndex = -1;
            txtObtainMarks.Text = string.Empty;
            txtCommentProj.InnerText = string.Empty;
            txtComment.InnerText = string.Empty;
            docPreview.Src = "about:blank";

        }

        private void PopulateDocument()                                                                 //populate uploded document 
        {
            using (var fyp = new FYPEntities())
            {
                if (Request.QueryString["project"] != null)
                {
                    var mid = Request.QueryString["Doc"].ToString();
                    var md = (fyp.ProjectMileStones.Where(p => p.Name == mid).Select(q => q.PMSId)).ToList();
                   // long msid = Convert.ToInt32(md);
                    string procName = Request.QueryString["project"].ToString();
                    var id = FrequentAccesses.GetProjectIdByName(procName);


                        long pid = Convert.ToInt32(id);
                        ddlDocumentSelection.DataSource = fyp.UploadedMileStones.Where(p => p.PMSId == md.FirstOrDefault() && p.ProjectId == pid).ToList();
                        ddlDocumentSelection.DataBind();
                        ddlDocumentSelection.Items.Insert(0, "Select Document");
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error!", new List<string>() { "No Project Is Available." }, this.Page, true);
                }


            }
        }

        protected void ddlDocumentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDocumentSelection.SelectedValue.ToString() != "Select Document")
            {
                string strFilePath = _studentDoc;
                string strFile = ddlDocumentSelection.SelectedItem.Text;
                string ext = System.IO.Path.GetExtension(strFile);
                if (ext == ".doc" || ext == ".docx")
                {
                    string Filename = strFilePath + strFile.Split('.')[0] + ".pdf";

                    if (System.IO.File.Exists(Filename))
                    {
                        System.IO.File.Delete(Filename);
                    }
                    ConvertHTMLFromWord(strFilePath + strFile, strFilePath + strFile.Split('.')[0] + ".pdf");
                    string path = strFilePath + strFile.Split('.')[0] + ".pdf";
                    //Session[filepath] = strFile.Split('.')[0] + ".pdf";
                    docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path;
                    docPreview.Visible = true;
                    Session[FilePath] = path;
                }
                else if (ext == ".pdf")
                {
                    string path = strFilePath + strFile;
                    docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path;
                    docPreview.Visible = true;
                    Session[FilePath] = path;
                    //Session[filepath] = strFile;
                }
            }
            else
            {
                docPreview.Src = "about:blank";
            }

        }
        public void ConvertHTMLFromWord(object Source, object Target)
        {
            object Unknown = Type.Missing;                                                    // For passing Empty values
            if (Word == null)                                                                 // Check for the prior instance of the OfficeWord Object
                Word = new Microsoft.Office.Interop.Word.Application();

            try
            {
                // To suppress window display the following code will help
                Word.Visible = false;
                Word.Application.Visible = false;
                Word.WindowState = Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateMinimize;



                Word.Documents.Open(ref Source, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);

                object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;

                Word.ActiveDocument.SaveAs(ref Target, ref format, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);

                Status = StatusType.SUCCESS;
                Message = Status.ToString();
            }
            catch (Exception e)
            {
                Message = "Error :" + e.Message.ToString().Trim();
            }
            finally
            {
                if (Word != null)
                {
                    Word.Documents.Close(ref Unknown, ref Unknown, ref Unknown);
                    Word.Quit(ref Unknown, ref Unknown, ref Unknown);
                }
            }
        }

        protected void btnUpdateEvaluationt_Click(object sender, EventArgs e)
        {
           
            long uid = FYPSession.GetLoggedUser().UserId;
            string id = string.Empty;
            long pmsid = 0;
            string verdict = string.Empty;
            var result = string.Empty;
            double ObtainMarks = 0;
            if (Request.QueryString["project"].ToString() != null)
            {
               
                string procName = Request.QueryString["project"].ToString();
                var Iid = FrequentAccesses.GetProjectIdByName(procName);
                long pid = Convert.ToInt32(Iid);
                if (txtObtainMarks.Text != "" && rbtnVerdict.SelectedIndex != -1)
                {
                    if (txtObtainMarks.Text != "")
                    {
                        ObtainMarks = Convert.ToDouble(txtObtainMarks.Text);
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Enter Obtain Marks!" }, this.Page, true);
                    }
                    string comment = txtComment.InnerText;
                    if (rbtnVerdict.SelectedIndex != -1)
                    {
                        
                        using (var fyp = new FYPEntities())
                        {
                            var resultstudents = (from proj in fyp.ProjectGroups                                            //join query on projectGroup and Users to et Group of students
                                                  join student in fyp.Users on proj.StudentId equals student.UId
                                                  where proj.ProjectId == pid
                                                  select new
                                                  {
                                                      student.Name
                                                  }).ToList();

                            foreach (var item in resultstudents)
                            {
                                count++;
                                CommentsStudent.Text += item.Name + ", ";
                            }
                            verdict = rbtnVerdict.SelectedValue;

                            Verdict.Text += verdict;
                            if (count > 1)
                            {

                                result = (CommentsStudent.Text + comment + "\n" + Verdict.Text).ToString();
                            }
                            else if (count == 1)
                            {
                                CommentsStudent.Text = resultstudents[0].Name;
                                result = (CommentsStudent.Text + ":" + comment + "\n" + Verdict.Text).ToString();
                            }
                        }
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Select Verdict!" }, this.Page, true);
                        
                    }


                    using (var fyp = new FYPEntities())
                    {
                        var mid = Request.QueryString["Doc"].ToString();
                        var md = (fyp.ProjectMileStones.Where(p => p.Name == mid).Select(q => q.PMSId)).ToList();
                        long m = md.FirstOrDefault();
                        long roleid = FYPSession.GetLoggedUser().RoleId;
                        var lstStudents = fyp.SP_GetProjectStudentsWithId(pid).ToList();
                        lbltotal.Text = fyp.ProjectMileStones.Where(p => p.PMSId == m).FirstOrDefault().MileStoneMarks.ToString();

                        foreach (var lstStd in lstStudents)
                        {
                            if (comment != null)
                            {
                                fyp.SP_UpdateEvaluationRemarks(lstStd.UId, pid, result, txtCommentProj.InnerText, roleid, uid, md.FirstOrDefault(), ObtainMarks);
                            }
                        }

                        if (fyp.SaveChanges() >= 0)
                        {
                            fyp.SP_SetEvalStatus(pid, pmsid);
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Comments updated Successfully" }, this.Page, true);
                            clearfields();

                        }
                        else
                        {
                            FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Your request could not processed" }, this.Page, true);

                        }
                    }
                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Enter Required Fields!" }, this.Page, true);
                }
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Error!", new List<string>() { "Project is not available." }, this.Page, true);
            }

        }

        protected void AddText_Click(object sender, EventArgs e)
        {
            if (count >= 1)
            {
                yLoc += 20f;
                xLoc += 20f;
            }
            else
            {
                yLoc = 200f;
                xLoc = 100f;
            }
            var text = doctext.Text + "\r\n";
            string path = Session[FilePath].ToString();
            byte[] bytes = File.ReadAllBytes(path);
            iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    PdfReader reader = new PdfReader(bytes);
            //    using (PdfStamper stamper = new PdfStamper(reader, stream))
            //    {
            //        int pages = reader.NumberOfPages;
            //        for (int i = 1; i <= pages; i++)
            //        {
            //            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
            //        }

            //        ColumnText.ShowTextAligned(stamper.GetOverContent(1), Element.ALIGN_TOP, new Phrase(text, blackFont),500f, 100f, 0);

            //    }
            //    bytes = stream.ToArray();
            //}
            //File.WriteAllBytes(path, bytes);


            PdfReader reader = new PdfReader(bytes);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // PDFStamper is the class we use from iTextSharp to alter an existing PDF.

                PdfStamper pdfStamper = new PdfStamper(reader, memoryStream);
                int pnum = Convert.ToInt16(PageNum.Text);
                BaseFont font = BaseFont.CreateFont(); // Helvetica, WinAnsiEncoding


                PdfContentByte overContent = pdfStamper.GetOverContent(pnum);
                for (int i = 0; i < reader.NumberOfPages; ++i)
                {
                    overContent.SaveState();
                    overContent.BeginText();
                    overContent.SetFontAndSize(font, 12.0f);
                    overContent.SetTextMatrix(xLoc, yLoc);

                    //overContent.ShowText(text);
                    overContent.NewlineShowText(text);
                    // ColumnText.ShowTextAligned(pdfStamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
                    overContent.EndText();
                    doctext.Text = "";
                    PageNum.Text = "";
                    overContent.RestoreState();

                }

                // pdfStamper.Close();
                for (int i = 1; i <= reader.NumberOfPages; i++)                                                     // Must start at 1 because 0 is not an actual page.
                {
                    //           //Open the document for writing
                    //    iTextSharp.text.Rectangle pageSize = reader.GetPageSizeWithRotation(i);
                    //    iTextSharp.text.Phrase phrase = new iTextSharp.text.Phrase();
                    PdfContentByte pdfPageContents = pdfStamper.GetUnderContent(pnum);

                    pdfPageContents.BeginText();
                    // Start working with text.
                    //    iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(130, 635, 230, 650);
                    //    float[] quadPoints = { rect.Left, rect.Bottom, rect.Right, rect.Bottom, rect.Left, rect.Top, rect.Right, rect.Top };
                    //    PdfAnnotation highlight = PdfAnnotation.CreateMarkup(pdfStamper.Writer, rect, null, PdfAnnotation.MARKUP_HIGHLIGHT, quadPoints);
                    //    highlight.Color = BaseColor.GREEN;
                    //    pdfStamper.AddAnnotation(highlight, 1);
                    //    Chunk c = new Chunk(@"\n", blackFont);
                    //    Phrase p = new Phrase();

                    //    // Create a font to work with 
                    //    //
                    //    BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, Encoding.ASCII.EncodingName, false);
                    //    pdfPageContents.SetFontAndSize(baseFont, 12);                                                     // 12 point font
                    //    pdfPageContents.SetRGBColorFill(0, 0, 255);                                                     // Sets the color of the font, RED in this instance

                    ColumnText.ShowTextAligned(pdfStamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);


                    pdfPageContents.EndText();                                                                          // Done working with text
                }

                pdfStamper.FormFlattening = true;                                                                      // enable this if you want the PDF flattened. 
                pdfStamper.Close();                                                                                    // Always close the stamper or you'll have a 0 byte stream. 

                bytes = memoryStream.ToArray();
                File.WriteAllBytes(path, bytes);
                docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path;
                docPreview.Visible = true;

            }
            count++;
        }
    }
}