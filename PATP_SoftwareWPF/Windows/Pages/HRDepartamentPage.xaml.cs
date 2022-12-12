using PAPT_SoftwareWPF.Beans;
using PAPT_SoftwareWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для HRDepartamentPage.xaml
    /// </summary>
    public partial class HRDepartamentPage : Page
    {
        HRDepartamentBean hRDepartmentbean;
        StartBean startBean;
        private Brush invalidFieldColor = (Brush)new BrushConverter().ConvertFrom("#FFFFDDDB");
        private Brush validFieldColor = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
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
            hRDepartmentbean.SaveChanges();
        }

        private void departmentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HRDepartamentbean.SelectedDepartment = ((sender as ComboBox).SelectedItem) as Department;
        }

        private void employmentsDataTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hRDepartmentbean.SelectedEmployment = employmentsDataTable.SelectedItem as Employment;
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Regex.Replace(textBox.Text, "[^А-Яа-яЁё]*[ ]*", "");
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Background = invalidFieldColor;
                HRDepartamentbean.IsValidName = false;
                return;
            }
            textBox.Background = validFieldColor;
            if (!HRDepartamentbean.IsValidName)
                HRDepartamentbean.CheckValidColumnName();
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Regex.Replace(textBox.Text, "[^А-Яа-яЁё]*[ ]*", "");
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Background = invalidFieldColor;
                HRDepartamentbean.IsValidSurname = false;
                return;
            }
            textBox.Background = validFieldColor;
            if (!HRDepartamentbean.IsValidSurname)
                HRDepartamentbean.CheckValidColumnSurname();
        }

        private void contactNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Regex.Replace(textBox.Text, "[^0-9]*", "");
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text.Length != 11)
            {
                textBox.Background = invalidFieldColor;
                HRDepartamentbean.IsValidContactNumber = false;
                return;
            }
            textBox.Background = validFieldColor;
            if (!HRDepartamentbean.IsValidContactNumber)
                HRDepartamentbean.CheckValodColumnContactNumber();
        }

        private void dateOfBirthTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Regex.Replace(textBox.Text, "[^0-9-.-.]*", "");
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
                textBox.CaretIndex = 1;
            }
            if (textBox.Text.Length != 10 || DateTime.Parse(textBox.Text) > DateTime.Now)
            {
                textBox.Background = invalidFieldColor;
                HRDepartamentbean.IsValidDateOfBirth = false;
                return;
            }
            textBox.Background = validFieldColor;
            if (!HRDepartamentbean.IsValidDateOfBirth)
                HRDepartamentbean.CheckValidColumnYearOfBirth();
        }

        private void createExelFileButton_Click(object sender, RoutedEventArgs e)
        {
            HRDepartamentbean.MakeReport();
        }

        private void createJsonFileButton_Click(object sender, RoutedEventArgs e)
        {
            HRDepartamentbean.MakeJsonReport();
        }

        private void departamentsCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HRDepartamentbean.CheckDepartmentEdition((sender as ComboBox).SelectedItem as Department);
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            //FIX ME СУПЕР ПУПЕР ПЛОХАЯ ФИЛЬТРАЦИЯ СДЕЛАТЬ ПО УМНОМУ
            if (e.Item != null)
            {
                Department department = departmentFilterComboBox.SelectedItem as Department;
                string name = nameFilterTextBox.Text;
                string surname = surnameFilterTextBox.Text;
                string patronomic = patronomicFilterTextBox.Text;
                string dateOfbirth = dateOfBirthFilterTextBox.Text;
                string contactNumber = contactNumberFilterTextBox.Text;

                if (department != null)
                    e.Accepted = (e.Item as Employment).Department == department;

                if (!string.IsNullOrEmpty(name))
                    e.Accepted = (e.Item as Employment).Name.StartsWith(name);

                if (!string.IsNullOrEmpty(surname))
                    e.Accepted = (e.Item as Employment).Surname.StartsWith(surname);

                if (!string.IsNullOrEmpty(patronomic))
                    e.Accepted = (e.Item as Employment).Patronymic.StartsWith(patronomic);

                if (!string.IsNullOrEmpty(dateOfbirth))
                    e.Accepted = (e.Item as Employment).DateOfBirth.StartsWith(dateOfbirth);

                if (!string.IsNullOrEmpty(contactNumber))
                    e.Accepted = (e.Item as Employment).ContactNumber.StartsWith(contactNumber);
            } 
        }

        private void departmentFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(employmentsDataTable.ItemsSource).Refresh();
        }

        private void universal_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(employmentsDataTable.ItemsSource).Refresh();
        }
    }
}
