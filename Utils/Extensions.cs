using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    public static class ListExtension
    {
        public static List<T> RemoveDuplicates<T>(this IEnumerable<T> list)
        {
            var newList = new List<T>();
            foreach (var item in list)
            {
                if (!newList.Contains(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
    }
    public static class BoolExtension
    {
        public static bool Imp(this bool a, bool b)
        {
            return !a | b;
        }
    }
}
