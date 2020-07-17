using System;
using System.Collections.Generic;

namespace LinqLambda
{
    public class Functions
    {
        public void ExecuteFunctions()
        {
            int result = DoubleIt(4);
            Console.WriteLine($"DoubleIt(4) returned { result }");

            // let func = DoubleIt;
            // func(10)

            Func<int, int> funcByAnotherName = DoubleIt;
            result = funcByAnotherName(10);
            Console.WriteLine($"funcByAnotherName(10) returned { result }");

            Func<int, int> TripleIt = (n) =>
            {
                return n * 3;
            };

            result = TripleIt(14);
            Console.WriteLine($"TripleIt(14) returned { result }");

            Func<int, int> QuadrupleIt = n => n * 4;
            result = QuadrupleIt(22);
            Console.WriteLine($"QuadrupleIt(22) returned { result }");

            int[] arr = new int[] { 2, 23, 45, 6 };
            Console.WriteLine(String.Join(", ", arr));

            var outArr = forEach(arr, DoubleIt);
            Console.WriteLine(String.Join(", ", outArr));

            outArr = forEach(arr, i => i * 5);
            Console.WriteLine(String.Join(", ", outArr));
        }

        public int DoubleIt( int n)
        {
            return n * 2;
        }

        IEnumerable<int> forEach(IEnumerable<int> arrayIn, Func<int, int> functionToApply)
        {
            List<int> arrayOut = new List<int>();
            foreach (int element in arrayIn)
            {
                int result = functionToApply(element);
                arrayOut.Add(result);
            }
            return arrayOut;
        }

    }
}
