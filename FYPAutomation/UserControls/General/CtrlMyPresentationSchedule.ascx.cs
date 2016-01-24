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
    public partial class CtrlMyPresentationSchedule : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var fyp = new FYPEntities())
            {
                long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var usr = fyp.Users.FirstOrDefault(x => x.UId == uid);
                if (usr != null)
                {
                    lblSession.Text = FrequentAccesses.GetProjectSessionNameById(Convert.ToInt64(usr.ProjectSessionId));
                }
            }
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }

        /// <summary>
        /// Load Grid for Projects
        /// </summary>
        private void LoadGridData()
        {
            long uid = FYPUtilities.FYPSession.GetLoggedUser().UserId;
            long psid = Convert.ToInt64(FrequentAccesses.GetProjectSessionIdByUserId(uid));
            using (var fyp = new FYPEntities())
            {
                var data = fyp.SP_GetPresentationsToIndividualUser(psid, uid);
                GvdMyPresentationSchedule.DataSource = data.ToList();
                GvdMyPresentationSchedule.DataBind();
            }
        }
    }
}