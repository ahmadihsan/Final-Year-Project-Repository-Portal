using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPDAL;
using FYPUtilities;
using System.Xml;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
namespace FYPAutomation.UserControls.Admin
{
    public partial class AaaaaaaMarquee : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMarquee();
            }

        }
        private void PopulateGridData()
        {
            using (var fyp = new FYPEntities())
            {
                long psid = fyp.ProjectSessions.Max(ps => ps.PSId);
                var data = fyp.Announcments.Where(ann => ann.PSId == psid).ToList();
               
            }
        }
        public void PopulateMarquee()
        {

            try
            {
                StringBuilder strScrollingNews = new StringBuilder();
                using (var fyp = new FYPEntities())
                {
                    var data = (from pms in fyp.ProjectMileStones
                                join pmsd in fyp.ProjectMileStoneDeadLines on pms.PMSId equals
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

                    var data2 = (from dataToShow in data
                                 where
                                     (dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) > 0) || ((dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) == 0) && (dataToShow.TimeSpan.CompareTo(newDateTime.TimeOfDay) > 0))
                                 select new { dataToShow.Name,dataToShow.DeadLine, dataToShow.Description});
                    long psid = fyp.ProjectSessions.Max(ps => ps.PSId);
                    var data1 = fyp.Announcments.Where(ann => ann.PSId == psid).ToList();

                    if (data != null || data1 != null || data2 != null)
                    {
                        strScrollingNews.Append("<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='3'>");
                        foreach(var item in data1 )
                        {                           
                            strScrollingNews.Append("<b><u>" + "Latest News:" + "</u></b>"  + item.Title+"<br/>" + item.CreatedDate +"<br/>" + item.Description);
                            }
                        foreach (var i in data)
                        {
                            strScrollingNews.Append("<br/>" + "<b><u>" + "Mile Stone Notification:" + "</u></b>" + data.FirstOrDefault().DeadLine + "<br/>" + data.FirstOrDefault().Description);
                                              
                        }
                        foreach (var j in data2)
                        {
                            strScrollingNews.Append("<br/>"+"<b><u>" + "Deadlines:" + "</u></b>" + j.DeadLine + "<br/>" + j.Name + "<br/>" + j.Description);
                            
                        }
                        strScrollingNews.Append("</Marquee>");
                        Literal1.Text = strScrollingNews.ToString();
                    }
                    else
                    {
                        Literal1.Text = "No News";
                    }
                }

                lblNewsHeading.Text = "Notifications";

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {

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
                                (dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) > 0) || ((dataToShow.DeadLine.Date.CompareTo(newDateTime.Date) == 0) && (dataToShow.TimeSpan.CompareTo(newDateTime.TimeOfDay) > 0))
                            select dataToShow;


            }

        }
    }
}