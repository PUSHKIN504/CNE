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


namespace CNE.DataAccess.Repository { 

    public class CentroVotacionRepository : IRepository<tbCentrosVotaciones>
    {
        public RequestStatus Insert(tbCentrosVotaciones item)
        {
            const string sql = "Vota.sp_CentrosVotaciones_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@CeV_UsuarioCreacion ", item.CeV_UsuarioCreacion);
                parametro.Add("@CeV_FechaCreacion", item.CeV_FechaCreacion);
                 parametro.Add("@CeV_Nombre", item.CeV_Nombre); 


                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbCentrosVotaciones> List()
        {
            const string sql = "Vota.sp_CentrosVotaciones_listar";

            List<tbCentrosVotaciones> result = new List<tbCentrosVotaciones>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbCentrosVotaciones>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbCentrosVotaciones List(int id)
        {

            tbCentrosVotaciones result = new tbCentrosVotaciones();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("CeV_Id", id);
                result = db.QueryFirst<tbCentrosVotaciones>(ScriptsBaseDeDatos.CentroVotaciones_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }



        public tbCentrosVotaciones Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int EsC_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("CeV_Id", EsC_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.CentroVotaciones_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

        public RequestStatus Delete(tbCentrosVotaciones item)
        {
            throw new NotImplementedException();
        }


        public tbCentrosVotaciones find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbCentrosVotaciones item)
        {


            string sql = ScriptsBaseDeDatos.CentroVotaciones_Editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                var parametro = new DynamicParameters();
                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@CeV_Nombre", item.CeV_Nombre);
                parametro.Add("@CeV_UsuarioModificacion ", item.CeV_UsuarioModificacion);
                parametro.Add("@CeV_FechaModificacion", item.CeV_FechaModificacion);
            

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }




        }

        public tbCentrosVotaciones Details(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
