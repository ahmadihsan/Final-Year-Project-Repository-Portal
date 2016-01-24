using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlDocumentSubmitted : FYPBaseUserControl
    {
        private long _umsid;
        private long _custodyId;
        private long _umsdid;
        private long _projectId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSessions();
                PopulateMileStones();
                PopulatePcMembers();
                PopulateGridForDocs();
                PopulateExternals();
            }
        }

        private void PopulateMileStones()
        {
            using (var fyp = new FYPEntities())
            {
                var data = fyp.ProjectMileStones.ToList();
                ddlMileStones.DataSource = data;
                ddlMileStones.DataBind();
                ddlMileStones.Items.Insert(0, "Select Milestone");
            }
        }

        private void PopulateSessions()
        {
            using (var fyp = new FYPEntities())
            {
                var data = fyp.ProjectSessions.Where(prs=>prs.Status==true).ToList();
                ddlSession.DataSource = data;
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateExternals()
        {
            using (var fyp = new FYPEntities())
            {
              DropDownListExt.DataSource = fyp.Users.Where(usr => usr.RoleId == 8).ToList();
              DropDownListExt.DataBind();
              DropDownListExt.Items.Insert(0, "Select External");
            }
        }

        private void PopulatePcMembers()
        {
            using (var fyp = new FYPEntities())
            {
                ddlPCMember.DataSource = fyp.Users.Where(usr => usr.RoleId == 5 || usr.RoleId==2 || usr.RoleId==1).ToList();
                ddlPCMember.DataBind();
                ddlPCMember.Items.Insert(0, "Select PCMember");
            }
        }


        protected void GvdViewDocumentSumbittedRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var label = e.Row.Cells[4].FindControl("Label1") as Label;
                if(label!=null)
                {
                    if (label.Text.ToLower() == "evaluated".Trim())
                    {
                        e.Row.Attributes.Add("class", "evaluated");
                    }
                    if (label.Text.ToLower() == "not evaluated".Trim())
                    {
                        e.Row.Attributes.Add("class", "notevaluated");
                    }
                }
                //var cbox = e.Row.FindControl("cboxSelect") as CheckBox;
                //var lblCustody = e.Row.FindControl("lblGetCustodian") as Label;
                //if (lblCustody != null && (lblCustody.Text.ToLower() != "admin" && lblCustody.Text.ToLower() != "convener" ))
                //{
                //    if (cbox != null) cbox.Enabled = false;
                //}
                //e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
                //e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
            }
        }

        

        private void PopulateGridForDocs()
        {
            using (var fyp = new FYPEntities())
            {
                bool est = false;
                if(ddlEval.SelectedIndex == 0 || ddlEval.SelectedIndex == 2)
                {
                    est = false;
                }
                else if(ddlEval.SelectedIndex == 1)
                {
                     est = true;
                }
                    long psid = fyp.ProjectSessions.Max(x => x.PSId);
                    var data = fyp.SP_GetDocumentsSubmittedDataForGrid(psid, 0,est).ToList();
                    GvdViewAllDocs.DataSource = data;
                    GvdViewAllDocs.DataBind();
            }
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string stdName = string.Empty;
                if(txtSearchByProjectName.Text == string.Empty)
                {
                    FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Enter Project Title!" }, this.Page, true);
                    return;
                }
                else
                {
                    stdName = txtSearchByProjectName.Text;
                }
                long pid = fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName)  && std.Status == 2).FirstOrDefault().PId;
                var search = fypEntities.SP_GetDocumentsSubmittedDataForGrid(-1, pid, false).ToList();
                GvdViewAllDocs.DataSource = search;
                   //fypEntities.Projects.Where(std => std.Tiltle.Contains(stdName)  && std.Status == 2).ToList();
                GvdViewAllDocs.DataBind();
            }
        }

        protected void FwdStudentClick(object sender, EventArgs e)
        {
            bool check = false;
            if (!CheckStudentsInGridView())
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Please Select Document" }, this.Page, true);
                return;
            }
            using (var fypEntities = new FYPEntities())
            {
                foreach (GridViewRow row in GvdViewAllDocs.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                        if (checkBox != null && checkBox.Checked)
                        {
                            var dataKey = GvdViewAllDocs.DataKeys[row.RowIndex];
                            if (dataKey != null && dataKey.Values != null)
                            {
                                long umsId = Convert.ToInt64(dataKey.Values["UMSId"]);
                                long umsdId = Convert.ToInt64(dataKey.Values["UMSDId"]);
                                long uid = FYPSession.GetLoggedUser().UserId;
                                fypEntities.SP_DistributeDocsToSupervisor(umsId, uid,umsdId);
                                check = true;
                            }
                        }
                    }
                }
            }
            if (check)
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "File forwarded Sucessfully" }, this.Page, true);
                PopulateGridForDocs();
            }
        }

        protected void FwdPcMemberClick(object sender, EventArgs e)
        {
            bool check = false;
            if (!CheckStudentsInGridView())
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Select Document" }, this.Page, true);
                return;
            }
            using (var fypEntities = new FYPEntities())
            {
                foreach (GridViewRow row in GvdViewAllDocs.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                        if (checkBox != null && checkBox.Checked)
                        {
                            var dataKey = GvdViewAllDocs.DataKeys[row.RowIndex];
                            if (dataKey != null && dataKey.Values != null)
                            {
                                long umsId = Convert.ToInt64(dataKey.Values["UMSId"]);
                                long umsdid = Convert.ToInt64(dataKey.Values["UMSDId"]);
                                long uid = FYPSession.GetLoggedUser().UserId;
                                if (ddlPCMember.SelectedIndex != 0)
                                {
                                    long uId = Convert.ToInt64(ddlPCMember.SelectedValue);
                                    var est = fypEntities.UploadedMileStoneDocs.Where(p => p.UMSDId == umsdid).FirstOrDefault().EvalStatus;
                                    if (est.Value != true)
                                    {
                                       
                                        fypEntities.SP_DistributeDocsToPCMembers(umsId, uId, uid, umsdid);
                                        check = true;
                                    }
                                    else
                                    {
                                        fypEntities.SP_SetEvalStatus(-1,null);
                                        fypEntities.SP_DistributeDocsToPCMembers(umsId, uId, uid, umsdid);
                                        check = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (check)
                {
                    FYPMessage.ShowPopUpMessage("Success", new List<string>() { "File forwarded Sucessfully" }, this.Page, true);
                    PopulateGridForDocs();
                }
            }
        }

        private bool CheckStudentsInGridView()
        {
            foreach (var row in GvdViewAllDocs.Rows.Cast<GridViewRow>())
            {
                var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                if (checkBox != null && checkBox.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        protected void DdlSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long sId = 0;
                if (ddlMileStones.SelectedIndex != 0)
                {
                    if (ddlSession.SelectedIndex == 0)
                    {
                        sId = fyp.ProjectSessions.Max(p => p.PSId);
                    }
                    else
                    {
                        sId = Convert.ToInt64(ddlSession.SelectedValue);
                    }
                    long mId = Convert.ToInt64(ddlMileStones.SelectedValue);
                    if (ddlEval.SelectedIndex == 0 || ddlEval.SelectedIndex == 2)
                    {
                       
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, mId, false);
                        GvdViewAllDocs.DataSource = data;
                        GvdViewAllDocs.DataBind();
                    }
                    else if (ddlEval.SelectedIndex == 1)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, mId, true);
                        GvdViewAllDocs.DataSource = data;
                        GvdViewAllDocs.DataBind();
                    }
                }
                else
                {
                    
                    if (ddlSession.SelectedIndex == 0)
                    {
                        sId = fyp.ProjectSessions.Max(p => p.PSId);
                    }
                    else
                    {
                        sId = Convert.ToInt64(ddlSession.SelectedValue);
                    }

                    if (ddlEval.SelectedIndex == 0 || ddlEval.SelectedIndex == 2)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, 0,false);
                        GvdViewAllDocs.DataSource = data.ToList();
                        GvdViewAllDocs.DataBind();
                    }
                    else if (ddlEval.SelectedIndex == 1)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, 0,true);
                        GvdViewAllDocs.DataSource = data.ToList();
                        GvdViewAllDocs.DataBind();
                    }
                }
            }
        }

        protected void DdlMileStonesSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                
                if (ddlSession.SelectedIndex != 0)
                {
                    long mId = 0;
                    if(ddlMileStones.SelectedIndex == 0)
                    {
                        mId = fyp.ProjectMileStones.Min(x => x.PMSId);
                    }
                    else
                    {
                        mId = Convert.ToInt64(ddlMileStones.SelectedValue);
                    }
                 
                    long sId = Convert.ToInt64(ddlSession.SelectedValue);
                    if (ddlEval.SelectedIndex == 0 || ddlEval.SelectedIndex == 2)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, mId,false);
                        GvdViewAllDocs.DataSource = data.ToList();
                        GvdViewAllDocs.DataBind();
                    }
                    else if (ddlEval.SelectedIndex == 1)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(sId, mId, true);
                        GvdViewAllDocs.DataSource = data;
                        GvdViewAllDocs.DataBind();
                    }
                }
                else
                {
                    long mId =0 ;
                    if (ddlMileStones.SelectedIndex == 0)
                    {
                        mId = fyp.ProjectMileStones.Min(x => x.PMSId);
                    }
                    else
                    {
                        mId = Convert.ToInt64(ddlMileStones.SelectedValue);
                    }
                     
                    long psid = fyp.ProjectSessions.Max(x => x.PSId);
                    if (ddlEval.SelectedIndex == 0 || ddlEval.SelectedIndex == 2)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(psid, mId,false);
                        GvdViewAllDocs.DataSource = data;
                        GvdViewAllDocs.DataBind();
                    }
                    else if (ddlEval.SelectedIndex == 1)
                    {
                        var data = fyp.SP_GetDocumentsSubmittedDataForGrid(psid, mId, true);
                        GvdViewAllDocs.DataSource = data;
                        GvdViewAllDocs.DataBind();
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //ddlEval.Attributes.Add("onChange", "DdlEvalSelectedIndexChanged");
            base.OnPreRender(e);
        }

        protected void GvdViewAllDocsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "Select")
            {
                var dataKey = GvdViewAllDocs.DataKeys[row];
                if (dataKey != null && dataKey.Values != null)
                {
                    _umsid = Convert.ToInt64(dataKey.Values["UMSId"]);
                    _custodyId = Convert.ToInt64(dataKey.Values["InCustody"]);
                }

                using (var fyp = new FYPEntities())
                {
                    gvdViewHistory.DataSource = fyp.SP_GetRouteHistoryOfDocs(_umsid);
                    gvdViewHistory.DataBind();
                }
                FYPMessage.ShowBootStrapPopUp("DocHistory", this.Page, true);
            }
            if (e.CommandName == "Detail")
            {
                var dataKey = GvdViewAllDocs.DataKeys[row];
                if (dataKey != null && dataKey.Values != null)
                {
                    _umsid = Convert.ToInt64(dataKey.Values["UMSId"]);
                    _custodyId = Convert.ToInt64(dataKey.Values["InCustody"]);
                    _umsdid = Convert.ToInt64(dataKey.Values["UMSDId"]);
                    _projectId= Convert.ToInt64(dataKey.Values[0].ToString());
                }

                using (var fyp = new FYPEntities())
                {
                    dtvDocDetail.DataSource = fyp.SP_GetDocDetailSubmittedBy(_umsdid);
                    dtvDocDetail.DataBind();
                }
                FYPMessage.ShowBootStrapPopUp("DocDetail", this.Page, true);
            }
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey = GvdViewAllDocs.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey == null || dataKey.Values == null)
                    return;
                //long umsdid = Convert.ToInt64(dataKey.Values["UMSDId"]);
                long umsid = Convert.ToInt64(dataKey.Values["UMSId"]);
                using (var fypEntities = new FYPEntities())
                {
                    var obj = new ObjectParameter("checkBit", 0);
                        fypEntities.SP_DeleteDocumentFromUMDoc(umsid,obj);
                    if(Convert.ToBoolean(obj.Value))
                    {
                        var entity2 = fypEntities.UploadedMileStones.FirstOrDefault(uu => (long?)uu.UMSId == umsid);
                        if (entity2 == null)
                            return;
                        fypEntities.UploadedMileStones.Remove(entity2);
                        if (fypEntities.SaveChanges() <= 0)
                            return;
                        PopulateGridForDocs();
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Document removed successfully" }, this.Page, true);
                    }
                    else
                    {
                        FYPMessage.ShowPopUpMessage("Warning", new List<string>() { "Document could not be removed" }, this.Page, true);
                    }
                   
                    
                }
            }
            
        }

        protected void DtvDocDetailDataBound(object sender, EventArgs e)
        {
            var gvStudents = dtvDocDetail.Rows[0].Cells[0].FindControl("gdvStudents") as GridView;
            if (gvStudents != null)
            {
                using (var fypEntities = new FYPEntities())
                {
                    gvStudents.DataSource = fypEntities.SP_GetProjectStudentsWithReg(_projectId).ToList();
                    gvStudents.DataBind();
                }
            }
        }

        protected void HeaderCheckBoxChecked(object sender, EventArgs e)
        {
            var headerCheck = sender as CheckBox;
            if (headerCheck != null)
            {
                bool status = headerCheck.Checked;
                foreach (GridViewRow row in GvdViewAllDocs.Rows)
                {
                   var rowCheck = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                    if(rowCheck!=null && rowCheck.Enabled)
                    {
                        rowCheck.Checked = status;
                    }
                }
            }
        }

        protected void btnfwdExt_Click(object sender, EventArgs e)
        {
            bool check = false;
                       
            if (!CheckStudentsInGridView())
            {
                FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Please Select Document" }, this.Page, true);
                return;
            }
            if (DropDownListExt.SelectedIndex == 0)
            {
                FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "Please Select External" }, this.Page, true);
                return;
            }
                using (var fypEntities = new FYPEntities())
                {
                    foreach (GridViewRow row in GvdViewAllDocs.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            var checkBox = row.Cells[0].FindControl("cboxSelect") as CheckBox;
                            if (checkBox != null && checkBox.Checked)
                            {
                                var dataKey = GvdViewAllDocs.DataKeys[row.RowIndex];
                                if (dataKey != null && dataKey.Values != null)
                                {
                                    long umsId = Convert.ToInt64(dataKey.Values["UMSId"]);
                                    long umsdid = Convert.ToInt64(dataKey.Values["UMSDId"]);
                                    var pmsid = fypEntities.UploadedMileStones.Where(p => p.UMSId == umsId).ToList();
                                    long uid = FYPSession.GetLoggedUser().UserId;
                                    if (DropDownListExt.SelectedIndex != 0)
                                    {
                                        long uId = Convert.ToInt64(DropDownListExt.SelectedValue);
                                        if (pmsid.FirstOrDefault().PMSId == 10007)
                                        {
                                            fypEntities.SP_DistributeDocsToPCMembers(umsId, uId, uid, umsdid);
                                            check = true;
                                        }
                                        else
                                        {
                                            FYPMessage.ShowPopUpMessage("Notice!", new List<string>() { "You can only send Final Reports to External." }, this.Page, true);
                                            check = false;
                                        }
                                    }
                                }
                            }
                        }
                    if (check)
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "File forwarded Sucessfully" }, this.Page, true);
                        PopulateGridForDocs();
                    }
                }
            }
        }
    }
}