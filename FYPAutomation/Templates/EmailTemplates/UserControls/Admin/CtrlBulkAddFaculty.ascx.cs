using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.IO;
using FYPUtilities;
using FYPDAL;


namespace FYPAutomation.UserControls
{
    public partial class CtrlBulkAddFaculty : System.Web.UI.UserControl
    {
        private readonly string _bulkUploads = ConfigurationManager.AppSettings["AllUploads"] + "Faculty\\";
        private const string FacultyExcelData = "FacultyExcelData";
        private const string BulkFacultyError = "BulkFacultyError";
        private const string FacultyExcelValidData = "FacultyExcelValidData";
        private const string FacultyExcelInvalidData = "FacultyExcelInvalidData";
        private readonly string _emailTemplate = ConfigurationManager.AppSettings["EmailTemplates"] + "RegistrationEmail.html";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateRoles();
                PopulateDepartments();
                PopulateResearchGroup();
                if (!afuUploader.IsInFileUploadPostBack)
                {
                    ResetSessions();
                }
            }
        }

        private void PopulateResearchGroup()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlResearchGroup.DataSource = fypEntities.ResearchGroups.ToList();
                ddlResearchGroup.DataBind();
                ddlResearchGroup.Items.Insert(0, "Select ResearchGroup");
            }
        }

        private void PopulateRoles()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlRole.DataSource = fypEntities.Roles.ToList();
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "Select Role");
            }
        }
        private void PopulateDepartments()
        {
            using (var fypEntities = new FYPEntities())
            {

                ddlDepartment.DataSource = fypEntities.Departments.ToList();
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select Department");
            }
        }

        protected void AfuUploaderUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            ResetSessions();
            string uniqueStr = FYPDate.UniqueStringFromDate() + e.FileName;
            string saveAs = _bulkUploads + uniqueStr;
            if (!Directory.Exists(_bulkUploads))
            {
                Directory.CreateDirectory(_bulkUploads);
            }
            afuUploader.SaveAs(saveAs);
            DataTable dataTable = FYPExcel.ReadExcel(saveAs).Tables[0];
            if (dataTable != null && dataTable.Rows.Count > 0 && CheckHeaders(dataTable))
            {
                Session[FacultyExcelData] = dataTable;
                CheckDataSet(dataTable);
            }
            else
            {
                Session[BulkFacultyError] = "Either the Excel has no data or Missing Header Information";
            }
        }

        private void ResetSessions()
        {
            Session[BulkFacultyError] = null;
            Session[FacultyExcelData] = null;
            Session[FacultyExcelInvalidData] = null;
            Session[FacultyExcelValidData] = null;
        }

        private bool CheckHeaders(DataTable dataTable)
        {
            if (dataTable.Rows[0].Table.Columns.Contains("Name") && dataTable.Rows[0].Table.Columns.Contains("Email") && dataTable.Rows[0].Table.Columns.Contains("CiitExtension") && dataTable.Rows[0].Table.Columns.Contains("Mobile") && dataTable.Rows[0].Table.Columns.Contains("Designation"))
                return true;
            else
            {
                return false;
            }


        }
        private void CheckDataSet(DataTable dataTable)
        {
            try
            {
                var emails = new List<string>();
                var allEmails = dataTable.AsEnumerable().Select(row=>row.Field<string>("Email").Trim()).ToList();
                List<string> existingRecords;
                DataTable dataTableValid;
                DataTable dataTableInvalid;
                GeneratesColumn(out dataTableValid);
                GeneratesColumn(out dataTableInvalid);
                using (var fypEntities = new FYPEntities())
                {
                        existingRecords =
                        fypEntities.Users.Where(usr => allEmails.Contains(usr.Email)).Select(usr => usr.Email).ToList();
                }
                var duplicateEmails = allEmails.GroupBy(email=>email.ToString()).Where(email=>email.Count() > 1).Select(email=>email.Key).ToList();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string email = dataRow["Email"].ToString().Trim();
                    //changes : && !string.IsNullOrEmpty(dataRow["CiitExtension"].ToString()) 
                    if (!string.IsNullOrEmpty(dataRow["Name"].ToString()) && !string.IsNullOrEmpty(dataRow["Designation"].ToString()) && !string.IsNullOrEmpty(dataRow["Mobile"].ToString()) && !string.IsNullOrEmpty(dataRow["Email"].ToString()) && !duplicateEmails.Contains(email) && !existingRecords.Contains(email))
                    {
                       dataTableValid.ImportRow(dataRow);
                    }
                    else
                    {
                        dataTableInvalid.ImportRow(dataRow);
                    }
                }

                Session[FacultyExcelInvalidData] = dataTableInvalid;
                Session[FacultyExcelValidData] = dataTableValid;
                if (dataTableValid.Rows.Count == 0)
                    Session[BulkFacultyError] = "Either there is no data or all the data invalid in the provided excel sheet";
            }

            catch (Exception ex)
            {
                Session[BulkFacultyError] = ex.Message;
            }

        }

        protected void AddBulkFaculty(object sender, EventArgs e)
        {
            if (Session[FacultyExcelValidData]!=null)
            {
                var dtvalid = Session[FacultyExcelValidData] as DataTable;
                if(dtvalid== null)
                {
                    FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
                    //FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
                    return;
                }
                using (var fypEntities = new FYPEntities())
                {
                    
                    var usr = new List<User>();
                    foreach (DataRow row in dtvalid.Rows)
                    {
                        usr.Add(new User()
                                    {
                                        DepartmentId = int.Parse(ddlDepartment.SelectedValue),
                                        Name = row["Name"].ToString(),
                                        Email = row["Email"].ToString(),
                                        MobileNumber = row["Mobile"].ToString(),
                                        CiitExtension = row["CiitExtension"].ToString(),
                                        Designation = row["Designation"].ToString(),
                                        Status = true,
                                        RoleId = short.Parse(ddlRole.SelectedValue),
                                        ResearchId = ddlResearchGroup.SelectedIndex!=0 ? (int?)int.Parse(ddlResearchGroup.SelectedValue): null,
                                        Password = FYPPasswordManager.CreatePassword()
                                    });
                    }
                    if(usr.Count!=0)
                    {
                        fypEntities.Users.AddRange(usr);
                        if(fypEntities.SaveChanges()>0)
                        {
                            FYPMessage.ShowMessage(ref lblMessage, true, "Insertion and Emailing of All Records Successful");
                            /*FYPMessage.ShowPopUpMessage("Success Message", new List<string>() { "Insertion and Emailing of All Records Successful" }, this.Page, false);
                            X.Msg.Notify("Working", "Currently Emailing to the New Users").Show();
                            foreach (var uploadeduser in usr)
                            {
                                string body = FYPEmailManager.PopulateBody(uploadeduser.Name, "www.aaaa.com",
                                                               string.Format("Your Credentials for FYP Portal are given below : <br /><b>  User Name : {0} <br /> Password :{1}</b>", uploadeduser.Email, FYPPasswordManager.Decrypt(uploadeduser.Password)),
                                                               _emailTemplate);
                                FYPEmailManager.SendHtmlFormattedEmail(uploadeduser.Email, "FYP Portal Registraion", body);
                            }*/
                            ResetSessions();
                        }
                        else
                        {
                            FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
                            //FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
                        }
                    }
                }
            }
            else
            {
                FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
                //FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
            }
        }

        protected void BtnHiddenClicked(object sender, EventArgs e)
        {
           
           if(Session[BulkFacultyError]!=null)
           {
               GdvBulkFacultyUploadsValidData.DataSource = null;
               GdvBulkFacultyUploadsValidData.DataBind();
               lblUploadedDataMessage.Text = string.Empty;
               FYPMessage.ShowMessage(ref lblMessage, false, Session[BulkFacultyError].ToString());
               //FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { Session[BulkFacultyError].ToString() }, this.Page, false);
               ResetSessions();
           }
           else
           {
               var dataTableValid = Session[FacultyExcelValidData] as DataTable;
               var dataTable = Session[FacultyExcelData] as DataTable;
               var dataTableInvalid = Session[FacultyExcelInvalidData] as DataTable;
               GdvBulkFacultyUploadsValidData.DataSource = dataTableValid;
               GdvBulkFacultyUploadsValidData.DataBind();
               if(dataTable!=null && dataTable.Rows.Count> 0)
               {
                   lblUploadedDataMessage.Text = string.Format("Total Record Uploaded = {0} of which <b> {1} records are valid</b> and <b> {2} are invalid records </b> ", dataTable.Rows.Count, dataTableValid != null ? dataTableValid.Rows.Count : 0, dataTableInvalid != null ? dataTableInvalid.Rows.Count : 0);
               }
           }

        }
        private void GeneratesColumn(out DataTable dataTable)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Name"));
            dataTable.Columns.Add(new DataColumn("Designation"));
            dataTable.Columns.Add(new DataColumn("Email"));
            dataTable.Columns.Add(new DataColumn("Mobile")); 
            dataTable.Columns.Add(new DataColumn("CiitExtension"));
           
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if(Session[FacultyExcelInvalidData]!=null)
            {
                var dt = Session[FacultyExcelInvalidData] as DataTable;
                if(dt != null && dt.Rows.Count!=0)
                {
                    HyDownloadInvalidExcelData.Visible = true;
                }
                else
                {
                     HyDownloadInvalidExcelData.Visible = false;
                }

            }
            else
            {
                HyDownloadInvalidExcelData.Visible = false;
            }

            if (Session[FacultyExcelValidData] != null)
            {
                var dt = Session[FacultyExcelValidData] as DataTable;
                if (dt != null && dt.Rows.Count != 0)
                {
                    btnRegisterBulkFaculty.Enabled = true;
                }
                else
                {
                    btnRegisterBulkFaculty.Enabled = false;
                }

            }
            else
            {
                btnRegisterBulkFaculty.Enabled = false;
            }
          
        }
    }
}