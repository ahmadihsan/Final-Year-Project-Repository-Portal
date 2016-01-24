using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;

namespace FYPAutomation.UserControls.Admin
{
    public partial class CtrlAdminNotificationSideBar : System.Web.UI.UserControl
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
                var data = (from pms in fypEntities.ProjectMileStones
                            join pmsd in fypEntities.ProjectMileStoneDeadLines on pms.PMSId equals
                                pmsd.PMSId
                            //where pmsd.DeadLine >= DateTime.Now && pmsd.TimeSpan>DateTime.Now.TimeOfDay
                            select new
                            {
                                pms.PMSId,
                                pms.Name,
                                pmsd.PMSDId,
                                pmsd.DeadLine,
                                pmsd.TimeSpan,
                                pmsd.Description
                            }).ToList();
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                DateTime newDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

                //var d = data.First(p => p.PMSDId == 10005).DeadLine.Date;
                //var t = data.First(o => o.PMSDId == 10005).TimeSpan;
                //bool a = (data.First(p => p.PMSDId == 10005).DeadLine.Date.CompareTo(DateTime.Now.Date) >= 0);
                //bool b = (data.First(o => o.PMSDId == 10005).TimeSpan.CompareTo(DateTime.Now.TimeOfDay) > 0);
                //var data1 = data.Where(z => z.DeadLine.Date >= newDateTime && z.TimeSpan > newDateTime.TimeOfDay).ToList();

                var data1 = from dataToShow in data
                    where
                        (dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) > 0) ||((dataToShow.DeadLine.Date.CompareTo(newDateTime.Date)==0) && (dataToShow.TimeSpan.CompareTo(newDateTime.TimeOfDay) > 0)) 
                        select dataToShow;
                rptAccordian.DataSource = data1;
                rptAccordian.DataBind();

                var dataGeneral =
#pragma warning disable 612,618
 fypEntities.Announcments.Where(ann => ann.CreatedDate <= EntityFunctions.AddDays(ann.CreatedDate, 7))
#pragma warning restore 612,618
.Select(ann => new
                                           {
                                               ann.AnnId,
                                               ann.Title,
                                               ann.Description,
                                               ann.CreatedDate,
                                               ann.Upload
                                           });

                rptGeneralAnnouncement.DataSource = dataGeneral.ToList();
                rptGeneralAnnouncement.DataBind();
            }
        }
    }
}