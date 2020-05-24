using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using projet.Models;
using projet.Services;

namespace projet
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
            //services.AddTransient<RepositoryEnseignant, EnseignantServices>();
            services.AddScoped<RepositoryEnseignant, EnseignantServices>();
            services.AddSingleton<IFileProvider>(
           new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddMvc();
            services.AddDbContext<PrjContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStr")));
            
            services.AddDbContext<PrjContext>(options => options.UseInMemoryDatabase("PrjContext"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0).AddJsonOptions(options => { // For Maintaining Json Format
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
            //services.AddTransient<IEtudiantService, EtudiantServiceImpl>();
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddScoped<RepositoryModule, ModuleService>();
            /*Add jwt auth*/
            System.Diagnostics.Debug.WriteLine(Configuration["Jwt:Key"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                var signingKey = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.Use(async (context, next) => {
                var jwtToken = context.Request.Cookies["jwttoken"];
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + jwtToken);
                    System.Diagnostics.Debug.WriteLine(context.Request.Headers.ToString());
                    System.Diagnostics.Debug.WriteLine(context.Request.Headers.ToString());
                    System.Diagnostics.Debug.WriteLine("Middlware  :  " + context.Request.Headers["Authorization"]);
                }
                await next();
            });
            app.UseAuthentication();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
