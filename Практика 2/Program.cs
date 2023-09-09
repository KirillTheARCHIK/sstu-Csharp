using System;

namespace Практика_2
{
//    bool
//char
//sbyte
//byte
//int
//uint
//short
//ushort
//long
//ulong
//float
//double
//decimal

    class Program
    {
        static void Ex1()
        {
            Console.WriteLine("тип данных | размер");
            Console.WriteLine("{0,8}   |  {1,3}", "bool", sizeof(bool));
            Console.WriteLine("{0,8}   |  {1,3}", "char", sizeof(char));
            Console.WriteLine("{0,8}   |  {1,3}", "sbyte", sizeof(sbyte));
            Console.WriteLine("{0,8}   |  {1,3}", "int", sizeof(int));
            Console.WriteLine("{0,8}   |  {1,3}", "uint", sizeof(uint));
            Console.WriteLine("{0,8}   |  {1,3}", "short", sizeof(short));
            Console.WriteLine("{0,8}   |  {1,3}", "ushort", sizeof(ushort));
            Console.WriteLine("{0,8}   |  {1,3}", "long", sizeof(long));
            Console.WriteLine("{0,8}   |  {1,3}", "ulong", sizeof(ulong));
            Console.WriteLine("{0,8}   |  {1,3}", "float", sizeof(float));
            Console.WriteLine("{0,8}   |  {1,3}", "double", sizeof(double));
            Console.WriteLine("{0,8}   |  {1,3}", "decimal", sizeof(decimal));
        }
        //Преобразование одного числа для второго задания
        //n<0  |n|*2
        //n>0  -n
        static double convert(double n)
        {
            if (n<0)
            {
                return Math.Abs(n) * 2;
            }
            else if (n>0)
            {
                return -n;
            }
            else
            {
                throw new Exception("0 не принимается");
            }
        }
        static void Ex2()
        { 
            //A
            Console.Write("Введите первое число, не равное 0: ");
            string aStr = Console.ReadLine();
            double aParsed;
            if (!double.TryParse(aStr, out aParsed))
            {
                Console.WriteLine("Вы ввели не число");
                return;
            }
            double a = convert(aParsed);
            //B
            Console.Write("Введите второе число, не равное 0: ");
            string bStr = Console.ReadLine();
            double bParsed;
            if (!double.TryParse(bStr, out bParsed))
            {
                Console.WriteLine("Вы ввели не число");
                return;
            }
            double b = convert(bParsed);
            double c = a * b;
            Console.WriteLine($"{a} * {b} = {c}");
        }
        static void Ex3()
        {
            char c = 'b';
            char c1 = (char)(c - 1);
            char c2 = (char)(c + 1);
            Console.WriteLine($"символ = {c}, меньший = {c1}, больший = {c2}");
        }
        static void Main(string[] args)
        {
            string chose = "0";
            do
            {
                Console.Clear();
                Console.Write("Выберите задание (1,2,3) или введите 0 для выхода: ");
                chose = Console.ReadLine();
                switch (chose)
                {
                    case "1":
                        {
                            Ex1();
                            break;
                        }
                    case "2":
                        {
                            Ex2();
                            break;
                        }
                    case "3":
                        {
                            Ex3();
                            break;
                        }
                    default:
                        break;
                }
                Console.ReadLine();
            } while (chose!="0");
        }
    }
}
