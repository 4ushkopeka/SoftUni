using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    internal static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(obj);
                MyValidationAttribute attribute = prop.GetCustomAttribute<MyValidationAttribute>();
                if (!attribute.IsValid(value)) return false;
            }
            return true;
        }
    }
}
