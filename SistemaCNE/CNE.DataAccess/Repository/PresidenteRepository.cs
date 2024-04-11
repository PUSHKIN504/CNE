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
    public class PresidenteRepository : IRepository<tbPresidentes>
    {
        public RequestStatus Insert(tbPresidentes item)
        {
            const string sql = "Vota.sp_Presidente_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {


                var parametro = new DynamicParameters();
                parametro.Add("@Pre_Id", item.Pre_Id);
                parametro.Add("@Pre_ImgUrl", item.Pre_ImgUrl);
                parametro.Add("@Pre_UsuarioCreacion ", 1);
                parametro.Add("@Pre_FechaCreacion", item.Pre_FechaCreacion);
                parametro.Add("@Par_id", item.Par_id);



                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }
        public IEnumerable<tbPresidentes> List()
        {
            const string sql = " [Vota].[sp_Presidentes_listar]";

            List<tbPresidentes> result = new List<tbPresidentes>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbPresidentes>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }



        public tbPresidentes List(int id)
        {
            tbPresidentes result = new tbPresidentes();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Pre_Id", id);
                result = db.QueryFirst<tbPresidentes>(ScriptsBaseDeDatos.Presidente_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }


        }




        public RequestStatus Delete(int Dip_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Dip_Id", Dip_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Presi_eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }




        public tbAlcaldes Details(int id)
        {
            throw new NotImplementedException();
        }


        public RequestStatus Update(tbPresidentes item)
        {


            string sql = ScriptsBaseDeDatos.Presi_editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Pre_Id", item.Pre_Id);
                parameter.Add("@Pre_ImgUrl", item.Pre_ImgUrl);
                parameter.Add("@Pre_UsuarioModificacion ", item.Pre_UsuarioModificacion);
                parameter.Add("@Pre_FechaModificacion ", item.Pre_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }




        public tbPresidentes find(int? id)
        {
            throw new NotImplementedException();
        }



        RequestStatus IRepository<tbPresidentes>.Update(tbPresidentes item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(tbPresidentes item)
        {
            throw new NotImplementedException();
        }

        public tbPresidentes Details(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
