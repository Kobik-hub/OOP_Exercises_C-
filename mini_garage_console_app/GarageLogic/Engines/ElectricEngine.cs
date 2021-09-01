using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class ElectricEngine
    {
        private float m_TimeLeftInBatteryInHours;
        private readonly float r_MaxBatteryTimeInHours;
        public ElectricEngine(float i_TimeLeftInBattery, float i_MaxBatteryTimeInHours)
        {
            this.m_TimeLeftInBatteryInHours = i_TimeLeftInBattery;
            this.r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }
        public float TimeLeftInBatteryInHours
        {
            get
            {
                return m_TimeLeftInBatteryInHours;
            }
            set
            {
                m_TimeLeftInBatteryInHours = value;
            }
        }
        public float MaxBatteryTimeInHours
        {
            get
            {
                return r_MaxBatteryTimeInHours;
            }
        }
        public void BatteryCharge(float i_HoursToAdd)
        {
            try
            {
                if (m_TimeLeftInBatteryInHours + i_HoursToAdd <= r_MaxBatteryTimeInHours)
                {
                    m_TimeLeftInBatteryInHours += i_HoursToAdd;
                }
                else
                {
                    throw new Exception("Charge error");
                }
            }
            catch(Exception e)
            {
                throw new ValueOutOfRangeException(
                    MaxBatteryTimeInHours - m_TimeLeftInBatteryInHours,
                    0,
                    "hours to charge is out of range",
                    e);
            }
        }
        public ElectricEngine ShallowClone()
        {
            object clone = this.MemberwiseClone();
            return clone as ElectricEngine;
        }
        public override string ToString()
        {
            return string.Format(
                "Max Battery Time In Hours: {0}{2}Time Left In Battery In Hours: {1}",
                MaxBatteryTimeInHours,
                TimeLeftInBatteryInHours,
                Environment.NewLine);
        }
    }
}
