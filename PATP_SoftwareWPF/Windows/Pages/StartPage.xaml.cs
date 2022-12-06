using PAPT_SoftwareWPF.Beans;
using System.Windows.Controls;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private StartBean startBean;

        public StartPage(StartBean startBean)
        {
            this.startBean = startBean;
            DataContext = startBean;
            InitializeComponent();
        }

        private void hrDepatmentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToHRDepartment();
        }

        private void AccountingAndFinanceDepartmentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToAccountingAndFinanceDepartment();
        }

        private void PlanningDepartmentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToPlanningDepartment();
        }

        private void ProductionDepartmentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToProductionDepartment();
        }
    }
}
