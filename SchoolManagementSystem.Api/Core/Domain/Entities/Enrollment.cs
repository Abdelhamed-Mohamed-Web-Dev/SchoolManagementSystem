using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
  
    public class Enrollment : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = new Student();

        public int ClassId { get; set; }
        public Class Class { get; set; } = new Class();
    }

}
