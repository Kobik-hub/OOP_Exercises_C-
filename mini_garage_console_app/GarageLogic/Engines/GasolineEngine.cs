using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    public class GasolineEngine
    {
        private readonly eFuleType r_FuelType;
        private float m_CurrentFuel;
        private readonly float r_MaxFuelCapacityInLiter;
        public GasolineEngine(eFuleType i_FuelType, float i_CurrentFuel, float i_MaxFuelCapacityInLiter)
        {
            this.r_FuelType = i_FuelType;
            this.m_CurrentFuel = i_CurrentFuel;
            this.r_MaxFuelCapacityInLiter = i_MaxFuelCapacityInLiter;
        }
        public eFuleType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
        public float CurrentFuel
        {
            get
            {
                return m_CurrentFuel;
            }
            set
            {
                m_CurrentFuel = value;
            }
        }
        public float MaxFuelCapacityInLiter
        {
            get
            {
                return r_MaxFuelCapacityInLiter;
            }
        }
        public void Refueling(float i_LittersToAdd, eFuleType i_Fuel)
        {
            try
            {
                if(i_Fuel != r_FuelType)
                {
                    throw new ArgumentException("Fuel type is not match");
                }
                if ((m_CurrentFuel + i_LittersToAdd <= r_MaxFuelCapacityInLiter) && (r_FuelType == i_Fuel))
                {
                    m_CurrentFuel += i_LittersToAdd;
                }
                else
                {
                    throw new Exception("Refueling out of range error");
                }
            }
            catch(Exception e)
            {
                if(e.Message == "Refueling out of range error" )
                {
                    throw new ValueOutOfRangeException(
                        r_MaxFuelCapacityInLiter - m_CurrentFuel,
                        0,
                        "Can't refuel of of range.", e);
                }
                else
                {
                    throw;
                }
            }
        }
        public GasolineEngine ShallowClone()
        {
            object clone = this.MemberwiseClone();
            return clone as GasolineEngine;
        }
        public override string ToString()
        {
            return string.Format(
                "Fuel Type: {0}{3}Max Fuel Capacity In Liter: {1}{3}Current Fuel in liters:{2}",
                Enum.GetName(typeof(eFuleType), FuelType),MaxFuelCapacityInLiter,
                CurrentFuel,
                Environment.NewLine
                );
        }
    }
}
