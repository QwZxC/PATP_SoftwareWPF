using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPT_SoftwareWPF.Models
{
    public class Driver : Employment
    {
        private int id;
        private int driverLicenseNumber;
        private string whoIssuedIt;
        private string vehicleCategories;
        private string dateOfIssue;
        private string sateOfValidity;
        private int employementId;

        public Driver()
        {

        }

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int DriverLicenseNumber 
        {
            get { return driverLicenseNumber; }
            set { driverLicenseNumber = value;}
        }

        public string WhoIssuedIt 
        {
            get { return whoIssuedIt; }
            set { whoIssuedIt = value;}
        }

        public string VehicleCategories 
        {
            get { return vehicleCategories; }
            set { vehicleCategories = value;}
        }

        public string DateOfIssue 
        {
            get { return dateOfIssue; }
            set { dateOfIssue = value; }
        }

        public string SateOfValidity 
        {
            get { return sateOfValidity; }
            set { sateOfValidity = value; }
        }

        public int EmployementId
        {
            get { return employementId; }
            set { employementId = value; }
        }

        #endregion

    }
}
