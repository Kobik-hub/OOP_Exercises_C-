using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        public int m_EngineVolumeInCubicCentimeters;

        

        public Motorcycle(string i_ModelName,
                          string i_LicensePlateNumber,
                          eLicenseType i_LicenseType,
                          int i_EngineVolumeInCubicCentimeters,
                          params Wheel[] i_Wheels
        ): base(i_ModelName, i_LicensePlateNumber)
        {

            m_LicenseType = i_LicenseType;
            m_EngineVolumeInCubicCentimeters = i_EngineVolumeInCubicCentimeters;

            base.m_Wheels = new Wheel[2];
            try
            {
                if (i_Wheels.Length == 2)
                {
                    base.m_Wheels[0] = i_Wheels[0];
                    base.m_Wheels[1] = i_Wheels[1];

                }
                else if (i_Wheels.Length == 1)
                {
                    base.m_Wheels[0] = i_Wheels[0];
                    base.m_Wheels[1] = i_Wheels[0];
                }
                else
                {
                    throw new Exception("out of range");
                }
            }
            catch(Exception e)
            {
                throw new ValueOutOfRangeException(1, 2, "Number of wheels should be 1 if all the same or 2", e);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }
        public int EngineVolumeInCubicCentimeters
        {
            get
            {
                return m_EngineVolumeInCubicCentimeters;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("License type: {0}", Enum.GetName(typeof(eLicenseType), LicenseType)));
            sb.AppendLine(string.Format("Engine Volume In Cubic Centimeters: {0}", EngineVolumeInCubicCentimeters));
            return sb.ToString();
        }
    }
}
