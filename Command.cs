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
            if (source.StartsWith("-"))
            {
                source = " " + source;
            }

            var splitted = source.Split(' ');
            action = splitted[0];
            arguments = new List<string>();
            modificators = new List<string>();
            foreach (var str in splitted.Skip(1))
            {
                if (str.StartsWith("-"))
                {
                    modificators.Add(str);
                    break;
                }
                arguments.Add(str);
            }
        }
    }

    internal class CommandExeption : OSExeption {
        public CommandExeption() : base() { }
        public CommandExeption(string message) : base(message) { }
    }
}
