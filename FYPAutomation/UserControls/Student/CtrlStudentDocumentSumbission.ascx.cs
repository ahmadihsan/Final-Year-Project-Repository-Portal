using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPDAL;
using FYPUtilities;
namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlStudentDocumentSumbission : System.Web.UI.UserControl
    {
        private readonly string _studentDoc = ConfigurationManager.AppSettings["AllUploads"] + "StudentDocs\\";
        private const string StudentDocUrl = "/StudentDocs/";
        private const string FilePath = "filePath";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                PopulateActiveSupervisor();        //fill dropdown list with sessions name
                PopulateMileStones();              // fill dropdown list with milse stone names               
            }
        }

        private void PopulateActiveSupervisor()                                                             //populate supervisor,students and project name
        {
            
            using (var fyp = new FYPEntities())
            {              
                    long uid =  FYPSession.GetLoggedUser().UserId;
                    if (fyp.ProjectGroups.Any(p => p.StudentId == uid))
                    {
                        long pid = fyp.ProjectGroups.Where(p => p.StudentId == uid).FirstOrDefault().ProjectId;
                        var resultsup = (from proj in fyp.Projects                                                    //join query on project and supervisor to get supervisor name
                                         join supervisor in fyp.Users on proj.ProposedBy equals supervisor.UId
                                         where proj.PId == pid
                                         select new
                                         {
                                             supervisor.Name
                                         });
                        var projectName = (from proj in fyp.Projects                                                    //select project name from projects table
                                           where proj.PId == pid
                                           select new
                                           {
                                               proj.Tiltle
                                           });
                        lblSup.Text = resultsup.FirstOrDefault().Name;
                        lblProjects.Text = projectName.FirstOrDefault().Tiltle;
                        btnSumbitDoc.Enabled = true;
                        ddlMileStone.Enabled = true;
                        asyUploadFile.Enabled = true;
                    }
                    else
                    {
                        FYPUtilities.FYPMessage.ShowPopUpMessage("Notice!",
                                                                       new List<string>()
                                                                         {
                                                                             "Project is not assigned!"
                                                                         }, this.Page, true);
                        btnSumbitDoc.Enabled = false;
                        ddlMileStone.Enabled = false;
                        asyUploadFile.Enabled = false;
                        lblSup.Text = string.Empty;
                        lblProjects.Text = string.Empty;
                        return;
                    }
            }
        }

      
       private void PopulateMileStones()                //method in which milestone names are populated in ddl
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                ddlMileStone.DataBind();
                ddlMileStone.Items.Insert(0, "Select MileStone");
            }
        }
       private void clearAll()
       {
           ddlMileStone.SelectedIndex=0;
       }
       protected void SubmitDocument(object sender, EventArgs e)
        {
            long pId = 0;
            long supId = 0;
            long msId = 0;
            long upby = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            if( long.TryParse(ddlMileStone.SelectedValue,out msId))
            {
                using (var fypEntities = new FYPEntities())
                {
                      pId = fypEntities.ProjectGroups.Where(p => p.StudentId == upby).FirstOrDefault().ProjectId;
                     var resultsup = (from proj in fypEntities.Projects                                                    //join query on project and supervisor to get supervisor name
                                     join supervisor in fypEntities.Users on proj.ProposedBy equals supervisor.UId
                                     where proj.PId == pId
                                     select new
                                     {
                                         supervisor.UId
                                     });

                     supId = resultsup.FirstOrDefault().UId;
                    string url = Session[FilePath].ToString();
                   
                    if(fypEntities.SupervisodBies.Any(sup=>sup.ProjectId==pId && sup.SupervisodBy1==supId) )
                    {
                        fypEntities.SP_SubmitDocByStudent(msId,pId,supId,url,upby);

                        FYPUtilities.FYPMessage.ShowPopUpMessage("Submit Info ",
                                                                new List<string>()
                                                                         {
                                                                             "Document Submitted Successfully"
                                                                         }, this.Page, true);
                        clearAll();
                        
                       
                    }
                    else
                    {
                        FYPUtilities.FYPMessage.ShowPopUpMessage("Sorry",
                                                                 new List<string>()
                                                                         {
                                                                             "Only Students of this project can submit document"
                                                                         }, this.Page, true);
                    }
                }
            }
        
            else
            {
                FYPUtilities.FYPMessage.ShowPopUpMessage("Sorry",
                                                                 new List<string>()
                                                                     {
                                                                         "Form Values are Changed"
                                                                     }, this.Page, true);
            }
      
              }
       
    
       protected void AsyncDocumentUpload(object sender, AjaxFileUploadEventArgs e) // Event handler for uploding document
        {
            try
            {
                string uniqeString = FYPUtilities.FYPDate.UniqueStringFromDate() + e.FileName;   // save file name with formate in string
                string saveAs = _studentDoc + uniqeString;
                string savedUrl = StudentDocUrl + uniqeString;
                if (!Directory.Exists(_studentDoc)) // check docs directry
                {
                    Directory.CreateDirectory(_studentDoc);
                }
                asyUploadFile.SaveAs(saveAs);// save files 
                Session[FilePath] = savedUrl;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        protected void DdlMileStoneSelectedIndexChanged(object sender, EventArgs e)  // event handler to check submition of document
        {
            long pId = 0;
            if (ddlMileStone.SelectedIndex == 0)
                return;
                  
            long msId = Convert.ToInt64(ddlMileStone.SelectedValue);
            long upby = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            var opStatus = new ObjectParameter("Status", 0);
            using (var fyp = new FYPEntities())
            {
                pId = fyp.ProjectGroups.Where(p => p.StudentId == upby).FirstOrDefault().ProjectId;
             
                fyp.SP_CheckMileStoneSubmission(pId, msId, opStatus);
                if (Convert.ToBoolean(opStatus.Value))
                {
                    FYPUtilities.FYPMessage.ShowPopUpMessage("Already Submitted",
                                                             new List<string>() { "You have already submitted this mile stone" },
                                                             this.Page, true);
                    asyUploadFile.Enabled = false;
                    btnSumbitDoc.Enabled = false;
                   // PopulateGrid();                  // student can not view others files 
                }
                else
                {
                    btnSumbitDoc.Enabled = true;
                    asyUploadFile.Enabled = true;
                }
            }
        }
       

        //private void PopulateGrid()
        //{
        //    using (var fyp = new FYPEntities())
        //    {
        //        long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
        //        GvdViewDocumentSumbitted.DataSource = (from docs in fyp.SP_GetDataForGridStudent(uId)
        //                                               where docs.ReadStatus == false
        //                                               select new
        //                                                          {
        //                                                              docs.Name,
        //                                                              docs.SubmittedDate,
        //                                                              docs.UMSDId,
        //                                                              docs.ProjectId,
        //                                                              docs.InCustody,
        //                                                              docs.ReadStatus,
        //                                                              docs.EvalStatus,
        //                                                              docs.UploadedFile,
        //                                                              docs.Tiltle
        //                                                          }).ToList();
        //        GvdViewDocumentSumbitted.DataBind();

        //    }
        //}
        

        //protected void GvdViewDocumentSumbittedPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GvdViewDocumentSumbitted.PageIndex = e.NewPageIndex;
        //    PopulateGrid();
        //}
    }
}