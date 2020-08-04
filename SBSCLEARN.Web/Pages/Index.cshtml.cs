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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppSettings _appSettings;

        public string ServiceUrl { get; private set; }

        public IndexModel(IOptions<AppSettings> appSettings, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public void OnGet()
        {
            ServiceUrl = _appSettings.ServiceUrl;
        }

        public IActionResult OnGetNew()
        {
            //var filename = "OgunMonthlyReturnsTemplate.xlsx";
            //if (filename == null)
            //    return Content("filename not present");

            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TemplateFolders", filename);

            //var memory = new MemoryStream();
            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;
            //return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(path));
            return RedirectToPage("./New");
        }
    }
}
