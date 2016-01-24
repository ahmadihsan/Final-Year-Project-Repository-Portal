using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace FYPUtilities
{
    /// <summary>
    /// 
    /// </summary>
    public class FYPSession : IReadOnlySessionState 
    {
        /// <summary>
        /// 
        /// </summary>
        public FYPSession()
        {
        }
        private const string SessionName = "FYPSession";
        public long UserId { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public int? ResearchId { get; set; }
        public string RoleName { get; set; }
        public long? ProjectId { get; set; }
        public List<long> GroupMembers { get; set; }
        public string Email { get; set; }
        public static bool IsUserLoggedIn()
        {
            return HttpContext.Current.Session[SessionName] != null;
        }
        public static FYPSession GetLoggedUser()
        {
            return LoggedUser();
        }
        public static bool ReleaseSession()
        {
            HttpContext.Current.Session[SessionName] = null;
            return IsUserLoggedIn();
        }
        public bool CreateSession()
        {
            try
            {
                HttpContext.Current.Session[SessionName] = this;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static FYPSession LoggedUser()
        {
            if (IsUserLoggedIn())
            {
                var fypSession = HttpContext.Current.Session[SessionName] as FYPSession;
                return fypSession;
            }
            else
                return null;
        }

        
    }
}
