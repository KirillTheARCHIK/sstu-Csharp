using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    //Описать класс УЧЕНИК(поля: ФИО, ГОД ОБУЧЕНИЯ, НАЗВАНИЯ КЛАССА (БУКВА a-д)). +
    //Операция класса: перевод ученика в следующий класс(++). +
    //Статический метод класса: сортировка массива учеников по паре(год обучения, название класса); +
    //Функция демонстрационной программы: удаление ученика с заданной ФИО из массива.

    //В классе УЧЕНИК реализовать интерфейсы IComparable и IComparer и переопределить операции сравнения учеников, причем операцию == как сравнение учеников по ФИО. +
    //a)  С помощью метода Array.Sort осуществить сортировку массива учеников: по ФИО, по комбинации (год обучения, название класса). +
    //b)  Модифицировать функцию демонстрационной программы -  удаление ученика с заданной ФИО из массива, осуществляя в ней сравнение с помощью операции ==.

    // ** Реализовать всё с помощью WinForms, Entity Fraemwork; применить паттерн проектирования**
    internal class Student : IComparable
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
                    throw new Exception("Необходимы все 3 компонента ФИО");
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
                    throw new Exception("Номер класса должен быть в пределах [1, 11]");
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
                    throw new Exception("Буква класса должена быть в пределах [А, Д]");
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

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                return new StudentsNameComparer().Compare(this, obj as Student) == 0;
            }
            return base.Equals(obj);
        }

        public static bool operator ==(Student a, Student b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !(a == b);
        }

        public int CompareTo(object other)
        {
            if (other is Student)
            {
                return new StudentsYearGroupComparer().Compare(this, (Student)other);
            }
            throw new Exception("Сравниваемый объект не является Student");
        }

        //С помощью метода Array.Sort осуществить сортировку массива учеников: по ФИО, по комбинации (год обучения, название класса). 
        public static void SortListByName(List<Student> list)
        {
            Array.Sort(list.ToArray(), new StudentsNameComparer());
        }
        public static void SortListByYearGroup(List<Student> list)
        {
            Array.Sort(list.ToArray(), new StudentsYearGroupComparer());
        }
    }

    //В классе УЧЕНИК реализовать интерфейсы IComparable и IComparer и переопределить операции сравнения учеников, причем операцию == как сравнение учеников по ФИО.
    internal class StudentsYearGroupComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            int yearCompare = x.Year.CompareTo(y.Year);
            if (yearCompare != 0)
            {
                return yearCompare;
            }
            return x.Group.CompareTo(y.Group);
        }
    }
    internal class StudentsNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
