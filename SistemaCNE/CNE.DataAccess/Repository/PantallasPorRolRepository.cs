using CNE.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.DataAccess.Repository
{
   public class PantallasPorRolRepository
    {

        public IEnumerable<tbPantallasPorRoles> List()
        {
            const string sql = "Acce.sp_PantallasPorRol_listar";

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPantallasPorRoles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

    }
}
