using AutoMapper;
using CleanArchitecture.Application.AutoMapperProfiles;
using CleanArchitecture.Application.UseCases.EmployeeUseCases;
using CleanArchitecture.Data;
using CleanArchitecture.Data.Repositories;
using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace CleanArchitecture.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime, use it to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeesSalariesApi", Version = "v1" });
            })
            .AddSingleton<IMongoDatabase>(x => new MongoDbFactory(Configuration).GetDatabase())
            .AddAutoMapper(typeof(EmployeeProfile).Assembly)
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IGetEmployeesUseCase, GetEmployeesUseCase>()
            .AddScoped<IRegisterEmployeeUseCase, RegisterEmployeeUseCase>()
            .AddScoped<IRaiseEmployeeSalaryUseCase, RaiseEmployeeSalaryUseCase>();
        }

        // This method gets called by the runtime, use it to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeesSalariesApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
