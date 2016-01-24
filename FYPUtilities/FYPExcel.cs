using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel;
using System.IO;
namespace FYPUtilities
{
    public static class FYPExcel
    {
        public static DataSet ReadExcel(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                var extension = Path.GetExtension(filePath);
                if (extension != null)
                {
                    string fileExtension = extension.ToLower();
                    if (fileExtension == ".xlsx" || fileExtension == ".xls")
                    {
                        if (fileExtension == ".xlsx")
                            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                            {
                                excelDataReader.IsFirstRowAsColumnNames = true;
                                DataSet result = excelDataReader.AsDataSet();
                                excelDataReader.Close();
                                return result;
                            }
                        else if (fileExtension == ".xls")
                            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateBinaryReader(stream))
                            {
                                excelDataReader.IsFirstRowAsColumnNames = true;
                                DataSet result = excelDataReader.AsDataSet();
                                excelDataReader.Close();
                                return result;
                            }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;  // 
        }

    }
}
