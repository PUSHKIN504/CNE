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
    public class MunicipioRepository : IRepository<tbMunicipios>
    {
        public RequestStatus Insert(tbMunicipios item)
        {
            const string sql = "[Gral].[sp_Municipios_insertar]";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@Mun_Descripcion", item.Mun_Descripcion);
                parametro.Add("@Dep_Id", item.Dep_Id);

                parametro.Add("@Mun_UsuarioCreacion", item.Mun_UsuarioCreacion);
                parametro.Add("@Mun_FechaCreacion", item.Mun_FechaCreacion);


                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbMunicipios> List()
        {
            const string sql = "Gral.sp_Municipios_listar";

            List<tbMunicipios> result = new List<tbMunicipios>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbMunicipios>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbMunicipios List(string id)
        {

            tbMunicipios result = new tbMunicipios();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Mun_Id", id);
                result = db.QueryFirst<tbMunicipios>(ScriptsBaseDeDatos.Municipio_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }

        public RequestStatus Delete(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public tbMunicipios Details(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(string Mun_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Mun_Id", Mun_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Municipio_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }




        public tbMunicipios find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbMunicipios item)
        {


            string sql = ScriptsBaseDeDatos.Municipio_Editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Mun_Id", item.Mun_Id);
                parameter.Add("@Mun_Descripcion", item.Mun_Descripcion);
                parameter.Add("@Dep_Id", item.Dep_Id);
            
                parameter.Add("@Mun_UsuarioModificacion", item.Mun_UsuarioModificacion);
                parameter.Add("@Mun_FechaModificacion", item.Mun_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }




           
        }
    }
}
