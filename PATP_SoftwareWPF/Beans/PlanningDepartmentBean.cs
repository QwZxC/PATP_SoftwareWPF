using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAPT_SoftwareWPF.Models;
using PAPT_SoftwareWPF.Models.Data;

namespace PAPT_SoftwareWPF.Beans
{
    public class PlanningDepartmentBean
    {
        private MainBean mainBean;
        private ApplicationContext db;
        private ObservableCollection<Driver> drivers;

        public PlanningDepartmentBean(MainBean mainBean, ApplicationContext db)
        {
            this.db = db;
            this.mainBean = mainBean; 
        }

        public MainBean MainBean 
        {
            get { return mainBean; }
            private set { mainBean = value; }
        }

        public void AddDriver()
        {

        }

        public void DeleteDriver()
        {

        }
    }
}
