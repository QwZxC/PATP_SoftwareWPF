using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPT_SoftwareWPF.Models
{
    public class Technic
    {
        private int id;
        private string carBrand;
        private string model;
        private string colour;
        private string gosNumber;
        private TypeOfDestination type;
        private int maxPassangerPlaces;
        private int fuelConsumption;
        private int loadCapacity;
        private string vin;

        public Technic()
        {

        }

        #region Propeties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string CarBrand
        {
            get { return carBrand; }
            set { carBrand = value; }
        }

        public string Model 
        {  
            get { return model; }
            set { model = value; }
        }

        public string Colour 
        {
            get { return colour; }
            set { colour = value; }
        }

        public string GosNumber  
        { 
            get { return gosNumber; } 
            set { gosNumber = value; }
        }

        public TypeOfDestination Type 
        {
            get { return type; }
            set { type = value;}
        }

        public int MaxPassangerPlaces
        {
            get { return maxPassangerPlaces; }
            set { maxPassangerPlaces = value; }
        }

        public int FuelConsumption 
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public int LoadCapacity 
        { 
            get { return loadCapacity; }
            set { loadCapacity = value; }
        }

        public string Vin 
        {
            get { return vin; }
            set {vin = value; }
        }

        #endregion

    }
}
