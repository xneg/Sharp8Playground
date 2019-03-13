using System;

namespace Sharp8Playground._1.Nullable
{
    class NullablePlayground
    {
        public static void Main_()
        {
            Customer? customer = new Customer("Somebody");

            Console.WriteLine(customer.Address?.Country ?? "Address unknown");

            Address? address = customer.Address;

            if (address != null)
            {
                Console.WriteLine(address.Country);
            }

            if (customer.Address != null)
            {
                Console.WriteLine(customer.Address.Country);
            }

            string? t = null;

            PrintLength(t);

            Console.WriteLine(t[0]);

            object? b = null;

            //b.GetHashCode();

            if (!ReferenceEquals(b, null))
            {
                Console.WriteLine(b.GetHashCode());
            }
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
