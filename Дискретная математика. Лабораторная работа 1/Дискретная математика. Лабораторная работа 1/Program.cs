using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дискретная_математика.Лабораторная_работа_1
{
    class Program
    {
        static string SetToString(HashSet<int> set)
        {
            string s = set.Aggregate("", delegate (string str, int item) { return str + item.ToString() + ", "; });
            return s.Substring(0, s.Length - 2);
        }

        static HashSet<int> SetIntersect(HashSet<int> A, HashSet<int> B)
        {
            HashSet<int> R = A.Where(el => B.Contains(el)).ToHashSet();
            return R;
        }

        static HashSet<int> SetUnion(HashSet<int> A, HashSet<int> B)
        {
            HashSet<int> R = A.Concat(B).ToHashSet();
            return R;
        }

        static HashSet<int> SetSubstract(HashSet<int> A, HashSet<int> B)
        {
            HashSet<int> R = A.Where(el => !B.Contains(el)).ToHashSet();
            return R;
        }

        static HashSet<int> SetSimSubstract(HashSet<int> A, HashSet<int> B)
        {
            HashSet<int> R = SetSubstract(SetUnion(A,B), SetIntersect(A,B));
            return R;
        }

        static void InnerMenu(HashSet<int> A, HashSet<int> B)
        {
            int chose = 0;
            do
            {
                Console.Write(@"
Выберите операцию:
1) Пересечение
2) Объединение
3) Разность
4) Симметрическая разность
0) Изменить множества
Введите номер: 
");
                chose = int.Parse(Console.ReadLine());

                switch (chose)
                {
                    case 1:
                        {

                            break;
                        }
                    default:
                        break;
                }
            } while (chose != 0);
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Write(@"Введите элементы первого множества через запятую: ");
                HashSet<int> A = Console.ReadLine().Split(',').Select(delegate (string item)
                {
                    item = item.Trim();
                    return int.Parse(item);
                }).OrderBy(e => e).ToHashSet();
                Console.WriteLine(SetToString(A));
                Console.Write(@"Введите элементы второго множества через запятую: ");
                HashSet<int> B = Console.ReadLine().Split(',').Select(delegate (string item)
                {
                    item = item.Trim();
                    return int.Parse(item);
                }).OrderBy(e => e).ToHashSet();
                InnerMenu(A, B);
            } while (true);
        }
    }
}
