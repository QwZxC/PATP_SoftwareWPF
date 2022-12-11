using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using PAPT_SoftwareWPF.Models;
using System;
using System.Linq;

namespace PAPT_SoftwareWPF.Reports.ExelGenerators
{
    public class HRExcelGenerator
    {


        public byte[] Generate(HRReport report)
        {
            //FIX ME Каким-то боком пришло больше работников, чем есть на самом деле
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets
                .Add("HRReport");

            sheet.Cells["C1"].Value = "Работники";

            sheet.Cells["A2"].Value = "Имя";
            report.Employments.ForEach(employment => 
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId ) + 3,1].Value = employment.Name;
                return;
            });

            sheet.Cells["B2"].Value = "Фамилия";
            report.Employments.ForEach(employment =>
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId) + 3, 2].Value = employment.Surname;
                return;
            });

            sheet.Cells["C2"].Value = "Отчество";
            report.Employments.ForEach(employment =>
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId) + 3, 3].Value = employment.Patronymic;
                return;
            });

            sheet.Cells["D2"].Value = "Дата рождения";
            report.Employments.ForEach(employment =>
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId) + 3, 4].Value = employment.DateOfBirth;
                return;
            });

            sheet.Cells["E2"].Value = "Номер телефона";
            report.Employments.ForEach(employment =>
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId) + 3, 5].Value = Int64.Parse(employment.ContactNumber);
                return;
            });
           
            sheet.Cells["F2"].Value = "Название отдела";
            report.Employments.ForEach(employment =>
            {
                sheet.Cells[report.Employments.FindIndex(e => employment.EmploymentId == e.EmploymentId) + 3, 6].Value = employment.Department.Name;
                return;
            });

            sheet.Column(4).Style.Numberformat.Format = "yyyy-mm-dd";
            

            sheet.Cells.AutoFitColumns();
            return package.GetAsByteArray();
        }
    }
}
