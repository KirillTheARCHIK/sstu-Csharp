using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    internal class Utils
    {
        public static string getIndexString(double index)
        {
            var str = index.ToString();
            return str.Replace('0', '⁰').Replace('1', '¹').Replace('2', '²').Replace('3', '³').Replace('4', '⁴').Replace('5', '⁵').Replace('6', '⁶').Replace('7', '⁷').Replace('8', '⁸').Replace('9', '⁹');
        }
    }
}
