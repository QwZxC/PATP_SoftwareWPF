using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPT_SoftwareWPF.Models
{
    public class Department : BaseModel
    {
        private int id;
        private string name;
        private List<Employment> employments;

        public Department(string name = "")
        {
            this.name = name;
            employments= new List<Employment>();
        }

        public int Id 
        { 
            get { return id; } 
            set { id = value; } 
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public List<Employment> Employments
        {
            get { return employments; }
            set { employments = value; }
        }

    }
}
