using Newtonsoft.Json;
using System;

namespace Практики
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            new OS().listen();
        }
    }
}
