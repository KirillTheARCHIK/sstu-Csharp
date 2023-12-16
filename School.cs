using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class SchoolType
    {
        public SchoolType(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<School> Schools { get; set; } = new List<School>();
        public static List<SchoolType> Mock() => new List<SchoolType> { 
            new SchoolType("Школа"),
            new SchoolType("Лицей"),
            new SchoolType("Гимназия"),
        };
    }
    class School
    {
        public School(int number, string city, SchoolType schoolType)
        {
            Number = number;
            City = city;
            SchoolType = schoolType;
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public SchoolType SchoolType { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
