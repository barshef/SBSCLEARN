using System;
using System.Collections.Generic;

namespace SBSCLEARN.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Courses = new List<Course>();
        }

        public string CategoryName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public List<Course> Courses { get; set; }
    }
}
