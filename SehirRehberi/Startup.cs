using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sehir.Common.Helpers;
using Sehir.Core.Infrastructure.Repository;
using Sehir.Core.Infrastructure.Repository.EntityFramework;
using Sehir.Core.Services;
using Sehir.Core.Services.Interfaces;
using Sehir.Domain.Data;

namespace SehirRehberi
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

            services.AddDbContext<SehirContext>(x => x.UseSqlServer("Server=DESKTOP-FI9UVEQ\\MERTCAN;Database=Sehir;Trusted_Connection=True"));
            services.AddHttpContextAccessor();
            services.AddAutoMapper();
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<IEntityRepository, EntityRepositoryBase>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IHttpContextAccessor httpContextAccessor)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            HttpHelper.Configure(httpContextAccessor, Configuration);
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
