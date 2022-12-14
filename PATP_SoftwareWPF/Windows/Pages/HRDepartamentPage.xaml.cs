using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PAPT_SoftwareWPF.Beans;
using PAPT_SoftwareWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private bool isLoaded;
        public HRDepartamentPage(HRDepartamentBean hRDepartamentBean, StartBean startBean)
        {
            this.startBean = startBean;
            this.hRDepartmentbean = hRDepartamentBean;
            DataContext = hRDepartamentBean;
            isLoaded = false;
            InitializeComponent();
            isLoaded = true;
        }

        public HRDepartamentBean HRDepartamentbean
        {
            get { return hRDepartmentbean; }
            set { hRDepartmentbean = value; }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            // Допилить с проверкой на изменения
            if (!hRDepartmentbean.IsSaved
                && MessageBox.Show("Вы не сохранили изменения", "Предупреждение!", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
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

        private void namesurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int index = textBox.CaretIndex;
            textBox.Text = Regex.Replace(textBox.Text, "[^А-Яа-яЁё]*[ ]*", "");
            textBox.CaretIndex = index;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Background = invalidFieldColor;
                HRDepartamentbean.IsValidName = false;
                return;
            }
            textBox.Background = validFieldColor;
            if (!HRDepartamentbean.IsValidName)
            {
                HRDepartamentbean.CheckValidColumnName();
                HRDepartamentbean.CheckValidColumnSurname();
            }
        }

        private void contactNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int index = textBox.CaretIndex;
            textBox.Text = Regex.Replace(textBox.Text, "[^0-9]*", "");
            textBox.CaretIndex = index;
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
            int index = textBox.CaretIndex;
            textBox.Text = Regex.Replace(textBox.Text, "[^0-9.]", "");
            textBox.CaretIndex = index;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
                textBox.CaretIndex = 1;
            }
            try
            {
                if (textBox.Text.Length != 10 || DateTime.Parse(textBox.Text) > DateTime.Now)
                {
                    textBox.Background = invalidFieldColor;
                    HRDepartamentbean.IsValidDateOfBirth = false;
                    return;
                }
            }
            catch
            {
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
    }
}
