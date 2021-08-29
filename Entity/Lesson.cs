using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Lesson:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Logo { get; set; }
        public string Path { get; set; }

        //İlişkiler
        public int? EducationID { get; set; }
        public virtual Education Education { get; set; }
        public int LevelID { get; set; }
        public virtual Level Level { get; set; }
    }
}
