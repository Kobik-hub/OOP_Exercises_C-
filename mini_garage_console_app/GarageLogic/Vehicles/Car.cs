using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{ 
    internal abstract class Car : Vehicle
    {
        private readonly eCarColor r_Color;
        private readonly int r_NumbersOfDoors;
        internal Car(string i_ModelName,
                      string i_LicensePlateNumber,
                      eCarColor i_CarColor,
                      int i_NumberOfDoors,
                      params Wheel[] i_Wheels
        ) : base(i_ModelName, i_LicensePlateNumber)
        {
            r_Color = i_CarColor;
            r_NumbersOfDoors = i_NumberOfDoors;
            try
            {
                base.m_Wheels = new Wheel[4];
                if (i_Wheels.Length == 4)
                {
                    base.m_Wheels[0] = i_Wheels[0];
                    base.m_Wheels[1] = i_Wheels[1];
                    base.m_Wheels[2] = i_Wheels[2];
                    base.m_Wheels[3] = i_Wheels[3];
                }
                else if (i_Wheels.Length == 1)
                {
                    base.m_Wheels[0] = i_Wheels[0];
                    base.m_Wheels[1] = i_Wheels[0];
                    base.m_Wheels[2] = i_Wheels[0];
                    base.m_Wheels[3] = i_Wheels[0];
                }
                else
                {
                    throw new Exception("invalid inputs for the contractor");
                }
            }
            catch(Exception e)
            {
                throw new ValueOutOfRangeException(1, 4, "Number of wheels should be 1 if all the same or 4", e);
            }
        }
        public eCarColor CarColor
        {
            get
            {
                return r_Color;
            }
        }
        public int CarNumberOfDoors
        {
            get
            {
                return r_NumbersOfDoors;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("Color: {0}", Enum.GetName(typeof(eCarColor), CarColor)));
            sb.AppendLine(string.Format("Number Of Doors: {0}", CarNumberOfDoors));
            return sb.ToString();
        }
    }
}
