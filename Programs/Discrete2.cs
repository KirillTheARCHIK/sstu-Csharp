using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    //Рефлексивное: (1;1),(2;2),(3;3)
    //Иррефлексивное: (1;2),(2;1),(3;4)
    //Симметричное: (1;2),(2;1),(3;4),(4;3)
    //Антисимметричное: (1;1),(2;2),(3;3),(4;5)
    //Транзитивное: (1;2),(2;3),(1;3),(4;5)
    //Эквивалентность: 
    //Порядок: (1;2),(2;3),(3;4)
    internal class Discrete2 : SubProgram
    {
        public Discrete2(History history) : base("d2", history, new Listeners()
        {
            ["check"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count != 1)
                {
                    throw new CommandExeption("Отсутствует аргумент\n         ↓\ncheck <input>");
                }
                string input = command.Arguments[0];
                var binRel = new BinRel(input);
                Console.WriteLine($"Рефлексивное {(binRel.Reflective ? "+" : "-") }");
                Console.WriteLine($"Иррефлексивное {(binRel.IrReflective ? "+" : "-")}");
                Console.WriteLine($"Симметричное {(binRel.Symmetrical ? "+" : "-")}");
                Console.WriteLine($"Антисимметричное {(binRel.AntiSymmetrical ? "+" : "-")}");
                Console.WriteLine($"Транзитивное {(binRel.Transitive ? "+" : "-")}");
                if (binRel.Equivalence)
                {
                    Console.WriteLine($"Это эквивалентность");
                }
                else if (binRel.Order)
                {
                    Console.WriteLine($"Это порядок");
                }
                else
                {
                    Console.WriteLine($"Это не эквивалентность и не порядок");
                }
            },
            ["factor"] = delegate (Command command, History hist)
            {
                var books = new List<Book>() {
                    new Book("Мастер и Маргарита", "Михаил Булгаков"),
                    new Book("Маленький принц", "Антуан де Сент-Экзюпери"),
                    new Book("Собачье сердце", "Михаил Булгаков"),
                    new Book("Война и мир", "Лев Толстой"),
                    new Book("Преступление и наказание", "Федор Достоевский"),
                    new Book("Герой нашего времени", "Михаил Лермонтов"),
                    new Book("Двенадцать стульев", "Илья Ильф, Евгений Петров"),
                    new Book("Евгений Онегин", "Александр Пушкин"),
                    new Book("Сто лет одиночества", "Габриэль Гарсиа Маркес"),
                    new Book("Рассказы", "Антон Чехов"),
                };

                Console.WriteLine("\nВсе книги:");
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }

                var groupedBooks = books.GroupBy(book => book.author);
                Console.WriteLine("\n\nФактор-множества:");
                foreach (var item in groupedBooks)
                {
                    Console.WriteLine($"\n{item.Key}");
                    foreach (var book in item)
                    {
                        Console.WriteLine($"    {book.name}");
                    }
                }
            },
        })
        { }
    }

    internal class Book
    {
        public string name;
        public string author;

        public Book(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public override string ToString()
        {
            return $"{author} - {name}";
        }
    }

}
