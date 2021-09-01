using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsHaveHazmat;
        private float m_LuggageVolume;
        private GasolineEngine m_GasolineEngine;
        public Truck(string i_ModelName,
                     string i_LicensePlateNumber,
                     bool i_IsHaveHazmat,
                     float i_LuggageVolume,
                     GasolineEngine i_GasolineEngine,
                     params Wheel[] i_Wheels
        ): base(i_ModelName, i_LicensePlateNumber)
        {
            m_IsHaveHazmat = i_IsHaveHazmat;
            m_LuggageVolume = i_LuggageVolume;
            base.m_Wheels = new Wheel[16];
            try
            {
                if (i_Wheels.Length == 16)
                {
                    for (int i = 0; i < base.m_Wheels.Length; i++)
                    {
                        base.m_Wheels[i] = i_Wheels[i];
                    }
                }
                else if (i_Wheels.Length == 1)
                {
                    for (int i = 0; i < base.m_Wheels.Length; i++)
                    {
                        base.m_Wheels[i] = i_Wheels[0];
                    }
                }
                else
                {
                    throw new Exception("invalid inputs for the contractor");
                }
                m_GasolineEngine = i_GasolineEngine.ShallowClone();
            }
            catch(Exception e)
            {
                throw new ValueOutOfRangeException(1, 16, "Number of wheels must be 1 or 16", e);
            }
        }
        public bool IsHaveHazmat
        {
            get
            {
                return m_IsHaveHazmat;
            }
        }
        public float LuggageVolume
        {
            get
            {
                return m_LuggageVolume;
            }
        }
        public override float EnergyLeftInPercentage
        {
            get
            {
                return ((m_GasolineEngine.CurrentFuel / m_GasolineEngine.MaxFuelCapacityInLiter) * 100);
            }
        }
        public GasolineEngine Engine
        {
            get
            {
                return m_GasolineEngine;
            }
            set
            {
                m_GasolineEngine = value;
            }
        }
    }
}
