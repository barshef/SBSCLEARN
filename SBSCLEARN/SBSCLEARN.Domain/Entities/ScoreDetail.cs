using System;
using System.Collections.Generic;
using System.Text;

namespace SBSCLEARN.Domain.Entities
{
    public class ScoreDetail : BaseEntity
    {
        public int? CourseId { get; set; }
        public long? Score { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
}
