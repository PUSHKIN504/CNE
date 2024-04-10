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
    public class PresidenteRepository : IRepository<tbPresidentes>
    {
        public RequestStatus Insert(tbPresidentes item)
        {
            const string sql = "[Gral].[sp_Departamentos_insertar]";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                //parametro.Add("@Dep_Id", item.Dep_Id);
                //parametro.Add("@Dep_Descripcion", item.Dep_Descripcion);
                //parametro.Add("@Dep_UsuarioCreacion", item.Dep_UsuarioCreacion);
                //parametro.Add("@Dep_FechaCreacion", item.Dep_FechaCreacion);


                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbPresidentes> List()
        {
            const string sql = " [Vota].[sp_Presidentes_listar]";

            List<tbPresidentes> result = new List<tbPresidentes>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPresidentes>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }



        public RequestStatus Delete(tbPresidentes item)
        {
            throw new NotImplementedException();
        }

        public tbPresidentes Details(int? id)
        {
            throw new NotImplementedException();
        }



        public tbPresidentes find(int? id)
        {
            throw new NotImplementedException();
        }



        RequestStatus IRepository<tbPresidentes>.Update(tbPresidentes item)
        {
            throw new NotImplementedException();
        }
    }
}
