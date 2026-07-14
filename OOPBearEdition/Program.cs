using System;

namespace OOPBearEdition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Variable
            string name = "MR Duff";
            Console.WriteLine(name);

            // 2. Function
            int result = Add(2, 3);
            int Add(int a, int b)
            {
                return a + b;
            }
            Console.WriteLine(result);
        }
    }
}
