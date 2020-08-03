using System.ComponentModel.DataAnnotations;

namespace SBSCLEARN.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
