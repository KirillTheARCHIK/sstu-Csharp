using Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практики
{
    internal class OS : SubProgram
    {
        public OS() : base("~", new History() { }, new Listeners()
        {
            [""] = delegate (Command command, History hist)
            {
                if (command.Modificators.Contains("-h"))
                {
                    Console.WriteLine("Список комманд:");
                    foreach (var item in hist.Last().Listeners.Keys.Where(key => key != ""))
                    {
                        Console.WriteLine(item);
                    }
                }
            },
            ["run"] = delegate (Command command, History hist)
            {
                if (command.Modificators.Contains("-h"))
                {
                    Console.WriteLine("run [название_программы] - запускает программу");
                    Console.WriteLine("run -l - список программ");
                    return;
                }
                var programList = getProgramList(hist);
                if (command.Modificators.Contains("-l"))
                {
                    Console.WriteLine("Список программ:");
                    foreach (var item in programList)
                    {
                        Console.WriteLine(item.Name);
                    }
                    return;
                }

                var programName = command.Arguments[0];
                var findedProgram = programList.FirstOrDefault(program => program.Name == programName);
                if (findedProgram == null)
                {
                    throw new NoFoundProgramExeption(programName);
                }
                findedProgram.listen();
            },
        })
        { }

        static List<SubProgram> getProgramList(History history)
        {
            return new List<SubProgram>
            {
               new Practice6(history),
               new Practice7(history),
               new Practice8(history),
               new Practice9(history),
               new Practice10(history),
               new Discrete1(history),
               new Discrete2(history),
               new Discrete3(history),
               new Discrete5(history),
            };
        }
    }

    internal class OSExeption : Exception
    {
        public OSExeption() : base() { }
        public OSExeption(string message) : base(message) { }
    }

    internal class NoFoundProgramExeption : Exception
    {
        public NoFoundProgramExeption(string programName) : base($"Программа {programName} не найдена") { }
    }
}
