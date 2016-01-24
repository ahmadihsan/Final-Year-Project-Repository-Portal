using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Faculty
{
    public partial class CtrlMyProjectsFac : FYPBaseUserControl
    {
        public static int MinutesAllowed { get; set; }
        public static DateTime? TestStarted { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectForm();
                //MinutesAllowed = 30;
                //TestStarted = DateTime.Now;
                //Session["timeout"] = DateTime.Now.AddMinutes(30).ToString();
            }
            
                       
        }

        private void PopulateProjectForm()
        {
            long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            using (var fypEntities = new FYPEntities())
            { 
               lstProjects.DataSource = (from proj in fypEntities.Projects
                                          join usr in fypEntities.Users on proj.ProposedBy equals usr.UId
                                          where proj.ProposedBy==uid
                                          select new
                                          {
                                              proj.PId,
                                              proj.Tiltle,
                                              proj.Description,
                                              proj.ProposedBy,
                                              usr.Name,
                                              proj.Status
                                          }).ToList();
                lstProjects.DataBind();
            }
        }

        protected void WeeklyMeetingClicked(object sender, EventArgs e)
        {
            long pId = -1;
            var lnk = sender as LinkButton;
            if(lnk!=null)
            {
                pId = Convert.ToInt64(lnk.CommandArgument);
            }
            if(FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()=="convener")
            {
                Response.Redirect("~/Pages/Convener/WeeklyMeetings.aspx?pId="+pId);
            }
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "admin")
            {
                Response.Redirect("~/Pages/Admin/WeeklyMeetings.aspx?pId=" + pId);
            }
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "faculty")
            {
                Response.Redirect("~/Pages/Faculty/WeeklyMeetings.aspx?pId=" + pId);
            }
            if (FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower() == "pcmember")
            {
                Response.Redirect("~/Pages/PCMember/WeeklyMeetings.aspx?pId=" + pId);
            }
            
        }

        //protected void lstProjects_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{
        //    if (e.commandname == "btntime")
        //    {
        //        if (e.commandsource is button)
        //        {
        //            listviewdataitem item = (e.commandsource as button).namingcontainer as listviewdataitem;
        //            button btn = item.findcontrol("tnreserveproc") as button;
        //            if (0 > datetime.compare(datetime.now, datetime.parse(session["timeout"].tostring())))
        //            {
        //                btn.text = ((int32)datetime.parse(session["timeout"].tostring()).subtract(datetime.now).totalminutes).tostring();
        //            }
        //        }
        //    }
        //}





        

        
    }
}