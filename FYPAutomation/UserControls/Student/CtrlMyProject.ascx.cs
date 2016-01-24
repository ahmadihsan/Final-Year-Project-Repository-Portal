using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYPAutomation.App_Start;
using FYPDAL;
using FYPUtilities;
namespace FYPAutomation.UserControls.Student
{
    public partial class CtrlMyProject : FYPBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var fyp=new FYPEntities())
            {
                long uid = FYPSession.GetLoggedUser().UserId;
                var data = (from prj in fyp.Projects
                            join projg in fyp.ProjectGroups on prj.PId equals projg.ProjectId
                            join usr in fyp.Users on prj.ProposedBy equals usr.UId
                            where projg.StudentId == uid
                            select new
                            {
                                prj.PId,
                                prj.Tiltle,
                                usr.Name,
                                usr.UId
                            }).ToList();
                dtvProject.DataSource = data;
                dtvProject.DataBind();
            }
        }
    }
}