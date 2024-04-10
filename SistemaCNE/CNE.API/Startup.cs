using CNE.API.Extensions;
using CNE.BusinessLogic;
using CNE.DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNE.API
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
            services.DataAccess(Configuration.GetConnectionString("CNEConn"));
            services.BusinessLogic();
            services.AddAutoMapper(x => x.AddProfile<MappingProfileExtensions>(), AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpContextAccessor();
            services.AddScoped<PersonasRepository>();
            services.AddScoped<PresidenteRepository>();
            services.AddScoped<VotoRepository>();
            services.AddScoped<EstadoCivilRepository>();
            services.AddScoped<MunicipioRepository>();
            services.AddScoped<CentroVotacionRepository>();
            services.AddScoped<MesaRepository>();
            services.AddScoped<PantallaRepository>();
            services.AddScoped<RolRepository>();
            services.AddScoped<DiputadoRepository>();
            services.AddScoped<AlcaldeRepository>();
            services.AddScoped<PartidoRepository>();
            services.AddScoped<UsuarioRepository>();













            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CNE.API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                  builder =>
                  {
                      builder.WithOrigins(/*""*/)/*http://localhost:44334*/
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin();
                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CNE.API v1"));
            }
            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
