using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{ 
    internal class Wheel
    {
        internal string m_ManufacturerName;
        internal float m_CurrentAirPressure;
        internal readonly float r_MaxAirPressure;
        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure; 
        }
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
        public void Inflating(float i_AirToAdd)
        {
            try
            {
                if(m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
                else
                {
                    throw new Exception("Inflating error");
                }
            }
            catch(Exception ex)
            {
                throw new ValueOutOfRangeException(MaxAirPressure, MaxAirPressure - CurrentAirPressure,"Cant inflate out of range", ex);
            }
        }
        public override string ToString()
        {
           return string.Format(
                @"Manufacturer Name:{0}, Max Air Pressure:{1}, Current Air Pressure: {2}",
                ManufacturerName,
                MaxAirPressure,
                CurrentAirPressure
                );
        }
    }
}
