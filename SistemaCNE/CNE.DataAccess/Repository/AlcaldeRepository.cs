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
    public class AlcaldeRepository
    {
        public RequestStatus Insert(tbAlcaldes item)
        {
            throw new NotImplementedException();


        }

        public IEnumerable<tbAlcaldes> List()
        {
            const string sql = "Vota.sp_Alcaldes_listar";

            List<tbAlcaldes> result = new List<tbAlcaldes>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbAlcaldes>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbAlcaldes List(int id)
        {
            throw new NotImplementedException();


        }



        public tbAlcaldes Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Pan_Id)
        {
            throw new NotImplementedException();


        }

        public RequestStatus Delete(tbAlcaldes item)
        {
            throw new NotImplementedException();
        }


        public tbAlcaldes find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbAlcaldes item)
        {


            throw new NotImplementedException();






        }
    }
}
