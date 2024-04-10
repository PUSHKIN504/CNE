using CNE.BusinessLogic.Services;
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
  
        public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> List()
        {
            string sql = ScriptsBaseDeDatos.Empleados_Listar;

            List<tbEmpleados> result = new List<tbEmpleados>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbEmpleados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }

        }


        public RequestStatus Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}
