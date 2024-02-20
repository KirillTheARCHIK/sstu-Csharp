using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Analysis
{
    class MathFunction
    {
        public bool debug = false;
        string input;

        HashSet<char> variables;

        public MathFunction(string input, bool debug)
        {
            this.debug = debug;
            this.input = input;

            variables = getVariables(input);
        }

        static HashSet<char> getVariables(string input)
        {
            var variables = new HashSet<char>();
            foreach (char c in input)
            {
                if (c >= 'A' & c <= 'Z')
                {
                    variables.Add(c);
                }
            }
            return variables.OrderBy(c => (int)c).ToHashSet();
        }

        //string variableChars = "[A-Za-z]{1}";
        string variableChars = "[01]{1}";
        double ResolveExpression(string expression, Dictionary<char, double> variableValues)
        {
            double expressionValue;
            foreach (var entry in variableValues)
            {
                expression = expression.Replace(entry.Key.ToString(), entry.Value.ToString());
            }
            while (!double.TryParse(expression, out expressionValue))
            {
                if (debug)
                {
                    Console.WriteLine(expression);
                }
                if (ReplaceBrackets(ref expression))
                {
                    continue;
                }
                if (ReplaceUnary(ref expression, new string[]{"-"}))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "^" }))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "*", "/" }))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "+", "-" }))
                {
                    continue;
                }
                break;
            }
            if (debug)
            {
                Console.WriteLine(expression);
            }
            if ()
            {
                return expressionValue;
            }
            throw new Exception("Выражение составлено некорректно");
        }
        bool ReplaceBrackets(ref string expression)
        {
            Regex regex = new Regex(@"\((?<inner>[^\(\)]+?)\)");
            var match = regex.Match(expression);
            if (match.Success)
            {
                var inner = match.Groups["inner"].Value.ToString();
                Console.WriteLine($"Inner {inner}");
                expression = expression.Replace(match.Value, BoolToChar(ResolveExpression(inner)).ToString());
                return true;
            }
            return false;
        }
        bool ReplaceUnary(ref string expression, string[] operators)
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
        bool ReplaceBinary(ref string expression, string[] operators)
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
                case '>':
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
                    throw new Exception("Несуществующий бинарный оператор");
            }
        }
    }
}
