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
   public class UsuarioRepository
    {
        //public RequestStatus Insert(tbUsuarios item)
        //{
        //    const string sql = "Acce.sp_Usuarios_insertar";



        //    using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    {
        //        var parametro = new DynamicParameters();
        //        parametro.Add("@EsC_Descripcion", item.EsC_Descripcion);
        //        parametro.Add("@EsC_UsuarioCreacion ", item.EsC_UsuarioCreacion);
        //        parametro.Add("@EsC_FechaCreacion", item.EsC_FechaCreacion);
            


        //        var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
        //        string mensaje = (result == 1) ? "Exito" : "Error";
        //        return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        //    }

        //}

        public IEnumerable<tbUsuarios> List()
        {
            const string sql = "Acce.sp_Usuarios_listar";

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbUsuarios>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }





        public IEnumerable<tbUsuarios> Login(string Usuario, string Contra)
        {
            string sql = ScriptsBaseDeDatos.Usua_Login;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameters = new { @Usuario = Usuario, @Contra = Contra };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbUsuarios> ValidarUsuario(string Usuario)
        {
            string sql = ScriptsBaseDeDatos.Usua_usuario;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameters = new { @Usuario = Usuario };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbUsuarios> ValidarClave(string Contra)
        {
            string sql = ScriptsBaseDeDatos.Usua_clave;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameters = new { @Contra = Contra };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }






        //public tbUsuarios List(int id)
        //{

        //    tbUsuarios result = new tbUsuarios();
        //    using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("Usu",id);
        //        result = db.QueryFirst<tbUsuarios>(ScriptsBaseDeDatos.EstadoCivil_Llenar, parameter, commandType: CommandType.StoredProcedure);
        //        return result;
        //    }

        //}



        public tbUsuarios Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int EsC_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("EsC_Id", EsC_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.EstadoCivil_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

  public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }


        public tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }




        //public IEnumerable<tbUsuarios> Login(string Usua_Usuario, string Usua_Clave)
        //{
        //    const string sql = "Acce.sp_inicio_sesion2";
        //    List<tbUsuarios> result = new List<tbUsuarios>();
        //    using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    {
        //        result = db.Query<tbUsuarios>(sql, new { Usua_Usuario = Usua_Usuario, Usua_Clave = Usua_Clave }, commandType: CommandType.StoredProcedure).ToList();
        //        return result;
        //    }
        //}


        //public RequestStatus Update(tbUsuarios item)
        //{


        //    string sql = ScriptsBaseDeDatos.EstadoCivil_Editar;

        //    using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@EsC_Id", item.EsC_Id);
        //        parameter.Add("@EsC_Descripcion", item.EsC_Descripcion);
        //        parameter.Add("@EsC_UsuarioModificacion ", item.EsC_UsuarioModificacion);
        //        parameter.Add("@EsC_FechaModificacion ", item.EsC_FechaModificacion);

        //        var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
        //        string mensaje = (result == 1) ? "exito" : "error";
        //        return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

        //    }


        //}
    }
}
