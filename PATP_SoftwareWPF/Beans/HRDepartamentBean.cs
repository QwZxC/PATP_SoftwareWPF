using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PAPT_SoftwareWPF.Models;
using PAPT_SoftwareWPF.Models.Data;
using Microsoft.EntityFrameworkCore;


namespace PAPT_SoftwareWPF.Beans
{
    public class HRDepartamentBean : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ApplicationContext db;
        private MainBean mainBean;
        private ObservableCollection<Employment> employments;
        private Employment selectedEmployment;
        private List<Department> departments;
        private Department selectedDepartment;

        private bool isSaved;
        private bool isValidNameSurname;
        private bool isValidContactNumber;
        private bool isValidDateOfBirth;

        public HRDepartamentBean(MainBean mainBean, ApplicationContext db)
        {
            this.mainBean = mainBean;
            this.db = db;
            employments = new ObservableCollection<Employment>();
            departments = new List<Department>();
            LodadData();
        }

        #region Properties



        public MainBean MainBean
        {
            get { return mainBean; }
            private set { mainBean = value; }
        }

        public ObservableCollection<Employment> Employments
        {
            get { return employments; }
            set { employments = value; OnPropertyChanged("Employments"); }
        }

        public bool IsSaved
        {
            get { return isSaved; }
            set { isSaved = value; }
        }

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; OnPropertyChanged("SelectedDepartment"); }
        }

        public Employment SelectedEmployment
        {
            get { return selectedEmployment; }
            set { selectedEmployment = value; OnPropertyChanged("SelectedEmployment"); }
        }

        public List<Department> Departments
        {
            get { return departments; }
            set { departments = value; OnPropertyChanged("Departments"); }
        }

        public bool IsValidNameSurname
        {
            get { return isValidNameSurname; }
            set { isValidNameSurname = value; OnPropertyChanged("IsValidName"); }
        }

        public bool IsValidContactNumber
        {
            get { return isValidContactNumber; }
            set { isValidContactNumber = value;}
        }

        public bool IsValidDateOfBirth
        {
            get { return isValidDateOfBirth; }
            set { isValidDateOfBirth = value;}
        }

        #endregion

        #region Validation
        public void CheckValidColumnNameSurname()
        {
            IsValidNameSurname = !Employments.All(employment => string.IsNullOrEmpty(employment.Name) || string.IsNullOrEmpty(employment.Surname));
        }

        public void CheckValodColumnContactNumber()
        {
            IsValidContactNumber = !Employments.All(employment => string.IsNullOrEmpty(employment.ContactNumber));
        }

        public void CheckValidColumnYearOfBirth()
        {
            IsValidDateOfBirth = !Employments.ToList().All(employment => string.IsNullOrEmpty(employment.DateOfBirth));
        }

        #endregion
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void DeletEmployment(List<Employment> employments)
        {
            employments.ForEach(member => member.isDeleted = true);
            Employments.ToList().ForEach(employment => 
            {
                if (employment.isDeleted)
                {
                    Employments.Remove(employment);
                    db.Employments.Remove(employment);
                }
            });
            IsSaved = false;
        }

        public void AddEmployment()
        {
            Employment employment = new Employment() 
            {
                EmploymentId = Employments.Count + 1
            };
            employment.Department = Departments[0];
            IsSaved = false;
            IsValidContactNumber = false;
            isValidContactNumber = false;
            Employments.Add(employment);
            db.Employments.Add(employment);
        }

        public void LodadData()
        {
            db.Departments.ForEachAsync(department => Departments.Add(department));
            if (Departments.Count == 0)
            {
                db.Departments.Add(new Department("Отдел кадров"));
                db.Departments.Add(new Department("Отдел планирования"));
                db.Departments.Add(new Department("Отдел производства"));
                db.Departments.Add(new Department("Отдел бухгалтерии и финансов"));
                db.SaveChanges();
                db.Departments.ForEachAsync(department => Departments.Add(department));
            }
            db.Employments.ForEachAsync(employment => Employments.Add(employment));
        }
        
        public void SaveChanges()
        {
            db.SaveChanges();
            IsSaved = true;
        }
    }
}