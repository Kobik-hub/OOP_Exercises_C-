using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    public class GarageManger
    {
        private readonly Dictionary<string, CustomerCarDetails> r_CustomersVehicleDetails;
        private readonly Dictionary<string, Vehicle> r_Vehicles;
        public GarageManger()
        {
            r_CustomersVehicleDetails = new Dictionary<string, CustomerCarDetails>();
            r_Vehicles = new Dictionary<string, Vehicle>();
        }
        public Dictionary<int,string> GetSupportedVehicles()
        {
            Dictionary<int, string> supportedVehicles = new Dictionary<int, string>();
            int numberOfSupportedVehicles = Enum.GetNames(typeof(eVehicleTypes)).Length;
            for(int i = 0; i < numberOfSupportedVehicles; i++)
            {
                string supportedVehiclesNames = Enum.GetName(typeof(eVehicleTypes), i);
                supportedVehicles.Add(i, supportedVehiclesNames);
            }
            return supportedVehicles;
        }
        public Dictionary<int, string> GetSupportedFuelType()
        {
            Dictionary<int, string> supportedFuelType = new Dictionary<int, string>();
            int numberOfSupportedFuelTypes = Enum.GetNames(typeof(eFuleType)).Length;

            for (int i = 0; i < numberOfSupportedFuelTypes; i++)
            {
                string supportedFuelTypesNames = Enum.GetName(typeof(eFuleType), i);
                supportedFuelType.Add(i, supportedFuelTypesNames);
            }
            return supportedFuelType;
        }
        public Dictionary<int, string> GetSupportedLicenseType()
        {
            Dictionary<int, string> supportedLicenceTypes = new Dictionary<int, string>();
            int numberOfSupportedLicenceTypes = Enum.GetNames(typeof(eLicenseType)).Length;
            for (int i = 0; i < numberOfSupportedLicenceTypes; i++)
            {
                string supportedFuelTypesNames = Enum.GetName(typeof(eLicenseType), i);
                supportedLicenceTypes.Add(i, supportedFuelTypesNames);
            }
            return supportedLicenceTypes;
        }
        public Dictionary<int, string> GetSupportedCarColor()
        {
            Dictionary<int, string> supportedCarColor = new Dictionary<int, string>();
            int numberOfSupportedCarColors = Enum.GetNames(typeof(eCarColor)).Length;

            for (int i = 0; i < numberOfSupportedCarColors; i++)
            {
                string supportedCarNames = Enum.GetName(typeof(eCarColor), i);
                supportedCarColor.Add(i, supportedCarNames);
            }
            return supportedCarColor;
        }
        public void AddElectricMotorCycle(
            string i_ModelName,
            string i_LicensePlateNumber,
            eLicenseType i_LicenseType,
            int i_EngineVolumeInCubicCentimeters,
            float i_TimeLeftInBattery,
            float i_MaxBatteryTimeInHours,
            string[] i_ManufacturerName,
            float[] i_CurrentAirPressure,
            float[] i_MaxAirPressure, 
            string i_OwnerName,
            string i_PhoneNumber
            )
        {

            ElectricMotorCycle electricMotorCycle = ObjectModel.AddElectricMotorCycle(i_ModelName, i_LicensePlateNumber,
                              i_LicenseType, i_EngineVolumeInCubicCentimeters,
                             i_TimeLeftInBattery, i_MaxBatteryTimeInHours,
                             i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);

            CustomerCarDetails customerCarDetails = ObjectModel.AddCustomerCarDetails(i_OwnerName, i_PhoneNumber);

            //Add Vehicles
            r_Vehicles.Add(i_LicensePlateNumber, electricMotorCycle);
            //AddCustomerCarDetails
            r_CustomersVehicleDetails.Add(i_LicensePlateNumber, customerCarDetails);
        }
        public void AddGasolineMotorCycle(
            string i_ModelName,
            string i_LicensePlateNumber,
            eLicenseType i_LicenseType,
            int i_EngineVolumeInCubicCentimeters,
            eFuleType i_FuelType,
            float i_CurrentFuel,
            float i_MaxFuelCapacityInLiter,
            string[] i_ManufacturerName,
            float[] i_CurrentAirPressure,
            float[] i_MaxAirPressure,
            string i_OwnerName,
            string i_PhoneNumber
            )
        {

            GasolineMotorCycle gasolineMotorCycle = ObjectModel.AddGasolineMotorCycle(i_ModelName,
                             i_LicensePlateNumber,
                             i_LicenseType,
                             i_EngineVolumeInCubicCentimeters,
                             i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter,
                             i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);

            CustomerCarDetails customerCarDetails = ObjectModel.AddCustomerCarDetails(i_OwnerName, i_PhoneNumber);

            //Add Vehicles
            r_Vehicles.Add(i_LicensePlateNumber, gasolineMotorCycle);
            //AddCustomerCarDetails
            r_CustomersVehicleDetails.Add(i_LicensePlateNumber, customerCarDetails);
        }
        public void AddElectricCar(string i_ModelName, string i_LicensePlateNumber,
                                   eCarColor i_CarColor, int i_NumberOfDoors,
                                   float i_TimeLeftInBattery, float i_MaxBatteryTimeInHours,
                                   string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure,
                                   string i_OwnerName, string i_PhoneNumber)
        {
            ElectricCar electricCar = ObjectModel.AddElectricCar(i_ModelName,
                             i_LicensePlateNumber,
                             i_CarColor,
                             i_NumberOfDoors,
                             i_TimeLeftInBattery, i_MaxBatteryTimeInHours,
                             i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            CustomerCarDetails customerCarDetails = ObjectModel.AddCustomerCarDetails(i_OwnerName, i_PhoneNumber);
            r_Vehicles.Add(i_LicensePlateNumber, electricCar);
            r_CustomersVehicleDetails.Add(i_LicensePlateNumber, customerCarDetails);
        }
        public void AddGasolineCar(string i_ModelName, string i_LicensePlateNumber,
                                   eCarColor i_CarColor, int i_NumberOfDoors,
                                   eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter,
                                   string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure,
                                   string i_OwnerName, string i_PhoneNumber)
        {
            GasolineCar gasolineCar = ObjectModel.AddGasolineCar(i_ModelName,
                             i_LicensePlateNumber,
                             i_CarColor,
                             i_NumberOfDoors,
                             i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter,
                             i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            CustomerCarDetails customerCarDetails = ObjectModel.AddCustomerCarDetails(i_OwnerName, i_PhoneNumber);

            //Add Vehicles
            r_Vehicles.Add(i_LicensePlateNumber, gasolineCar);
            //AddCustomerCarDetails
            r_CustomersVehicleDetails.Add(i_LicensePlateNumber, customerCarDetails);
        }
        public void AddTruckCar(string i_ModelName, string i_LicensePlateNumber,
                                bool i_IsHaveHazmat, float i_LuggageVolume,
                                eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter,
                                string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure,
                                string i_OwnerName, string i_PhoneNumber)
        {
            Truck truck = ObjectModel.AddTruck(i_ModelName,
                             i_LicensePlateNumber,
                             i_IsHaveHazmat,
                             i_LuggageVolume,
                             i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter,
                              i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);

            CustomerCarDetails customerCarDetails = ObjectModel.AddCustomerCarDetails(i_OwnerName, i_PhoneNumber);

            //Add Vehicles
            r_Vehicles.Add(i_LicensePlateNumber, truck);
            //AddCustomerCarDetails
            r_CustomersVehicleDetails.Add(i_LicensePlateNumber, customerCarDetails);
        }
        public bool SearchVehicle(string i_LicensePlateNumber)
        {
            bool vehicleFound = r_Vehicles.ContainsKey(i_LicensePlateNumber);
            return vehicleFound;
        }
        public void ChangeVehicleStatusToInRepair(string i_LicensePlateNumber)
        {
            CustomerCarDetails customer = r_CustomersVehicleDetails[i_LicensePlateNumber];
            customer.Status = eVehicleStatus.InRepair;
        }
        public static int GetNumberOfWheelsOfVehicleType(eVehicleTypes i_VehicleType)
        {
            return ObjectModel.VehicleNumberOfWheel(i_VehicleType);
        }
        public string[] GetListOfVehiclesLicense()
        {
            List<string> licensesNumberList = new List<string>(r_Vehicles.Keys);
            return licensesNumberList.ToArray();
        }
        public string[] GetListOfVehiclesLicenseByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {

            List<string> licensesNumberList = new List<string>();
            foreach(KeyValuePair<string, CustomerCarDetails> customerCarDetails in r_CustomersVehicleDetails)
            {
                if(customerCarDetails.Value.Status == i_VehicleStatus)
                {
                    licensesNumberList.Add(customerCarDetails.Key);
                }
            }
            return licensesNumberList.ToArray();
        }
        public void ChangeVehicleStatus(string i_LicensePlateNumber, eVehicleStatus i_Status)
        {
            bool vehicleInGarage = SearchVehicle(i_LicensePlateNumber);
            if(vehicleInGarage == false)
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }
            else
            {
                r_CustomersVehicleDetails[i_LicensePlateNumber].Status = i_Status;
            }
        }
        public void InflatingWheelsAirPressureToMaximum(string i_LicensePlateNumber)
        {
            bool vehicleInGarage = r_Vehicles.ContainsKey(i_LicensePlateNumber);
            if (vehicleInGarage == false)
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }
            else
            {
                Wheel[] wheels = r_Vehicles[i_LicensePlateNumber].Wheels;
                foreach(Wheel wheel in wheels)
                {
                    wheel.CurrentAirPressure = wheel.MaxAirPressure;
                }
            }
        }
        public void RefuelVehicle(string i_LicensePlateNumber, eFuleType i_FuelType, float i_QuantityToRefuel)
        {
            bool vehicleInGarage = SearchVehicle(i_LicensePlateNumber);
            if(vehicleInGarage == false)
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }
            GasolineEngine engine = ObjectModel.GetGasolineEngine(r_Vehicles[i_LicensePlateNumber]);
            if(engine != null)
            {
                engine.Refueling(i_QuantityToRefuel, i_FuelType);
            }
            else
            { 
                throw new ArgumentException("Vehicle doesn't have gasoline engine");
            }
        }
        public void ChargeVehicle(string i_LicensePlateNumber, float i_CountToChargeBatteryInMinuets)
        {
            bool vehicleInGarage = SearchVehicle(i_LicensePlateNumber);
            if (vehicleInGarage == false)
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            ElectricEngine engine = ObjectModel.GetElectricEngine(r_Vehicles[i_LicensePlateNumber]);
            if (engine != null)
            {
                float countToChargeInHours = i_CountToChargeBatteryInMinuets / 60;
                engine.BatteryCharge(countToChargeInHours);
            }
            else
            {
                throw new ArgumentException("Vehicle doesn't have electric engine");
            }
        }
        public string GetVehicleInformation(string i_LicensePlateNumber)
        {
            return  r_Vehicles[i_LicensePlateNumber].ToString();
        }
        public string GetCustomerInformation(string i_LicensePlateNumber)
        {
            string customerName = r_CustomersVehicleDetails[i_LicensePlateNumber].CustomerName;
            string CustomerPhoneNumber = r_CustomersVehicleDetails[i_LicensePlateNumber].CustomerPhoneNumber;
            int statusCode = (int) r_CustomersVehicleDetails[i_LicensePlateNumber].Status;
            return string.Format(
                "Customer Name: {1}{0}Customer Phone Number: {2}{0}Vehicle status:{3}",
                Environment.NewLine,
                customerName,
                CustomerPhoneNumber,
                Enum.GetName(typeof(eVehicleStatus), statusCode));
        }
    }
}