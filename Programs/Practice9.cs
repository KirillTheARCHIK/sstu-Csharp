using DeepMorphy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практики;

namespace Programs
{
    internal class Practice9 : SubProgram
    {
        public Practice9(History history) : base("p9", history, new Listeners()
        {
            ["a"] = delegate (Command command, History hist)
            {
                {
                    string[] words = new string[]
                {
                    "Играют",
                    "волны",
                    "ветер",
                    "свищет",
                    "И",
                    "мачта",
                    "гнется",
                    "и",
                    "скрипит",
                    "Увы",
                    "Он",
                    "счастия",
                    "не",
                    "ищет",
                    "И",
                    "не",
                    "от",
                    "счастия",
                    "бежит"
                }; var m = new MorphAnalyzer();
                    var results = m.Parse(words).ToArray();
                    foreach (var morphInfo in results)
                    {
                        if (morphInfo["чр"].BestGramKey == "гл")
                        {
                            Console.WriteLine(morphInfo.ToString());
                        }
                    }

                }
            }
        })
        { }
    }

    internal class Student
    {
        string name; //ФИО
        int year; //1-11
        char group; //а-д

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length < 3)
                {
                    throw new StudentExeption("Необходимы все 3 компонента ФИО");
                }
                name = value;
            }
        }
        public int Year
        {
            get => year;
            private set
            {
                if (value < 1 || value > 11)
                {
                    throw new StudentExeption("Номер класса должен быть в пределах [1, 11]");
                }
                year = value;
            }
        }
        public char Group
        {
            get => group;
            private set
            {
                if (value < 'А' || value > 'Д')
                {
                    throw new StudentExeption("Буква класса должена быть в пределах [А, Д]");
                }
                group = value;
            }
        }

        public Student(string name, int year, char group)
        {
            Name = name;
            Year = year;
            Group = group;
        }

        public Student(string name, char group)
        {
            Name = name;
            Year = 1;
            Group = group;
        }

        public Student(string str)
        {
            var splitted = str.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Name = splitted[0];
            Year = int.Parse(splitted[1]);
            Group = splitted[2][0];
        }

        public static Student operator ++(Student s)
        {
            s.Year++;
            return s;
        }

        public override string ToString()
        {
            return $"{Name}, {year}, {group}";
        }
    }

    internal class StudentExeption : OSExeption
    {
        public StudentExeption() : base() { }
        public StudentExeption(string message) : base(message) { }
    }
}
