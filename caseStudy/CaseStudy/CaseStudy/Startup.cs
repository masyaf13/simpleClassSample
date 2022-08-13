using CaseStudy.Context;
using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Base;
using CaseStudy.RepositoryPattern.Concrete;
using CaseStudy.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Startup
    {
        readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Mssql"]));
            services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
            services.AddScoped<IRepository<ClassRoom>, Repository<ClassRoom>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "Management",
                     pattern: "{area:exists}/{controller=Student}/{action=StudentList}/");


                 endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

             });

        }
    }
}
