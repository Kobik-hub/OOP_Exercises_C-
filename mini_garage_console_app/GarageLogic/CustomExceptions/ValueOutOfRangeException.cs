using System;
using System.Collections.Generic;
using System.Text;
namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_Message, Exception i_InnerException )
            :base(i_Message, i_InnerException)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
