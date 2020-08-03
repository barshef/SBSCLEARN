using System;
using System.Collections.Generic;

namespace SBSCLEARN.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.ScoreDetails = new List<ScoreDetail>();
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public List<ScoreDetail> ScoreDetails { get; set; }
    }
}
