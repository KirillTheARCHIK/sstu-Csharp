using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    //Описать класс УЧЕНИК(поля: ФИО, ГОД ОБУЧЕНИЯ, НАЗВАНИЯ КЛАССА (БУКВА a-д)). +
    //Операция класса: перевод ученика в следующий класс(++). +
    //Статический метод класса: сортировка массива учеников по паре(год обучения, название класса); +
    //Функция демонстрационной программы: удаление ученика с заданной ФИО из массива. +

    //В классе УЧЕНИК реализовать интерфейсы IComparable и IComparer и переопределить операции сравнения учеников, причем операцию == как сравнение учеников по ФИО. +
    //a)  С помощью метода Array.Sort осуществить сортировку массива учеников: по ФИО, по комбинации (год обучения, название класса). +
    //b)  Модифицировать функцию демонстрационной программы -  удаление ученика с заданной ФИО из массива, осуществляя в ней сравнение с помощью операции ==. +

    // ** Реализовать всё с помощью WinForms, Entity Fraemwork **
    internal class Student : IComparable
    {
        string name; //ФИО
        int year; //1-11
        char group; //а-д

        public int Id { get; set; }
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
                    throw new Exception($"Буква класса должена быть в пределах [А, Д], была введена: {value}");
                }
                group = value;
            }
        }
        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }

        public Student(string name, int year, char group, School school)
        {

            Name = name;
            Year = year;
            Group = group;
            School = school;
        }

        public Student(string name, char group)
        {

            Name = name;
            Year = 1;
            Group = group;
        }

        public Student(string str)
        {
            var splitted = str.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries).Select((s) => s.Trim()).ToList();
            Name = splitted[0];
            Year = int.Parse(splitted[1]);
            Group = splitted[2][0];
        }

        public static Student operator ++(Student s)
        {
            s.Year++;
            return s;
        }

        public static List<Student> MockStudents = new List<Student>()
        {
            new Student("Коноплев Кирилл Дмитриевич, 9, В"),
            new Student("Засорина Анастасия Борисовна, 3, А"),
            new Student("Обыденнова Татьяна Дмитриевна, 9, А"),
            new Student("Золотухина Анна Александровна, 4, Д"),
            new Student("Мурзаев Максим Павлович, 1, Г"),
        };

        public override string ToString()
        {
            return $"{Id}; {Name}; {year}{group}; {School.SchoolType.Name} №{School.Number}";
        }

        public override bool Equals(object obj)
        {
            var baseEqual = base.Equals(obj);
            if (!baseEqual && obj is Student)
            {
                if (IsNull() || (obj as Student).IsNull())
                {
                    return false;
                }
                return new StudentsNameComparer().Compare(this, obj as Student) == 0;
            }
            return baseEqual;
        }

        public bool IsNull()
        {
            return base.Equals(null);
        }

        public static bool operator ==(Student a, Student b)
        {
            if (a is null)
            {
                return b is null;
            }
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
        public static List<Student> SortListByName(List<Student> list)
        {
            var newList = list.ToArray();
            Array.Sort(newList, new StudentsNameComparer());
            return newList.ToList();
        }
        public static List<Student> SortListByYearGroup(List<Student> list)
        {
            var newList = list.ToArray();
            Array.Sort(newList, new StudentsYearGroupComparer());
            return newList.ToList();
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
