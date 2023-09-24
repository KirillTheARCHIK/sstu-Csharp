using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Practice8 : SubProgram
    {
        //"Дана текстовая строка. Распечатать строку, состоящую из слов заданной, расположенных в лексикографическом порядке, используя методы класса String или StringBuilder."
        public Practice8(History history) : base("p8", history, new Listeners()
        {
            ["order"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count < 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\norder <string>");
                }
                if (command.Arguments.Count > 1)
                {
                    throw new CommandExeption("Слишком много аргументов");
                }
                var words = command.Arguments[0].Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                var ordered = words.OrderBy(x => x).ToList();
                Console.WriteLine($"Отсортированная строка:\n{string.Join(" ", ordered)}");
            }
        })
        { }
    }
}
