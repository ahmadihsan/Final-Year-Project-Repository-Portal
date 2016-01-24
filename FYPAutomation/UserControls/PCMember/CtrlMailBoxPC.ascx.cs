using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using System.Collections.Specialized;
using System.Net.Mail;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.PCMember
{
    public partial class CtrlMailBoxPC : System.Web.UI.UserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";
        long currentid = FYPSession.GetLoggedUser().UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !asyEmailUploadFile.IsInFileUploadPostBack)
            {
                PopulateMailContentStudent();
                populateproject();
                PopupPanelPC.Visible = false;
            }
            
        }

        private void populateproject()
        {
            using (var fyp = new FYPEntities())
            {
                ddlprojectnamePC.DataSource = fyp.Projects.Where(p => p.Status == 2).ToList();
                ddlprojectnamePC.DataBind();
                ddlprojectnamePC.Items.Insert(0, "Select Project");
            }
        }

        private void PopulateMailContentFac()
        {
            using (var fyp = new FYPEntities())
            {
                var query = from com in fyp.Communications
                            join u in fyp.Users
                               on com.Message_From equals u.UId into sr

                            from x in sr.DefaultIfEmpty()
                            where x.RoleId == 3 && com.Message_To == currentid
                            orderby com.ReceivedDate descending

                            select new
                            {
                                COMID = com.COMId,
                                EmailSubject = com.EmailSubject,
                                Message_Content = com.Message_Content,
                                File_Attached = com.File_Attached
                            };
                GvdViewAllMailsPC.DataSource = query.ToList();
                GvdViewAllMailsPC.DataBind();

            }

        }

        private void PopulateMailContentAdmin()
        {
            using (var fyp = new FYPEntities())
            {

                var queryPC = from com in fyp.Communications
                              join u in fyp.Users
                                 on com.Message_From equals u.UId into sds

                              from x in sds.DefaultIfEmpty()
                              where (x.RoleId == 1) && com.Message_To == currentid
                              orderby com.ReceivedDate descending

                              select new
                              {
                                  COMId = com.COMId,
                                  EmailSubject = com.EmailSubject,
                                  Message_Content = com.Message_Content,
                                  File_Attached = com.File_Attached
                              };
                GvdViewAllMailsPC.DataSource = queryPC.ToList();
                GvdViewAllMailsPC.DataBind();
            }
        }

        private void PopulateMailContentStudent()
        {
            using (var fyp = new FYPEntities())
            {

                var queryStudent = from com in fyp.Communications
                                   join u in fyp.Users
                                      on com.Message_From equals u.UId into srs

                                   from x in srs.DefaultIfEmpty()
                                   where x.RoleId == 4 && com.Message_To == currentid
                                   orderby com.ReceivedDate descending

                                   select new
                                   {
                                       COMID = com.COMId,
                                       EmailSubject = com.EmailSubject,
                                       Message_Content = com.Message_Content,
                                       File_Attached = com.File_Attached
                                   };
                GvdViewAllMailsPC.DataSource = queryStudent.ToList();
                GvdViewAllMailsPC.DataBind();
            }


        }

        private void DeleteRecords(StringCollection sc)
        {
            long cmid = 0;
            var obj = new ObjectParameter("checkBit", 0);
            using (var fyp = new FYPEntities())
            {
                foreach (var item in sc)
                {
                    cmid = Convert.ToInt64(item);
                    fyp.SP_DeleteEmailFromCommunication(cmid, obj);
                }
            }
        }

        private void ClearAll()
        {
            txtEmailToPC.Text = string.Empty;
            txtEmailSubjectPC.Text = string.Empty;
            txtEmailBodyPC.Text = string.Empty;
            ddlprojectnamePC.SelectedIndex = 0;
            lblStudentsPC.Text = string.Empty;
            lblSupervisorPC.Text = string.Empty;
        }
        private void ResetSession()
        {
            Session[FilePath] = null;
        }

        private void ClearIt()
        {
            lblStudentsPC.Text = string.Empty;
        }

        protected void asyEmailUploadFile_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {
                string uniqeString = FYPUtilities.FYPDate.UniqueStringFromDate() + e.FileName;
                string saveAs = _studentDoc + uniqeString;
                string savedUrl = StudentDocUrl + uniqeString;
                if (!Directory.Exists(_studentDoc))
                {
                    Directory.CreateDirectory(_studentDoc);
                }
                asyEmailUploadFile.SaveAs(saveAs);
                Session[FilePath] = savedUrl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnFacMailPC_Click(object sender, EventArgs e)
        {
            if (PopupPanelPC.Visible != false)
            {
                PopupPanelPC.Visible = true;
            }
            PopulateMailContentFac();
        }

        protected void btnAdminMailPC_Click(object sender, EventArgs e)
        {
            if (PopupPanelPC.Visible != false)
            {
                PopupPanelPC.Visible = true;
            }
            PopulateMailContentAdmin();
        }

        protected void btnStudentMailPC_Click(object sender, EventArgs e)
        {
            if (PopupPanelPC.Visible != false)
            {
                PopupPanelPC.Visible = true;
            }
            PopulateMailContentStudent();
        }

        protected void DeleteAllMailPC_Click(object sender, ImageClickEventArgs e)
        {
            int count = 0;
            string comid = string.Empty;
            StringCollection str = new StringCollection();
            CheckBox ch;


            for (int i = 0; i < GvdViewAllMailsPC.Rows.Count; i++)
            {

                ch = (CheckBox)GvdViewAllMailsPC.Rows[i].Cells[0].FindControl("chkviewPC");
                if (ch.Checked == true)
                {
                    comid = GvdViewAllMailsPC.Rows[i].Cells[1].Text;
                    str.Add(comid);
                    count++;
                }

            }
            DeleteRecords(str);
            if (count > 0)
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { count + " Email(s) removed successfully" }, this.Page, true);
                PopulateMailContentFac();

            }
            else
            {

                FYPMessage.ShowPopUpMessage("Error", new List<string>() { " NO email removed" }, this.Page, true);

            }
        }

        protected void btnMailClosePC_Click(object sender, EventArgs e)
        {
            ClearAll();
            PopupPanelPC.Visible = false;
        }

        protected void ddlprojectnamePC_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopupPanelPC.Visible = true;
            if (ddlprojectnamePC.SelectedValue != "Select Project")
            {
                ClearIt();
                long projectId = Convert.ToInt64(ddlprojectnamePC.SelectedValue);
                using (var fyp = new FYPEntities())
                {
                    var resultsup = (from proj in fyp.Projects
                                     join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                     where proj.PId == projectId
                                     select new
                                     {
                                         supervisor.Name
                                     });

                    var resultstudents = (from proj in fyp.ProjectGroups
                                          join student in fyp.Users on proj.StudentId equals student.UId
                                          where proj.ProjectId == projectId
                                          select new
                                          {
                                              student.Name
                                          }).ToList();

                    string namesup = resultsup.FirstOrDefault().Name;
                    lblSupervisorPC.Text = "Supervisor:  " + namesup + "<br />" + "Group Members:  ";

                    for (int i = 0; i < resultstudents.Count; i++)
                    {

                        lblStudentsPC.Text += resultstudents[i].Name + "<br/>";

                    }
                    lblSupervisorPC.Visible = true;
                    lblStudentsPC.Visible = true;

                }

            }
            else
            {
                lblSupervisorPC.Visible = false;
                lblStudentsPC.Visible = false;
            }
        }

        protected void btnEmailSendPC_Click(object sender, EventArgs e)
        {
            long projectId = 0;
            if (txtEmailToPC.Text == string.Empty)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please enter atleast one recipient." }, this.Page, true);
                PopupPanelPC.Visible = true;
            }
            else
            {
                using (var fyp = new FYPEntities())
                {
                    string filepath = "path";
                    long message_From = FYPSession.GetLoggedUser().UserId;
                    long message_To = fyp.Users.FirstOrDefault(p => p.Email == txtEmailToPC.Text || p.RegistrationNo == txtEmailToPC.Text).UId;
                    string uname = fyp.Users.FirstOrDefault(p => p.Email == txtEmailToPC.Text || p.RegistrationNo == txtEmailToPC.Text).Name;
                    string subject = txtEmailSubjectPC.Text;
                    string body = txtEmailBodyPC.Text;
                    bool readstatus = false;

                    if (Session[FilePath] != null)
                        filepath = Session[FilePath].ToString();
                    if (ddlprojectnamePC.SelectedValue != "Select Project")
                    {
                        projectId = Convert.ToInt64(ddlprojectnamePC.SelectedValue);

                        fyp.SP_Communication(message_From, message_To, subject, body, readstatus, projectId, filepath);
                    }
                    else
                    {
                        fyp.SP_Communication(message_From, message_To, subject, body, readstatus, null, filepath);

                    }

                    MailMessage Mailmessage = new MailMessage("ahmadahsan4574@gmail.com", txtEmailToPC.Text);



                    if (fyp.SaveChanges() >= 0)
                    {
                        StringBuilder MailBody = new StringBuilder();
                        MailBody.Append("Dear " + uname + ",<br/><br/>");
                        if (ddlprojectnamePC.SelectedIndex != 0)
                        {
                            MailBody.Append("Supervisor:  " + lblSupervisorPC.Text + "Group Members:  " + lblStudentsPC.Text + "<br/><br/>");
                        }
                        MailBody.Append(body + "<br/>");
                        MailBody.Append("COMSATS CS Department");

                        Mailmessage.IsBodyHtml = true;
                        Mailmessage.Subject = subject;
                        Mailmessage.Body = MailBody.ToString();

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                        smtpClient.Credentials = new System.Net.NetworkCredential()
                        {
                            UserName = "ahmadahsan4574@gmail.com",
                            Password = "window8sp12"
                        };

                        smtpClient.EnableSsl = true;
                        smtpClient.Send(Mailmessage);
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Email sent successfully to" + "<br/>" + uname }, this.Page, true);
                        PopupPanelPC.Visible = true;
                        ClearAll();
                        ResetSession();

                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Email could not be send to" + "<br/>" + uname }, this.Page, true);
                        PopupPanelPC.Visible = true;
                        ResetSession();
                    }
                }
            }
        }

        protected void btnComposeMailPC_Click(object sender, EventArgs e)
        {
            PopupPanelPC.Visible = true;
            fromPC.Text = FYPSession.GetLoggedUser().Name;
        }

        
    }
}