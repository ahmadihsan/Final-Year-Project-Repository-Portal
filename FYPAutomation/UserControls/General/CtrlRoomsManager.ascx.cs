using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;

namespace FYPAutomation.UserControls.General
{
    public partial class CtrlRoomsManager : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().ToLower().IndexOf("RoomsManager.aspx") != -1)
                {
                    if (Request.QueryString["mid"] != null && Request.QueryString["mid"] == "true")
                    {
                        FYPMessage.ShowPopUpMessage("Success", new List<string>() { "Room Added Successfully" }, this.Page, true);
                    }
                }
                //PopulateGridForRooms();

            }
        }
        private void PopulateGridForRooms()
        {
            using (var fypEntities = new FYPEntities())
            {
                GvdRooms.DataSource = fypEntities.RoomsForPresentations.ToList();
                GvdRooms.DataBind();
            }
        }
      
        protected void CancelDeadLineClick(object sender, EventArgs e)
        {
            FYPMessage.RedirectToUrl(VirtualPathUtility.ToAbsolute("~/Pages/Convener/MileStoneDeadline.aspx"), true, this.Page);
        }

        /// <summary>
        /// Add Rooms clicked
        /// </summary>
        protected void AddRoomClicked(object sender, EventArgs e)
        {
            using (var fypEntities = new FYPEntities())
            {
                var rm=new RoomsForPresentation()
                                            {
                                                Title =txtRoom.Text
                                            };
                fypEntities.RoomsForPresentations.Add(rm);
                if(fypEntities.SaveChanges()>0)
                {
                    string url = Request.RawUrl;
                    if (url.IndexOf("?", System.StringComparison.Ordinal) != -1)
                    {
                        url = url.Substring(0, url.IndexOf("?") + 1) + "mid=true";
                    }
                    else
                    {
                        url = url + "?mid=true";
                    }
                    FYPMessage.RedirectToUrl(url, true, this.Page);
                }
            }
        }

        /// <summary>
        /// Show Pop UP
        /// </summary>
        protected void AddRoomsClickedToShowPopUp(object sender, EventArgs e)
        {
            FYPMessage.ShowBootStrapPopUp("AddDeadLine", this.Page, true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lbll.Attributes.Add("rules", "all");
            lbll.Attributes.Add("style", "border:1px solid #c1dad7");
            base.OnPreRender(e);
        }
    }
}