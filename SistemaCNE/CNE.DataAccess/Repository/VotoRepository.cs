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
    public class VotoRepository : IRepository<tbVotos>
    {
        public RequestStatus Insert(tbVotos item)
        {
            const string sql = "Vota.sp_Voto_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@Mes_Id", item.Mes_Id);
                parametro.Add("@Pre_Id", item.Pre_Id);
                parametro.Add("@Alc_Id", item.Alc_Id);


                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbVotos> List()
        {
            const string sql = "Gral.sp_Departamentos_listar";

            List<tbVotos> result = new List<tbVotos>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbVotos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }



        public RequestStatus Delete(tbVotos item)
        {
            throw new NotImplementedException();
        }

        public tbVotos Details(int? id)
        {
            throw new NotImplementedException();
        }



        public tbVotos find(int? id)
        {
            throw new NotImplementedException();
        }



        RequestStatus IRepository<tbVotos>.Update(tbVotos item)
        {
            throw new NotImplementedException();
        }
    }
}
