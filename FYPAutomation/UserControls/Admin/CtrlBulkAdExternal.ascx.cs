using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data;
using FYPUtilities;
using AjaxControlToolkit;
using FYPDAL;
namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlBulkAdExternal : System.Web.UI.UserControl
    {
        private readonly string _bulkUploads = ConfigurationManager.AppSettings["AllUploads"] + "External\\";
        private const string ExternalExcelData = "ExternalExcelData";
        private const string BulkExternalError = "BulkExternalError";
        private const string ExternalExcelValidData = "ExternalExcelValidData";
        private const string ExternalExcelInvalidData = "ExternalExcelInvalidData";
        private readonly string _emailTemplate = ConfigurationManager.AppSettings["EmailTemplates"] + "RegistrationEmail.html";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateRoles();
                PopulateDepartments();

                if (!afuUploader.IsInFileUploadPostBack)
                {
                    ResetSessions();
                }
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
        protected void afuUploader_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
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
                Session[ExternalExcelData] = dataTable;
                CheckDataSet(dataTable);
            }
            else
            {
                Session[BulkExternalError] = "Either the Excel has no data or Missing Header Information";
            }

        }
        private void ResetSessions()
        {
            Session[BulkExternalError] = null;
            Session[ExternalExcelData] = null;
            Session[ExternalExcelInvalidData] = null;
            Session[ExternalExcelValidData] = null;
        }
        private bool CheckHeaders(DataTable dataTable)
        {
            if (dataTable.Rows[0].Table.Columns.Contains("Name") && dataTable.Rows[0].Table.Columns.Contains("Email") && dataTable.Rows[0].Table.Columns.Contains("E_CNIC") && dataTable.Rows[0].Table.Columns.Contains("MobileNumber") && dataTable.Rows[0].Table.Columns.Contains("E_Specialization") && dataTable.Rows[0].Table.Columns.Contains("E_ContactAddresss") && dataTable.Rows[0].Table.Columns.Contains("E_Office"))
            {
                return true;
            }
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
                var allEmails = dataTable.AsEnumerable().Select(row => row.Field<string>("Email").Trim()).ToList();
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
                var duplicateEmails = allEmails.GroupBy(email => email.ToString()).Where(email => email.Count() > 1).Select(email => email.Key).ToList();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string email = dataRow["Email"].ToString().Trim();
                    //changes : && !string.IsNullOrEmpty(dataRow["CiitExtension"].ToString()) 
                    if (!string.IsNullOrEmpty(dataRow["Name"].ToString()) && !string.IsNullOrEmpty(dataRow["Email"].ToString()) && !string.IsNullOrEmpty(dataRow["MobileNumber"].ToString()) && !string.IsNullOrEmpty(dataRow["E_Specialization"].ToString()) && !string.IsNullOrEmpty(dataRow["E_ContactAddresss"].ToString()) && !string.IsNullOrEmpty(dataRow["E_Office"].ToString()) && !string.IsNullOrEmpty(dataRow["E_CNIC"].ToString()) && !duplicateEmails.Contains(email) && !existingRecords.Contains(email))
                        

                    {
                        dataTableValid.ImportRow(dataRow);
                    }
                    else
                    {
                        dataTableInvalid.ImportRow(dataRow);
                    }
                }

                Session[ExternalExcelInvalidData] = dataTableInvalid;
                Session[ExternalExcelValidData] = dataTableValid;
                if (dataTableValid.Rows.Count == 0)
                    Session[BulkExternalError] = "Either there is no data or all the data invalid in the provided excel sheet";
            }

            catch (Exception ex)
            {
                Session[BulkExternalError] = ex.Message;
            }

        }
        private void GeneratesColumn(out DataTable dataTable)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Name"));
            dataTable.Columns.Add(new DataColumn("Email"));
            dataTable.Columns.Add(new DataColumn("E_CNIC"));
            dataTable.Columns.Add(new DataColumn("MobileNumber"));
            dataTable.Columns.Add(new DataColumn("E_Specialization"));
            dataTable.Columns.Add(new DataColumn("E_ContactAddresss"));
            dataTable.Columns.Add(new DataColumn("E_Office"));

        }

        protected void btnHidden_Click(object sender, EventArgs e)
        {

            if (Session[BulkExternalError] != null)
            {
                GdvBulkExternalUploadsValidData.DataSource = null;
                GdvBulkExternalUploadsValidData.DataBind();
                lblUploadedDataMessage.Text = string.Empty;
                FYPMessage.ShowMessage(ref lblMessage, false, Session[BulkExternalError].ToString());

                ResetSessions();
            }
            else
            {
                var dataTableValid = Session[ExternalExcelValidData] as DataTable;
                var dataTable = Session[ExternalExcelData] as DataTable;
                var dataTableInvalid = Session[ExternalExcelInvalidData] as DataTable;
                GdvBulkExternalUploadsValidData.DataSource = dataTableValid;
                GdvBulkExternalUploadsValidData.DataBind();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    lblUploadedDataMessage.Text = string.Format("Total Record Uploaded = {0} of which <b> {1} records are valid</b> and <b> {2} are invalid records </b> ", dataTable.Rows.Count, dataTableValid != null ? dataTableValid.Rows.Count : 0, dataTableInvalid != null ? dataTableInvalid.Rows.Count : 0);
                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session[ExternalExcelInvalidData] != null)
            {
                var dt = Session[ExternalExcelInvalidData] as DataTable;
                if (dt != null && dt.Rows.Count != 0)
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

            if (Session[ExternalExcelValidData] != null)
            {
                var dt = Session[ExternalExcelValidData] as DataTable;
                if (dt != null && dt.Rows.Count != 0)
                {
                    btnRegisterBulkExternal.Enabled = true;
                }
                else
                {
                    btnRegisterBulkExternal.Enabled = false;
                }

            }
            else
            {
                btnRegisterBulkExternal.Enabled = false;
            }

        }

        protected void btnRegisterBulkExternal_Click(object sender, EventArgs e)
        {
            if (Session[ExternalExcelValidData] != null)
            {
                var dtvalid = Session[ExternalExcelValidData] as DataTable;
                if (dtvalid == null)
                {
                    //FYPMessage.ShowMessage(ref lblMessage, false, "No Valid Records to Upload");
                    FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
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
                            E_CNIC = row["E_CNIC"].ToString(),
                            MobileNumber = row["MobileNumber"].ToString(),
                            E_Specialization = row["E_Specialization"].ToString(),
                            E_ContactAddresss = row["E_ContactAddresss"].ToString(),
                            E_Office = row["E_Office"].ToString(),
                            Status = true,
                            RoleId = short.Parse(ddlRole.SelectedValue),

                            Password = FYPPasswordManager.Encrypt("evaluate")
                        });
                    }
                    if (usr.Count != 0)
                    {
                        fypEntities.Users.AddRange(usr);
                        if (fypEntities.SaveChanges() > 0)
                        {
                            FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Insertion and Emailing of All Records Successful" }, this.Page, true);

                            ResetSessions();
                        }
                        else
                        {
                            FYPMessage.ShowPopUpMessage("Success Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
                        }
                    }
                }
            }
            else
            {
                FYPMessage.ShowPopUpMessage("Error Message", new List<string>() { "No Valid Records to Upload" }, this.Page, false);
            }
        }

    }
}