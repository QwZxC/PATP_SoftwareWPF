using PAPT_SoftwareWPF.Beans;
using System.Windows.Controls;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductionDepartmentPage.xaml
    /// </summary>
    public partial class ProductionDepartmentPage : Page
    {
        ProductionDepartmentBean productionDepartmentBean;
        StartBean startBean;

        public ProductionDepartmentPage(ProductionDepartmentBean productionDepartmentBean, StartBean startBean)
        {
            this.startBean = startBean;
            this.productionDepartmentBean = productionDepartmentBean;
            DataContext = productionDepartmentBean;
            InitializeComponent();
        }

        private void backButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToStartPage();
        }
    }
}
