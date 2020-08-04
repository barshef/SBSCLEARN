using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using SBSCLEARN.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SBSCLEARN.Web.Pages
{
    public class NewModel : PageModel
    {
        public string ServiceUrl { get; private set; }

        private readonly AppSettings _appSettings;
        private readonly ILogger<NewModel> _logger;

        public NewModel(IOptions<AppSettings> appSettings, ILogger<NewModel> logger)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public IActionResult OnGet()
        {
            ServiceUrl = _appSettings.ServiceUrl;
            return Page();
        }
    }
}
