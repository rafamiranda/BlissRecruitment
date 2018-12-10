using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlissRecruitment.Managers;
using BlissRecruitment.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.HealthChecks;
using Microsoft.AspNetCore.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BlissRecruitment.DataAccess;

namespace BlissRecruitment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSingleton(Configuration);
            services.AddDbContext<BlissRecruitmentDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("BlissRecruitmentDatabase")));
            services.AddTransient<IQuestionsProvider, QuestionsProvider>();
            services.AddTransient<IQuestionsManager, QuestionsManager>();
            services.AddTransient<IShareProvider, ShareProvider>();
            services.AddTransient<IShareManager, ShareManager>();
            services.AddLogging();
            services.AddHealthChecks(checks =>
            {
                checks.AddValueTaskCheck("HTTP Endpoint", () => new
                    ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);
            loggerFactory.AddEventSourceLogger();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
