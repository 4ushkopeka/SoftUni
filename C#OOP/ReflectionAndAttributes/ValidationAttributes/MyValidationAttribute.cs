using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal abstract class MyValidationAttribute:Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
