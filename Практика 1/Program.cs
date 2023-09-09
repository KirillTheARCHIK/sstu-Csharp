using System;

namespace Практика_1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string str;
                bool hasLetters = false;
                bool hasDigits = false;
                bool hasSpaces = false;
                //Start
                Console.Clear();
                Console.Write("Введите строку: ");
                str = Console.ReadLine();
                var chars = str.ToCharArray();
                
                if (chars.Length == 0)
                {
                    Console.WriteLine("Это пустая строка");
                }
                else
                {
                    foreach (var c in chars)
                    {
                        var charIndex = (int)c;
                        if (charIndex >= 48 && charIndex <= 57)
                        {
                            hasDigits = true;
                        }
                        else if (charIndex >= 65 && charIndex <= 122)
                        {
                            hasLetters = true;
                        }
                        else if (charIndex == ' ')
                        {
                            hasSpaces = true;
                        }
                    }
                    //Return result
                    var result = $"Вы ввели {(hasLetters ? "буквы, " : "")}{(hasDigits ? "цифры, " : "")}{(hasSpaces ? "пробелы" : "")}";
                    if (result.EndsWith(", "))
                    {
                        result = result.Remove(result.Length - 2);
                    }
                    Console.WriteLine(result);
                }
                    Console.ReadLine();
            } while (true);
        }
    }
}
