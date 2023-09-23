using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Practice7 : SubProgram
    {
        //2 матрицы из файла, меньшая выравнивается нулями, находятся определители, у матрицы с большим определителем находится обратная
        public Practice7(History history) : base("p7", history, new Listeners()
        {
            ["start"] = delegate (Command command, History hist)
            {
                var rand = new Random();
                int n = rand.Next(-3, 10);
                if (n < 1)
                {
                    throw new CommandExeption("Отрицательная длина массива");
                }
                List<List<int>> list = new List<List<int>>();
                for (int i = 0; i < n; i++)
                {
                    List<int> inner = new List<int>();
                    for (int j = 0; j < rand.Next(3, 11); j++)
                    {
                        inner.Add(rand.Next(0, 2));
                    }
                    list.Add(inner);
                }
                Console.WriteLine($"Изначальный массив:\n{JsonConvert.SerializeObject(list.Select(e => JsonConvert.SerializeObject(e)), Formatting.Indented).Replace("\"", "")}");
                var result = convert(list);
                Console.WriteLine($"Итоговый массив:\n{JsonConvert.SerializeObject(result.Select(e => JsonConvert.SerializeObject(e)), Formatting.Indented).Replace("\"", "")}");
            }
        })
        { }

        static List<List<int>> convert(List<List<int>> list)
        {
            var newList = new List<List<int>>(list);
            foreach (var item in newList)
            {
                item.RemoveAll(e => e == 0);
                if (item.Count == 0)
                {
                    item.Add(-1);
                }
            }
            return newList;
        }
    }
}
