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
    public class PartidoRepository
    {
        public RequestStatus Insert(tbPartidos item)
        {
            throw new NotImplementedException();


        }

        public IEnumerable<tbPartidos> List()
        {
            const string sql = "Vota.sp_Partidos_listar";

            List<tbPartidos> result = new List<tbPartidos>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPartidos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbPartidos List(int id)
        {
            throw new NotImplementedException();


        }



        public tbPartidos Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Pan_Id)
        {
            throw new NotImplementedException();


        }

        public RequestStatus Delete(tbPartidos item)
        {
            throw new NotImplementedException();
        }


        public tbPartidos find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbPartidos item)
        {


            throw new NotImplementedException();






        }
    }
}
