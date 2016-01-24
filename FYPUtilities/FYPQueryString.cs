using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPUtilities
{
    public static class FYPQueryString
    {
      public static bool GetQueryString(string queryString, out long outParam)
      {
          if (queryString == null)
          {
              outParam = -1;
              return false;
          }
             
          else
          {
              if(Convert.ToInt64(queryString)!=0)
              {
                  outParam = Convert.ToInt64(queryString);
                  return true;
              }
              else
              {
                  outParam = -1;
                  return false;
              }
              
          }
      }
    }
}
