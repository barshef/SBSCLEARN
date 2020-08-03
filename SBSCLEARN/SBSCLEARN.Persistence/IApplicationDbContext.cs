using Microsoft.EntityFrameworkCore;
using SBSCLEARN.Domain.Entities;
using System.Threading.Tasks;

namespace SBSCLEARN.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Course> Courses { get; set; }
        //DbSet<ScoreDetail> ScoreDetails { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
