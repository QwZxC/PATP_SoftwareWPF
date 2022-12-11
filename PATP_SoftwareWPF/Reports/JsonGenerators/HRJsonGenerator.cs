using Newtonsoft.Json;
using PAPT_SoftwareWPF.Models;
using System.Collections.Generic;
using System.IO;
using System;


namespace PAPT_SoftwareWPF.Reports.JsonGenerators
{
    public class HRJsonGenerator
    {
        private readonly string PATH;

        public HRJsonGenerator(string path)
        {
            PATH = path;
        }

        public void SaveData(List<Employment> employments)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(employments);
                writer.Write(output);
            }
        }
    }
}
