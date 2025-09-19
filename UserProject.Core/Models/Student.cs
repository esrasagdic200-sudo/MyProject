using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProject.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }

        public int? CourseId { get; set; }    // opsiyonel ilişki için nullable
        public Course Course { get; set; }


    }
}
