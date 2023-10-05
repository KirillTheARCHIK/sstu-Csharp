using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Discrete3 : SubProgram
    {
        public Discrete3(History history) : base("d3", history, new Listeners()
        {
            ["build"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\nbuild <input>");
                }
                string input = command.Arguments[0];
                var exp = new BoolExpression(input.Replace(" ", ""));
                exp.printTable();
            },
        })
        { }
    }
}
