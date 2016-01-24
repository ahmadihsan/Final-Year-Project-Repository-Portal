using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlAssignedDocs : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSessions();
                PopulateMileStones();
                PopulateGrid();
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
                var data = fyp.ProjectSessions.Where(prs => prs.Status == true).ToList();
                ddlSession.DataSource = data;
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }

        private void PopulateGrid()
        {
            using (var fyp = new FYPEntities())
            {
                GvdAssignedDocs.DataSource = fyp.SP_AssignedDocsToPC(null,null);
                GvdAssignedDocs.DataBind();
            }
        }

        protected void GvdAssignDocsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "unassign")
            {
                var gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                DataKey dk = GvdAssignedDocs.DataKeys[gvr.RowIndex];
                long umsdid = -1;
                long umsid = -1;
                if (dk != null && dk.Values != null)
                {
                    umsdid = Convert.ToInt64(dk.Values["UMSDId"]);
                    umsid = Convert.ToInt64(dk.Values["UMSId"]);
                }
                if (umsdid > 0 && umsid > 0)
                {
                    using (var fyp = new FYPEntities())
                    {
                        UploadedMileStoneDoc umsd = fyp.UploadedMileStoneDocs.FirstOrDefault(um => um.UMSDId == umsdid);
                        fyp.UploadedMileStoneDocs.Remove(umsd);
                        if (fyp.SaveChanges() > 0)
                        {
                            long adminID = fyp.Users.Where(p => p.RoleId == 1).FirstOrDefault().UId;
                            UploadedMileStoneDoc umsdd = fyp.UploadedMileStoneDocs.FirstOrDefault(ums => ums.UMSId == umsid);
                            if (umsdd != null)
                            {
                                umsdd.ReadStatus = false;
                                umsdd.ToAdmin = true;
                                umsdd.InCustody = adminID;
                                umsdd.EvalStatus = false;
                                umsdd.CustodyHistory = true;
                                if (fyp.SaveChanges() > 0)
                                {
                                    FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Document unassigned successfully" }, this.Page, true);
                                }
                            }
                        }
                        PopulateGrid();
                    }
                }
            }
        }

        protected void DdlSessionSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long sId = Convert.ToInt64(ddlSession.SelectedValue);
                if (ddlMileStones.SelectedIndex != 0)
                {
                    long mId = Convert.ToInt64(ddlMileStones.SelectedValue);
                    var data = fyp.SP_AssignedDocsToPC(sId, mId);
                    GvdAssignedDocs.DataSource = data;
                    GvdAssignedDocs.DataBind();
                }
                else
                {
                    var data = fyp.SP_AssignedDocsToPC(sId, null);
                    GvdAssignedDocs.DataSource = data;
                    GvdAssignedDocs.DataBind();
                }
            }
        }

        protected void DdlMileStonesSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long mId = Convert.ToInt64(ddlMileStones.SelectedValue);
                if (ddlSession.SelectedIndex != 0)
                {
                    long sId = Convert.ToInt64(ddlSession.SelectedValue);
                    var data = fyp.SP_AssignedDocsToPC(sId, mId);
                    GvdAssignedDocs.DataSource = data;
                    GvdAssignedDocs.DataBind();
                }
                else
                {
                    var data = fyp.SP_AssignedDocsToPC(null, mId);
                    GvdAssignedDocs.DataSource = data;
                    GvdAssignedDocs.DataBind();
                }
            }
        }
    }
}