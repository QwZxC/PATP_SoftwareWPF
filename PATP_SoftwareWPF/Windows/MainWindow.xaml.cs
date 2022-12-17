using System.Windows;
using System.Windows.Navigation;
using PAPT_SoftwareWPF.Beans;
using PAPT_SoftwareWPF.Types;
using PAPT_SoftwareWPF.Windows.Pages;
using Microsoft.EntityFrameworkCore;
using PAPT_SoftwareWPF.Models.Data;

namespace PAPT_SoftwareWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainBean mainBean;
        ApplicationContext db = new ApplicationContext();
        private StartPage startPage;

        public MainWindow()
        {
            InitializeComponent();
            mainBean = new MainBean(db);
            mainBean.MainPageTypeSwitched += SwitchPage;
            startPage = new StartPage(mainBean.StartBean);
            mainBean.SwitchPage(MainPageType.Start);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Employments.Load();
            db.Departments.Load();
        }

        private void SwitchPage(MainPageType mainPageType)
        {
            switch (mainPageType)
            {
                case MainPageType.Start:
                    mainFrame.Content = startPage;
                    break;
                case MainPageType.HRDepartamentPage:
                    mainFrame.Content = new HRDepartamentPage(mainBean.HRDepartamentBean, mainBean.StartBean);
                    break;
                case MainPageType.ProductionDepartmentPage:
                    mainFrame.Content = new ProductionDepartmentPage(mainBean.ProductionDepartmentBean, mainBean.StartBean);
                    break;
                case MainPageType.AccountingAndFinanceDepartmentPage:
                    mainFrame.Content = new AccountingAndFinanceDepartmentPage(mainBean.AccountingAndFinanceDepartmentBean, mainBean.StartBean);
                    break;
                case MainPageType.PlanningDepartmentPage:
                    mainFrame.Content = new PlanningDepartmentPage(mainBean.PlanningDepartmentBean, mainBean.StartBean);
                    break;
            }
        }
        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode != NavigationMode.New)
                e.Cancel = true;
        }
    }
}
