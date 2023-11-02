using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
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
                return this.All(tuple => tuple.Item1 == tuple.Item2);
            }
        }
        public bool IrReflective
        {
            get
            {
                return this.All(tuple => tuple.Item1 != tuple.Item2);
            }
        }
        public bool Symmetrical
        {
            get
            {
                return this.All(tuple =>
                    this.Any(t =>
                        tuple.Item1 == t.Item2 &&
                        tuple.Item2 == t.Item1
                    )
                );
            }
        }
        public bool AntiSymmetrical
        {
            get
            {
                return this.All(tuple =>
                   this.Any(t =>
                        tuple.Item1 == t.Item2 &&
                        tuple.Item2 == t.Item1
                    ).Imp(tuple.Item1 == tuple.Item2)
               );
            }
        }
        public bool Transitive
        {
            get
            {
                return this.All(delegate (Tuple<int, int> AB)
                {
                    AB.Deconstruct(out int a, out int b);
                    var findedBC = this.FirstOrDefault(tuple => tuple.Item1 == b);
                    if (findedBC != null)
                    {
                        int c = findedBC.Item2;
                        return (findedBC != null).Imp(this.Any(tuple => tuple.Item1 == a && tuple.Item2 == c));
                    }
                    else
                    {
                        return true;
                    }
                }
               ); ;
            }
        }
        public bool Equivalence
        {
            get
            {
                return Reflective & Symmetrical & Transitive;
            }
        }
        public bool Order
        {
            get
            {
                return Reflective & AntiSymmetrical & Transitive;
            }
        }
    }
}
