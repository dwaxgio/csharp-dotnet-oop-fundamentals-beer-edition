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

            // 4. Object
            var sale = new Sale();
            sale.Add(10);
            sale.Add(20);
            Console.WriteLine(sale.Total);
        }

        // 5. Interface (contracts)
        interface ISale
        {
            string Total { get; }
            void Add(decimal amount);
        }

        // 3. Class
        class Sale : ISale
        {
            private decimal _total = 0;
            public string Total => _total.ToString("C");
            public void Add(decimal amount)
            {
                _total += amount;
            }
        }

        // 6. Constructor and Abstraction
        class SenderSale
        {
            private ISale _sale;
            public SenderSale(ISale sale)
            {
                _sale = sale;
            }

            public void SendMail()
            {
                Console.WriteLine($"Enviando correo con la venta que tiene total {_sale.Total}");
            }
        }
    }
}
