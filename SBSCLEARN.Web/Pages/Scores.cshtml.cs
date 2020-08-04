using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SBSCLEARN.Web.Models;

namespace SBSCLEARN.Web.Pages
{
    public class ScoresModel : PageModel
    {
        public string ServiceUrl { get; private set; }

        private readonly AppSettings _appSettings;
        private readonly ILogger<ScoresModel> _logger;

        public ScoresModel(IOptions<AppSettings> appSettings, ILogger<ScoresModel> logger)
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
