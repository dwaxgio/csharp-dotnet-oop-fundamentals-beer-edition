using System;
using System.Runtime.InteropServices;

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

        // 3. Class
        class Sale
        {
            private decimal _total = 0;
            public string Total => _total.ToString("C");
            public void Add(decimal amount)
            {
                _total += amount;
            }
        }
    }
}
