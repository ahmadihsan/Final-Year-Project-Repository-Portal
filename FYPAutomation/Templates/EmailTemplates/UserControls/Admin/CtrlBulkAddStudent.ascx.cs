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
    public partial class CtrlBulkAddStudent : System.Web.UI.UserControl
    {
        private readonly string _bulkUploads = ConfigurationManager.AppSettings["AllUploads"] + "Student\\";
        private const string StudentExcelData = "StudentExcelData";
        private const string BulkStudentError = "BulkStudentError";
        private const string StudentExcelValidData = "StudentExcelValidData";
        private const string StudentExcelInvalidData = "StudentExcelInvalidData";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDepartments();
                if (!afuUploader.IsInFileUploadPostBack)
                {
                    ResetSessions();
                    PopulateSessions();
                }
            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0,"Select Session");
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

            string saveAs = _bulkUploads + FYPDate.UniqueStringFromDate() + e.FileName;
            if (!Directory.Exists(_bulkUploads))
            {
                Directory.CreateDirectory(_bulkUploads);
            }
            afuUploader.SaveAs(saveAs);
            DataTable dataTable = FYPExcel.ReadExcel(saveAs).Tables[0];
            if (dataTable != null && dataTable.Rows.Count > 0 && CheckHeaders(dataTable))
            {
                Session[StudentExcelData] = dataTable;
                CheckDataSet(dataTable);
            }
            else
            {
                Session[BulkStudentError] = "Either the Excel has no data or Missing Header Information";
            }
        }

        private void ResetSessions()
        {
            Session[BulkStudentError] = null;
            Session[StudentExcelData] = null;
            Session[StudentExcelInvalidData] = null;
            Session[StudentExcelValidData] = null;
        }

        private bool CheckHeaders(DataTable dataTable)
        {
            if (dataTable.Rows[0].Table.Columns.Contains("Name") && dataTable.Rows[0].Table.Columns.Contains("Semester") && dataTable.Rows[0].Table.Columns.Contains("Email") && dataTable.Rows[0].Table.Columns.Contains("Mobile") && dataTable.Rows[0].Table.Columns.Contains("Cgpa") && dataTable.Rows[0].Table.Columns.Contains("RegistrationNo"))
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

                    if (!string.IsNullOrEmpty(dataRow["Name"].ToString()) && !string.IsNullOrEmpty(dataRow["RegistrationNo"].ToString()) && !string.IsNullOrEmpty(dataRow["Email"].ToString()) && !string.IsNullOrEmpty(dataRow["Mobile"].ToString()) && !string.IsNullOrEmpty(dataRow["Cgpa"].ToString()) && !string.IsNullOrEmpty(dataRow["Semester"].ToString()) && !duplicateEmails.Contains(email) && !existingRecords.Contains(email))
                    {
                       dataTableValid.ImportRow(dataRow);
                    }
                    else
                    {
                        dataTableInvalid.ImportRow(dataRow);
                    }
                }

                Session[StudentExcelInvalidData] = dataTableInvalid;
                Session[StudentExcelValidData] = dataTableValid;
                if (dataTableValid.Rows.Count == 0)
                    Session[BulkStudentError] = "Either there is no data or all the data invalid in the provided excel sheet";
            }

            catch (Exception ex)
            {
                Session[BulkStudentError] = ex.Message;
            }

        }

        protected void AddBulkStudent(object sender, EventArgs e)
        {
            if (Session[StudentExcelValidData]!=null)
            {
                var dtvalid = Session[StudentExcelValidData] as DataTable;
                if(dtvalid== null)
                {
                    FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
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
                                        RegistrationNo = row["RegistrationNo"].ToString(),
                                        Email = row["Email"].ToString(),
                                        MobileNumber = row["Mobile"].ToString(),
                                        Cgpa = float.Parse(row["Cgpa"].ToString()),
                                        Semester =int.Parse(row["Semester"].ToString()),
                                        ProjectSessionId = Convert.ToInt32(ddlSession.SelectedValue),
                                        Status = true,
                                        RoleId = 4,
                                        Password = FYPPasswordManager.CreatePassword()
                                    });
                    }
                    if(usr.Count!=0)
                    {
                        fypEntities.Users.AddRange(usr);
                        if(fypEntities.SaveChanges()>0)
                        {
                            FYPMessage.ShowMessage(ref lblMessage, true, "Insertion and Emailing of All Records Successful");
                            //X.Msg.Notify("Working", "Currently Emailing to the New Users").Show();
                            foreach (var uploadeduser in usr)
                            {
                                // Email Portion Goes Here
                            }
                            ResetSessions();
                        }
                        else
                        {
                            FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
                        }
                    }
                }
            }
            else
            {
                FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
            }
        }

        protected void BtnHiddenClicked(object sender, EventArgs e)
        {
           
           if(Session[BulkStudentError]!=null)
           {
               GdvBulkStudentUploadsValidData.DataSource = null;
               GdvBulkStudentUploadsValidData.DataBind();
               lblUploadedDataMessage.Text = string.Empty;
               FYPMessage.ShowMessage(ref lblMessage, false, Session[BulkStudentError].ToString());
               ResetSessions();
           }
           else
           {
               var dataTableValid = Session[StudentExcelValidData] as DataTable;
               var dataTable = Session[StudentExcelData] as DataTable;
               var dataTableInvalid = Session[StudentExcelInvalidData] as DataTable;
               GdvBulkStudentUploadsValidData.DataSource = dataTableValid;
               GdvBulkStudentUploadsValidData.DataBind();
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
            dataTable.Columns.Add(new DataColumn("Semester"));
            dataTable.Columns.Add(new DataColumn("RegistrationNo"));
            dataTable.Columns.Add(new DataColumn("Email"));
            dataTable.Columns.Add(new DataColumn("Mobile")); 
            dataTable.Columns.Add(new DataColumn("Cgpa"));
           
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if(Session[StudentExcelInvalidData]!=null)
            {
                var dt = Session[StudentExcelInvalidData] as DataTable;
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

            if (Session[StudentExcelValidData] != null)
            {
                var dt = Session[StudentExcelValidData] as DataTable;
                if (dt != null && dt.Rows.Count != 0)
                {
                    btnRegisterBulkStudent.Enabled = true;
                }
                else
                {
                    btnRegisterBulkStudent.Enabled = false;
                }

            }
            else
            {
                btnRegisterBulkStudent.Enabled = false;
                
            }
          
        }
    }
}