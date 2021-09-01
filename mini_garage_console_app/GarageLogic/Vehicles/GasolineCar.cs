using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    internal class GasolineCar : Car
    {
        private GasolineEngine m_GasolineEngine;

        public GasolineCar(string i_ModelName,
                  string i_LicensePlateNumber,
                  eCarColor i_CarColor,
                  int i_NumberOfDoors,
                  GasolineEngine i_GasolineEngine,
                  params Wheel[] i_Wheels
       ) : base(i_ModelName, i_LicensePlateNumber, i_CarColor, i_NumberOfDoors, i_Wheels)
        {
            m_GasolineEngine = i_GasolineEngine.ShallowClone();
        }

        public override float EnergyLeftInPercentage
        {
            get
            {
                return ((this.m_GasolineEngine.CurrentFuel / this.m_GasolineEngine.MaxFuelCapacityInLiter) * 100);
            }
        }
        public GasolineEngine Engine
        {
            get
            {
                return m_GasolineEngine;
            }
        }

        public override string ToString()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(m_GasolineEngine.ToString());
            return sb.ToString();
        }
    }
}
