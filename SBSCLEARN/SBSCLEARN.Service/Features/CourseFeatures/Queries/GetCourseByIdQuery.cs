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
    public class GetCourseByIdQuery : IRequest<List<Course>>
    {
        public int Id { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, List<Course>>
        {
            private readonly IApplicationDbContext _context;
            public GetCourseByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<List<Course>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
            {
                var course = _context.Courses.Where(a => a.CategoryId == request.Id).ToListAsync();
                if (course == null) return null;
                return course;
            }
        }
    }
}
