using System.Windows.Controls;
using PAPT_SoftwareWPF.Beans;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountingAndFinanceDepartment.xaml
    /// </summary>
    public partial class AccountingAndFinanceDepartmentPage : Page
    {
        private AccountingAndFinanceDepartmentBean accountingAndFinanceDepartmentBean;
        private StartBean startBean;
        public AccountingAndFinanceDepartmentPage(AccountingAndFinanceDepartmentBean accountingAndFinanceDepartmentBean, StartBean startBean)
        {
            this.startBean = startBean;
            this.accountingAndFinanceDepartmentBean = accountingAndFinanceDepartmentBean;
            DataContext = accountingAndFinanceDepartmentBean;
            InitializeComponent();
        }

        private void backButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToStartPage();
        }
    }
}
