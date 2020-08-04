using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBSCLEARN.Dtos
{
    public class CreateCourseParameters
    {
        public int? CategoryId { get; set; }
        public string CourseName { get; set; }
    }
}
