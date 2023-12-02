using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDB
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            AppDBContext.db.Students.RemoveRange(AppDBContext.db.Students.Where((Student s) => true));
            AppDBContext.db.Students.AddRange(Student.MockStudents);
            AppDBContext.db.SaveChanges();
            students = AppDBContext.db.Students.ToList();
            dataGridView1.DataSource = students;
        }

        private void StudentDeleteButton_Click(object sender, EventArgs e)
        {
            var studentName = NameTextBox.Text;
            var studentToFind = new Student(studentName, 'А');
            foreach (var item in AppDBContext.db.Students.ToList())
            {
                Console.WriteLine(item);
            }
            var findedStudent = AppDBContext.db.Students.FirstOrDefault(s => s == studentToFind);
            if (findedStudent==null)
            {
                MessageBox.Show("Студент с таким ФИО не найден");
            }
            AppDBContext.db.Students.Remove(findedStudent);
            AppDBContext.db.SaveChanges();
            students = AppDBContext.db.Students.ToList();
            dataGridView1.DataSource = students;
        }

        private void SortByNameButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Student.SortListByName(students);
        }

        private void SortByYearButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Student.SortListByYearGroup(students);
        }
    }
}
