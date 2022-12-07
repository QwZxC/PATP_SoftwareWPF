using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PAPT_SoftwareWPF.Models
{
    public class RouteModel
    {
        private int id;
        private string name;
        private string theDateOfTheBeginning;
        private string expirationDate;
        private string routeCode;
        private int fare;
        private bool isClosedRoute;
        private bool workingDays;
        private bool isWorksOnWeekends;
        private bool isOpenAllYearRound;

        public RouteModel() 
        { 
        }

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string TheDateOfTheBeginning 
        {
            get { return theDateOfTheBeginning; }
            set { theDateOfTheBeginning = value; }
        }

        public string TheExpirationDate
        { 
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public string RouteCode
        { 
            get { return routeCode; }
            set { routeCode = value; }
        }

        public int Fare
        { 
            get { return fare; } 
            set { fare = value; } 
        }

        public bool IsClosedRoute
        { 
            get { return isClosedRoute; }
            set { isClosedRoute = value; }
        }

        public bool IsWorksOnWeekends
        { 
            get { return isWorksOnWeekends;}
            set { isWorksOnWeekends = value; }
        }

        public bool IsOpenAllYearRound
        { 
            get { return isOpenAllYearRound; }
            set { isOpenAllYearRound = value; }
        }

        #endregion
    }
}
