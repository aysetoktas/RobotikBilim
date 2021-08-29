using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Document:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
