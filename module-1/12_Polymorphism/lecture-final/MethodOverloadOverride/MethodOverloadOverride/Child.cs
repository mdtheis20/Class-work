using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverloadOverride
{
    public class Child : Parent
    {
        public override int DoMath(int x, int y, int z)
        {
            Console.WriteLine(secretCode);
            return x * y * z;
        }
    }
}
