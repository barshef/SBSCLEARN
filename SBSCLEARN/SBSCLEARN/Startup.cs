using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SBSCLEARN.Infrastructure.Attributes;
using SBSCLEARN.Infrastructure.Extension;
using SBSCLEARN.Service;
using Serilog;
using System.IO;

namespace SBSCLEARN
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext(Configuration, configRoot);

            services.AddAutoMapper();

            services.AddAddScopedServices();

            services.AddTransientServices();

            services.AddSwaggerOpenAPI();

            services.AddMailSetting(Configuration);

            services.AddMediatorCQRS();

            services.AddVersion();

            services.AddMvc(options => options.Filters.Add(typeof(ValidationFilterAttribute)));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.ConfigureSwagger();

            log.AddSerilog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
