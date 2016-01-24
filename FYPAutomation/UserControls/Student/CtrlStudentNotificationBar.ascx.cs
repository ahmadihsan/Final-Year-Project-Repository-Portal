using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlStudentNotificationBar : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAccordian();
            }

        }

        private void PopulateAccordian()
        {
            using (var fypEntities = new FYPEntities())
            {
                long uId = FYPUtilities.FYPSession.GetLoggedUser().UserId;
                var firstOrDefault = fypEntities.Users.FirstOrDefault(usr => usr.UId == uId);
                if (firstOrDefault != null)
                {
                    long? projSessionId = firstOrDefault.ProjectSessionId;

                    var data = (from pms in fypEntities.ProjectMileStones
                                join pmsd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                    pmsd.PMSId
                                where pmsd.DeadLine >= DateTime.Now && pmsd.PSId == projSessionId
                                select new
                                           {
                                               pms.PMSId,
                                               pms.Name,
                                               pmsd.PMSDId,
                                               pmsd.DeadLine,
                                               pmsd.TimeSpan,
                                               pmsd.Description
                                           }).ToList();
                    rptAccordian.DataSource = data;
                    rptAccordian.DataBind();

                    var dataGeneral =
#pragma warning disable 612,618
 fypEntities.Announcments.Where(
                            ann =>
                            (ann.CreatedDate <= EntityFunctions.AddDays(ann.CreatedDate, 7) && ann.PSId == projSessionId) || (ann.CreatedDate <= EntityFunctions.AddDays(ann.CreatedDate, 7) || ann.IsVisibleToBothSessions!=null))
#pragma warning restore 612,618
.Select(ann => new
                                               {
                                                   ann.AnnId,
                                                   ann.Title,
                                                   ann.Description,
                                                   ann.CreatedDate,
                                                   ann.Upload,
                                                   ann.IsVisibleToBothSessions
                                               });

                    rptGeneralAnnouncement.DataSource = dataGeneral.ToList();
                    rptGeneralAnnouncement.DataBind();
                }
            }
        }
    }
}