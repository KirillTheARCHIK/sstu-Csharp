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
            if (BoolExpression.debug)
            {
                Console.WriteLine($"\nCASE   {String.Join(" ", variableValues.Values.Select(e => e ? "1" : "0"))}\n");
            }
            result = ResolveExpression(expression);
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
                if (BoolExpression.debug)
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
                if (ReplaceBinary(ref expression, "˅∨↓".ToCharArray()))
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
            if (BoolExpression.debug)
            {
                Console.WriteLine(expression);
            }
            if (expression.Length == 1)
            {
                return expression[0] == '1';
            }
            throw new OSExeption("Выражение составлено некорректно");
            //if (subExpression.StartsWith("(") && subExpression.EndsWith(")"))
            //{
            //    subExpression = subExpression.Substring(1, subExpression.Length - 2);
            //}
            //if (subExpression.Length == 1)
            //{
            //    return variableValues[subExpression[0]];
            //}
            //Regex binaryRegex = new Regex($"\\A(?<valueA>(\\(.+\\)|{variableChars}))(?<operator>{binaryOperators})(?<valueB>(\\(.+\\)|{variableChars}))\\Z");
            //var binaryMatch = binaryRegex.Match(subExpression);
            //if (binaryMatch.Success)
            //{
            //    return BoolOperation(ResolveExpression(binaryMatch.Groups["valueA"].Value), ResolveExpression(binaryMatch.Groups["valueB"].Value), binaryMatch.Groups["operator"].Value[0]);
            //}
            //Regex unaryRegex = new Regex($"\\A(?<operator>{unaryOperators})(?<value>(\\(.+\\)|{variableChars}))\\Z");
            //var unaryMatch = unaryRegex.Match(subExpression);
            //if (unaryMatch.Success)
            //{
            //    return BoolOperation(ResolveExpression(unaryMatch.Groups["value"].Value), unaryMatch.Groups["operator"].Value[0]);
            //}
            //throw new OSExeption("Выражение составлено некорректно");
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
        //Дизъюнкция: ∨˅
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
        static uint cellWidth = 3;
        public static bool debug = true;

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
            var header = ConsoleTable.makeRow(columns, widths);
            Console.WriteLine(ConsoleTable.makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var _case in cases)
            {
                var rowData = _case.variableValues.Values.Select(e => e ? "1" : "0").ToList();
                rowData.Add(_case.result ? "1" : "0");
                Console.WriteLine(ConsoleTable.makeRow(rowData, widths));
            }
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
