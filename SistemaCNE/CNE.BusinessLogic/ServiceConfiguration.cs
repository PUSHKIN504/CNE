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
            service.AddScoped<AlcaldesRepository>();
            service.AddScoped<DiputadoRepository>();
            CNEContext.BuildConnectionString(conn);
        }
        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<GeneralServices>();
        }
    }
}
