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
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {

        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCategoriesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categoriesList = await _context.Categories.ToListAsync();
                if (categoriesList == null)
                {
                    return null;
                }
                return categoriesList.AsReadOnly();
            }
        }
    }
}
