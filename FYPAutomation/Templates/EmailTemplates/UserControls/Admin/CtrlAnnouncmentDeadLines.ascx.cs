using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlAnnouncmentDeadLines : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForAnnouncemnts();
                if (Request.QueryString["mId"] != null)
                {
                    if (Request.QueryString["mId"].ToString().ToLower() == "delete")
                    {
                        FYPMessage.ShowMessage(ref lblMessage, true, "Deadline Removed Successfully");
                    }
                    if (Request.QueryString["mId"].ToString().ToLower() == "update")
                    {
                        FYPMessage.ShowMessage(ref lblMessage, true, "Deadline Updated Successfully");
                    }
                }
            }
        }

        private void PopulateGridForAnnouncemnts()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdDeadline.DataSource = (from projSe in fypEntities.ProjectSessions
                                          join prjmd in fypEntities.ProjectMileStoneDeadLines on projSe.PSId equals
                                              prjmd.PSId
                                          join prjms in fypEntities.ProjectMileStones on prjmd.PMSId equals prjms.PMSId
                                          select new
                                                     {
                                                         sessName = projSe.Name,
                                                         prjmd.DeadLine,
                                                         mileStoneName = prjms.Name,
                                                         prjmd.PMSDId,
                                                         prjms.PMSId,
                                                         projSe.PSId
                                                     }).ToList();
                GvdDeadline.DataBind();

            }
        }

        protected void GvdDeadlineRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GvdDeadline.EditIndex = rowIndex;
                PopulateGridForAnnouncemnts();
                string psid = string.Empty;
                string pmsid = string.Empty;
                var dataKey = GvdDeadline.DataKeys[rowIndex];
                if (dataKey != null)
                {
                    if (dataKey.Values != null)
                    {
                        psid = dataKey.Values["PSId"].ToString();
                        pmsid = dataKey.Values["PMSId"].ToString();
                    }
                }
                var ddlMileStone = GvdDeadline.Rows[rowIndex].FindControl("ddlMileStoneGrid") as DropDownList;
                var ddlSession = GvdDeadline.Rows[rowIndex].FindControl("ddlSessionGrid") as DropDownList;
                if (ddlMileStone != null)
                {
                    PopulateMileStone(ref ddlMileStone, pmsid);
                }
                if (ddlSession != null)
                {
                    PopulateSessions(ref ddlSession, psid);
                }
            }

            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                var datakey = GvdDeadline.DataKeys[rowIndex];
                if (datakey != null)
                {
                    if (datakey.Values != null)
                    {
                        var pmsdid = Convert.ToInt32(datakey.Values["PMSDId"].ToString());
                        using (var fypEntitites = new FYPEntities())
                        {
                            ProjectMileStoneDeadLine prmd =
                                fypEntitites.ProjectMileStoneDeadLines.FirstOrDefault(pr => pr.PMSDId == pmsdid);
                            fypEntitites.ProjectMileStoneDeadLines.Remove(prmd);
                            if (fypEntitites.SaveChanges() > 0)
                            {
                                Response.Redirect("~/Pages/Admin/Announcment.aspx?MId=delete");
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "CancelUpdate")
            {
                GvdDeadline.EditIndex = -1;
                PopulateGridForAnnouncemnts();
            }
            if (e.CommandName == "UpdateRow")
            {
                var ddlMilestone = new int();
                var session = new int();
                var dDeadline = new DateTime();
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                var dropDownList = GvdDeadline.Rows[rowIndex].FindControl("ddlMileStoneGrid") as DropDownList;
                if (dropDownList != null)
                {
                    ddlMilestone =
                        Convert.ToInt32(dropDownList.SelectedValue);
                }
                var textBox = GvdDeadline.Rows[rowIndex].FindControl("cldCalender") as TextBox;
                if (textBox != null)
                {
                    dDeadline = Convert.ToDateTime(textBox.Text);
                }
                var downList = GvdDeadline.Rows[rowIndex].FindControl("ddlSessionGrid") as DropDownList;
                if (downList != null)
                {
                    session = Convert.ToInt32(downList.SelectedValue);
                }

                var datakey = GvdDeadline.DataKeys[rowIndex];
                if (datakey != null)
                {
                    if (datakey.Values != null)
                    {
                        var pmsdid = Convert.ToInt32(datakey.Values["PMSDId"].ToString());
                        using (var fypEntitites = new FYPEntities())
                        {
                            ProjectMileStoneDeadLine prmd =
                                fypEntitites.ProjectMileStoneDeadLines.FirstOrDefault(pr => pr.PMSDId == pmsdid);
                            if (prmd != null)
                            {
                                prmd.PMSId = ddlMilestone;
                                prmd.PSId = session;
                                prmd.DeadLine = dDeadline;
                                if (fypEntitites.SaveChanges() > 0)
                                {
                                    Response.Redirect("~/Pages/Admin/Announcment.aspx?MId=update");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PopulateSessions(ref DropDownList ddlSession, string psid)
        {
            try
            {
                using (var fypEntities = new FYPEntities())
                {
                    ddlSession.DataSource = fypEntities.ProjectSessions.Where(ps => ps.Status == true).ToList();
                    ddlSession.DataBind();
                    ddlSession.Items.Insert(0, "Select Session");
                    ddlSession.SelectedIndex = ddlSession.Items.IndexOf(ddlSession.Items.FindByValue(psid));
                }
            }
            catch (Exception)
            {


            }
        }
        private void PopulateMileStone(ref DropDownList ddlMileStone, string pmsid)
        {
            try
            {
                using (var fypEntities = new FYPEntities())
                {
                    ddlMileStone.DataSource = fypEntities.ProjectMileStones.ToList();
                    ddlMileStone.DataBind();
                    ddlMileStone.Items.Insert(0, "Select MileStone");
                    ddlMileStone.SelectedIndex = ddlMileStone.Items.IndexOf(ddlMileStone.Items.FindByValue(pmsid));
                }
            }
            catch (Exception)
            {


            }
        }


        protected void AddDedLineClick(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("AddDeadLine",this.Page,true);
        }

       

        protected void BtnSearchClicked(object sender, EventArgs e)
        {

        }




    }
}