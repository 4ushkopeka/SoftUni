using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class MyRangeAttribute:MyValidationAttribute
    {
        int minVal;
        int maxVal;
        public MyRangeAttribute(int minval, int maxval)
        {
            minVal = minval;
            maxVal = maxval;
        }
        public override bool IsValid(object obj)
        {
            int pers = (int)obj;
            if (pers >= minVal && pers<=maxVal) return true;
            return false;
        }
    }
}
