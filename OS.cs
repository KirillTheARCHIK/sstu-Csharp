using System;
using System.Collections.Generic;
using System.Text;

namespace Практики
{
    internal class OS : SubProgram
    {
        List<SubProgram> programList = new List<SubProgram>
        {
           new Practice6(history),
        };
        public OS() : base("~", new History() { }, new Listeners()
        {
            ["run"] = delegate (Command command) {
                
            },
        })
        { }


    }

    internal class OSExeption : Exception
    {
        public OSExeption() : base() { }
        public OSExeption(string message) : base(message) { }
    }
}
