using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Numerical_Analysis
{
    class MathFunction
    {
        public bool debug = false;
        public string input;

        public HashSet<char> variables;

        public MathFunction(string input, bool debug)
        {
            this.debug = debug;
            this.input = input;

            variables = getVariables(input);
            if (debug)
            {
                Program.logger.Log(LogLevel.Information, "variables: " + JsonConvert.SerializeObject(variables));
            }
        }

        static HashSet<char> getVariables(string input)
        {
            var variables = new HashSet<char>();
            foreach (char c in input)
            {
                if (c >= 'A' & c <= 'Z' || c >= 'a' & c <= 'z')
                {
                    variables.Add(c);
                }
            }
            return variables.OrderBy(c => (int)c).ToHashSet();
        }

        string numberChars = "\\d+";
        public double ResolveExpression(Dictionary<char, double?> variableValues)
        {
            return ResolveExpression(input, variableValues);
        }
        public double ResolveExpression(string expression, Dictionary<char, double?> variableValues)
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
                    Program.logger.Log(LogLevel.Information, expression);
                }
                if (ReplaceBrackets(ref expression, variableValues))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "\\^" }))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "\\*", "/" }))
                {
                    continue;
                }
                if (ReplaceUnary(ref expression, new string[] { "-" }))
                {
                    continue;
                }
                if (ReplaceBinary(ref expression, new string[] { "\\+", "-" }))
                {
                    continue;
                }
                throw new Exception("Выражение составлено некорректно");
            }
            if (debug)
            {
                Program.logger.Log(LogLevel.Information, expression);
            }
            if (double.TryParse(expression, out expressionValue))
            {
                return expressionValue;
            }
            throw new Exception("Выражение составлено некорректно");
        }
        public double GetDerivative(Dictionary<char, double?> variableValues, char axis)
        {
            var delta = 1e-8;
            return (
                ResolveExpression(variableValues.Select(
                    pair => pair.Key != axis ?
                        pair :
                        new KeyValuePair<char, double?>(pair.Key, pair.Value + delta)).ToDictionary()
                ) -
                ResolveExpression(variableValues.Select(
                    pair => pair.Key != axis ?
                        pair :
                        new KeyValuePair<char, double?>(pair.Key, pair.Value - delta)).ToDictionary()
                )
             ) / (2 * delta);
        }
        bool ReplaceBrackets(ref string expression, Dictionary<char, double?> variableValues)
        {
            Regex regex = new Regex(@"\((?<inner>[^\(\)]+?)\)");
            var match = regex.Match(expression);
            if (match.Success)
            {
                var inner = match.Groups["inner"].Value.ToString();
                Program.logger.Log(LogLevel.Information, $"Inner {inner}");
                expression = expression.Replace(match.Value, ResolveExpression(inner, variableValues).ToString());
                return true;
            }
            return false;
        }
        bool ReplaceUnary(ref string expression, string[] operators)
        {
            Regex regex = new Regex($"(?<operator>[{string.Join("", operators)}])(?<valueA>{numberChars})");
            var match = regex.Match(expression);
            if (match.Success)
            {
                expression = expression.Replace(
                    match.Value,
                        ArithmeticOperation(
                            double.Parse(match.Groups["valueA"].Value),
                            match.Groups["operator"].Value[0]
                        )
                    .ToString()
                );
                return true;
            }
            return false;
        }
        bool ReplaceBinary(ref string expression, string[] operators)
        {
            Regex regex = new Regex($"(?<valueA>{numberChars})(?<operator>[{String.Join("", operators)}])(?<valueB>{numberChars})");
            var match = regex.Match(expression);
            if (match.Success)
            {
                expression = expression.Replace(
                    match.Value,
                        ArithmeticOperation(
                            double.Parse(match.Groups["valueA"].Value),
                            double.Parse(match.Groups["valueB"].Value),
                            match.Groups["operator"].Value[0]
                    ).ToString()
                );
                return true;
            }
            return false;
        }
        double ArithmeticOperation(double a, char operation)
        {
            switch (operation)
            {
                case '-':
                    {
                        return -a;
                    }
                default:
                    throw new Exception("Несуществующий унарный оператор");
            }
        }
        double ArithmeticOperation(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    {
                        return a + b;
                    }
                case '-':
                    {
                        return a - b;
                    }
                case '*':
                    {
                        return a * b;
                    }
                case '/':
                    {
                        return a / b;
                    }

                case '^':
                    {

                        return Math.Pow(a, b);
                    }
                default:
                    throw new Exception("Несуществующий бинарный оператор");
            }
        }
    }
}
