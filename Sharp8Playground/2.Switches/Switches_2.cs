using System;

namespace Sharp8Playground._2.Switches
{
    class Order
    {
        public IPizza? Pizza { get; }

        public Order(IPizza? pizza)
        {
            Pizza = pizza;
        }
    }

    interface IPizza
    {
    }

    class Pepperoni : IPizza
    {
        public int SausageCount { get; }

        public Pepperoni(int sausageCount)
        {
            SausageCount = sausageCount;
        }
    }

    class Hawaiian : IPizza
    {
        public int PineapplesCount { get; }
        
        public Hawaiian(int pineapplesCount)
        {
            PineapplesCount = pineapplesCount;
        }
    }

    partial class SwitchUtils
    {
        public static void DescribeOrder(Order? order)
        {
            switch (order)
            {
                case { Pizza: Pepperoni { SausageCount: var count } }:
                    Console.WriteLine($"This is pepperoni with {count} sausages");
                    break;
                case { Pizza: Hawaiian { PineapplesCount: var count } }:
                    Console.WriteLine($"This is hawaiian with {count} pineapples");
                    break;
                case { Pizza: { } }:
                    Console.WriteLine("You don't have pizza in your order");
                    break;
                default:
                    Console.WriteLine("You don't have an order");
                    break;
            }
        }
    }
}
