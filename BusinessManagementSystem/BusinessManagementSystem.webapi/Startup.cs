using BusinessManagementSystem.Bll;
using BusinessManagementSystem.Dal.Abstract;
using BusinessManagementSystem.Dal.Concrete.EntityFramework.Context;
using BusinessManagementSystem.Dal.Concrete.EntityFramework.Repository;
using BusinessManagementSystem.Dal.Concrete.EntityFramework.UnitOfWork;
using BusinessManagementSystem.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.webapi
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
            #region JwtTokenService
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Tokens : Issuer"],
                        ValidAudience = Configuration["Tokens : Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token : Key"])),
                        RequireSignedTokens=true,
                        RequireExpirationTime=true
                    
                    };
                });
            #endregion

            #region ApplicationContext
            services.AddDbContext<BusinessManagementSystemContext>();
            services.AddScoped<DbContext, BusinessManagementSystemContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IBusinessService, BusinessManager>();
            services.AddScoped<IRequestService, RequestManager>();
            //service >> manager
            #endregion

            #region RepositorySection
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            //Irepository >> repository
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessManagementSystem.webapi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
