using MediatR;
using Microsoft.EntityFrameworkCore;
using SBSCLEARN.Domain.Entities;
using SBSCLEARN.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SBSCLEARN.Service.Features.CourseFeatures.Queries
{
    public class GetUserScoresByIdQuery : IRequest<List<CategoryScore>>
    {
        public int Id { get; set; }
        public class GetUserScoresByIdQueryHandler : IRequestHandler<GetUserScoresByIdQuery, List<CategoryScore>>
        {
            private readonly IApplicationDbContext _context;
            public GetUserScoresByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<CategoryScore>> Handle(GetUserScoresByIdQuery request, CancellationToken cancellationToken)
            {
                
                var query = await (from s in _context.ScoreDetails
                                   join c in _context.Courses on s.CourseId equals c.Id
                                   join ct in _context.Categories on c.CategoryId equals ct.Id
                                   join u in _context.Users on s.UserId equals u.Id
                                   group s by new { ct.CategoryName, ct.Id } into g
                                   select new CategoryScore
                                   {
                                       CategoryName = g.Key.CategoryName,
                                       CategoryId = g.Key.Id,
                                       //User = g.Select(x => new { x.Score, x.User }).OrderByDescending(x => x.Score).FirstOrDefault().User.UserName,
                                       MaxScore = g.Max(x => x.Score)
                                   }).ToListAsync();

                if (query == null) return null;
                return query;
            }
        }


    }

    public class CategoryScore
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string User { get; set; }
        public long? MaxScore { get; set; }
    }
}
