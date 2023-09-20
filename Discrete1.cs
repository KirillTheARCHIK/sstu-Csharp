using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    internal class Discrete1 : SubProgram
    {
        public Discrete1(History history) : base("d1", history, new Listeners() {
            ["start"] = delegate (Command command, History hist)
            {
                discrete();
            },
        }) { }

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
            HashSet<int> R = SetSubstract(SetUnion(A, B), SetIntersect(A, B));
            return R;
        }

        static void InnerSetMenu(HashSet<int> A, HashSet<int> B)
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
0) Назад
Введите номер: ");
                chose = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (chose)
                {
                    case 1:
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(SetIntersect(A, B)));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(SetUnion(A, B)));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(SetSubstract(A, B)));
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(SetSimSubstract(A, B)));
                            break;
                        }
                    default:
                        break;
                }
            } while (chose != 0);
        }

        static void SetMenu()
        {
            Console.Clear();
            Console.Write(@"Введите элементы первого множества через запятую: ");
            HashSet<int> A = Console.ReadLine().Split(',').Select(delegate (string item)
            {
                item = item.Trim();
                return int.Parse(item);
            }).OrderBy(e => e).ToHashSet();
            Console.WriteLine(JsonConvert.SerializeObject(A));
            Console.Write(@"Введите элементы второго множества через запятую: ");
            HashSet<int> B = Console.ReadLine().Split(',').Select(delegate (string item)
            {
                item = item.Trim();
                return int.Parse(item);
            }).OrderBy(e => e).ToHashSet();
            InnerSetMenu(A, B);
        }
        //(1;2),(3;4),(5;6)
        static void BinRelMenu()
        {
            int chose = 0;
            do
            {
                Console.Write(@"
Выберите операцию:
1) Обращение
2) Композиция
0) Назад
Введите номер: ");
                chose = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.Write(@"Введите элементы первого бинарного отношения через запятую: ");
                BinRel br1 = new BinRel(Console.ReadLine());
                switch (chose)
                {
                    case 1:
                        {
                            Console.WriteLine(br1.reverse().toString());
                            break;
                        }
                    case 2:
                        {
                            Console.Write(@"Введите элементы второго бинарного отношения через запятую: ");
                            BinRel br2 = new BinRel(Console.ReadLine());
                            Console.WriteLine();
                            break;
                        }
                    default:
                        break;
                }
            } while (chose != 0);
        }
        static void discrete()
        {
            do
            {
                Console.Write(@"
Выберите раздел:
1) Множества
2) Бинарные отношения
Введите номер: ");
                string chose = Console.ReadLine();
                switch (chose)
                {
                    case "1":
                        {
                            SetMenu();
                            break;
                        }
                    case "2":
                        {
                            BinRelMenu();
                            break;
                        }
                    default:
                        break;
                }
            } while (true);
        }
    }

    [Serializable]
    class BinRel : HashSet<Tuple<int, int>>
    {
        public BinRel(string input) : base(input.Split(',').Select(delegate (string tupleStr)
        {
            var withoutBraces = tupleStr.Replace("(", "").Replace(")", "");
            var splitted = withoutBraces.Split(';').Select(strNum => int.Parse(strNum)).ToArray();
            return new Tuple<int, int>(splitted[0], splitted[1]);
        }))
        { }

        public BinRel(IEnumerable<Tuple<int, int>> set) : base(set) { }

        public BinRel reverse()
        {
            return new BinRel(this.Select(delegate (Tuple<int, int> tuple)
            {
                return new Tuple<int, int>(tuple.Item2, tuple.Item1);
            }));
        }

        public string toString()
        {
            return JsonConvert.SerializeObject(this.Select(tuple => $"({tuple.Item1};{tuple.Item2})")).Replace("\"", "");
        }
    }
}
