using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using PAPT_SoftwareWPF.Beans;
using PAPT_SoftwareWPF.Models;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для HRDepartamentPage.xaml
    /// </summary>
    public partial class HRDepartamentPage : Page
    {
        HRDepartamentBean hRDepartmentbean;
        StartBean startBean;

        public HRDepartamentPage(HRDepartamentBean hRDepartamentBean, StartBean startBean)
        {
            this.startBean = startBean;
            this.hRDepartmentbean = hRDepartamentBean;
            DataContext = hRDepartamentBean;
            InitializeComponent();
        }

        public HRDepartamentBean HRDepartamentbean
        {
            get { return hRDepartmentbean; } 
            set { hRDepartmentbean = value; }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Допилить с проверкой на изменения
            if (!hRDepartmentbean.IsSaved)
                MessageBox.Show("Есть не сохранённые изменения");
            startBean.GoToStartPage();
        }

        private void addEmploymentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            hRDepartmentbean.AddEmployment();
        }

        private void deleteEmploymentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<Employment> deleteMembers = employmentsDataTable.SelectedItems.Cast<Employment>().ToList();
            hRDepartmentbean.DeletEmployment(deleteMembers);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Допилить с проверкой на изменения
            hRDepartmentbean.SaveChanges();
        }

        private void departmentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             HRDepartamentbean.SelectedDepartment = (sender as ComboBox).SelectedItem as Department;
        }

        private void employmentsDataTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hRDepartmentbean.SelectedEmployment = employmentsDataTable.SelectedItem as Employment;
        }
    }
}
