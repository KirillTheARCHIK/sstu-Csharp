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

        static public string makeCell(string data, uint width)
        {
            string s = "";
            for (int i = 0; i < width; i++)
            {
                s += ' ';
            }
            s = s.Insert((int)((width - data.Length) / 2), data).Substring(0, (int)width);
            s += '|';
            return s;
        }

        static public string makeRow(List<string> data, List<uint> widths)
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

        static public void makeTable(List<uint> widths, List<string> headerData, List<List<string>> data)
        {
            var header = ConsoleTable.makeRow(headerData, widths);
            Console.WriteLine(ConsoleTable.makeLine(header.Length / 2));
            Console.WriteLine(header);
            foreach (var item in data)
            {
                Console.WriteLine(ConsoleTable.makeRow(item, widths));
            }
        }
    }
}
