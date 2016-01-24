using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FYPDAL;

namespace FYPAutomation.App_Start
{
    public class FYPBaseUserControl : UserControl
    {
        public long UserId;
        public FYPBaseUserControl()
        {
            UserId = FYPUtilities.FYPSession.GetLoggedUser() != null
                         ? FYPUtilities.FYPSession.GetLoggedUser().UserId
                         : -1;
        }
        public static List<User> GetFacultyStaffs()
        {
            return FrequentAccesses.GetFaculty();
        }

        public static List<KeyValue> GetProjectStatuses()
        {
            return FrequentAccesses.ListOfProjectStatus();
        }
        public static List<KeyValue> GetComplexeties()
        {
            return FrequentAccesses.Complexities();
        }
        public static List<KeyValue> GetDesignationStatuses()
        {
            return FrequentAccesses.ListOfDesignations();
        }
        public static List<KeyValue> GetFacultyRoles()
        {
            return FrequentAccesses.ListOfFacultyRoles();
        }
        public static List<KeyValue> GetListOfAllRoles()
        {
            return FrequentAccesses.ListOfAllRoles();
        }
        public static List<Department> GetDepartments()
        {
            using (var fypEntities = new FYPEntities())
            {
                return fypEntities.Departments.ToList();
            }
        }
        public static List<ResearchGroup> GetResearchGroups()
        {
            using (var fypEntities = new FYPEntities())
            {
                return fypEntities.ResearchGroups.ToList();
            }
        }
        public static List<KeyValue> GetUserStatus()
        {
            return FrequentAccesses.GetUserStatuses();
        }
        public static List<KeyValue> GetSemesterList()
        {
            return FrequentAccesses.ListOfSemester();
        }
        public static List<ProjectSession> GetProjectSessions()
        {
            using (var fypEntities = new FYPEntities())
            {
                return fypEntities.ProjectSessions.ToList();
            }
        }
    }
}