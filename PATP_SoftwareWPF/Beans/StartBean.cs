using PAPT_SoftwareWPF.Types;
using Microsoft.EntityFrameworkCore;
using PAPT_SoftwareWPF.Models.Data;
using System.Collections.ObjectModel;
using PAPT_SoftwareWPF.Models;

namespace PAPT_SoftwareWPF.Beans
{
    public class StartBean
    {
        private MainBean mainBean;
        private ApplicationContext db;

        public StartBean(MainBean mainBean, ApplicationContext db)
        {
            this.mainBean = mainBean;
            this.db = db;
        }

        public MainBean MainBean
        {
            get { return mainBean; }
            private set { mainBean = value; }
        }

        public void GoToAccountingAndFinanceDepartment()
        {
            mainBean.SwitchPage(MainPageType.AccountingAndFinanceDepartmentPage);
        }

        public void GoToHRDepartment()
        {
            mainBean.SwitchPage(MainPageType.HRDepartamentPage);
        }

        public void GoToPlanningDepartment()
        {
            mainBean.SwitchPage(MainPageType.PlanningDepartmentPage);
        }

        public void GoToProductionDepartment()
        {
            mainBean.SwitchPage(MainPageType.ProductionDepartmentPage);
        }


        public void GoToStartPage()
        {
            mainBean.SwitchPage(MainPageType.Start);
        }
    }
}
