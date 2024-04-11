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
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        public RequestStatus Insert(tbDepartamentos item)
        {
            const string sql = "[Gral].[sp_Departamentos_insertar]";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Dep_Id", item.Dep_Id);
                parametro.Add("@Dep_Descripcion", item.Dep_Descripcion);
                parametro.Add("@Dep_UsuarioCreacion", item.Dep_UsuarioCreacion);
                parametro.Add("@Dep_FechaCreacion", item.Dep_FechaCreacion);


                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbDepartamentos> List()
        {
            const string sql = "Gral.sp_Departamentos_listar";

            List<tbDepartamentos> result = new List<tbDepartamentos>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbDepartamentos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbDepartamentos List(string id)
        {

            tbDepartamentos result = new tbDepartamentos();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Dep_Id", id);
                result = db.QueryFirst<tbDepartamentos>(ScriptsBaseDeDatos.Depa_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }

        public RequestStatus Delete(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos Details(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(string Dep_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Dep_Id", Dep_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Depa_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }




        public tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbDepartamentos item)
        {


            string sql = ScriptsBaseDeDatos.Depa_Editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Dep_Id", item.Dep_Id);
                parameter.Add("@Dep_Descripcion", item.Dep_Descripcion);
                parameter.Add("@Dep_UsuarioModificacion", item.Dep_UsuarioModificacion);
                parameter.Add("@Dep_FechaModificacion", item.Dep_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }






            //using (var db = new SqlConnection(CNEContext.ConnectionString))
            //{
            //    var parameter = new DynamicParameters();
            //    parameter.Add("Dep_Id", item.Dep_Id);
            //    parameter.Add("Dep_Descripcion", item.Dep_Descripcion);
            //    parameter.Add("Dep_UsuarioModificacion", 1);
            //    parameter.Add("Dep_FechaModificacion", DateTime.Now);

            //    var result = db.QueryFirst(ScriptsBaseDeDatos.Depa_Editar, parameter, commandType: CommandType.StoredProcedure);
            //    return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            //}
        }






        public async Task<IEnumerable<tbDepartamentos>> ObtenerDepto()
        {
            using (var connection = new SqlConnection(CNEContext.ConnectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<tbDepartamentos>("Gral.sp_Departamentos_listar", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
