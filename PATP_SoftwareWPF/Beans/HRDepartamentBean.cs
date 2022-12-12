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
using PAPT_SoftwareWPF.Reports;
using PAPT_SoftwareWPF.Reports.ExelGenerators;
using System.IO;
using PAPT_SoftwareWPF.Reports.JsonGenerators;
using System.Windows;
using System.Windows.Controls;

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
        private HRReport hRReport;
        private HRExcelGenerator hrExcelGenerator;
        private HRJsonGenerator hrJsonGenerator;

        private bool isSaved;
        private bool isSaveButtonEnabled;
        private bool isValidNameSurname;
        private bool isValidContactNumber;
        private bool isValidDateOfBirth;

        public HRDepartamentBean(MainBean mainBean, ApplicationContext db)
        {
            this.mainBean = mainBean;
            this.db = db;
            employments = new ObservableCollection<Employment>();
            departments = new List<Department>();
            hRReport = new HRReport(Employments.ToList());
            hrExcelGenerator = new HRExcelGenerator();
            LoadData();
        }

        #region Propertie


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

        public HRReport HRReport
        {
            get { return hRReport; }
            set { hRReport = value; }
        }

        public HRExcelGenerator HRExcelGenerator
        {
            get { return hrExcelGenerator; }
            set { hrExcelGenerator = value; }
        }
        
        public HRJsonGenerator HRJsonGenerator
        {
            get { return hrJsonGenerator; }
            set { hrJsonGenerator = value; }
        }

        public bool IsValidName
        {
            get { return isValidNameSurname; }
            set 
            { 
                isValidNameSurname = value;
                IsSaveButtonEnabled = value && CheckDataValid();
            }
        }

        public bool IsValidSurname
        {
            get { return isValidNameSurname; }
            set
            {
                isValidNameSurname = value;
                IsSaveButtonEnabled = value && CheckDataValid();
            }
        }

        public bool IsValidContactNumber
        {
            get { return isValidContactNumber; }
            set 
            { 
                isValidContactNumber = value;
                IsSaveButtonEnabled = value && CheckDataValid();
            }
        }

        public bool IsValidDateOfBirth
        {
            get { return isValidDateOfBirth; }
            set 
            { 
                isValidDateOfBirth = value;
                IsSaveButtonEnabled = value && CheckDataValid();
            }
        }

        public bool IsSaveButtonEnabled
        {
            get { return isSaveButtonEnabled; }
            set 
            { 
                isSaveButtonEnabled = value;
                IsSaved = !value;
                OnPropertyChanged("IsSaveButtonEnabled"); 
            }
        }

        #endregion

        #region Validation
        public void CheckValidColumnName()
        {
            IsValidName = Employments.All(employment => !string.IsNullOrEmpty(employment.Name));
        }

        public void CheckValidColumnSurname()
        {
            IsValidSurname = Employments.All(employment => !string.IsNullOrEmpty(employment.Name));
        }

        public void CheckValodColumnContactNumber()
        {
            IsValidContactNumber = Employments.All(employment => !string.IsNullOrEmpty(employment.ContactNumber));
        }

        public void CheckValidColumnYearOfBirth()
        {
            IsValidDateOfBirth = Employments.ToList().All(employment => !string.IsNullOrEmpty(employment.DateOfBirth));
        }

        public void CheckDepartmentEdition(Department selectedDepartment)
        {
            
        }

        public void CheckAllColumn()
        {
            CheckValidColumnYearOfBirth();
            CheckValodColumnContactNumber();
            CheckValidColumnName();
            CheckValidColumnSurname();
        }

        private bool CheckDataValid()
        {
            return IsValidDateOfBirth && IsValidContactNumber && IsValidName && IsValidDateOfBirth && IsValidSurname;
        }

        #endregion
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void DeletEmployment(List<Employment> employments)
        {
            employments.ForEach(employments => employments.isDeleted = true);
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
            IsValidContactNumber = false;
            IsValidDateOfBirth = false;
            IsValidName = false;
            IsValidSurname = false;
            IsSaveButtonEnabled = false;
            Employments.Add(employment);
            db.Employments.Add(employment);
            IsSaved = false;
        }

        public void LoadData()
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
            IsSaveButtonEnabled = false;
        }
        
        public void SaveChanges()
        {
            db.SaveChanges();
            IsSaved = true;
            IsSaveButtonEnabled = false;
        }

        public void MakeReport()
        {
            Employments.ToList().ForEach(employment => HRReport.Employments.Add(employment));
            var hrExelReport = HRExcelGenerator.Generate(HRReport);
            try
            {
                File.WriteAllBytes("Отчет отдела кадров.xlsx", hrExelReport);
            }
            catch
            {
                MessageBox.Show("Пожалуйста,закройте файл и повторите сохранение", "Ошибка!", MessageBoxButton.OK);
            }
            HRReport.Employments = new List<Employment>();
        }

        public void MakeJsonReport()
        {
            HRJsonGenerator.SaveData(Employments.ToList());
        }
    }
}