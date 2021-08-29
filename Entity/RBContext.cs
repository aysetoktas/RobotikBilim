using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RBContext:DbContext
    {
        public RBContext():base("RBDatabase")
        {
            Database.Connection.ConnectionString = "server=.;database=RobotikBilim;Integrated Security=true";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
