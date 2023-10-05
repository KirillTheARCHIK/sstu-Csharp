using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;
using System.Text.RegularExpressions;

namespace Programs
{
    internal class BoolExpressionCase
    {
        public Dictionary<char, bool> variableValues;
        public bool result;
        public BoolExpressionCase(HashSet<char> variables, int index, string expression)
        {
            variableValues = new Dictionary<char, bool>();
            for (int j = 0; j < variables.Count; j++)
            {
                int value = (index % (int)Math.Pow(2, variables.Count - j)) / (int)Math.Pow(2, variables.Count - j - 1);
                variableValues.Add(variables.ElementAt(j), value == 1);
            }
            result = ResolveExpression(expression);
        }
        bool ResolveExpression(string subExpression)
        {
            if (subExpression.Length==1)
            {
                return variableValues[subExpression[0]];
            }
            Regex binaryRegex = new Regex(@"");
            Regex unaryRegex = new Regex(@"^(?<operator>[!])(?<value>(\(.+\)|[A-Za-z]{1}))&");
        }
        bool BoolOperation(bool a, char operation)
        {
            switch (operation)
            {
                case '!':
                    {
                        return !a;
                    }
                default:
                    throw new OSExeption("Wrong bool operator");
            }
        }
        bool BoolOperation(bool a, bool b, char operation)
        {
            switch (operation)
            {
                case '&':
                    {
                        return a & b;
                    }
                case '|':
                    {
                        return a | b;
                    }
                default:
                    throw new OSExeption("Wrong bool operator");
            }
        }
    }
    internal class BoolExpression
    {
        static uint cellWidth = 3;

        HashSet<char> variables;
        List<BoolExpressionCase> cases;

        public BoolExpression(string input)
        {
            variables = getVariables(input);
            cases = new List<BoolExpressionCase>();
            for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++)
            {
                var newCase = new BoolExpressionCase(variables, i, input);
                cases.Add(newCase);
            }
        }

        public void printTable()
        {
            List<uint> widths = new List<uint>() { };
            for (int i = 0; i < variables.Count; i++)
            {
                widths.Add(cellWidth);
            }
            widths.AddRange(new List<uint> { 7, 5, 5 });
            var columns = new List<string>(cases[0].variableValues.Keys.Select(c => c.ToString()));
            columns.AddRange(new List<string> { "резул", "кон", "диз" });
            var header = makeRow(columns, widths);
            Console.WriteLine(makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var _case in cases)
            {
                Console.WriteLine(makeRow(_case.variableValues.Values.Select(e => e ? "1" : "0").ToList(), widths));
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

        static string makeCell(string data, uint width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += ' ';
            }
            s = s.Insert((int)((width - data.Length) / 2), data).Substring(0, (int)width);
            s += '|';
            return s;
        }

        static string makeRow(List<string> data, List<uint> widths)
        {
            string s = "|";
            for (int i = 0; i < widths.Count; i++)
            {
                s += makeCell(data.Count > i ? data[i] : "", widths[i]);
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
