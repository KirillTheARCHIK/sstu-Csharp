using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практики
{
    internal class Practice6 : SubProgram
    {
        public Practice6(History history) : base("p6", history, new Listeners()
        {
            ["start"] = delegate (Command command, History hist)
            {
                //if (command.Arguments.Count != 1)
                //{
                //    throw new CommandExeption("Отсутствует аргумент\n         ↓\nstart <count>");
                //}

                Random rand = new Random();
                int n  = rand.Next(1,11);
                //if (!int.TryParse(command.Arguments[0], out n))
                //{
                //    throw new CommandExeption("Аргумент <count> не число");
                //}
                //if (n < 1)
                //{
                //    throw new CommandExeption("Аргумент <count> меньше единицы");
                //}
                var initialList = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    initialList.Add(rand.Next(1, 11));
                }
                Console.WriteLine($"Изначальные числа: {JsonConvert.SerializeObject(initialList)}");
                int c = initialList[initialList.Count - 1];
                initialList.RemoveAt(initialList.Count - 1);
                var polynomial = new Polynomial();
                if (initialList.Count >= 1)
                {
                    foreach (var power in initialList)
                    {
                        if (polynomial.Count == 0 || polynomial[polynomial.Count - 1].power - power == 1)
                        {
                            polynomial.Add(new PolynomialVariable(rand.Next(-20,20) , power));
                        }
                    }
                }
                polynomial.Add(new PolynomialVariable(c, 0));
                Console.WriteLine($"С коэффициентами: {polynomial}");
            }
        })
        { }
    }

    internal class PolynomialVariable
    {
        public double coefficient;
        public double power;

        public PolynomialVariable(double coefficient, double power)
        {
            this.coefficient = coefficient;
            this.power = power;
        }


    }

    internal class Polynomial : List<PolynomialVariable>
    {
        public Polynomial() : base(){ }
        public Polynomial(List<PolynomialVariable> polynomialVariables) : base(polynomialVariables) { }

        override
        public string ToString()
        {
            return String.Join(" + ", this.Select(e => e.power == 0 ? $"{e.coefficient}" : $"{e.coefficient}x{Utils.getIndexString(e.power)}")).Replace("+ -", "- ");
        }
    }

}
