using System;
using System.Collections.Generic;

namespace SBSCLEARN.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            this.ScoreDetails = new List<ScoreDetail>();
        }

        public string CourseName { get; set; }
        public int? CategoryId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public Category Category { get; set; }
        public List<ScoreDetail> ScoreDetails { get; set; }
    }
}
