using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Практики
{
    internal class Practice6 : SubProgram
    {
        public Practice6(History history) : base("p6", history, new Listeners()
        {
            ["start"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\nstart <count>");
                }

                int n;
                if (!int.TryParse(command.Arguments[0], out n))
                {
                    throw new CommandExeption("Аргумент <count> не число");
                }
                if (n < 0)
                {
                    throw new CommandExeption("Аргумент <count> меньше нуля");
                }
                Random rand = new Random();
                var X1 = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    X1.Add(rand.Next(0, 51));
                }
                Console.WriteLine(JsonConvert.SerializeObject(X1));
                var X2 = new List<double>();
                foreach (var item in X1)
                {
                    if (item > 24 && item < 34)
                    {
                        X2.Add(item);
                    }
                }
                Console.WriteLine(JsonConvert.SerializeObject(X2));
            }
        })
        { }
    }
}
