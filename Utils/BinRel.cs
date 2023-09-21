using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    [Serializable]
    class BinRel : HashSet<Tuple<int, int>>
    {
        public BinRel() : base() { }
        public BinRel(string input) : base(input.Split(',').Select(delegate (string tupleStr)
        {
            var withoutBraces = tupleStr.Replace("(", "").Replace(")", "");
            var splitted = withoutBraces.Split(';').Select(strNum => int.Parse(strNum)).ToArray();
            return new Tuple<int, int>(splitted[0], splitted[1]);
        }))
        { }

        public BinRel(IEnumerable<Tuple<int, int>> set) : base(set) { }

        public BinRel reverse()
        {
            return new BinRel(this.Select(delegate (Tuple<int, int> tuple)
            {
                return new Tuple<int, int>(tuple.Item2, tuple.Item1);
            }));
        }

        public BinRel composition(BinRel other)
        {
            return new BinRel(this.Join(other, tuple => tuple.Item2, tuple => tuple.Item1, (t1, t2) => new Tuple<int, int>(t1.Item1, t2.Item2)));
        }

        public string toString()
        {
            return JsonConvert.SerializeObject(this.Select(tuple => $"({tuple.Item1};{tuple.Item2})")).Replace("\"", "");
        }

        public bool Reflective
        {
            get
            {
                return false;
            }
        }
    }
}
