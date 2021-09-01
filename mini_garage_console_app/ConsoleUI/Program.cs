using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Runtime.Remoting.Messaging;
using System.Text;
using GarageLogic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage();
        }
        public static void Garage()
        {
            GarageManger garageManger = new GarageManger();
            eUserChoice userChoice = GarageUtils.GetMenuChoiceFromUser();
            while(userChoice != eUserChoice.Quit)
            {
                switch (userChoice)
                {
                    case eUserChoice.NewCar:
                        Console.Clear();
                        GarageUtils.EnterANewVehicleInToeGarage(garageManger);
                        Console.Clear();
                        break;
                    case eUserChoice.ListOfVehiclesLicenseNumber:
                        Console.Clear();
                        GarageUtils.DisplayListOfLicensesNumbers(garageManger);
                        break;
                    case eUserChoice.ChangeVehicleStatus:
                        Console.Clear();
                        GarageUtils.ChangeVehicleStatus(garageManger);
                        break;
                    case eUserChoice.WheelInflatingToMaximum:
                        Console.Clear();
                        GarageUtils.InflatingWheelsToMaximum(garageManger);
                        break;
                    case eUserChoice.RefuelGasolineVehicle:
                        Console.Clear();
                        GarageUtils.RefuelGasolineVehicle(garageManger);
                        break;
                    case eUserChoice.ChargeElectricVehicle:
                        Console.Clear();
                        GarageUtils.ChargeElectricVehicle(garageManger);
                        break;
                    case eUserChoice.DisplayVehicleInformation:
                        Console.Clear();
                        GarageUtils.DisplayVehicleInCustomerInformation(garageManger);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press enter to back to main menu");
                Console.ReadLine();
                Console.Clear();
                userChoice = GarageUtils.GetMenuChoiceFromUser();
            }
        }
    }
}
