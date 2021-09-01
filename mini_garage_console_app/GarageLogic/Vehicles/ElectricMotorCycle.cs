using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    internal class ElectricMotorCycle : Motorcycle
    {
        private ElectricEngine m_ElectricEngine;

        public ElectricMotorCycle(string i_ModelName,
                          string i_LicensePlateNumber,
                          eLicenseType i_LicenseType,
                          int i_EngineVolumeInCubicCentimeters,
                          ElectricEngine i_ElectricEngine,
                          params Wheel[] i_Wheels
        ): base(i_ModelName, i_LicensePlateNumber, i_LicenseType, i_EngineVolumeInCubicCentimeters, i_Wheels)
        {
            m_ElectricEngine = i_ElectricEngine.ShallowClone();
        }

        public override float EnergyLeftInPercentage
        {
            get
            {
                return ((this.m_ElectricEngine.TimeLeftInBatteryInHours / this.m_ElectricEngine.MaxBatteryTimeInHours) * 10);
            }
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(m_ElectricEngine.ToString());
            return sb.ToString();
        }
    }
}
