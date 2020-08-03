using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SBSCLEARN.Service.Features.CourseFeatures.Commands;
//using SBSCLEARN.Service.Features.CourseFeatures.Queries;
using System.Threading.Tasks;

namespace SBSCLEARN.Controllers
{
    [Route("api/Course")]
    //[Route("api/v{version:apiVersion}/Customer")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
