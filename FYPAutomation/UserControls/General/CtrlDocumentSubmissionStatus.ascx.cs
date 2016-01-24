using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlDocumentSubmissionStatus : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateSessions();
                PopulateGrid();
            }
        }

        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSessionSearch.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                ddlSessionSearch.DataBind();
                ddlSessionSearch.Items.Insert(0, "Select Session");
            }
        }

        /// <summary>
        /// Loading grid to show the statuses of document either submitted or not
        /// </summary>
        private void PopulateGrid()
        {
            using (var fyp=new FYPEntities())
            {
                long psid = fyp.ProjectSessions.Max(p => p.PSId);
                GvdDocSubmissionStatus.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status==2).ToList();
                GvdDocSubmissionStatus.DataBind();
            }
        }

        protected void GvdDocSubmissionStatusRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                int rowIndex = e.Row.RowIndex;
                DataKey dk = GvdDocSubmissionStatus.DataKeys[rowIndex];
                if (dk != null && dk.Values != null)
                {
                    var imgScope = e.Row.FindControl("imgScope") as Image;
                    var imgSrs = e.Row.FindControl("imgSRS") as Image;
                    var imgSds = e.Row.FindControl("imgSDS") as Image;
                    var imgRpt = e.Row.FindControl("imgRpt") as Image;
                    long pId = Convert.ToInt64(dk.Values["PId"]);
                    using (var fyp = new FYPEntities())
                    {
                        var scope = new ObjectParameter("scope", 0);
                        var srs = new ObjectParameter("srs", 0);
                        var sds = new ObjectParameter("sds", 0);
                        var rpt = new ObjectParameter("rpt", 0);
                        fyp.SP_DocSubmissionStatus(pId, scope, srs, sds,rpt);
                        if (Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl ="~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && !Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/cross.png";
                        }
                        if (!Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && Convert.ToBoolean(srs.Value) && !Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                        if (Convert.ToBoolean(scope.Value) && !Convert.ToBoolean(srs.Value) && Convert.ToBoolean(sds.Value) && Convert.ToBoolean(rpt.Value))
                        {
                            if (imgScope != null)
                                imgScope.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgSrs != null)
                                imgSrs.ImageUrl = "~/Images/DashBoardImages/cross.png";
                            if (imgSds != null)
                                imgSds.ImageUrl = "~/Images/DashBoardImages/tick.png";
                            if (imgRpt != null)
                                imgRpt.ImageUrl = "~/Images/DashBoardImages/tick.png";
                        }
                    }
                }
            }
        }

        protected void SessionSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long psid;
                if (long.TryParse(ddlSessionSearch.SelectedValue, out psid))
                {
                    GvdDocSubmissionStatus.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                    GvdDocSubmissionStatus.DataBind();
                }
                else
                {
                    psid = fyp.ProjectSessions.Max(p => p.PSId);
                    GvdDocSubmissionStatus.DataSource = fyp.Projects.Where(x => x.ProjectSessionId == psid && x.Status == 2).ToList();
                    GvdDocSubmissionStatus.DataBind();
                }
            }
        }

        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                string prName = txtSearchByName.Text;
                var data = fypEntities.Projects.Where(x => x.Tiltle.Contains(prName));
                GvdDocSubmissionStatus.DataSource = data.ToList();
                GvdDocSubmissionStatus.DataBind();
            }
        }
    }
}