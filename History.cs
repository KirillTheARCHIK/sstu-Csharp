using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практики
{
    internal class History : List<SubProgram>
    {
        public History() : base() { }
        public History(IEnumerable<SubProgram> pathList) : base(pathList) { }

        override
        public string ToString()
        {
            var strings = this.Select(x => x.Name + "/");
            return strings.Aggregate("", (string acc, string item)=>acc + item).TrimEnd('/');
        }
    }
}
