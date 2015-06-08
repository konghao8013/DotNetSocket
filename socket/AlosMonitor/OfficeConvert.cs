using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlosMonitor
{
    public class ServerOfficeConvert
    {
        public string Convert(string lastname, string url, string outUrl)
        {
            OfficeConvert office = new OfficeConvert();
            string message="";
            switch (lastname)
            {

                case "ppt":
                    message = office.PowerPointConvert(url, outUrl, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsXPS);
                    break;
                case "pptx":
                    message = office.PowerPointConvert(url, outUrl, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsXPS);
                    break;
                case "doc":
                    message = office.WordConvert(url, outUrl, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatXPS);
                    break;
                case "docx":
                    message = office.WordConvert(url, outUrl, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatXPS);
                    break;
                case "xls":
                    message = office.ExcelConvert(url, outUrl, Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypeXPS);
                    break;
                case "xlsx": break;
            }
            return message;
        }
    }
}
