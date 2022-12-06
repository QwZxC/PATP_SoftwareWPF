using PAPT_SoftwareWPF.Beans;
using System.Windows.Controls;

namespace PAPT_SoftwareWPF.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlanningDepartmentPage.xaml
    /// </summary>
    public partial class PlanningDepartmentPage : Page
    {
        PlanningDepartmentBean planningDepartmentBean;
        StartBean startBean;
        public PlanningDepartmentPage(PlanningDepartmentBean planningDepartmentBean, StartBean startBean)
        {
            this.startBean = startBean;
            this.planningDepartmentBean = planningDepartmentBean;
            DataContext = planningDepartmentBean;
            InitializeComponent();
        }

        private void backButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            startBean.GoToStartPage();
        }
    }
}
