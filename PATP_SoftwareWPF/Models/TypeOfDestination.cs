using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPT_SoftwareWPF.Models
{
    public class TypeOfDestination : BaseModel
    {
        private int id;
        private string name;

        public TypeOfDestination(string name)
        {
            this.name = name;
        }

        public int ID
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
