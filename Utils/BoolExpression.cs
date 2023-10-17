using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;
using System.Text.RegularExpressions;

namespace Programs
{
    internal class Konjunct
    {
        public Dictionary<char, bool> variableValues;
        public Konjunct(Dictionary<char, bool> variableValues)
        {
            this.variableValues = variableValues;
        }

        override public string ToString()
        {
            return string.Join("", variableValues.Select(v => v.Value ? v.Key.ToString() : "¬" + v.Key.ToString()));
        }
    }
    internal class Disjunct
    {
        public Dictionary<char, bool> variableValues;
        public Disjunct(Dictionary<char, bool> variableValues)
        {
            this.variableValues = variableValues;
        }

        override public string ToString()
        {
            return string.Join("v", variableValues.Select(v => v.Value ? "¬" + v.Key.ToString() : v.Key.ToString()));
        }
    }
    internal class BoolExpressionCase
    {
        public bool debug = false;

        public Dictionary<char, bool> variableValues;
        public bool result;
        public Konjunct konjunct;
        public Disjunct disjunct;
        public BoolExpressionCase(HashSet<char> variables, int index, string expression, bool debug)
        {
            this.debug = debug;
            variableValues = new Dictionary<char, bool>();
            for (int j = 0; j < variables.Count; j++)
            {
                int value = (index % (int)Math.Pow(2, variables.Count - j)) / (int)Math.Pow(2, variables.Count - j - 1);
                variableValues.Add(variables.ElementAt(j), value == 1);
            }
            if (debug)
            {
                Console.WriteLine($"\nCASE   {String.Join(" ", variableValues.Values.Select(e => e ? "1" : "0"))}\n");
            }
            result = ResolveExpression(expression);
            if (result)
            {
                konjunct = new Konjunct(variableValues);
            }
            else
            {
                disjunct = new Disjunct(variableValues);
            }

            this.debug = debug;
        }
        string unaryOperators = "¬!";
        string binaryOperators = "\\˄∧&\\|˅∨↓→=≡↔☺⊕";
        //string variableChars = "[A-Za-z]{1}";
        string variableChars = "[01]{1}";
        bool ResolveExpression(string expression)
        {
            foreach (var entry in variableValues)
            {
                expression = expression.Replace(entry.Key, entry.Value ? '1' : '0');
            }
            while (expression.Length > 1)
            {
                if (debug)
                {
                    Console.WriteLine(expression);
                }
                if (ReplaceBrackets(ref expression))
                {
                    continue;
                }
                if (ReplaceUnary(ref expression, "¬!┐".ToCharArray()))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, "˄∧&|".ToCharArray()))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, "˅∨vV↓".ToCharArray()))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, "→".ToCharArray()))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, "=≡↔☺⊕+".ToCharArray()))
                {
                    continue;
                }
                break;
            }
            if (debug)
            {
                Console.WriteLine(expression);
            }
            if (expression.Length == 1)
            {
                return expression[0] == '1';
            }
            throw new OSExeption("Выражение составлено некорректно");
        }
        bool ReplaceBrackets(ref string expression)
        {
            Regex regex = new Regex($"\\((?<valueA>{variableChars})\\)");
            var match = regex.Match(expression);
            if (match.Success)
            {
                expression = expression.Replace(match.Value, match.Groups["valueA"].Value);
                return true;
            }
            return false;
        }
        bool ReplaceUnary(ref string expression, char[] operators)
        {
            Regex regex = new Regex($"(?<operator>[{String.Join("", operators)}])(?<valueA>{variableChars})");
            var match = regex.Match(expression);
            if (match.Success)
            {
                expression = expression.Replace(
                    match.Value,
                    BoolToChar(
                        BoolOperation(
                            StringToBool(match.Groups["valueA"].Value),
                            match.Groups["operator"].Value[0]
                        )
                    ).ToString()
                );
                return true;
            }
            return false;
        }
        bool ReplaceBinary(ref string expression, char[] operators)
        {
            Regex regex = new Regex($"(?<valueA>{variableChars})(?<operator>[{String.Join("", operators)}])(?<valueB>{variableChars})");
            var match = regex.Match(expression);
            if (match.Success)
            {
                expression = expression.Replace(
                    match.Value,
                    BoolToChar(
                        BoolOperation(
                            StringToBool(match.Groups["valueA"].Value),
                            StringToBool(match.Groups["valueB"].Value),
                            match.Groups["operator"].Value[0]
                        )
                    ).ToString()
                );
                return true;
            }
            return false;
        }
        //Отрицание: ¬!
        bool BoolOperation(bool a, char operation)
        {
            switch (operation)
            {
                case '!':
                case '¬':
                case '┐':
                    {
                        return !a;
                    }
                default:
                    throw new OSExeption("Несуществующий унарный оператор");
            }
        }
        //Коньюнкция: ∧˄&
        //Дизъюнкция: ∨˅Vv
        //Импликация: → 
        //Эквивалентность: =≡↔
        //Исключающее или: ☺⊕
        //Стрелка Пирса: ↓
        //Штрих Шеффера: |
        bool BoolOperation(bool a, bool b, char operation)
        {
            switch (operation)
            {
                case '∧':
                case '˄':
                case '&':
                    {
                        return a & b;
                    }
                case '∨':
                case '˅':
                case 'v':
                case 'V':
                    {
                        return a | b;
                    }
                case '→':
                    {
                        return !a | b;
                    }
                case '=':
                case '≡':
                case '↔':
                    {
                        return a == b;
                    }
                case '⊕':
                case '☺':
                case '+':
                    {

                        return a != b;
                    }
                case '↓':
                    {
                        return !(a | b);
                    }
                case '|':
                    {
                        return !(a & b);
                    }
                default:
                    throw new OSExeption("Несуществующий бинарный оператор");
            }
        }
        static bool StringToBool(string str)
        {
            return str == "1" ? true : str == "0" ? false : throw new OSExeption("Неудачный перевод string в bool");
        }
        static bool CharToBool(char str)
        {
            return str == '1' ? true : str == '0' ? false : throw new OSExeption("Неудачный перевод char в bool");
        }
        static char BoolToChar(bool b)
        {
            return b ? '1' : '0';
        }
    }
    internal class BoolExpression
    {
        static int cellWidth = 3;
        public bool debug = false;

        HashSet<char> variables;
        List<BoolExpressionCase> cases;

        public BoolExpression(string input, bool debug)
        {
            this.debug = debug;

            variables = getVariables(input);
            cases = new List<BoolExpressionCase>();
            for (int i = 0; i < (int)Math.Pow(2, variables.Count); i++)
            {
                var newCase = new BoolExpressionCase(variables, i, input, debug);
                cases.Add(newCase);
            }
        }

        public void printTable()
        {
            List<int> widths = new List<int>() { };
            for (int i = 0; i < variables.Count; i++)
            {
                widths.Add(cellWidth);
            }
            widths.AddRange(new List<int> { 7, variables.Count * 2, variables.Count * 2 });
            var columns = new List<string>(cases[0].variableValues.Keys.Select(c => c.ToString()));
            columns.AddRange(new List<string> { "резул", "кон", "диз" });
            var header = ConsoleTable.makeRow(columns, widths);
            Console.WriteLine(ConsoleTable.makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var _case in cases)
            {
                //variables
                var rowData = _case.variableValues.Values.Select(e => e ? "1" : "0").ToList();
                //result
                rowData.Add(_case.result ? "1" : "0");
                //kon
                rowData.Add(_case.konjunct?.ToString() ?? "");
                //dis
                rowData.Add(_case.disjunct?.ToString() ?? "");
                Console.WriteLine(ConsoleTable.makeRow(rowData, widths));
            }
            Console.WriteLine($"СКНФ: {string.Join("&", cases.Where(c => c.disjunct != null).Select(c => $"({c.disjunct})"))}");
            Console.WriteLine($"СДНФ: {string.Join("v", cases.Where(c => c.konjunct != null).Select(c => $"({c.konjunct})"))}");
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
