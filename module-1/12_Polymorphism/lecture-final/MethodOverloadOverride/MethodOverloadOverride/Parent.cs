using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverloadOverride
{
    public class Parent
    {
        public int secretCode = 1234;
        virtual public int DoMath(int x, int y)
        {
            return x + y;
        }

        virtual public int DoMath(int x, int y, int z)
        {
            return x + y + z;
        }
    }

}
