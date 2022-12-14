using Newtonsoft.Json;
using PAPT_SoftwareWPF.Models;
using System.Collections.Generic;
using System.IO;
using System;


namespace PAPT_SoftwareWPF.Reports.JsonGenerators
{
    public class HRJsonGenerator
    {
        public void SaveData(List<Employment> employments)
        {
            using (StreamWriter writer = File.CreateText("../../../Reports/Files/Отчет отдела кадров.json"))
            {
                string output = JsonConvert.SerializeObject(employments);
                writer.Write(output);
            }
        }
    }
}
