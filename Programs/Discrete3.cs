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
        public Discrete3(History history) : base("d2", history, new Listeners()
        {
            ["build"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\nbuild <input>");
                }
                string input = command.Arguments[0];
                buildTable(input);
            },
        })
        { }

        static void buildTable(string input)
        {
            var variables = getVariables(input);
            List<Dictionary<char, bool>> cases = new List<Dictionary<char, bool>>();
            for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++)
            {
                Dictionary<char, bool> newCase = new Dictionary<char, bool>();
                for (int j = 0; j < variables.Count; j++)
                {
                    int value = (i % (int)Math.Pow(2, variables.Count - j)) / (int)Math.Pow(2, variables.Count - j - 1);
                    newCase.Add(variables.ElementAt(j), value == 1);
                }
                cases.Add(newCase);
            }
            printTable(cases);
        }

        static int cellWidth = 3;
        static void printTable(List<Dictionary<char, bool>> cases)
        {
            var header = makeRow(cases[0].Keys.Select(c => c.ToString()).ToList());
            Console.WriteLine(makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var _case in cases)
            {
                Console.WriteLine(makeRow(_case.Values.Select(e => e ? "1" : "0").ToList()));
            }
        }

        static string makeLine(int width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += '-';
            }
            return s;
        }

        static string makeCell(string data, int width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += ' ';
            }
            s = s.Insert(width / 2, data).Substring(0, width);
            s += '|';
            return s;
        }

        static string makeRow(List<string> data)
        {
            string s = "|";
            foreach (var item in data)
            {
                s += makeCell(item, cellWidth);
            }
            s += '\n';
            s += makeLine(s.Length - 1);
            return s;
        }

        static HashSet<char> getVariables(string input)
        {
            var variables = new HashSet<char>();
            foreach (char c in input)
            {
                if (c >= 'A' & c <= 'z')
                {
                    variables.Add(c);
                }
            }
            return variables.OrderBy(c => (int)c).ToHashSet();
        }
    }
}
