using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAPT_SoftwareWPF.Models;

namespace PAPT_SoftwareWPF.Reports
{
    public class HRReport
    {
        private List<Employment> employments;

        public List<Employment> Employments
        {
            get { return employments; }
            set { employments = value; }
        }
    }
}
