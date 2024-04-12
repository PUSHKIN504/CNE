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
    public class PersonasRepository : IRepository<tbPersonas>
    {
        public RequestStatus Insert(tbPersonas item)
        {

            const string sql = "Gral.sp_Personas_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Per_CedulaIdentidad", item.Per_CedulaIdentidad);
                parametro.Add("@Per_Nombre ", item.Per_Nombre);
                parametro.Add("@Per_Apellido", item.Per_Apellido);
                parametro.Add("@Per_FechaNacimiento", item.Per_FechaNacimiento);
                parametro.Add("@Per_Sexo", item.Per_Sexo);
                parametro.Add("@Per_Direccion", item.Per_Direccion);
                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@Per_Telefono", item.Per_Telefono);
                parametro.Add("@Per_UsuarioCreacion", item.Per_UsuarioCreacion);
                parametro.Add("@Per_FechaCreacion", item.Per_FechaCreacion);
                parametro.Add("@EsC_Id", item.EsC_Id);
                parametro.Add("@Mes_Id", item.Mes_Id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbPersonas> List()
        {
            const string sql = "Gral.sp_Personas_listar";

            List<tbPersonas> result = new List<tbPersonas>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPersonas>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbPersonas VotoVerf(string  DNI)
        {
            tbPersonas result = new tbPersonas();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Per_CedulaIdentidad", DNI);
                result = db.QueryFirst<tbPersonas>(ScriptsBaseDeDatos.ObtenerYaVoto, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }


        public tbPersonas List(int id)
        {

            tbPersonas result = new tbPersonas();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Per_Id", id);
                result = db.QueryFirst<tbPersonas>(ScriptsBaseDeDatos.personas_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }


        public RequestStatus Delete(int Per_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Per_Id", Per_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.personas_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

        public RequestStatus Delete(tbPersonas item)
        {
            throw new NotImplementedException();
        }

        public tbPersonas Details(int? id)
        {
            throw new NotImplementedException();
        }



        public tbPersonas find(int? id)
        {
            throw new NotImplementedException();
        }


        public RequestStatus Update(tbPersonas item)
        {
            string sql = ScriptsBaseDeDatos.personas_Editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Per_CedulaIdentidad", item.Per_CedulaIdentidad);
                parametro.Add("@Per_Nombre ", item.Per_Nombre);
                parametro.Add("@Per_Apellido", item.Per_Apellido);
                parametro.Add("@Per_FechaNacimiento", item.Per_FechaNacimiento);
                parametro.Add("@Per_Sexo", item.Per_Sexo);
                parametro.Add("@Per_CedulaIdentidad", item.Per_CedulaIdentidad);
                parametro.Add("@Per_Direccion", item.Per_Direccion);
                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@Per_Telefono", item.Per_Telefono);
                parametro.Add("@Per_UsuarioModificacion", item.Per_UsuarioModificacion);
                parametro.Add("@Per_FechaModificacion", item.Per_FechaModificacion);
                parametro.Add("@Mes_Mesa", item.Mes_Mesa);
                parametro.Add("@Mes_Id", item.Mes_Id);

                parametro.Add("@Per_Id", item.Per_Id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }





        }


        RequestStatus IRepository<tbPersonas>.Update (tbPersonas item)
        {
            throw new NotImplementedException();

        }
    }
}
