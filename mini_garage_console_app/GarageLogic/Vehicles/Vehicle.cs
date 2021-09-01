using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    internal abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlateNumber;
        protected Wheel[] m_Wheels;
        protected Vehicle(string i_ModelName, string i_LicensePlateNumber)
        {
            r_ModelName = i_ModelName;
            r_LicensePlateNumber = i_LicensePlateNumber;
            m_Wheels = null;
        }
        public abstract float EnergyLeftInPercentage { get; }
        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }
        public Wheel GetWheel(int i_WheelNumber)
        {
            return m_Wheels[i_WheelNumber];
        }
        public string LicensePlateNumber
        {
            get { return r_LicensePlateNumber; }
        }
        public int NumberOfWheels
        {
            get { return m_Wheels.Length; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("ModelName: {0}", ModelName));
            sb.AppendLine(string.Format("License Plate Number: {0}", LicensePlateNumber));
            sb.AppendLine(string.Format("Energy left:{0}%", EnergyLeftInPercentage));
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                sb.AppendLine(string.Format("wheel {0} : {2}{1}", i+1, m_Wheels[i].ToString(),Environment.NewLine));
            }
            return sb.ToString();
        }
    }
}
