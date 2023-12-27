using Microsoft.EntityFrameworkCore;
using SchoolDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class SchoolDBContext : DbContext
    {
        public DbSet<SchoolType> SchoolTypes => Set<SchoolType>();
        public DbSet<School> Schools => Set<School>();
        public DbSet<Student> Students => Set<Student>();
        public SchoolDBContext(bool drop = false)
        {
            if (drop)
            {
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=studentsDB.db");
        }
    }
}
