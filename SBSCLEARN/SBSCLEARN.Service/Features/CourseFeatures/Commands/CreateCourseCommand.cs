using MediatR;
using SBSCLEARN.Domain.Entities;
using SBSCLEARN.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SBSCLEARN.Service.Features.CourseFeatures.Commands
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string CourseName { get; set; }
        public int? CategoryId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        //public Category Category { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCourseCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseName = request.CourseName,
                    CategoryId = request.CategoryId,  //Fix this later.
                    FileName = request.FileName,
                    FilePath = request.FilePath,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "System Admin"
                };

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return course.Id;
            }
        }

    }
}
