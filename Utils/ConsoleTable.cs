using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    class ConsoleTable
    {
        static public string makeLine(int width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += '-';
            }
            return s;
        }

        static public string makeCell(string data, int width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += ' ';
            }
            s = s.Insert((width - data.Length) / 2, data).Substring(0, width);
            s += '|';
            return s;
        }

        static public string makeRow(List<string> data, List<int> widths)
        {
            string s = "|";
            for (int i = 0; i < widths.Count; i++)
            {
                s += makeCell(data.Count > i ? data[i] : "", widths[i]);
            }
            s += '\n';
            s += makeLine(s.Length - 1);
            return s;
        }

        static public void makeTable(List<int> widths, List<string> headerData, List<List<string>> data)
        {
            var header = makeRow(headerData, widths);
            Console.WriteLine(makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var item in data)
            {
                Console.WriteLine(makeRow(item, widths));
            }
        }
    }
}
