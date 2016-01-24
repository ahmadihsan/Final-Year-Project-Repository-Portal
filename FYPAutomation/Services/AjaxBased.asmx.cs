using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using FYPDAL;

namespace FYPAutomation.Services
{
    /// <summary>
    /// Summary description for AjaxBased
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AjaxBased : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public List<string> SearchProjectsByTitle(string prefixText, int count)
        {
            using (var fyp = new FYPEntities())
            {
                return (from pro in fyp.Projects
                        where pro.Tiltle.ToLower().Contains(prefixText.ToLower())
                        select pro.Tiltle).ToList();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public List<string> SearchByFaculty(string prefixText, int count)
        {
            using (var fyp = new FYPEntities())
            {
                return fyp.Users.Where(usr => usr.Name.Contains(prefixText) && usr.RoleId!=4).Select(usr => usr.Name).ToList();
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public List<string> SearchStudentByName(string prefixText, int count)
        {
            using (var fyp = new FYPEntities())
            {
                return fyp.Users.Where(usr => usr.Name.Contains(prefixText) && usr.RoleId==4).Select(usr => usr.Name).ToList();
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public List<string> SearchProjectBySessionId(string prefixText, int count,string contextKey)
        {
            using (var fyp = new FYPEntities())
            {
                long sid = -1;
                if (contextKey != "0")
                    sid = Convert.ToInt64(contextKey);
                return fyp.Projects.Where(pr => pr.ProjectSessionId == sid && pr.Tiltle.Contains(prefixText) && pr.Status==2).Select(prr => prr.Tiltle).ToList();
            }
        }
    }
}
