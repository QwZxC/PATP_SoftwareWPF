using PAPT_SoftwareWPF.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAPT_SoftwareWPF.Models.Data;
using PAPT_SoftwareWPF.Models;

namespace PAPT_SoftwareWPF.Beans
{
    public class MainBean
    {
        public delegate void mainPageTypeHandler(MainPageType mainPageType);
        public event mainPageTypeHandler MainPageTypeSwitched;

        private ApplicationContext db;
        private AccountingAndFinanceDepartmentBean accountingAndFinanceDepartmentBean;
        private HRDepartamentBean hrDepartamentBean;
        private PlanningDepartmentBean planningDepartmentBean;
        private ProductionDepartmentBean productionDepartmentBean;
        private StartBean startBean;

        private MainPageType mainPageType;

        public MainBean(ApplicationContext db)
        {
            this.db = db;
            StartBean = new StartBean(this, db);
            LoadData();
            SwitchPage(MainPageType.Start);
        }

        public AccountingAndFinanceDepartmentBean AccountingAndFinanceDepartmentBean
        {
            get { return accountingAndFinanceDepartmentBean; }
            private set { accountingAndFinanceDepartmentBean = value; }
        }

        public HRDepartamentBean HRDepartamentBean
        {
            get { return hrDepartamentBean; }
            private set { hrDepartamentBean = value; }
        }
        
        public PlanningDepartmentBean PlanningDepartmentBean
        {
            get { return planningDepartmentBean; }
            private set { planningDepartmentBean = value; }
        }

        public ProductionDepartmentBean ProductionDepartmentBean
        {
            get { return productionDepartmentBean; }
            private set { productionDepartmentBean = value; }
        }

        public StartBean StartBean
        {
            get { return startBean; }
            private set { startBean = value; }
        }

        private void LoadData()
        {
            db.Database.SqlQueryRaw<Department>("SELECT * FROM Departments");
            db.Database.SqlQueryRaw<Employment>("SELECT * FROM Employments");
            
        }

        private MainPageType MainPageType
        {
            get { return mainPageType; }
            set { mainPageType = value; }
        }

        public void SwitchPage(MainPageType mainPageType)
        {
            if (MainPageTypeSwitched == null)
                return;

            MainPageType = mainPageType;
            switch (mainPageType)
            {
                case MainPageType.Start:
                    if (StartBean == null)
                        StartBean = new StartBean(this, db);
                    break;
                case MainPageType.HRDepartamentPage:
                    if (HRDepartamentBean == null)
                        HRDepartamentBean = new HRDepartamentBean(this, db);
                    break;
                case MainPageType.AccountingAndFinanceDepartmentPage:
                    if (AccountingAndFinanceDepartmentBean == null)
                        AccountingAndFinanceDepartmentBean = new AccountingAndFinanceDepartmentBean(this, db);
                    break;
                case MainPageType.PlanningDepartmentPage:
                    if (PlanningDepartmentBean == null)
                        PlanningDepartmentBean = new PlanningDepartmentBean(this, db);
                    break;
                case MainPageType.ProductionDepartmentPage:
                    if (ProductionDepartmentBean == null)
                        ProductionDepartmentBean = new ProductionDepartmentBean(this, db);
                    break;
            }
            MainPageTypeSwitched.Invoke(mainPageType);
        }
    }
}
