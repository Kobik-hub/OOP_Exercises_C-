using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    internal class CustomerCarDetails
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatusInGrage;
        public CustomerCarDetails(string i_OwnerName, string i_PhoneNumber)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_VehicleStatusInGrage = eVehicleStatus.InRepair;
        }
        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatusInGrage;
            }
            set
            {
                m_VehicleStatusInGrage = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string CustomerPhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
            }
        }
    }
}
