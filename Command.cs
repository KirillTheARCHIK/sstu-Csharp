using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практики
{
    internal class Command
    {
        string action;
        List<string> arguments;
        List<string> modificators;

        public string Action { get { return action; } }
        public List<string> Arguments { get { return arguments; } }
        public List<string> Modificators { get { return modificators; } }

        public Command(string source)
        {
            arguments = new List<string>();
            modificators = new List<string>();
            if (source.StartsWith("-"))
            {
                source = " " + source;
            }

            var quotesSplitted = source.Split('"').ToList();
            var outerQuotesStr = "";
            for (int i = 0; i < quotesSplitted.Count; i++)
            {
                if (i % 2 == 1)
                {
                    arguments.Add(quotesSplitted[i]);
                }
                else
                {
                    outerQuotesStr += quotesSplitted[i];
                }
            }
            var splitted = outerQuotesStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            action = splitted[0];

            foreach (var str in splitted.Skip(1))
            {
                if (str.StartsWith("-") && !double.TryParse(str, out var _))
                {
                    modificators.Add(str);
                    break;
                }
                arguments.Add(str);
            }
        }
    }

    internal class CommandExeption : OSExeption
    {
        public CommandExeption() : base() { }
        public CommandExeption(string message) : base(message) { }
    }
}
