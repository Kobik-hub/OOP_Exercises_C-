using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public enum eVehicleTypes
    {
        ElectricMotorCycle = 0,
        GasolineMotorCycle,
        ElectricCar,
        GasolineCar,
        Truck
    }
    public class ObjectModel
    {
        internal static GasolineEngine GetGasolineEngine(Vehicle i_Vehicle)
        {
            if(i_Vehicle is GasolineCar)
            {
                GasolineCar car = i_Vehicle as GasolineCar;
                return car.Engine;
            }
            else if(i_Vehicle is GasolineMotorCycle)
            {
                GasolineMotorCycle motorcycle = i_Vehicle as GasolineMotorCycle;
                return motorcycle.Engine;
            }
            else
            {
                return null;
            }
        }
        internal static ElectricEngine GetElectricEngine(Vehicle i_Vehicle)
        {
            if (i_Vehicle is ElectricCar)
            {
                ElectricCar car = i_Vehicle as ElectricCar;
                return car.Engine;
            }
            else if (i_Vehicle is ElectricMotorCycle)
            {
                ElectricMotorCycle motorcycle = i_Vehicle as ElectricMotorCycle;
                return motorcycle.Engine;
            }
            else
            {
                return null;
            }
        }
        private static Wheel[] NewWheelsList(
            string[] i_ManufacturerName,
            float[] i_CurrentAirPressure,
            float[] i_MaxAirPressure)
        {
            int numberOfWheels = i_MaxAirPressure.Length;
            Wheel[] wheels = new Wheel[numberOfWheels];
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i] = new Wheel(i_ManufacturerName[i], i_CurrentAirPressure[i], i_MaxAirPressure[i]);
            }
            return wheels;
        }
        internal static CustomerCarDetails AddCustomerCarDetails(string i_OwnerName, string i_PhoneNumber)
        {
            return new CustomerCarDetails(i_OwnerName, i_PhoneNumber);
        }
        internal static ElectricMotorCycle AddElectricMotorCycle(string i_ModelName, string i_LicensePlateNumber,
                                                                 eLicenseType i_LicenseType, int i_EngineVolumeInCubicCentimeters,
                                                                 float i_TimeLeftInBattery, float i_MaxBatteryTimeInHours,
                                                                 string[] i_ManufacturerName, float[] i_CurrentAirPressure,float[] i_MaxAirPressure)
         {
             Wheel[] wheels = NewWheelsList(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
             return  new ElectricMotorCycle(i_ModelName,
                              i_LicensePlateNumber,
                              i_LicenseType,
                              i_EngineVolumeInCubicCentimeters,
                              new ElectricEngine(i_TimeLeftInBattery, i_MaxBatteryTimeInHours),
                              wheels);
        }
        internal static GasolineMotorCycle AddGasolineMotorCycle(string i_ModelName, string i_LicensePlateNumber,
                                                                 eLicenseType i_LicenseType, int i_EngineVolumeInCubicCentimeters,
                                                                 eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter,
                                                                 string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure)
         {
             Wheel[] wheels = NewWheelsList(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            return new GasolineMotorCycle(i_ModelName,
                             i_LicensePlateNumber,
                             i_LicenseType,
                             i_EngineVolumeInCubicCentimeters,
                             new GasolineEngine(i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter),
                             wheels);
         }
        internal static ElectricCar AddElectricCar(string i_ModelName, string i_LicensePlateNumber,
                                                   eCarColor i_CarColor, int i_NumberOfDoors,
                                                   float i_TimeLeftInBattery, float i_MaxBatteryTimeInHours,
                                                   string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure)
        {
            Wheel[] wheels = NewWheelsList(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            return new ElectricCar(i_ModelName,
                             i_LicensePlateNumber,
                             i_CarColor,
                             i_NumberOfDoors,
                             new ElectricEngine(i_TimeLeftInBattery, i_MaxBatteryTimeInHours),
                             wheels);
        }
        internal static GasolineCar AddGasolineCar(string i_ModelName, string i_LicensePlateNumber,
                                                   eCarColor i_CarColor, int i_NumberOfDoors,
                                                   eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter,
                                                   string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure)
        {
            Wheel[] wheels = NewWheelsList(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            return new GasolineCar(i_ModelName,
                             i_LicensePlateNumber,
                             i_CarColor,
                             i_NumberOfDoors,
                             new GasolineEngine(i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter),
                             wheels);
        }
          internal static Truck AddTruck(string i_ModelName, string i_LicensePlateNumber,
                                         bool i_IsHaveHazmat, float i_LuggageVolume,
                                         eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter,
                                         string[] i_ManufacturerName, float[] i_CurrentAirPressure, float[] i_MaxAirPressure)
        {
            Wheel[] wheels = NewWheelsList(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            return  new Truck(i_ModelName,
                             i_LicensePlateNumber,
                             i_IsHaveHazmat,
                             i_LuggageVolume,
                             new GasolineEngine(i_FuelType, i_CurrentFuel, i_MaxFuelCapacityInLiter),
                             wheels);
        }
          internal static int VehicleNumberOfWheel(eVehicleTypes i_VehicleType)
           {
               switch(i_VehicleType)
               {
                   case eVehicleTypes.GasolineCar:
                   case eVehicleTypes.ElectricCar:
                        return 4;
                   case eVehicleTypes.GasolineMotorCycle:
                   case eVehicleTypes.ElectricMotorCycle:
                        return 2;
                   case eVehicleTypes.Truck:
                        return 16;
                   default:
                       return -1;
               }    
           }
    }
}
