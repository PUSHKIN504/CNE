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
        //public RequestStatus Insert(tbPartidos item)
        //{
        //    using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("Par_Nombre", item.Par_Nombre);
        //        parameter.Add("Par_UsuarioCreacion", 1);
        //        parameter.Add("Par_FechaCreacion", item.Par_FechaCreacion);
        //        parameter.Add("Par_ImgUrl", item.Par_ImgUrl);

        //        var result = db.QueryFirst(ScriptsBaseDeDatos.Partido_Insertar, parameter, commandType: CommandType.StoredProcedure);
        //        return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
        //    }
        //}


        public RequestStatus Insert(tbPartidos item)
        {
            const string sql = "[Vota].[sp_Partidos_insertar]";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Par_Nombre", item.Par_Nombre);
                parametro.Add("@Par_UsuarioCreacion ", item.Par_UsuarioCreacion);
                parametro.Add("@Par_FechaCreacion", item.Par_FechaCreacion);
                parametro.Add("@Par_ImgUrl", item.Par_ImgUrl);



                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

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
            tbPartidos result = new tbPartidos();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Par_id", id);
                result = db.QueryFirst<tbPartidos>(ScriptsBaseDeDatos.Partido_Lenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }


        }




        public RequestStatus Delete(int Par_id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Par_id", Par_id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Partido_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }



        public RequestStatus Update(tbPartidos item)
        {


            string sql = ScriptsBaseDeDatos.Diputado_editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Par_id", item.Par_id);
                parameter.Add("@Par_Nombre", item.Par_Nombre);

                parameter.Add("@Par_ImgUrl", item.Par_ImgUrl);
                parameter.Add("@Par_UsuarioModificacion ", item.Par_UsuarioModificacion);
                parameter.Add("@Par_FechaModificacion ", item.Par_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }




        public tbPartidos Details(int id)
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



   
    }
}
