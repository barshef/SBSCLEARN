using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SBSCLEARN.Domain.Entities;
using SBSCLEARN.Dtos;
using SBSCLEARN.Helpers;
using SBSCLEARN.Infrastructure.Attributes;
using SBSCLEARN.Service.Features.CourseFeatures.Commands;
using SBSCLEARN.Service.Features.CourseFeatures.Queries;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SBSCLEARN.Controllers
{
    [Route("api/Course")]
    [ApiController]
    [ApiVersion("1.0")]
    [ValidationFilter]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createCourse")]
        public async Task<IActionResult> CreateCourse()
        {
            var bc = new MessageClass();
            IFormFile file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "AttachedFiles");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var sentHeaders = HttpContext.Request.Headers["createCourseParameters"].ToString();
                var sentHeadersDesirialized = JsonConvert.DeserializeObject<CreateCourseParameters>(sentHeaders);

                var tempFilename = $"{sentHeadersDesirialized.CourseName.ObjectToString()}.{file.FileName}";
                string fullPath = Path.Combine(pathToSave, tempFilename);

                var command = new CreateCourseCommand
                {
                    CourseName = sentHeadersDesirialized.CourseName,
                    CategoryId = sentHeadersDesirialized.CategoryId,  
                    FileName = tempFilename,
                    FilePath = fullPath
                };
                var results = await _mediator.Send(command);
                if(results <= 0)
                {
                    bc.StatusId = -1;
                    bc.StatusMessage = "Unable to create course; Record Already Exist!.";
                    return Ok(bc);
                }

                bc.StatusId = 1;
                bc.StatusMessage = "Course Created Successfully!.";
                using var stream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(stream);
                return Ok(bc);
                //return Ok(await _mediator.Send(command));
            }
            else
            {
                bc.StatusId = -1;
                bc.StatusMessage = "Unable to create course; Bad Input Detected!.";
                return Ok(bc);
            }
        }

        [HttpGet("getCourseByCategoryId")]
        public async Task<IActionResult> GetCourseByCategoryId(DataSourceLoadOptions loadOptions, int categoryId)
        {
            var result = await _mediator.Send(new GetCourseByIdQuery { Id = categoryId });
            loadOptions.PrimaryKey = new[] { "Id" };
            return Ok(DataSourceLoader.Load(result, loadOptions));
        }

        [HttpGet("getUserScoreBycourseId")]
        public async Task<IActionResult> GetUserScoreBycourseId(DataSourceLoadOptions loadOptions, int courseId)
        {
            var result = await _mediator.Send(new GetUserScoresByIdQuery { Id = courseId });
            loadOptions.PrimaryKey = new[] { "CategoryId" };
            return Ok(DataSourceLoader.Load(result, loadOptions));
        }

        [HttpGet("getAllCategories")]
        public async Task<IActionResult> GetAllCategories(DataSourceLoadOptions loadOptions)
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            loadOptions.PrimaryKey = new[] { "Id" };
            return Ok(DataSourceLoader.Load(result, loadOptions));
        }
    }
}
