using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    internal class ElectricCar : Car
    {
        private ElectricEngine m_ElectricEngine;
        internal ElectricCar(string i_ModelName,
                           string i_LicensePlateNumber,
                           eCarColor i_CarColor,
                           int i_NumberOfDoors,
                           ElectricEngine i_ElectricEngine,
                           params Wheel[] i_Wheels
        ) : base(i_ModelName,
            i_LicensePlateNumber,
            i_CarColor,
            i_NumberOfDoors,
            i_Wheels
            )
        {
            m_ElectricEngine = i_ElectricEngine.ShallowClone();

        }
        public ElectricEngine Engine
        {
            get
            {
                return m_ElectricEngine;
            }
            set
            {
                m_ElectricEngine = value;
            }
        }
        public override float EnergyLeftInPercentage
        {
            get
            {
                return ((this.m_ElectricEngine.TimeLeftInBatteryInHours / this.m_ElectricEngine.MaxBatteryTimeInHours)*100);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(m_ElectricEngine.ToString());
            return sb.ToString();
        }
    }
}
