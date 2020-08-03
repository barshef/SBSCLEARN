using System;
using System.Collections.Generic;
using System.Text;

namespace SBSCLEARN.Infrastructure.ViewModel
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? CategoryId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
