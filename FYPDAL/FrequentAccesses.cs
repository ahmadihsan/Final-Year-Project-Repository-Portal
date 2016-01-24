using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using FYPDAL;
namespace FYPDAL
{
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public KeyValue()
        {

        }
        public KeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class FrequentAccesses
    {
        public static string TimeWithAMorPm(TimeSpan ts)
        {
            DateTime dt = DateTime.Today.Add(ts);
            string ret = dt.ToString("h:mm tt");
            return ret;
        }

        public static string GetStringDayFrom(int day)
        {
            string stringDay = string.Empty;
            switch (day)
            {
                case 1: stringDay = "Monday"; break;
                case 2: stringDay = "Tuesday"; break;
                case 3: stringDay = "Wednesday"; break;
                case 4: stringDay = "Thursday"; break;
                case 5: stringDay = "Friday"; break;
                case 6: stringDay = "Saturday"; break;
            }
            return stringDay;
        }

        public static long? GetProjectSessionIdByUserId(long uid)
        {
            using (var fyp = new FYPEntities())
            {
                long? psid = 0;
                User u = fyp.Users.FirstOrDefault(x => x.UId == uid && x.RoleId == 4);
                if (u != null) psid = u.ProjectSessionId;
                return psid;
            }
        }

        public static TimeSpan FormatTime(string timePicker)
        {
            string timeSpan = string.Empty;
            var splitted = timePicker.Split(':');
            if (splitted.Length == 2)
            {
                if (splitted[1].IndexOf("pm", System.StringComparison.Ordinal) != -1)
                {
                    splitted[0] = (Convert.ToInt32(splitted[0]) + 12).ToString();
                }
                splitted[1] = splitted[1].Replace("am", "").Replace("pm", "");
            }
            return new TimeSpan(Convert.ToInt32(splitted[0]), Convert.ToInt32(splitted[1]), 0);
        }


        public enum ProjectStatus
        {
            NotAssigned = 1,
            Assigned = 2,
            Cancelled = 3
        }

        public enum UserStatus
        {
            Enabled = 1,
            Disabled = 0
        }
        public static List<User> GetFaculty()
        {
            using (var fypEntities = new FYPEntities())
            {
                return fypEntities.Users.Where(usr => usr.Role.Name.ToLower() != "student").ToList();
            }
        }
        public static List<User> GetStudent()
        {
            using (var fypEntities = new FYPEntities())
            {
                return fypEntities.Users.Where(usr => usr.Role.Name.ToLower() == "student").ToList();
            }
        }
        public static List<KeyValue> ListOfAllRoles()
        {
            using (var fypEntities = new FYPEntities())
            {
                return (from role in fypEntities.Roles
                        select new KeyValue(role.Name, role.Rid.ToString())).ToList();
            }
        }
        public static List<KeyValue> ListOfFacultyRoles()
        {
            var roleList = new List<KeyValue>();
            using (var fypEntities = new FYPEntities())
            {
                var rList = (from role in fypEntities.Roles
                             where role.Name.ToLower() != "student"
                             select new { role.Name, role.Rid }).ToList();
                roleList.AddRange(rList.Select(rlist => new KeyValue(rlist.Name, rlist.Rid.ToString())));
            }
            return roleList;
        }
        public static List<KeyValue> ListOfProjectStatus()
        {
            var returnStatus = new List<KeyValue>();
            for (int i = 1; i <= 3; i++)
            {
                returnStatus.Add(new KeyValue(i.ToString(CultureInfo.InvariantCulture),
                                 Enum.GetName(typeof(ProjectStatus), i)));
            }
            return returnStatus;
        }
        public static List<KeyValue> Complexities()
        {
            return new List<KeyValue>
                       {
                           new KeyValue("1","1"),
                           new KeyValue("2","2"),
                           new KeyValue("3","3"),
                           new KeyValue("4","4"),
                           new KeyValue("5","5")
                       };
        }
        public static List<KeyValue> ListOfDesignations()
        {
            return new List<KeyValue>
                       {
                           new KeyValue("HOD","HOD"),
                           new KeyValue("Associate Professor","Associate Professor"),
                           new KeyValue("Assistant Professor","Assistant Professor"),
                           new KeyValue("Lecturer","Lecturer"),
                           new KeyValue("RA","RA"),
                           new KeyValue("TA","TA"),
                           new KeyValue("External Examiner","External Examiner")
                       };
        }
        public static List<KeyValue> ListOfSemester()
        {
            return new List<KeyValue>
                       {
                           new KeyValue("7","7th"),
                           new KeyValue("8","8th"),
                           new KeyValue("9","9th"),
                           new KeyValue("10","10th"),
                           new KeyValue("11","11th"),
                           new KeyValue("12","12th"),
                       };
        }
        public static string GetFacultyById(long uid)
        {
            string facName = null;
            using (var fypEntities = new FYPEntities())
            {
                var userName = fypEntities.Users.FirstOrDefault(fac => fac.UId == uid);
                if (userName != null)
                    facName = userName.Name;
            }
            return facName;
        }
        public static string GetStatusByValue(int sid)
        {
            string status = null;
            switch (sid)
            {
                case 1:
                    var name = Enum.GetName(typeof(ProjectStatus), 1);
                    if (name != null)
                        status = name.ToString();
                    break;
                case 2:
                    var s = Enum.GetName(typeof(ProjectStatus), 2);
                    if (s != null) status = s.ToString();
                    break;
                case 3:
                    var name1 = Enum.GetName(typeof(ProjectStatus), 3);
                    if (name1 != null) status = name1.ToString();
                    break;
            }
            return status;
        }               //Project statuses
        public static string GetResearchGroupById(int rid)
        {
            string rGroup = null;
            using (var fypEntities = new FYPEntities())
            {
                var firstOrDefault = fypEntities.ResearchGroups.FirstOrDefault(r => r.ResearchId == rid);
                if (firstOrDefault != null)
                    rGroup = firstOrDefault.Title;
            }
            return rGroup;
        }
        public static string GetDepartmentNameById(int did)
        {
            string dName = null;
            using (var fypEntities = new FYPEntities())
            {
                var firstOrDefault = fypEntities.Departments.FirstOrDefault(d => d.DId == did);
                if (firstOrDefault != null)
                    dName = firstOrDefault.Name;
            }
            return dName;
        }
        public static string GetRoleNameById(int rid)
        {
            string roleName = null;
            using (var fypEntities = new FYPEntities())
            {
                var firstOrDefault = fypEntities.Roles.FirstOrDefault(d => d.Rid == rid);
                if (firstOrDefault != null)
                    roleName = firstOrDefault.Name;
            }
            return roleName;
        }
        public static string GetUserStatusById(bool rid)
        {
            return rid ? "Enabled" : "Disabled";
        }
        public static string Get10FromBoolean(bool rid)
        {
            return rid ? "1" : "0";
        }
        public static bool GetBooleanFrom10(int rid)
        {
            return rid == 1 ? true : false;
        }
        public static List<KeyValue> GetUserStatuses()
        {
            return new List<KeyValue>
                       {
                           new KeyValue("Enabled","1"),
                           new KeyValue("Disabled","0")
                       };
        }
        public static string GethSemesterString(int sId)
        {
            string semester = null;
            switch (sId)
            {
                case 7: semester = "7th"; break;
                case 8: semester = "8th"; break;
                case 9: semester = "9th"; break;
                case 10: semester = "10th"; break;
                case 11: semester = "11th"; break;
                case 12: semester = "12th"; break;
            }
            return semester;
        }
        public static string GetProjectSessionStatus(bool sessState)
        {
            string projectStatus = null;
            projectStatus = sessState ? "Enabled" : "Disabled";
            return projectStatus;
        }
        public static long GetProjectId(long uId)
        {
            long pId = -1;
            using (var fypEntities = new FYPEntities())
            {
                var firstOrDefault = fypEntities.ProjectGroups.FirstOrDefault(pg => pg.StudentId == uId);
                if (firstOrDefault != null)
                    pId = firstOrDefault.ProjectId;
            }
            return pId;
        }
        public static string GetMsDocumentStatus(int dId)
        {
            string retStr = string.Empty;
            //return dId == 1 ? "Accepted" : "Rejected";
            switch (dId)
            {
                case 0:
                    retStr = "In Process";
                    break;
                case 1:
                    retStr = "Accepted";
                    break;
                case 2:
                    retStr = "Rejected";
                    break;
                case 3:
                    retStr = "Re Submit";
                    break;
            }
            return retStr;
        }
        public static string GetCustodianOfDocument(long umsId, long projectId)
        {
            using (var fyp = new FYPEntities())
            {
                var inCustody = fyp.SP_GetCustodianOfDocument(umsId, projectId).ToList();
                return inCustody[0];
            }

        }

        public static string GetCustodianOfDocumentHistory(long cid)
        {
            using (var fyp = new FYPEntities())
            {
                var inCustody = fyp.SP_GetCustodianOfDocumentHistory(cid).ToList();
                return inCustody[0];
            }

        }
        public static int GetRoleIdByUserId(long uid)
        {
            int rid = -1;
            using (var fypEntities = new FYPEntities())
            {
                var orDefault = fypEntities.Users.FirstOrDefault(r => r.UId == uid);
                if (orDefault != null)
                {
                    rid = orDefault.RoleId;
                }
            }
            return rid;
        }
        public static bool IsCustodian(long umsid, long userId)
        {
            using (var fyp = new FYPEntities())
            {
                string roleName = GetRoleNameById(GetRoleIdByUserId(userId));
                var uploadedMileStoneDoc = fyp.UploadedMileStoneDocs.FirstOrDefault(umsd => umsd.UMSDId == umsid);
                if (uploadedMileStoneDoc != null)
                {
                    if (uploadedMileStoneDoc.ToAdmin == true && roleName.ToString().ToLower() == "admin")
                        return true;
                    else if (uploadedMileStoneDoc.InCustody == null && (roleName.ToString().ToLower() != "admin" || roleName.ToString().ToLower() != "convener"))
                        return false;
                    return uploadedMileStoneDoc.InCustody == userId;
                }
                return false;
            }
        }

        public static string ReadStatusOfDocument(bool val)
        {
            return val ? "Evaluated" : "NotEvaluated";
        }

        public static string DocumentCheckedOrNot(int val)
        {
            string statusOfDoc = string.Empty;
            switch (val)
            {
                case 1:
                    statusOfDoc = "Evaluated";
                    break;
                case 0:
                    statusOfDoc = "Not Evaluated";
                    break;
            }
            return statusOfDoc;
        }

        public static string GetProjectIdByName(string projectName)
        {
            string pid = string.Empty;
            using (var fyp = new FYPEntities())
            {
                var proj = fyp.Projects.FirstOrDefault(p => p.Tiltle == projectName);
                if (proj != null)
                    pid = proj.PId.ToString();
            }
            return pid;
        }

        public static string GetProjectSessionNameById(long psId)
        {
            string sessName = string.Empty;
            if (psId == -1)
            {
                sessName = "FYP-I/FYP-II";
            }
            else
            {
                using (var fyp = new FYPEntities())
                {
                    var firstOrDefault = fyp.ProjectSessions.Where(ps => ps.PSId == psId).Select(ps => ps.Name).FirstOrDefault();
                    if (firstOrDefault != null)
                        sessName = firstOrDefault.ToString();
                }
            }
            return sessName;
        }
        public static void GetAllAssignedProjects()
        {
            using (var fyp = new FYPEntities())
            {
                var projectSessions = fyp.ProjectSessions.Where(ps => ps.Status == true).Select(ps => ps.PSId).ToList();
                foreach (var projectSession in projectSessions)
                {
                    HttpContext.Current.Cache[projectSession.ToString()] =
                        fyp.Projects.Where(pr => pr.ProjectSessionId == projectSession && pr.Status == 2).Select(
                            prr => prr.Tiltle).ToList();
                }

            }
        }

        public static string GetUrlForSchedule(string roleName)
        {
            string url = string.Empty;
            switch (roleName.ToLower())
            {
                case "convener": url = "~/Pages/Convener/WeeklySchedule.aspx"; break;
                case "admin": url = "~/Pages/Admin/WeeklySchedule.aspx"; break;
                case "pcmember": url = "~/Pages/PCMember/WeeklySchedule.aspx"; break;
                case "faculty": url = "~/Pages/Faculty/WeeklySchedule.aspx"; break;
                case "student": url = "~/Pages/Student/WeeklySchedule.aspx"; break;
            }
            return url;
        }

        public static string GetUrlForSubmissionDocument(string rName, string id)
        {
            long dId;
            string url = string.Empty;
            if (long.TryParse(id, out dId))
            {
                using (var fyp = new FYPEntities())
                {
                    ProjectMileStoneDeadLine deadLine = fyp.ProjectMileStoneDeadLines.First(x => x.PMSDId == dId);
                    TimeSpan take = DateTime.Now.TimeOfDay;

                    //-------------

                    int a = deadLine.DeadLine.Date.CompareTo(DateTime.Now.Date);
                    int b = deadLine.TimeSpan.CompareTo(take);
                    //-------------



                    if (((deadLine.DeadLine.Date.CompareTo(DateTime.Now.Date) > 0)) ||
                        ((deadLine.DeadLine.Date.CompareTo(DateTime.Now.Date) == 0) &&
                         (deadLine.TimeSpan.CompareTo(take)) > 0))
                    {
                        switch (rName.ToLower())
                        {
                            case "convener": url = "~/Pages/Convener/SubmitDocs.aspx"; break;
                            case "admin": url = "~/Pages/Admin/SubmitDocs.aspx"; break;
                            case "pcmember": url = "~/Pages/PCMember/SubmitDocs.aspx"; break;
                            case "faculty": url = "~/Pages/Faculty/SubmitDocs.aspx"; break;
                            //case "student": url = "~/Pages/Student/SubmitDocs.aspx"; break;
                        }
                        
                    }
                    else
                    {
                        switch (rName.ToLower())
                        {
                            case "convener": url = "~/Pages/Convener/Notify.aspx"; break;
                            case "admin": url = "~/Pages/Admin/Notify.aspx"; break;
                            case "pcmember": url = "~/Pages/PCMember/Notify.aspx"; break;
                            case "faculty": url = "~/Pages/Faculty/Notify.aspx"; break;
                            //case "student": url = "~/Pages/Student/SubmitDocs.aspx"; break;
                        }
                    }
                }
            }
            return url;
        }
    }
}
