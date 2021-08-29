using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Query
    {
        private static RBContext db = new RBContext();

        public static List<User> UserList()
        {
            return db.Users.AsNoTracking().ToList();
        }

        public static List<Education> EducationList()
        {
            return db.Educations.AsNoTracking().ToList();
        }

        public static List<Classroom> ClassroomList()
        {
            return db.Classrooms.AsNoTracking().ToList();
        }

        public static List<Lesson> LessonList()
        {
            return db.Lessons.AsNoTracking().ToList();
        }
        public static List<Level> LevelList()
        {
            return db.Levels.AsNoTracking().ToList();
        }
        public static List<Admin> AdminList()
        {
            return db.Admins.AsNoTracking().ToList();
        }
        public static List<Teacher> TeacherList()
        {
            return db.Teachers.AsNoTracking().ToList();
        }
        public static List<Student> StudentList()
        {
            return db.Students.AsNoTracking().ToList();
        }
        public static List<Category> CategoryList()
        {
            return db.Categories.AsNoTracking().ToList();
        }
        public static List<Document> DocumentList()
        {
            return db.Documents.AsNoTracking().ToList();
        }
    }
}
