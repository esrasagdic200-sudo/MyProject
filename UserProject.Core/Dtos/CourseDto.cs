using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProject.Core.Dtos
{
    public class CourseDto
    {
        public string CourseName { get; set; }

        public int InstructorId { get; set; }

        public List<int> StudentIds { get; set; }
    }
}
