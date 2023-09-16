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
            ["run"] = delegate (Command command, History history)
            {
                var programList = getProgramList(history);
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
