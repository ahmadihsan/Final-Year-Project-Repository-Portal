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
    public partial class CtrlProjectArchive : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
        }

        private void PopulateGrid()
        {
            long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            using (var fyp = new FYPEntities())
            {
                var ArcList = (from p in fyp.Projects
                               from pd in fyp.ProjectDirectories
                               from ps in fyp.ProjectSessions
                               where p.PId == pd.ProjectId && pd.psId == ps.PSId && p.ProposedBy==uid
                               select new
                               {
                                   p.PId,
                                   pd.PDId,
                                   p.Tiltle,
                                   ps.Name,
                                   pd.Description,
                                   pd.UploadedFile
                               }).ToList();


                GvdViewProjectArchive.DataSource= ArcList;
                GvdViewProjectArchive.DataBind();
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

        protected void AddArchiveClick(object sender, EventArgs e)
        {
            if(FYPSession.GetLoggedUser().RoleName.ToLower()=="convener")
            {
                Response.Redirect("~/Pages/Convener/AddArchiveRecord.aspx");
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
            {
                Response.Redirect("~/Pages/Admin/AddArchiveRecord.aspx");
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "faculty")
            {
                Response.Redirect("~/Pages/Faculty/AddArchiveRecord.aspx");
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "pcmember")
            {
                Response.Redirect("~/Pages/PCMember/AddArchiveRecord.aspx");
            }
            if (FYPSession.GetLoggedUser().RoleName.ToLower() == "student")
            {
                Response.Redirect("~/Pages/Student/AddArchiveRecord.aspx");
            }
        }
    }
}