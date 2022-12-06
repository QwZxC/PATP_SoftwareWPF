using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAPT_SoftwareWPF.Models.Data;

namespace PAPT_SoftwareWPF.Beans
{
    public class ProductionDepartmentBean
    {
        private MainBean mainBean;
        private ApplicationContext db;

        public ProductionDepartmentBean(MainBean mainBean, ApplicationContext db)
        {
            this.db = db;
            this.mainBean = mainBean;
        }

        public MainBean MainBean 
        {
            get { return mainBean; }
            private set { mainBean = value; }
        }
    }
}
