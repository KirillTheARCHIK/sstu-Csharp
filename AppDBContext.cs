using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class AppDBContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public AppDBContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=studentsDB.db");
        }

        public static AppDBContext db = new AppDBContext();
    }
}
