using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
using ObjectParameter = System.Data.Entity.Core.Objects.ObjectParameter;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlViewAllArchive : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
                PopulateSessions();
            }
        }
        private void PopulateSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                ddlSession.DataSource = fypEntities.ProjectSessions.ToList();
                ddlSession.DataBind();
                ddlSession.Items.Insert(0, "Select Session");
            }
        }
        private void PopulateGrid()
        {
            using (var fyp = new FYPEntities())
            {
                var ArcList = ( from p in fyp.Projects
                                from pd in fyp.ProjectDirectories
                                from ps in fyp.ProjectSessions
                                where p.PId==pd.ProjectId && pd.psId==ps.PSId
                                select new
                                {
                                    p.PId,
                                    pd.PDId,
                                    p.Tiltle,
                                    ps.Name,
                                    pd.Description,
                                    pd.UploadedFile
                                }).ToList();

                GvdViewProjectArchive.DataSource = ArcList;
                GvdViewProjectArchive.DataBind();
            }
        }
        protected void BtnProjectSearchClicked(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                string prName = txtByProjectName.Text;
                var LstArcbyPro = (from p in fyp.Projects
                                   from pd in fyp.ProjectDirectories
                                   from ps in fyp.ProjectSessions
                                   where p.PId == pd.ProjectId && ps.PSId == pd.psId && p.Tiltle==prName
                                   select new
                                   {
                                       p.PId,
                                       pd.PDId,
                                       p.Tiltle,
                                       ps.Name,
                                       pd.Description,
                                       pd.UploadedFile
                                   }).ToList();
                GvdViewProjectArchive.DataSource = LstArcbyPro;
                GvdViewProjectArchive.DataBind();
            }
        }
        protected void ArchiveSearchSelectedIndexChanged(object sender, EventArgs e)
        {
            using (var fyp= new FYPEntities())
            {
                if (ddlSession.SelectedIndex == 0)
                {
                    PopulateGrid();
                }
                else
                {
                    long psid = Convert.ToInt64(ddlSession.SelectedValue);
                    var LstArc = (from p in fyp.Projects
                                  from pd in fyp.ProjectDirectories
                                  from ps in fyp.ProjectSessions
                                  where p.PId == pd.ProjectId && ps.PSId == pd.psId && pd.psId == psid
                                  select new
                                  {
                                      p.PId,
                                      pd.PDId,
                                      p.Tiltle,
                                      ps.Name,
                                      pd.Description,
                                      pd.UploadedFile
                                  }).ToList();

                    GvdViewProjectArchive.DataSource = LstArc;
                    GvdViewProjectArchive.DataBind();
                }
            }
        }

        protected void GvdViewProjectArchiveRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                DataKey dataKey =
                    GvdViewProjectArchive.DataKeys[((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex];
                if (dataKey != null && dataKey.Values != null)
                {
                    long PDID = Convert.ToInt64(dataKey.Values["PDId"]);
                    using (var fyp = new FYPEntities())
                    {
                        ProjectDirectory pd = fyp.ProjectDirectories.FirstOrDefault(x => x.PDId == PDID);

                        if (pd != null)
                        {
                            fyp.ProjectDirectories.Remove(pd);

                            if (fyp.SaveChanges() > 0)
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Project Archive removed successfully!" }, this.Page, true);
                                PopulateGrid();
                            }
                            else
                            {
                                FYPUtilities.FYPMessage.ShowPopUpMessage("Error", new List<string>() { "Project Archive could not be removed!" }, this.Page, true);
                                PopulateGrid();
                            }
                        }
                    }
                }
            }
        }
    }
}