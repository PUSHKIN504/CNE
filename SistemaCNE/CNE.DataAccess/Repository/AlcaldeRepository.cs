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
            const string sql = "Vota.sp_Alcaldes_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Alc_Id", item.Alc_Id);

                parametro.Add("@Alc_ImgUrl", item.Alc_ImgUrl);
                parametro.Add("@Alc_UsuarioCreacion ", 1);
                parametro.Add("@Alc_FechaCreacion", item.Alc_FechaCreacion);
                parametro.Add("@Par_id", item.Par_id);



                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

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
            tbAlcaldes result = new tbAlcaldes();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Alc_Id", id);
                result = db.QueryFirst<tbAlcaldes>(ScriptsBaseDeDatos.Alcalde_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }


        }




        public RequestStatus Delete(int Alc_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Alc_Id", Alc_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Alcalde_eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }




        public tbAlcaldes Details(int id)
        {
            throw new NotImplementedException();
        }


        public RequestStatus Update(tbAlcaldes item)
        {


            string sql = ScriptsBaseDeDatos.Alcalde_editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Alc_Id", item.Alc_Id);
                parameter.Add("@Alc_ImgUrl", item.Alc_ImgUrl);
                parameter.Add("@Alc_UsuarioModificacion ", item.Alc_UsuarioModificacion);
                parameter.Add("@Alc_FechaModificacion ", item.Alc_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }

            public RequestStatus Delete(tbAlcaldes item)
        {
            throw new NotImplementedException();
        }


        public tbAlcaldes find(int? id)
        {
            throw new NotImplementedException();
        }



      
    }
}
