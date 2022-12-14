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

        public Department(string name = "")
        {
            this.name = name;
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


    }
}
