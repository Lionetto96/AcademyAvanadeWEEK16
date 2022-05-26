using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.EF;
using AgenziaConsulenzaAMM.EF.Repositories;
using AgenziaConsulenzaAMM.MOCK.ReposotoriesMock;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MVC
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
            services.AddControllersWithViews();
            services.AddScoped<IBusinessLayer, MainBusinessLayer>();

            //Registrazione delle dipendenze con EF
            services.AddScoped<IRepositoryDipendente, EFRepositoryDipendente>();
            services.AddScoped<IRepositoryTimesheet, EFRepositoryTimesheet>();
            services.AddScoped<IRepositoryCliente, EFRepositoryCliente>();
            services.AddScoped<IRepositoryAttivita, EFRepositoryAttivita>();
            services.AddScoped<IRepositoryCommesse, EFRepositoryCommessa>();
            services.AddScoped<IRepositoryUser, EFRepositoryUser>();

            //Registrazione delle dipendenze con Mock
            //services.AddScoped<IRepositoryDipendente, MockRepositoryDipendente>();
            //services.AddScoped<IRepositoryTimesheet, MockRepositoryTimesheet>();
            //services.AddScoped<IRepositoryCliente, MockRepositoryCliente>();
            //services.AddScoped<IRepositoryAttivita, MockRepositoryAttivita>();
            //services.AddScoped<IRepositoryCommesse, MockRepositoryCommessa>();
            //services.AddScoped<IRepositoryUser, MockRepositoryUser>();

            services.AddDbContext<AgenziaDBContext>(
                //Connection string impostata in appsetting
                options => options.UseSqlServer(Configuration.GetConnectionString("AgenziaConsulenzaAMM"))

                );
            services.AddAuthorization(options => {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = new PathString("/Users/Login");
                   options.AccessDeniedPath = new PathString("/Users/Forbidden");
               });

            services.AddScoped<AgenziaDBContext>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgenziaConsulenzaAMM.MVC v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
