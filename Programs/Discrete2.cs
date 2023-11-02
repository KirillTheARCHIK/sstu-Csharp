using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    //Рефлексивное: (1;1),(2;2),(3;3)
    //Иррефлексивное: (1;2),(2;1),(3;4)
    //Симметричное: (1;2),(2;1),(3;4),(4;3)
    //Антисимметричное: (1;1),(2;2),(3;3),(4;5)
    //Транзитивное: (1;2),(2;3),(1;3),(4;5)
    //Эквивалентность: 
    //Порядок: (1;2),(2;3),(3;4)
    internal class Discrete2 : SubProgram
    {
        public Discrete2(History history) : base("d2", history, new Listeners()
        {
            ["check"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\ncheck <input>");
                }
                string input = command.Arguments[0];
                var binRel = new BinRel(input);
                Console.WriteLine($"Рефлексивное {(binRel.Reflective ? "+" : "-") }");
                Console.WriteLine($"Иррефлексивное {(binRel.IrReflective ? "+" : "-")}");
                Console.WriteLine($"Симметричное {(binRel.Symmetrical ? "+" : "-")}");
                Console.WriteLine($"Антисимметричное {(binRel.AntiSymmetrical ? "+" : "-")}");
                Console.WriteLine($"Транзитивное {(binRel.Transitive ? "+" : "-")}");
                if (binRel.Equivalence)
                {
                    Console.WriteLine($"Это эквивалентность");
                }
                else if (binRel.Order)
                {
                    Console.WriteLine($"Это порядок");
                }
                else
                {
                    Console.WriteLine($"Это не эквивалентность и не порядок");
                }
            },
        })
        { }
    }
}
