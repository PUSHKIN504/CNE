using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNE.DataAccess;
using Microsoft.Data.SqlClient;
using CNE.DataAccess.Repository;
using CNE.BusinessLogic.Services;

namespace CNE.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string conn)
        {
            service.AddScoped<DepartamentoRepository>();
            service.AddScoped<VotacionesServices>();
            service.AddScoped<VotoRepository>();
            CNEContext.BuildConnectionString(conn);
            service.AddScoped<EstadoCivilRepository>();
            service.AddScoped<PersonasRepository>();
            service.AddScoped<MunicipioRepository>();
            service.AddScoped<CentroVotacionRepository>();
            service.AddScoped<MesaRepository>();
            service.AddScoped<PantallaRepository>();
            service.AddScoped<DiputadoRepository>();
            service.AddScoped<PartidoRepository>();
            service.AddScoped<AlcaldeRepository>();
            service.AddScoped<PantallaRepository>();
            service.AddScoped<RolRepository>();
            service.AddScoped<UsuarioRepository>();







        }
        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<GeneralServices>();
            service.AddScoped<AccesoServices>();
            service.AddScoped<VotacionesServices>();

        }
    }
}
