using Sharp8Playground._2.Switches;
using System;

namespace Sharp8Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region 1. Nullable reference
            //Customer? customer = new Customer("Somebody");

            //Console.WriteLine(customer.Address?.Country ?? "Address unknown");

            //Address? address = customer.Address;

            //if (address != null)
            //{
            //    Console.WriteLine(address.Country);
            //}

            //if (customer.Address != null)
            //{
            //    Console.WriteLine(customer.Address.Country);
            //}

            //string? t = null;

            //PrintLength(t);

            //Console.WriteLine(t[0]);

            //object? b = null;

            ////b.GetHashCode();

            //if (!ReferenceEquals(b, null))
            //{
            //    Console.WriteLine(b.GetHashCode());
            //}
            //#endregion

            #region 2. Switches

            SwitchUtils.DescribeOrder(null);
            SwitchUtils.DescribeOrder(new Order(null));
            SwitchUtils.DescribeOrder(new Order(new Pepperoni(3)));
            SwitchUtils.DescribeOrder(new Order(new Hawaiian(4)));

            #endregion

            Console.Write(Environment.NewLine);

            #region 3. Indexes and ranges

            Index start = 2;
            Index end = ^2;
            Index a = new Index(1, false);

            Range all = ..;
            Range startOnly = start..;
            Range endOnly = ..end;
            Range startAndEnd = start..end;

            string text = "hello world";


            Console.WriteLine(text[2]);

            // сейчас почему-то не работает
            //Console.WriteLine(text[^3]);
            Console.WriteLine(text[2..7]);

            Span<int> span = stackalloc int[] { 5, 2, 7, 8, 2, 4, 3 };

            Console.WriteLine(span[2]);
            Console.WriteLine(span[^3]);

            Span<int> slice = span[2..7];

            Console.WriteLine(string.Join(", ", slice.ToArray()));
            #endregion

            Console.Write(Environment.NewLine);

            #region 4. More asyncs

            #endregion

        }

        static void PrintLength(string? text)
        {
            if (!string.IsNullOrEmpty(text))
                Console.WriteLine(text.Length);
            else
                Console.WriteLine("Empty or null");
        }
    }
}