using System;

namespace Практика_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            double n = double.Parse(Console.ReadLine());
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetWindowSize(200, 100);
            var dateTime = DateTime.Now;
            Console.Write("{0}\n\n\n", dateTime.ToLongTimeString());
            Console.WriteLine("{0:F2}".PadRight(20, '0'), n);
        }
    }
}
