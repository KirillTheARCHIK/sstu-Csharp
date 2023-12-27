using DeepMorphy;
using Newtonsoft.Json;
using SchoolDB;
using StudentsDB;
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
        static SchoolDBContext db;
        protected override void OnListen()
        {
            base.OnListen();
            db = new SchoolDBContext();
        }
        public Practice9(History history) : base("p9", history, new Listeners()
        {
            ["refresh"] = delegate (Command command, History hist)
            {
                db = new SchoolDBContext(true);
                List<SchoolType> schoolTypes = SchoolType.Mock();
                db.AddRange(schoolTypes);
                List<School> schools = new List<School>()
                {
                    new School(21, "Саратов", schoolTypes[0]),
                };
                db.AddRange(schools);
                List<Student> students = new List<Student>() { 
                    new Student("Коноплев Кирилл Дмитриевич", 9, 'В', schools[0]),
                };
                db.AddRange(students);
                db.SaveChanges();
            },
            ["schooltype"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count == 0 && command.Modificators.Contains("-h"))
                {
                    Console.WriteLine("Список команд:");
                    Console.WriteLine("list");
                    Console.WriteLine("add <Название>");
                    Console.WriteLine("delete <Номер в списке>");
                    return;
                }
                if (command.Arguments[0] == "list")
                {
                    Console.WriteLine("Типы учебных заведений:");
                    foreach (var item in db.SchoolTypes.ToList())
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return;
                }
                if (command.Arguments[0] == "add")
                {
                    string name = command.Arguments[1];
                    if (db.SchoolTypes.FirstOrDefault(e => e.Name == name) != null)
                    {
                        throw new Exception("Такой тип уже существует");
                    }
                    var newSchoolType = new SchoolType(name);
                    db.Add(newSchoolType);
                    db.SaveChanges();
                    return;
                }
                if (command.Arguments[0] == "delete")
                {
                    int schoolTypeId = int.Parse(command.Arguments[1]);
                    var findedSchoolType = db.SchoolTypes.ToList().FirstOrDefault(e => e.Id == schoolTypeId);
                    if (findedSchoolType == null)
                    {
                        throw new Exception("Такого типа не существует");
                    }
                    db.SchoolTypes.Remove(findedSchoolType);
                    db.SaveChanges();
                    return;
                }
            },
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            ["school"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count == 0 && command.Modificators.Contains("-h"))
                {
                    Console.WriteLine("Список команд:");
                    Console.WriteLine("list");
                    Console.WriteLine("add <Город> <Номер типа> <Номер заведения>");
                    Console.WriteLine("delete <Номер в списке>");
                    return;
                }
                if (command.Arguments[0] == "list")
                {
                    Console.WriteLine("Учебные заведения:");
                    foreach (var item in db.Schools.ToList())
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return;
                }
                if (command.Arguments[0] == "add")
                {
                    string city = command.Arguments[1];
                    int schoolTypeId = int.Parse(command.Arguments[2]);
                    int number = int.Parse(command.Arguments[3]);
                    var findedSchoolType = db.SchoolTypes.FirstOrDefault(e => e.Id == schoolTypeId);
                    if (findedSchoolType == null)
                    {
                        throw new Exception("Такого типа школ не существует");
                    }
                    if (db.Schools.FirstOrDefault(e => e.Number == number && e.SchoolType == findedSchoolType && e.City == city) != null)
                    {
                        throw new Exception("Такая школа уже существует");
                    }
                    var newSchool = new School(number, city, findedSchoolType);
                    db.Add(newSchool);
                    db.SaveChanges();
                    return;
                }
                if (command.Arguments[0] == "delete")
                {
                    int schoolId = int.Parse(command.Arguments[1]);
                    var findedSchool = db.Schools.ToList().FirstOrDefault(e => e.Id == schoolId);
                    if (findedSchool == null)
                    {
                        throw new Exception("Такой школы не существует");
                    }
                    db.Schools.Remove(findedSchool);
                    db.SaveChanges();
                    return;
                }
            },
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            ["student"] = delegate (Command command, History hist)
            {
                if (command.Arguments.Count == 0 && command.Modificators.Contains("-h"))
                {
                    Console.WriteLine("Список команд:");
                    Console.WriteLine("list");
                    Console.WriteLine("\t-sortn: сотрировка по ФИО");
                    Console.WriteLine("\t-sortyg: сотрировка по году и классу");
                    Console.WriteLine("add <Фамилия> <Имя> <Отчество> <Год обучения> <Класс> <Номер заведения>");
                    Console.WriteLine("delete \"<ФИО>\"");
                    return;
                }
                if (command.Arguments[0] == "list")
                {
                    var students = db.Students.ToList();
                    if (command.Modificators.Contains("-sortn"))
                    {
                        students = Student.SortListByName(students);
                    }
                    if (command.Modificators.Contains("-sortyg"))
                    {
                        students = Student.SortListByYearGroup(students);
                    }
                    Console.WriteLine("Ученики:");
                    foreach (var item in students)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return;
                }
                if (command.Arguments[0] == "add")
                {
                    string lastName = command.Arguments[1];
                    string firstName = command.Arguments[2];
                    string patronymic = command.Arguments[3];
                    int year = int.Parse(command.Arguments[4]);
                    char group = command.Arguments[5][0];
                    int schoolId = int.Parse(command.Arguments[6]);

                    var findedSchool = db.Schools.FirstOrDefault(e => e.Id == schoolId);
                    if (findedSchool == null)
                    {
                        throw new Exception("Такой школы не существует");
                    }
                    string name = $"{lastName} {firstName} {patronymic}";
                    if (db.Students.FirstOrDefault(e =>
                        e.Name == name &&
                        e.Year == year &&
                        e.Group == group &&
                        e.School == findedSchool
                    ) != null)
                    {
                        throw new Exception("Такой ученик уже существует");
                    }
                    var newStudent = new Student(name, year, group, findedSchool);
                    db.Add(newStudent);
                    db.SaveChanges();
                    return;
                }
                if (command.Arguments[0] == "delete")
                {
                    string name = command.Arguments[1];
                    var compareStudent = new Student(name, 'А');
                    var findedStudent = db.Students.ToList().FirstOrDefault(e => e == compareStudent);
                    if (findedStudent == null)
                    {
                        throw new Exception("Такого ученика не существует");
                    }
                    db.Students.Remove(findedStudent);
                    db.SaveChanges();
                    return;
                }
            }
        })
        { }
    }
}