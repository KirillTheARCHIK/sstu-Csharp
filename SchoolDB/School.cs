using SchoolDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class School
    {
        public School() { }
        public School(int number, string city, SchoolType schoolType)
        {
            Number = number;
            City = city;
            SchoolType = schoolType;
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public int SchoolTypeId { get; set; }
        [ForeignKey("SchoolTypeId")]
        public virtual SchoolType SchoolType { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public override string ToString()
        {
            return $"{Id}; г. {City}; {SchoolType.Name} №{Number}";
        }
    }
}
