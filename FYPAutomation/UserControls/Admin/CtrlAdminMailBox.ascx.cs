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


namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlAdminMailBox : System.Web.UI.UserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "Faculty//";
        private const string FacultyDocUrl = "/Faculty/";
        //string file = HttpContext.Current.Server.MapPath("~/App_Data/");
        private const string FilePath = "filePath";
        long currentid = FYPSession.GetLoggedUser().UserId;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !asyEmailUploadFile.IsInFileUploadPostBack)
            {
                PopulateMailContentPC();
                populateproject();
                PopupPanel.Visible = false;
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
                            where x.RoleId == 3 && com.Message_To ==  currentid
                            orderby com.ReceivedDate descending
                            select new
                            {
                                COMID=com.COMId,
                                EmailSubject = com.EmailSubject,
                                Message_Content = com.Message_Content,
                                File_Attached = com.File_Attached
                            };
                GvdViewAllMails.DataSource = query.ToList();
                GvdViewAllMails.DataBind();

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
                                       COMID=com.COMId,
                                       EmailSubject = com.EmailSubject,
                                       Message_Content = com.Message_Content,
                                       File_Attached = com.File_Attached
                                   };
                GvdViewAllMails.DataSource = queryStudent.ToList();
                GvdViewAllMails.DataBind();
            }


        }


        private void PopulateMailContentPC()
        {
            using (var fyp = new FYPEntities())
            {
                //long id = FYPSession.GetLoggedUser().RoleId;

                var queryPC = from com in fyp.Communications
                              join u in fyp.Users
                                 on com.Message_From equals u.UId into sds

                              from x in sds.DefaultIfEmpty()
                              where (x.RoleId == 5 || x.RoleId == 2) && com.Message_To == currentid
                              orderby com.ReceivedDate descending

                              select new
                              {
                                  COMId=com.COMId,
                                  EmailSubject = com.EmailSubject,
                                  Message_Content = com.Message_Content,
                                  File_Attached = com.File_Attached
                              };
                GvdViewAllMails.DataSource = queryPC.ToList();
                GvdViewAllMails.DataBind();
            }

        }


        protected void btnPCMail_Click(object sender, EventArgs e)
        {
            PopulateMailContentPC();
            if (PopupPanel.Visible != false)
            {
                PopupPanel.Visible = true;
            }
        }

        protected void btnFacMail_Click(object sender, EventArgs e)
        {
            PopulateMailContentFac();
            if (PopupPanel.Visible != false)
            {
                PopupPanel.Visible = true;
            }
        }

        protected void btnStudentMail_Click(object sender, EventArgs e)
        {

            PopulateMailContentStudent();
            if (PopupPanel.Visible != false)
            {
                PopupPanel.Visible = true;
            }
        }
       
     
       
        protected void GvdViewAllMails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            PopupPanel.Visible = true;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GvdViewAllMails.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey == null || dataKey.Values == null)
                    return;

                long comid = Convert.ToInt64(dataKey.Values["COMId"]);
                using (var fypEntities = new FYPEntities())
                {
                    var queryStudent = (from u in fypEntities.Users
                                        join com in fypEntities.Communications
                                           on u.UId equals com.Message_From
                                        where com.COMId == comid
                                        select new
                                        {
                                            u.RoleId
                                        });

                    long rid = queryStudent.FirstOrDefault().RoleId;
                    var obj = new ObjectParameter("checkBit", 0);
                    fypEntities.SP_DeleteEmailFromCommunication(comid, obj);
                    fypEntities.SaveChanges();
                    if (rid == 3)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Email removed successfully" }, this.Page, true);
                        PopulateMailContentFac();
                    }
                    else if (rid == 4)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Email removed successfully" }, this.Page, true);
                        PopulateMailContentStudent();
                    }
                    else if (rid == 5 || rid == 2)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Email removed successfully" }, this.Page, true);
                        PopulateMailContentPC();
                    }

                    if (fypEntities.SaveChanges() <= 0)
                    {
                        FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Email could not be removed" }, this.Page, true);
                    }


                }

            }
        }
        private void ClearAll()
        {
            txtEmailTo.Text = string.Empty;
            txtEmailSubject.Text = string.Empty;
            txtEmailBody.Text = string.Empty;
            ddlprojectname.SelectedIndex = 0;
            lblStudents.Text = string.Empty;
            lblSupervisor.Text = string.Empty;
        }
        private void ResetSession()
        {
            Session[FilePath] = null;
        }
        private void populateproject()
        {
            using (var fyp = new FYPEntities())
            {
                ddlprojectname.DataSource = fyp.Projects.Where(p =>p.Status == 2 ).ToList();
                ddlprojectname.DataBind();
                ddlprojectname.Items.Insert(0, "Select Project");
            }
        }

        private void ClearIt()
        {
            lblStudents.Text = string.Empty;
        }

        protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopupPanel.Visible = true;
            if (ddlprojectname.SelectedValue != "Select Project")
            {
                ClearIt();
                long projectId = Convert.ToInt64(ddlprojectname.SelectedValue);
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
                    lblSupervisor.Text = "Supervisor:  " + namesup + "<br />" + "Group Members:  " ;
                    
                    for (int i = 0; i < resultstudents.Count; i++ )
                    {

                        lblStudents.Text += resultstudents[i].Name + "<br/>";

                    }
                        lblSupervisor.Visible = true;
                        lblStudents.Visible = true;
                    
                }

            }
            else
            {
                lblSupervisor.Visible = false;
                lblStudents.Visible = false;
            }
           
            
        }
        
        

        protected void btnEmailSend_Click(object sender, EventArgs e)
        {
            long projectId = 0;
            string filepath = "path";
            if (txtEmailTo.Text == string.Empty)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please enter atleast one recipient." }, this.Page, true);
                PopupPanel.Visible = true;
            }
            else
            {
                using (var fyp = new FYPEntities())
                {
                    
                    long message_From = FYPSession.GetLoggedUser().UserId;
                     var user = fyp.Users.FirstOrDefault(usr => (usr.Email.Equals(txtEmailTo.Text)));
                    if (user != null)
                    {
                        long message_To = user.UId;
                        string uname = user.Name;
                        string subject = txtEmailSubject.Text;
                        string body = txtEmailBody.Text;
                        bool readstatus = false;

                        if (Session[FilePath] != null)
                            filepath = Session[FilePath].ToString();
                        if (ddlprojectname.SelectedValue != "Select Project")
                        {
                            projectId = Convert.ToInt64(ddlprojectname.SelectedValue);

                            fyp.SP_Communication(message_From, message_To, subject, body, readstatus, projectId, filepath);
                        }
                        else
                        {
                            fyp.SP_Communication(message_From, message_To, subject, body, readstatus, null, filepath);

                        }
                        if (fyp.SaveChanges() >= 0)
                        {
                            MailMessage Mailmessage = new MailMessage("ahmadahsan4574@gmail.com", txtEmailTo.Text);

                            StringBuilder MailBody = new StringBuilder();
                            MailBody.Append("Dear " + uname + ",<br/><br/>");
                            if (ddlprojectname.SelectedIndex != 0)
                            {
                                MailBody.Append("Supervisor:  " + lblSupervisor.Text + "Group Members:  " + lblStudents.Text + "<br/><br/>");
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
                            PopupPanel.Visible = true;
                            ClearAll();
                            ResetSession();

                        }
                        else
                        {
                            FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Email could not be send to" + "<br/>" + uname }, this.Page, true);
                            PopupPanel.Visible = true;
                        }
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Error!", new List<string>() { "Email does not exists!" }, this.Page, true);
                        PopupPanel.Visible = true;
                    }

                    
                }
            }
        }

        protected void btnComposeMail_Click(object sender, EventArgs e)
        {
            PopupPanel.Visible = true;
            from.Text = FYPSession.GetLoggedUser().Name;

        }

        protected void btnMailClose_Click(object sender, EventArgs e)
        {
            ClearAll();
            PopupPanel.Visible = false;
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

        protected void DeleteAllMail_Click(object sender, ImageClickEventArgs e)
        {
            int count = 0;
            string comid = string.Empty;
            StringCollection str = new StringCollection();
            CheckBox ch;


            for (int i = 0; i < GvdViewAllMails.Rows.Count; i++)
            {

                ch = (CheckBox)GvdViewAllMails.Rows[i].Cells[0].FindControl("chkview");
                if (ch.Checked == true)
                {
                    comid = GvdViewAllMails.Rows[i].Cells[1].Text;
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

        protected void asyEmailUploadFile_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {
                string uniqeString = FYPUtilities.FYPDate.UniqueStringFromDate() + e.FileName;
                string saveAs = _studentDoc + uniqeString;
                string savedUrl = FacultyDocUrl + uniqeString;
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

        protected void GvdViewAllMails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
               if (e.Row.RowType == DataControlRowType.DataRow)
               {
                   e.Row.Attributes.Add("onMouseOver", "this.style.cursor = 'hand';this.style.backgroundColor = 'grey';");
                    e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor = 'white';");
            //        DataControlFieldCell cid = (DataControlFieldCell)( );                  
            //        string path = "summary.aspx?id="+cid.Text;
            //        e.Row.Attributes["onclick"] = " return SelectedObjRptPopUp('" + path + "')";
               }
        }

    }
}