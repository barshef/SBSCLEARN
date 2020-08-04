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
    public class GetUserScoresByIdQuery : IRequest<List<ScoreDetail>>
    {
        public int Id { get; set; }
        public class GetUserScoresByIdQueryHandler : IRequestHandler<GetUserScoresByIdQuery, List<ScoreDetail>>
        {
            private readonly IApplicationDbContext _context;
            public GetUserScoresByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<List<ScoreDetail>> Handle(GetUserScoresByIdQuery request, CancellationToken cancellationToken)
            {
                var scoreDetails = _context.ScoreDetails.Where(a => a.CourseId == request.Id).ToListAsync();

                //var maxAge = _context.Courses.Max(c => c.ScoreDetails.FirstOrDefault().Score);

                //var robotDogs = _context.Courses.GroupBy(x => x.CourseName).Select(g => new { Name = g.Key, Guns = g.Sum(x => x.ScoreDetails.FirstOrDefault().Score) });
                //int maxAge = (int)_context.Courses.Select(p => p.ScoreDetails.FirstOrDefault().Score).DefaultIfEmpty(0).Max();
                //var robotDog = from d in _context.Courses
                //               join f in _context.RobotFactories
                //                on d.RobotFactoryId equals f.RobotFactoryId
                //                select new { f.Location, d.RobotDogId } into x
                //                group x by new { x.Location } into g
                //                select new
                //                {
                //                    Location = g.Key.Location,
                //                    Guns = g.Select(x => x.RobotDogId).Max()
                //                };
                if (scoreDetails == null) return null;
                //return course.AsReadOnly();
                return scoreDetails;
            }
        }
    }
}
