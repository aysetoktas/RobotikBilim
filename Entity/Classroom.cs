﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Classroom:BaseEntity
    {
        public string Name { get; set; }

        //İlişkiler
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
