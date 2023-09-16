using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практики
{
    internal class Listeners : Dictionary<string, Action<Command>> { }
    internal class SubProgram
    {
        string name;
        History history;
        Listeners listeners;

        public string Name { get { return name; } }

        public SubProgram(string name, History history, Listeners listeners)
        {
            this.name = name;
            this.listeners = listeners;

            var newHistory = new History(history) { this };
            this.history = newHistory;
        }

        public void listen()
        {
            while (true)
            {
                try
                {
                    Console.Write($"{history} > ");
                    var enter = Console.ReadLine();
                    if (enter == "")
                    {
                        continue;
                    }
                    var command = new Command(enter);

                    var findedSubProgram = Enumerable.Reverse(history).FirstOrDefault((subProgram) => subProgram.listeners.ContainsKey(command.Action));
                    if (findedSubProgram != null)
                    {
                        findedSubProgram.listeners[command.Action](command);
                        continue;
                    }

                    throw new NoFoundCommandExeption(command);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}\n{e.StackTrace}");
                }

            }
        }
    }

    internal class SubProgramExeption : OSExeption
    {
        public SubProgramExeption() : base() { }
        public SubProgramExeption(string message) : base(message) { }
    }

    internal class NoFoundCommandExeption : SubProgramExeption
    {
        public NoFoundCommandExeption(Command command) : base($"Команды {command.Action} не существует") { }
    }
}
