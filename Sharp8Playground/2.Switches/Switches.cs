using System;

namespace Sharp8Playground.Switches
{
    class Shape
    {
    }

    class Rectangle : Shape
    {
        public int Height { get; internal set; }
        public int Width { get; internal set; }
    }

    class Circle : Shape
    {
        public int Radius { get; internal set; }
    }

    class Triangle : Shape
    {
        public int SideA { get; internal set; }
        public int SideB { get; internal set; }
        public int SideC { get; internal set; }
    }

    partial class SwitchUtils
    {
        static double Perimeter_1(Shape shape)
        {
            return shape switch
            {
                null => throw new ArgumentNullException(nameof(shape)),
                Rectangle rect => 2 * (rect.Height + rect.Width),
                Circle circle => 2 * Math.PI * circle.Radius,
                Triangle triangle => triangle.SideA + triangle.SideB + triangle.SideC,
                _ => throw new ArgumentException($"Shape type {shape.GetType()} perimeter unknown", nameof(shape))
            };
        }

        static double Perimeter_2(Shape shape) => shape switch
        {
            null => throw new ArgumentNullException(nameof(shape)),
            Rectangle { Height: var h, Width: var w } => 2 * (h + w),
            Circle { Radius: var r } => 2 * Math.PI * r,
            Triangle { SideA: var a, SideB: var b, SideC: var c } => a + b + c,
            _ => throw new ArgumentException($"Shape type {shape.GetType()} perimeter unknown", nameof(shape))
        };

        static void Greet(Customer customer)
        {
            var greeting = customer switch
            {
                { Address: { Country: "UK" } } => "Welcome, customer from the United Kingdom!",
                { Address: { Country: "RU" } } => "Na zdorovje!",
                { Address: { Country: string country } } => $"Welcome, customer from {country}",
                // Так не работает
                //{ Address: { Country: var country } } => $"Welcome, customer from {country}",
                { Address: { } } => "Welcome, customer whose address has no country!",
                { } => "Welcome, customer of an unknown address!",
                _ => "Welcome, nullness my old friend!"
            };

            Console.WriteLine(greeting);

            // Так не работает

            //customer switch
            //{
            //    { Address: { Country: "UK" } } => Console.WriteLine("Welcome, customer from the United Kingdom!"),
            //    { Address: { Country: "RU" } } => Console.WriteLine("Na zdorovje!"),
            //    { Address: { Country: string country } } => Console.WriteLine($"Welcome, customer from {country}"),
            //    { Address: { } } => Console.WriteLine("Welcome, customer whose address has no country!"),
            //    { } => Console.WriteLine("Welcome, customer of an unknown address!"),
            //    _ => Console.WriteLine("Welcome, nullness my old friend!")
            //}
        }
    }
}
