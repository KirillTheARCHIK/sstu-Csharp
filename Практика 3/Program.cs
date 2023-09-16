using System;

namespace Практика_3
{
    class Program
    {
        static void ConsoleColorMenu()
        {
            //light: 8, 11, 15, 16
            int chose = (int)ConsoleColor.Black;
            do
            {
                Console.BackgroundColor = (ConsoleColor)chose;
                switch (chose)
                {
                    case 7:
                    case 10:
                    case 14:
                    case 15:
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
                Console.Clear();
                Console.WriteLine("Цвета для консоли:");
                for (int i = 0; i < 16; i++)
                {
                    Console.Write($"{i + 1,2}) ");
                    Console.BackgroundColor = (ConsoleColor)i;
                    if (i == chose)
                    {
                        Console.WriteLine("Текущий");
                    }
                    else
                    {
                        Console.WriteLine("       ");
                    }
                    Console.BackgroundColor = (ConsoleColor)chose;
                }
                Console.Write("Выберите номер цвета или введите \"0\" для продолжения: ");
                chose = int.Parse(Console.ReadLine()) - 1;

            } while (chose != -1);
        }
        static void ConsoleWidthMenu()
        {
            string chose = "";
            do
            {
                Console.Clear();
                Console.Write("Введите размер окна в формате \"ширина,высота\" или нажмите Ввод, чтобы продолжить: ");
                chose = Console.ReadLine();
                if (chose == "")
                {
                    return;
                }
                var splittedSize = chose.Split(',');
                int width = int.Parse(splittedSize[0]);
                int height = int.Parse(splittedSize[1]);
                Console.SetWindowSize(width, height);
            } while (true);
        }
        static void Main(string[] args)
        {
            ConsoleWidthMenu();
            ConsoleColorMenu();
            Console.Clear();
            Console.Write("Введите число: ");
            double n = double.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Введите дату в формате день.месяц.год: ");
            var myDateTimeStringSplitted = Console.ReadLine().Split('.');
            DateTime myDateTime = new DateTime(
                int.Parse(myDateTimeStringSplitted[2]),
                int.Parse(myDateTimeStringSplitted[1]),
                int.Parse(myDateTimeStringSplitted[0])
                );
            Console.Clear();
            var dateTime = DateTime.Now;
            Console.Write($"{dateTime.ToShortDateString()}\n{myDateTime.ToShortDateString()}\nРазница в днях: {dateTime.Subtract(myDateTime).TotalDays}\n\n\n");
            Console.WriteLine("{0:F2}".PadRight(20, '0'), n);
        }
    }
}
