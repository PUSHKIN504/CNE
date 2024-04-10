using FrontendCNE.Models;
using FrontendCNE.Services;
using FrontendCNE.WebAPI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE
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
        {services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<API>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddControllersWithViews();
            services.AddScoped<DepartamentoService>();
            services.AddScoped<VotacionesService>();
            services.AddScoped<PresidenteService>();
            services.AddScoped<EstadoCivilServices>();
            services.AddScoped<RolService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<MunicipioService>();
            services.AddScoped<PersonasServices>();
            services.AddScoped<AlcaldeService>();
            services.AddScoped<CentroVotacionService>();
            services.AddScoped<DiputadoService>();
            services.AddScoped<PartidoService>();
            services.AddScoped<MesaService>();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(option =>
{
    option.LoginPath = "/Home/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    option.AccessDeniedPath = "/Home/AccessDenied";
});

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".MySession";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
