using StudentsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    class SchoolType
    {
        public SchoolType() { }
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
        public override string ToString()
        {
            return $"{Id}; {Name}";
        }
    }
}
