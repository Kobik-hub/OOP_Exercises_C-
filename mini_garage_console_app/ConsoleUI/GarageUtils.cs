using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic;
namespace ConsoleUI
{
    class GarageUtils
    {
        public static eUserChoice GetMenuChoiceFromUser()
        {
            bool validChoice = false;
            int o_UserChoiceCode = -1;
            int numberOfChoices = Enum.GetNames(typeof(eUserChoice)).Length;
            while (validChoice != true)
            {
                DisplayMenuChoice();
                bool isNumber = int.TryParse(Console.ReadLine(), out o_UserChoiceCode);
                if (isNumber == true)
                {
                    if (o_UserChoiceCode > 0 && o_UserChoiceCode <= numberOfChoices)
                    {
                        validChoice = true;
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input!");
                }
                Console.Clear();
                Console.WriteLine("Invalid Input!");
            }
            return (eUserChoice)o_UserChoiceCode;
        }
        public static void EnterANewVehicleInToeGarage(GarageManger i_GarageManger)
        {
            eVehicleTypes VehicleType;
            getVehicleTypeFromUser(out VehicleType, i_GarageManger);
            Console.Clear();
            string o_LicensePlateNumber;
            getVehicleLicenseNumber(out o_LicensePlateNumber);
            bool isExists = i_GarageManger.SearchVehicle(o_LicensePlateNumber);
            if (isExists)
            {
                i_GarageManger.ChangeVehicleStatusToInRepair(o_LicensePlateNumber);
                Console.WriteLine("The vehicle already in the garage, the status of the vehicle changed to in repair");
            }
            else
            {
                switch (VehicleType)
                {
                    case eVehicleTypes.ElectricCar:
                        createElectricCar(i_GarageManger, o_LicensePlateNumber);
                        break;
                    case eVehicleTypes.GasolineCar:
                        createGasolineCar(i_GarageManger, o_LicensePlateNumber);
                        break;
                    case eVehicleTypes.GasolineMotorCycle:
                        createGasolineMotorcycle(i_GarageManger, o_LicensePlateNumber);
                        break;
                    case eVehicleTypes.ElectricMotorCycle:
                        createElectricMotorcycle(i_GarageManger, o_LicensePlateNumber);
                        break;
                    case eVehicleTypes.Truck:
                        createTruck(i_GarageManger, o_LicensePlateNumber);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void DisplayListOfLicensesNumbers(GarageManger i_Controller)
        {
            bool displayByStatus = false;
            bool validChoice = false;
            while (validChoice != true)
            {
                Console.WriteLine(
                    string.Format(
                        "Enter 1 to display all vehicles licenses numbers{0}Press 2 to display vehicles licenses number by status",
                        Environment.NewLine));
                int o_Choice;
                bool isNumber = int.TryParse(Console.ReadLine(), out o_Choice);
                if (isNumber == true)
                {
                    if (o_Choice == 1)
                    {
                        displayByStatus = false;
                        break;
                    }
                    else if (o_Choice == 2)
                    {
                        displayByStatus = true;
                        break;
                    }
                }

                Console.Clear();
                Console.WriteLine("Invalid choice!");
            }
            Console.Clear();
            switch (displayByStatus)
            {
                case false:
                    displayListOfAllLicenseNumbers(i_Controller);
                    break;
                case true:
                    eVehicleStatus o_Status;
                    Console.Clear();
                    getVehicleStatusFromUser(out o_Status);
                    Console.Clear();
                    displayListOfLicensesNumbersByVehicleStatus(i_Controller, o_Status);
                    break;
                default:
                    break;
            }
        }
        public static void ChangeVehicleStatus(GarageManger i_Controller)
        {
            Console.WriteLine("Enter License Plate Number:");
            string licensePlateNumber = Console.ReadLine();
            bool isExists = i_Controller.SearchVehicle(licensePlateNumber);
            if (isExists == false)
            {
                Console.WriteLine("The vehicle not found.");
                return;
            }
            string[] statusNames = Enum.GetNames(typeof(eVehicleStatus));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < statusNames.Length; i++)
            {
                sb.AppendLine(string.Format("For {0} press {1}", statusNames[i], i + 1));
            }
            bool validStatusCode = false;
            int o_StatusCode = -1;
            int numberOfStatus = Enum.GetNames(typeof(eVehicleStatus)).Length;
            Console.WriteLine(numberOfStatus.ToString());
            while (validStatusCode != true)
            {
                Console.WriteLine(sb.ToString());
                bool isNumber = int.TryParse(Console.ReadLine(), out o_StatusCode);
                if (isNumber == true)
                {
                    if (o_StatusCode > 0 && o_StatusCode <= numberOfStatus)
                    {
                        validStatusCode = true;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
            Console.Clear();
            i_Controller.ChangeVehicleStatus(licensePlateNumber, (eVehicleStatus)o_StatusCode);
            Console.WriteLine("Vehicle status changed successfully");
        }
        public static void InflatingWheelsToMaximum(GarageManger i_Controller)
        {
            Console.WriteLine("Inflate wheels to maximum");
            Console.WriteLine("Enter License Plate Number:");
            string licensePlateNumber = Console.ReadLine();

            bool isExists = i_Controller.SearchVehicle(licensePlateNumber);

            if (isExists == false)
            {
                Console.WriteLine("The vehicle not found.");
                return;
            }
            else
            {
                i_Controller.InflatingWheelsAirPressureToMaximum(licensePlateNumber);
                Console.Clear();
                Console.WriteLine("All wheels inflated to maximum.");
            }
        }
        public static void RefuelGasolineVehicle(GarageManger i_Controller)
        {
            Console.WriteLine("Reful Vehicle:");
            Console.WriteLine("Enter License Plate Number:");
            string licensePlateNumber = Console.ReadLine();
            bool isExists = i_Controller.SearchVehicle(licensePlateNumber);
            if (isExists == false)
            {
                Console.WriteLine("The vehicle not found.");
                return;
            }
            eFuleType o_FuelType;
            float amontOfFuelToRefuel;
            getAmountFuelToRefuel(out amontOfFuelToRefuel);
            getFuelType(out o_FuelType, i_Controller);
            try
            {
                i_Controller.RefuelVehicle(licensePlateNumber, o_FuelType, amontOfFuelToRefuel);
                Console.WriteLine("Vehicle refueled successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ChargeElectricVehicle(GarageManger i_Controller)
        {
            Console.WriteLine("Charge Vehicle:");
            Console.WriteLine("Enter License Plate Number:");
            string licensePlateNumber = Console.ReadLine();
            bool isExists = i_Controller.SearchVehicle(licensePlateNumber);
            if (isExists == false)
            {
                Console.WriteLine("The vehicle not found.");
                return;
            }
            float amountOfMinutesToCharge;
            getAmountOfMinutesToCharge(out amountOfMinutesToCharge);
            try
            {
                i_Controller.ChargeVehicle(licensePlateNumber, amountOfMinutesToCharge);
                Console.WriteLine("Vehicle charged successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public static void DisplayVehicleInCustomerInformation(GarageManger i_Controller)
        {
            Console.WriteLine("Display vehicle information");
            Console.WriteLine("Enter License Plate Number:");
            string licensePlateNumber = Console.ReadLine();
            bool isExists = i_Controller.SearchVehicle(licensePlateNumber);
            if (isExists == false)
            {
                Console.WriteLine("The vehicle not found.");
                return;
            }
            Console.Clear();
            Console.WriteLine(i_Controller.GetVehicleInformation(licensePlateNumber));
            Console.WriteLine(i_Controller.GetCustomerInformation(licensePlateNumber));
        }
        public static void DisplayMenuChoice()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Garage Main Menu");
            sb.AppendLine("1. To add new car to the garage press 1");
            sb.AppendLine("2. To display list of vehicles license Numbers press 2");
            sb.AppendLine("3. To change vehicle status press 3");
            sb.AppendLine("4. To inflate wheels to maximum press 4");
            sb.AppendLine("5. To refuel gasoline vehicle press 5");
            sb.AppendLine("6. To charge electric vehicle press 6");
            sb.AppendLine("7. To display vehicle information press 7");
            sb.AppendLine("8. To Quit press 8");
            Console.WriteLine(sb.ToString());
        }
        private static void getAmountOfMinutesToCharge(out float o_AmountOfMinutesToCharge)
        {
            o_AmountOfMinutesToCharge = -1;
            bool validAmountToCharge = false;
            while (validAmountToCharge != true)
            {
                Console.WriteLine("Please enter amount of minutes to charge between 1 - 1000");
                bool isNumber = float.TryParse(Console.ReadLine(), out o_AmountOfMinutesToCharge);
                if (isNumber == true)
                {
                    if (o_AmountOfMinutesToCharge > 0 && o_AmountOfMinutesToCharge <= 1000)
                    {
                        validAmountToCharge = true;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getAmountFuelToRefuel(out float o_AmontOfFuelToRefuel)
        {
            o_AmontOfFuelToRefuel = -1;
            bool validAmountToRefuel = false;
            while (validAmountToRefuel != true)
            {
                Console.WriteLine("Please enter amount to refuel in liters between 1 - 200");
                bool isNumber = float.TryParse(Console.ReadLine(), out o_AmontOfFuelToRefuel);
                if (isNumber == true)
                {
                    if (o_AmontOfFuelToRefuel > 0 && o_AmontOfFuelToRefuel <= 200)
                    {
                        validAmountToRefuel = true;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getVehicleTypeFromUser(out eVehicleTypes o_VehicleType, GarageManger iController)
        {
            const bool v_ValidNumberCode = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter a valid vehicle type code");
            foreach (KeyValuePair<int, string> vehicleType in iController.GetSupportedVehicles())
            {
                sb.AppendFormat("{0}: {1}", vehicleType.Key.ToString(), vehicleType.Value);
                sb.AppendLine();
            }
            while ((!v_ValidNumberCode) != true)
            {
                Console.WriteLine(sb.ToString());
                int o_VehicleTypeCode = -1;
                bool isNumber = int.TryParse(Console.ReadLine(), out o_VehicleTypeCode);
                if (isNumber)
                {
                    if (o_VehicleTypeCode >= 0 && o_VehicleTypeCode < iController.GetSupportedVehicles().Count)
                    {
                        o_VehicleType = (eVehicleTypes)o_VehicleTypeCode;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid code number!");
                    }
                }
            }
        }
        private static void createElectricCar(GarageManger i_Controller, string i_LicensePlateNumber)
        {
            string o_CustomerName;
            getCustomerName(out o_CustomerName);
            Console.Clear();
            string o_CustomerPhoneNumber;
            getCustomerPhoneNumber(out o_CustomerPhoneNumber);
            Console.Clear();
            string o_ModelName;
            getVehicleModelName(out o_ModelName);
            Console.Clear();
            int numberOfWheels = GarageManger.GetNumberOfWheelsOfVehicleType(eVehicleTypes.ElectricCar);
            Console.WriteLine(eVehicleTypes.ElectricCar);
            string[] o_ManufacturerNames;
            float[] o_CurrentAirPressures;
            float[] o_MaxAirPressures;
            getWheelsInfo(numberOfWheels, out o_ManufacturerNames, out o_CurrentAirPressures, out o_MaxAirPressures);
            float o_MaxBatteryTimeInHours;
            float o_TimeLeftInBatteryInHours;
            getBatteryMaxCapacityInHours(out o_MaxBatteryTimeInHours);
            getBatteryLeftCapacityInHours(out o_TimeLeftInBatteryInHours, o_MaxBatteryTimeInHours);
            eCarColor color;
            getCarColor(out color, i_Controller);
            int o_NumberOfDoors;
            getNumberOfDoors(out o_NumberOfDoors);
            i_Controller.AddElectricCar(
                o_ModelName,
                i_LicensePlateNumber,
                color,
                o_NumberOfDoors,
                o_TimeLeftInBatteryInHours,
                o_MaxBatteryTimeInHours,
                o_ManufacturerNames,
                o_CurrentAirPressures,
                o_MaxAirPressures,
                o_CustomerName,
                o_CustomerPhoneNumber
            );
        }
        private static void createGasolineCar(GarageManger i_Controller, string i_LicensePlateNumber)
        {
            string cutomerName;
            getCustomerName(out cutomerName);
            Console.Clear();
            string customerPhoneNumber;
            getCustomerPhoneNumber(out customerPhoneNumber);
            Console.Clear();
            string modelName;
            getVehicleModelName(out modelName);
            Console.Clear();
            int numberOfWheels = GarageManger.GetNumberOfWheelsOfVehicleType(eVehicleTypes.GasolineCar);
            Console.WriteLine(eVehicleTypes.GasolineCar);
            string[] manufacturerNames;
            float[] currentAirPressures;
            float[] maxAirPressures;
            getWheelsInfo(numberOfWheels, out manufacturerNames, out currentAirPressures, out maxAirPressures);
            float maxFuelCapacityInLiters;
            float currentFuelInLiters;
            eFuleType fuelType;
            getFuelType(out fuelType, i_Controller);
            getMaxFuelCapacityInLiter(out maxFuelCapacityInLiters);
            getBatteryLeftCapacityInHours(out currentFuelInLiters, maxFuelCapacityInLiters);
            eCarColor color;
            getCarColor(out color, i_Controller);
            int numberOfDoors;
            getNumberOfDoors(out numberOfDoors);
            i_Controller.AddGasolineCar(
                modelName,
                i_LicensePlateNumber,
                color,
                numberOfDoors,
                fuelType,
                currentFuelInLiters,
                maxFuelCapacityInLiters,
                manufacturerNames,
                currentAirPressures,
                maxAirPressures,
                cutomerName,
                customerPhoneNumber
            );
        }
        private static void createGasolineMotorcycle(GarageManger i_Controller, string i_LicensePlateNumber)
        {
            string cutomerName;
            getCustomerName(out cutomerName);
            Console.Clear();
            string customerPhoneNumber;
            getCustomerPhoneNumber(out customerPhoneNumber);
            Console.Clear();
            string modelName;
            getVehicleModelName(out modelName);
            Console.Clear();
            int numberOfWheels = GarageManger.GetNumberOfWheelsOfVehicleType(eVehicleTypes.GasolineMotorCycle);
            Console.WriteLine(eVehicleTypes.GasolineMotorCycle);
            string[] manufacturerNames;
            float[] currentAirPressures;
            float[] maxAirPressures;
            getWheelsInfo(numberOfWheels, out manufacturerNames, out currentAirPressures, out maxAirPressures);
            float maxFuelCapacityInLiters;
            float currentFuelInLiters;
            eFuleType fuelType;
            getFuelType(out fuelType, i_Controller);
            getMaxFuelCapacityInLiter(out maxFuelCapacityInLiters);
            getCurrentFuelInLiter(out currentFuelInLiters, maxFuelCapacityInLiters);
            eLicenseType licenseType;
            getLicenseType(out licenseType, i_Controller);
            int engineVolumeInCubicCentimeters;
            getEngineVolumeInCubicCentimeters(out engineVolumeInCubicCentimeters);
            i_Controller.AddGasolineMotorCycle(
                modelName,
                i_LicensePlateNumber,
                licenseType,
                engineVolumeInCubicCentimeters,
                fuelType,
                currentFuelInLiters,
                maxFuelCapacityInLiters,
                manufacturerNames,
                currentAirPressures,
                maxAirPressures,
                cutomerName,
                customerPhoneNumber
            );
        }
        private static void createElectricMotorcycle(GarageManger i_Controller, string i_LicensePlateNumber)
        {
            string cutomerName;
            getCustomerName(out cutomerName);
            Console.Clear();
            string customerPhoneNumber;
            getCustomerPhoneNumber(out customerPhoneNumber);
            Console.Clear();
            string modelName;
            getVehicleModelName(out modelName);
            Console.Clear();
            int numberOfWheels = GarageManger.GetNumberOfWheelsOfVehicleType(eVehicleTypes.ElectricMotorCycle);
            Console.WriteLine(eVehicleTypes.ElectricMotorCycle);
            string[] manufacturerNames;
            float[] currentAirPressures;
            float[] maxAirPressures;
            getWheelsInfo(numberOfWheels, out manufacturerNames, out currentAirPressures, out maxAirPressures);
            float maxBatteryTimeInHours;
            float timeLeftInBatteryInHours;
            getBatteryMaxCapacityInHours(out maxBatteryTimeInHours);
            getBatteryLeftCapacityInHours(out timeLeftInBatteryInHours, maxBatteryTimeInHours);
            eLicenseType licenseType;
            getLicenseType(out licenseType, i_Controller);
            int engineVolumeInCubicCentimeters;
            getEngineVolumeInCubicCentimeters(out engineVolumeInCubicCentimeters);
            i_Controller.AddElectricMotorCycle(
                modelName,
                i_LicensePlateNumber,
                licenseType,
                engineVolumeInCubicCentimeters,
                timeLeftInBatteryInHours,
                maxBatteryTimeInHours,
                manufacturerNames,
                currentAirPressures,
                maxAirPressures,
                cutomerName,
                customerPhoneNumber
            );
        }
        private static void createTruck(GarageManger i_Controller, string i_LicensePlateNumber)
        {
            string cutomerName;
            getCustomerName(out cutomerName);
            Console.Clear();
            string customerPhoneNumber;
            getCustomerPhoneNumber(out customerPhoneNumber);
            Console.Clear();
            string modelName;
            getVehicleModelName(out modelName);
            Console.Clear();
            int numberOfWheels = GarageManger.GetNumberOfWheelsOfVehicleType(eVehicleTypes.Truck);
            Console.WriteLine(eVehicleTypes.Truck);
            string[] manufacturerNames;
            float[] currentAirPressures;
            float[] maxAirPressures;
            getWheelsInfo(numberOfWheels, out manufacturerNames, out currentAirPressures, out maxAirPressures);
            float maxFuelCapacityInLiters;
            float currentFuelInLiters;
            eFuleType fuelType;
            getFuelType(out fuelType, i_Controller);
            getMaxFuelCapacityInLiter(out maxFuelCapacityInLiters);
            getCurrentFuelInLiter(out currentFuelInLiters, maxFuelCapacityInLiters);
            bool isHaveHazmat;
            float luggageVolume;
            getIsHaveHazmat(out isHaveHazmat);
            getLuggageVolume(out luggageVolume);
            i_Controller.AddTruckCar(
                modelName,
                i_LicensePlateNumber,
                isHaveHazmat,
                luggageVolume,
                fuelType,
                currentFuelInLiters,
                maxFuelCapacityInLiters,
                manufacturerNames,
                currentAirPressures,
                maxAirPressures,
                cutomerName,
                customerPhoneNumber
            );
        }
        private static void getBatteryMaxCapacityInHours(out float o_BatteryMaxCapacityInHours)
        {
            o_BatteryMaxCapacityInHours = -1;
            bool validBatteryCapacity = false;
            while (validBatteryCapacity != true)
            {
                Console.WriteLine("Enter battery max capacity in hours between 2-50");
                bool isNumber = float.TryParse(Console.ReadLine(), out o_BatteryMaxCapacityInHours);
                if (isNumber)
                {
                    if (o_BatteryMaxCapacityInHours >= 2 && o_BatteryMaxCapacityInHours <= 50)
                    {
                        validBatteryCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getBatteryLeftCapacityInHours(out float o_BatteryLeftCapacityInHours, float i_BatteryMaxCapacityInHours)
        {
            o_BatteryLeftCapacityInHours = -1;
            bool validBatteryCapacity = false;
            while (validBatteryCapacity != true)
            {
                Console.WriteLine(string.Format("Enter how much battery left to use in hours between 2-{0}", i_BatteryMaxCapacityInHours.ToString()));
                bool isNumber = float.TryParse(Console.ReadLine(), out o_BatteryLeftCapacityInHours);
                if (isNumber)
                {
                    if (o_BatteryLeftCapacityInHours >= 2 && o_BatteryLeftCapacityInHours <= i_BatteryMaxCapacityInHours)
                    {
                        validBatteryCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getWheelsInfo(
            int numberOfWheels,
            out string[] i_ManufacturerNames,
            out float[] i_CurrentAirPressures,
            out float[] i_MaxAirPressures)
        {
            i_ManufacturerNames = new string[numberOfWheels];
            i_MaxAirPressures = new float[numberOfWheels];
            i_CurrentAirPressures = new float[numberOfWheels];
            Console.WriteLine("Wheels information:");
            Console.WriteLine(string.Format("enter 1 if all wheels are the same{0}enter 2 if they different",Environment.NewLine));
            bool validChoice = true;
            int choice = 0;
            while (validChoice == true)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out choice);
                if (isNumber == true)
                {
                    if (choice == 1 || choice == 2)
                    {
                        break;
                    }

                }

            }
            Console.Clear();
            string manufacturerName = null;
            float maxAirPressure = 0;
            float currentAirPressure = 0;
            for (int i = 0; i < numberOfWheels; i++)

            {
                Console.WriteLine(string.Format("Wheel number {0}:", i + 1));

                if (choice == 2 || (choice == 1 && manufacturerName == null))
                {
                    bool IsValidManufacturerName = false;

                    while (IsValidManufacturerName != true)
                    {
                        Console.WriteLine("Please enter manufacturer name must to be at least 3");
                        manufacturerName = Console.ReadLine();
                        if (manufacturerName.Length > 3)
                        {
                            IsValidManufacturerName = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid manufacturer!");
                        }

                    }
                    bool validMaxAirPressure = false;
                    while (validMaxAirPressure != true)
                    {
                        Console.WriteLine("Please enter a max air pressure between 10-50 ");
                        bool isNumber = float.TryParse(Console.ReadLine(), out maxAirPressure);
                        if (isNumber == true)
                        {
                            if (maxAirPressure <= 50 && maxAirPressure >= 10)
                            {
                                validMaxAirPressure = true;

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input!");
                        }

                    }
                }
                string currentAirPressureNameMsg = string.Format(
                    "Please enter current air pressure that between 1-{0}", maxAirPressure.ToString());
                bool validCurrentAirPressure = false;
                while (validCurrentAirPressure != true)
                {
                    Console.WriteLine(currentAirPressureNameMsg);
                    bool isNumber = float.TryParse(Console.ReadLine(), out currentAirPressure);
                    if (isNumber == true)
                    {
                        if (currentAirPressure <= maxAirPressure && maxAirPressure >= 0)
                        {
                            break;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                }
                Console.Clear();
                i_ManufacturerNames[i] = manufacturerName;
                i_MaxAirPressures[i] = maxAirPressure;
                i_CurrentAirPressures[i] = currentAirPressure;
            }
        }
        private static void getCarColor(out eCarColor o_Color, GarageManger i_Controller)
        {
            bool validColorCode = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter a valid car color code");
            foreach (KeyValuePair<int, string> vehicleType in i_Controller.GetSupportedCarColor())
            {
                sb.AppendFormat("{0}: {1}", vehicleType.Key.ToString(), vehicleType.Value);
                sb.AppendLine();
            }
            int vehicleColorCode = -1;
            while (validColorCode != true)
            {
                Console.WriteLine(sb.ToString());

                bool isNumber = int.TryParse(Console.ReadLine(), out vehicleColorCode);
                if (isNumber)
                {
                    if (vehicleColorCode >= 0 && vehicleColorCode < i_Controller.GetSupportedCarColor().Count)
                    {
                        break;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid color code number!");
                    }
                }
            }
            o_Color = (eCarColor)vehicleColorCode;
        }
        private static void getNumberOfDoors(out int o_NumberOfDoors)
        {
            o_NumberOfDoors = -1;
            bool validBatteryCapacity = false;
            while (validBatteryCapacity != true)
            {
                Console.WriteLine("Enter number of doors between 2-5");
                bool isNumber = int.TryParse(Console.ReadLine(), out o_NumberOfDoors);
                if (isNumber)
                {
                    if (o_NumberOfDoors >= 2 && o_NumberOfDoors <= 5)
                    {
                        validBatteryCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getVehicleModelName(out string o_ModelName)
        {
            const bool v_IsValidModelName = true;
            while (!v_IsValidModelName != true)
            {
                Console.WriteLine("Please enter a model name that greater then 3 letters");
                o_ModelName = Console.ReadLine();
                if (o_ModelName.Length > 3)
                {
                    break;
                }
            }
        }
        private static void getCustomerName(out string o_CustomerName)
        {
            o_CustomerName = "";
            bool validCustomerName = false;
            while (validCustomerName != true)
            {
                Console.WriteLine("Please enter customer full name with at least 5 letters");
                o_CustomerName = Console.ReadLine();
                if (o_CustomerName.Length > 5)
                {
                    validCustomerName = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static void getCustomerPhoneNumber(out string o_CustomerPhoneNumber)
        {
            o_CustomerPhoneNumber = "";
            bool validCustomerName = false;
            while (validCustomerName != true)
            {
                Console.WriteLine("Please enter phone with 10 digits");
                o_CustomerPhoneNumber = Console.ReadLine();
                if (o_CustomerPhoneNumber.Length == 10)
                {
                    validCustomerName = true;
                }

            }
        }
        private static void getLicenseType(out eLicenseType o_LicenseType, GarageManger i_Controller)
        {
            const bool v_ValidNumberCode = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter a license type code");
            foreach (KeyValuePair<int, string> fuelType in i_Controller.GetSupportedLicenseType())
            {
                sb.AppendFormat("{0}: {1}", fuelType.Key.ToString(), fuelType.Value);
                sb.AppendLine();
            }

            while ((!v_ValidNumberCode) != true)
            {
                Console.WriteLine(sb.ToString());
                int licenseTypeCode = -1;
                bool isNumber = int.TryParse(Console.ReadLine(), out licenseTypeCode);
                if (isNumber)
                {
                    if (licenseTypeCode >= 0 && licenseTypeCode < i_Controller.GetSupportedLicenseType().Count)
                    {
                        o_LicenseType = (eLicenseType)licenseTypeCode;
                        break;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid code number!");
                    }
                }
            }
        }
        private static void getFuelType(out eFuleType o_FuelType, GarageManger i_Controller)
        {
            const bool v_ValidNumberCode = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter a valid fuel type code");
            foreach (KeyValuePair<int, string> fuelType in i_Controller.GetSupportedFuelType())
            {
                sb.AppendFormat("{0}: {1}", fuelType.Key.ToString(), fuelType.Value);
                sb.AppendLine();
            }

            while ((!v_ValidNumberCode) != true)
            {
                Console.WriteLine(sb.ToString());
                int fuelTypeCode = -1;
                bool isNumber = int.TryParse(Console.ReadLine(), out fuelTypeCode);
                if (isNumber)
                {
                    if (fuelTypeCode >= 0 && fuelTypeCode < i_Controller.GetSupportedFuelType().Count)
                    {
                        o_FuelType = (eFuleType)fuelTypeCode;
                        break;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid code number!");
                    }
                }
            }
        }
        private static void getMaxFuelCapacityInLiter(out float o_MaxFuelInLiter)
        {
            o_MaxFuelInLiter = -1;
            bool validFuelCapacity = false;
            while (validFuelCapacity != true)
            {
                Console.WriteLine("Enter fuel max capacity in liters between 2-50");
                bool isNumber = float.TryParse(Console.ReadLine(), out o_MaxFuelInLiter);
                if (isNumber)
                {
                    if (o_MaxFuelInLiter >= 2 && o_MaxFuelInLiter <= 50)
                    {
                        validFuelCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getCurrentFuelInLiter(out float o_CurrentFuelInLiter, float i_MaxFuelInLiter)
        {
            o_CurrentFuelInLiter = -1;
            bool validFuelCapacity = false;
            while (validFuelCapacity != true)
            {
                Console.WriteLine(string.Format("Enter current fuel in liters between 2-{0}", i_MaxFuelInLiter));
                bool isNumber = float.TryParse(Console.ReadLine(), out o_CurrentFuelInLiter);
                if (isNumber)
                {
                    if (o_CurrentFuelInLiter >= 2 && o_CurrentFuelInLiter <= i_MaxFuelInLiter)
                    {
                        validFuelCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getEngineVolumeInCubicCentimeters(out int o_EngineVolumeInCubicCentimeters)
        {
            o_EngineVolumeInCubicCentimeters = -1;
            bool validEngineVolumeInCubicCentimeters = false;
            while (validEngineVolumeInCubicCentimeters != true)
            {
                Console.WriteLine("Enter engine volume in cubic centimeters between 500-1500");
                bool isNumber = int.TryParse(Console.ReadLine(), out o_EngineVolumeInCubicCentimeters);
                if (isNumber)
                {
                    if (o_EngineVolumeInCubicCentimeters >= 500 && o_EngineVolumeInCubicCentimeters <= 1500)
                    {
                        validEngineVolumeInCubicCentimeters = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getIsHaveHazmat(out bool o_IsHaveHazmat)
        {
            o_IsHaveHazmat = false;
            bool validInput = false;
            int choice;
            while (validInput != true)
            {
                Console.WriteLine("Enter 1 if the truck have hazmat or 2 if not");
                bool isNumber = int.TryParse(Console.ReadLine(), out choice);
                if (isNumber)
                {
                    if (choice == 1 || choice == 2)
                    {
                        o_IsHaveHazmat = true;
                        validInput = true;
                        break;
                    }
                    else if (choice == 2)
                    {
                        o_IsHaveHazmat = false;
                        validInput = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getLuggageVolume(out float o_LuggageVolume)
        {
            o_LuggageVolume = -1;
            bool validFuelCapacity = false;
            while (validFuelCapacity != true)
            {
                Console.WriteLine("Enter luggage volume between 0-2000");
                bool isNumber = float.TryParse(Console.ReadLine(), out o_LuggageVolume);
                if (isNumber)
                {
                    if (o_LuggageVolume >= 0 && o_LuggageVolume <= 50)
                    {
                        validFuelCapacity = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");
            }
        }
        private static void getVehicleStatusFromUser(out eVehicleStatus o_VehicleStatus)
        {
            bool validChoice = false;
            int userChoiceCode = -1;
            int numberOfStatus = Enum.GetNames(typeof(eVehicleStatus)).Length;
            string[] statusNames = Enum.GetNames(typeof(eVehicleStatus));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberOfStatus; i++)
            {
                sb.AppendLine(string.Format("For {0} press {1}", statusNames[i], i + 1));
            }
            while (validChoice != true)
            {
                Console.WriteLine("Enter vehicle status");
                Console.WriteLine(sb.ToString());

                bool isNumber = int.TryParse(Console.ReadLine(), out userChoiceCode);
                if (isNumber == true)
                {
                    if (userChoiceCode > 0 && userChoiceCode <= numberOfStatus)
                    {
                        validChoice = true;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid Input!");
            }
            o_VehicleStatus = (eVehicleStatus)userChoiceCode;
        }
        private static void displayListOfAllLicenseNumbers(GarageManger i_Controller)
        {
            string[] licensesNumbers = i_Controller.GetListOfVehiclesLicense();
            if (licensesNumbers.Length > 0)
            {
                Console.WriteLine("All vehicle licenses numbers in the garage");
                foreach (string licensesNumber in licensesNumbers)
                {
                    Console.WriteLine(licensesNumber);
                }
            }
            else
            {
                Console.WriteLine("0 vehicles in the garage");
            }
        }
        private static void displayListOfLicensesNumbersByVehicleStatus(GarageManger i_Controller, eVehicleStatus i_VehicleStatus)
        {
            string status;
            switch (i_VehicleStatus)
            {
                case eVehicleStatus.InRepair:
                    status = "in repair";
                    break;
                case eVehicleStatus.Paid:
                    status = "paid";
                    break;
                case eVehicleStatus.Repaired:
                    status = "repaired";
                    break;
                default:
                    status = "";
                    break;
            }


            string[] licensesNumbers = i_Controller.GetListOfVehiclesLicenseByVehicleStatus(i_VehicleStatus);
            if (licensesNumbers.Length > 0)
            {
                Console.WriteLine(string.Format("All vehicle licenses numbers on status {0}  in the garage:", status));
                foreach (string licensesNumber in licensesNumbers)
                {
                    Console.WriteLine(licensesNumber);
                }
            }
            else
            {
                Console.WriteLine(string.Format("0 vehicles in {0} status", status));
            }
        }
        private static void getVehicleLicenseNumber(out string o_LicenseNumber)
        {
            o_LicenseNumber = "";
            bool isValidLicenseNumber = false;
            while (isValidLicenseNumber != true)
            {
                Console.WriteLine("Enter License Plate Number with 7 digits");
                o_LicenseNumber = Console.ReadLine();
                int o_LicenseNumberInInt;
                bool isNumber = int.TryParse(o_LicenseNumber, out o_LicenseNumberInInt);
                if (isNumber == true)
                {
                    if (o_LicenseNumber.Length == 7)
                    {
                        isValidLicenseNumber = true;
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid input!");

            }
        }
    }
}
