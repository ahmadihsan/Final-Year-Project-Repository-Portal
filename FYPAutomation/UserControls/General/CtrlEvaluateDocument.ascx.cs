
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
    public partial class CtrlEvaluateDocument : System.Web.UI.UserControl
    {

        private string _studentDoc = ConfigurationManager.AppSettings["AllUploads"];
        object Unknown = Type.Missing;          // For passing Empty values

        public string basepath = "http://localhost:58919/";
        public string Message = string.Empty;           // To store the Error or Message
        private Microsoft.Office.Interop.Word.Application Word;     // The Interop Object for Word
        int count=0;
        public enum StatusType { SUCCESS, FAILED };     // To Specify Success or Failure Types
        public StatusType Status;                       // To know the Current Status
        private const string FilePath = "filepath";
        float xLoc = 100f;
        float yLoc = 200f;
        string empty = "";
       
        StringBuilder text = new StringBuilder();

        private string filepath = "htlmpath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                lblddlMilstone.Text = Request.QueryString["MileName"].ToString();
                PopulateProjectInfo();
                ddlDocumentSelection.Items.Insert(0, "Select Document");
                PopulateDocument();
                PopulateImageName();
                BindTotal(lblddlMilstone.Text);
            }

        }

        private void PopulateImageName()
        {

            ddlImageName.Items.Insert(0, "Select Image Name");
            ddlImageName.Items.Insert(1, "Tick Image");
            ddlImageName.Items.Insert(2, "Cross Image");

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
       
        protected void BtnSubmitEvaluation(object sender, EventArgs e)
        {
            //int count = 0;
            long pmsid = 0;
            long uid = FYPSession.GetLoggedUser().UserId;
            string id = string.Empty;
            using (var fyp = new FYPEntities())
            {
                var msid = fyp.ProjectMileStones.Where(p => p.Name == lblddlMilstone.Text).FirstOrDefault().PMSId;
                pmsid = Convert.ToInt32(msid);
            }
            string verdict = string.Empty;
            var result = string.Empty;
            double ObtainMarks = 0;
            if (Request.QueryString["PId"].ToString() != null)
            {
                id = Request.QueryString["PId"].ToString();
                long pid = Convert.ToInt32(id);
                if (  txtObtainMarks.Text != "" && rbtnVerdict.SelectedIndex != -1)
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

                        long roleid = FYPSession.GetLoggedUser().RoleId;
                        var lstStudents = fyp.SP_GetProjectStudentsWithId(pid).ToList();
                        var lstMse = new List<MileStoneEvaluation>();
                        string url = Session[filepath].ToString();
                        lbltotal.Text = fyp.ProjectMileStones.Where(p => p.PMSId == pmsid).FirstOrDefault().MileStoneMarks.ToString();
                         var resultsup = (from proj in fyp.Projects                                                    //join query on project and supervisor to get supervisor name
                                     join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                     where proj.PId == pid
                                     select new
                                     {
                                         supervisor.UId
                                     });
                       

                        
                        foreach (var lstStd in lstStudents)
                        {
                            if (comment != null)
                            {
                                var mse = new MileStoneEvaluation();
                                mse.ComentedDate = DateTime.Now;
                                if (roleid == 5)
                                {
                                    mse.CommentedBy = uid;
                                    mse.CommentByPC = result;
                                    mse.ObtainMarks = ObtainMarks;
                                    
                                }
                                else if (roleid == 2)
                                {
                                    mse.CommentedBy = uid;
                                    mse.CommentedByPCHead = result;
                                    mse.ObtainMarks = ObtainMarks;
                                }
                                else if (roleid == 1)
                                {
                                    mse.CommentedBy = uid;
                                    mse.CommentByHead = result;
                                    mse.ObtainMarks = ObtainMarks;
                                }
                                else if (roleid == 3)
                                {
                                    mse.CommentedBy = uid;
                                    mse.CommentBySupervisor = result;
                                    mse.ObtainMarks = ObtainMarks;
                                }
                                else if (roleid == 8)
                                {
                                    mse.CommentedBy = uid;
                                    mse.CommentByExternal = result;
                                    mse.ObtainMarks = ObtainMarks;
                                }
                                mse.StudentId = lstStd.UId;
                                mse.PMSId = pmsid;
                                mse.ProjectId = pid;
                                if (txtCommentProj != null) mse.CommentByPcAboutProject = txtCommentProj.InnerText;
                                mse.IsVisibletToStudent = true;
                                lstMse.Add(mse);
                            }
                        }
                        var umsid = fyp.UploadedMileStones.Where(p => p.PMSId == pmsid && p.ProjectId == pid && p.SupervisorId == resultsup.FirstOrDefault().UId).FirstOrDefault().UMSId;
                        long umsid1 = Convert.ToInt32(umsid);
                        var umsdid = fyp.UploadedMileStoneDocs.Where(p => p.UMSId == umsid1 && p.InCustody == uid && p.CustodyHistory == true).FirstOrDefault().UMSDId;
                        long umsdid1 = Convert.ToInt32(umsdid);

                        if (lstMse.Count != 0)
                        {
                           
                             
                            fyp.MileStoneEvaluations.AddRange(lstMse);
                            
                            fyp.SP_SubmitDocumentByPcMemberAfterCheck(umsid1,url,empty, umsdid1, uid);
                           
                           
                        }
                        
                        if (fyp.SaveChanges() >= 0)
                        {
                            
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Comments Added Successfully" }, this.Page, true);
                            clearfields();
                            long rId = fyp.Users.Where(p => p.UId == uid).FirstOrDefault().RoleId;
                            var evalstatus = fyp.UploadedMileStoneDocs.Where(q => q.UMSId == umsid1 && q.InCustody == uid && q.CustodyHistory == true).FirstOrDefault().EvalStatus;
                            long est = Convert.ToInt64(evalstatus);
                            if (rId == 1)
                            {
                                Response.Redirect("~/Pages/Admin/EvaluateProjects.aspx?EvalSt=" + est);
                            }
                            else if (rId == 2)
                            {
                                Response.Redirect("~/Pages/Convener/EvaluateProjects.aspx?EvalSt=" + est);
                            }
                            else if (rId == 5)
                            {
                                Response.Redirect("~/Pages/PCMember/EvaluateProjectsPC.aspx?EvalSt=" + est);
                            }
                            else if (rId == 8)
                            {
                                Response.Redirect("~/Pages/External/EvaluateProjects.aspx?EvalSt=" + est);
                            }

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
                if (Request.QueryString["PId"] != null)
                {
                    if (lblddlMilstone.Text != "")
                    {
                        var Msid = fyp.ProjectMileStones.Where(p => p.Name == lblddlMilstone.Text).ToList();
                        long Pmsid = Msid.FirstOrDefault().PMSId;
                        string id = (Request.QueryString["PId"].ToString());
                        long pid = Convert.ToInt32(id);
                        ddlDocumentSelection.DataSource = fyp.UploadedMileStones.Where(p => p.PMSId == Pmsid && p.ProjectId == pid).ToList();
                        ddlDocumentSelection.DataBind();
                        ddlDocumentSelection.Items.Insert(0, "Select Document");

                    }



                }
                else
                {
                    FYPMessage.ShowPopUpMessage("Error!", new List<string>() { "No Project Is Available." }, this.Page, true);
                }


            }
        }
        private void PopulateProjectInfo()                                                              //populate supervisor,students and project name
        {
            using (var fyp = new FYPEntities())
            {
                string id = string.Empty;
                if (Request.QueryString["PId"] != null)
                {
                    id = (Request.QueryString["PId"].ToString());
                    long pid = Convert.ToInt32(id);
                    var resultsup = (from proj in fyp.Projects                                                    //join query on project and supervisor to get supervisor name
                                     join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                     where proj.PId == pid
                                     select new
                                     {
                                         supervisor.Name
                                     });

                    var resultstudents = (from proj in fyp.ProjectGroups                                            //join query on projectGroup and Users to et Group of students
                                          join student in fyp.Users on proj.StudentId equals student.UId
                                          where proj.ProjectId == pid
                                          select new
                                          {
                                              student.Name
                                          }).ToList();

                    var projectName = (from proj in fyp.Projects                                                    //select project name from projects table
                                       where proj.PId == pid
                                       select new
                                       {
                                           proj.Tiltle
                                       });
                    string proname = projectName.FirstOrDefault().Tiltle;
                    lblProjectTitle.Text = proname + "<br />";
                    string namesup = resultsup.FirstOrDefault().Name;                                               //display of supervisor name
                    lblSuperviserName.Text = namesup + "<br />";

                    for (int i = 0; i < resultstudents.Count; i++)                                                  //display all groupmembers name from list
                    {
                        lblGroupMembers.Text += resultstudents[i].Name + "<br/>";
                    }
                    lblSuperviserName.Visible = true;
                    lblGroupMembers.Visible = true;

                }
            }
        }

        protected void ddlDocumentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ddlDocumentSelection.SelectedValue.ToString() != "Select Document")
            {
                string strFilePath = _studentDoc;
                string strFile = ddlDocumentSelection.SelectedItem.Text;
                //string[] File = strFile.Split('.');
                //string strExtension = File[0].ToString();
                //string strUrl = "http://" + Request.Url.Authority + "/" + Server.MapPath("~/AllUploads");                                 // 


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
                    Session[filepath] = strFile.Split('.')[0] + ".pdf";
                    docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path; 
                    docPreview.Visible = true;
                    Session[FilePath] = path;
                }
                else if(ext == ".pdf")
                {
                    string path = strFilePath + strFile;
                    docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path; 
                    docPreview.Visible = true;
                    Session[FilePath] = path;
                    Session[filepath] = strFile;
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

        protected void AddText_Click(object sender, EventArgs e)
        {
            if (ddlDocumentSelection.SelectedIndex == 0)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Open Document First." }, this.Page, true);
                return;
            }
            if (PageNum.Text == "")
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Specify Page Number." }, this.Page, true);
                return;
            }
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

        protected void AddImage_Click(object sender, EventArgs e)
        {
            string imageFileName = string.Empty;
            if (ddlDocumentSelection.SelectedIndex == 0)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Open Document First" }, this.Page, true);
                return;
            }
            if (ddlImageName.SelectedIndex == 0)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Select Image Name" }, this.Page, true);
                return;
            }
            if (PageNum.Text == "")
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Specify Page Number" }, this.Page, true);
                return;
            }

            if (ddlImageName.SelectedItem.Text == "Tick Image")
            {
                imageFileName = Server.MapPath("~/Images/DashBoardImages/TickImage.png").ToString();
            }
            else if (ddlImageName.SelectedItem.Text == "Cross Image")
            {
                imageFileName = Server.MapPath("~/Images/DashBoardImages/CrossImage.png").ToString();
            }
            string path = Session[FilePath].ToString();
            byte[] bytes = File.ReadAllBytes(path);
            int pnum = Convert.ToInt16(PageNum.Text);
            iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //using (Stream imageStream = new FileStream(imageFileName, FileMode.Open))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfReader pdfReader = new PdfReader(bytes);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
                PdfContentByte pdfContentByte = pdfStamper.GetOverContent(pnum);
                for (int i = 0; i < pdfReader.NumberOfPages; ++i)
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFileName);
                    image.SetAbsolutePosition(575, 500);
                    pdfContentByte.AddImage(image);
                }
                pdfStamper.Close();

                // Always close the stamper or you'll have a 0 byte stream. 

                bytes = memoryStream.ToArray();
                File.WriteAllBytes(path, bytes);
                docPreview.Attributes["src"] = "~/Pages/FilesData.ashx?htmlFilePath=" + path;
                docPreview.Visible = true;
            }
        }
    }
}