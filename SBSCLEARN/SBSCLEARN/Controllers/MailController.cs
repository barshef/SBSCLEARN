﻿using Microsoft.AspNetCore.Mvc;
using SBSCLEARN.Domain;
using SBSCLEARN.Service.Contract;
using System.Threading.Tasks;

namespace SBSCLEARN.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Mail")]
    [ApiVersion("1.0")]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }

    }
}