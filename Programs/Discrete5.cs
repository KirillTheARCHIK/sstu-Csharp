using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Discrete5 : SubProgram
    {
        public Discrete5(History history) : base("d5", history, new Listeners()
        {
            ["s"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 2)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\n stirling <input>");
                }
                string n = command.Arguments[0];
                string k = command.Arguments[1];
                Console.WriteLine($"Число Стрилинга для ({n}, {k}) = {S((uint)int.Parse(n), (uint)int.Parse(k))}");
            },
            ["b"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\n stirling <input>");
                }
                string n = command.Arguments[0];
                Console.WriteLine($"Число Белла для {n} = {B((uint)int.Parse(n))}");
            },
        })
        { }

        static uint S(uint n, uint k)
        {
            if (k>n)
            {
                return 0;
            }
            if (k==0)
            {
                if (n==0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return S(n - 1, k - 1) + k * S(n - 1, k);
            }
        }
        static uint B(uint n)
        {
            uint Sum = 0;
            for (uint i = 1; i <= n; i++)
            {
                Sum += S(n, i);
            }
            return Sum;
        }
    }
}
