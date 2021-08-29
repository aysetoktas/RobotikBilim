using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Education:BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string ImagePath { get; set; }
        public int Hour { get; set; }

        //İlişkiler
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

    }
}
