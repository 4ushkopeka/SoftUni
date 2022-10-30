using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int CalcDiff(DateTime date1, DateTime date2)
        {
            return (int)Math.Abs((date1 - date2).TotalDays);
        }
    }
}
