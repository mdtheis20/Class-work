using System;

namespace MethodOverloadOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            // String escaping

            string s = "This is a \"quote\" ";
            Console.WriteLine(s);
            string backslashed = "A back\\lash";
            Console.WriteLine(backslashed);
            string tab = "\t\tIndented text";
            Console.WriteLine(tab);
            string multipleLines = "This is line 1.\r\nThis is line 2.";
            Console.WriteLine(multipleLines);
            Parent p = new Parent();
            int result = p.DoMath(32, 51);
            Console.WriteLine(result);

            result = p.DoMath(32, 51, -100);
            Console.WriteLine(result);

            Child c = new Child();
            result = c.DoMath(14, 26, 38);
            Console.WriteLine(result);

            result = c.DoMath(14, 26);
            Console.WriteLine(result);

            Console.WriteLine(p.secretCode);
        }
    }
}
