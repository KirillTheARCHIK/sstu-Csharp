using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class Teacher
    {
        public Teacher(string name, string subject, School school)
        {
            Name = name;
            Subject = subject;
            School = school;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public School School { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return Name;
        }
    }
}
