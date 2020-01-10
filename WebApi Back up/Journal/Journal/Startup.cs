using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Journal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Journal
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JournalContext>();
            services.AddScoped<IJournalRepository, JournalRepository>();

            services.AddAutoMapper();
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 1);
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new HeaderApiVersionReader("JVersion");
                /*opt.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("X-Version"),
                                                                new QueryStringApiVersionReader("Ver", "Version"));*/
            });

            services.AddMvc(opt => opt.EnableEndpointRouting = false);

            services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    //internal interface IJournalRepository
    //{
    //}
}
