using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using PAPT_SoftwareWPF.Models;

namespace PAPT_SoftwareWPF.Reports.ExelGenerators
{
    public class HRExcelGenerator
    {
        public byte[] Generate(HRReport report)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets
                .Add("HRReport");


            sheet.Protection.IsProtected = true;
            return package.GetAsByteArray();
        }
    }
}
