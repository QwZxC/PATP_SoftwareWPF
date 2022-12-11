using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PAPT_SoftwareWPF.Models
{
    public class Employment : BaseModel
    {
        private int id;
        private int employmentId;
        private string name;
        private string surname;
        private string patronymic;
        private string dateOfBirth;
        private string contactNumber;
        private Department department;

        public bool isDeleted;


        public Employment()
        {
            patronymic = "";
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

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; OnPropertyChanged(); }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; OnPropertyChanged(); }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; OnPropertyChanged(); }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged(); }
        }

        public int EmploymentId
        {
            get { return employmentId; }
            set { employmentId = value; OnPropertyChanged(); }
        }
    }
}
