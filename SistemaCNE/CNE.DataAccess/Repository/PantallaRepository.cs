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
    public class PantallaRepository
    {
        public RequestStatus Insert(tbPantallas item)
        {
            throw new NotImplementedException();


        }

        public IEnumerable<tbPantallas> List()
        {
            const string sql = "Acce.sp_Pantallas_listar";

            List<tbPantallas> result = new List<tbPantallas>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPantallas>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbPantallas List(int id)
        {
            throw new NotImplementedException();


        }



        public tbPantallas Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Pan_Id)
        {
            throw new NotImplementedException();


        }

        public RequestStatus Delete(tbPantallas item)
        {
            throw new NotImplementedException();
        }


        public tbPantallas find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbPantallas item)
        {


            throw new NotImplementedException();






        }
    }
}
