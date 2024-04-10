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
    public class DiputadoRepository
    {
        public RequestStatus Insert(tbDiputados item)
        {
            throw new NotImplementedException();


        }

        public IEnumerable<tbDiputados> List()
        {
            const string sql = "Vota.sp_Diputados_listar";

            List<tbDiputados> result = new List<tbDiputados>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbDiputados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbDiputados List(int id)
        {
            throw new NotImplementedException();


        }



        public tbDiputados Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Pan_Id)
        {
            throw new NotImplementedException();


        }

        public RequestStatus Delete(tbDiputados item)
        {
            throw new NotImplementedException();
        }


        public tbDiputados find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbDiputados item)
        {


            throw new NotImplementedException();






        }
    }
}
