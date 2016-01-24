using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPUtilities
{
    public static class FYPDate
    {
        public static string UniqueStringFromDate()
        {
            var dt = DateTime.Now;
            return (dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString()+ dt.Minute.ToString() + dt.Second.ToString());
        }
    }
}
