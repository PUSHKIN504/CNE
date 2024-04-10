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
    public class MesaRepository
    {
        public RequestStatus Insert(tbMesas item)
        {
            const string sql = "Vota.sp_Mesas_insertar";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Mes_Jurado", item.Mes_Jurado);
                parametro.Add("@Mes_Custodio1 ", item.Mes_Custodio1);

                parametro.Add("@Mes_Custodio2 ", item.Mes_Custodio2);
                parametro.Add("@Mes_UsuarioCreacion", item.Mes_UsuarioCreacion);
                parametro.Add("@Mes_FechaCreacion", item.Mes_FechaCreacion);




                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbMesas> List()
        {
            const string sql ="Vota.sp_Mesas_listar";

            List<tbMesas> result = new List<tbMesas>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbMesas>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbMesas List(int id)
        {

            tbMesas result = new tbMesas();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Mes_Id", id);
                result = db.QueryFirst<tbMesas>(ScriptsBaseDeDatos.Mesa_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }



        public tbEstadosCiviles Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Mes_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Mes_Id", Mes_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Mesa_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

        public RequestStatus Delete(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }


        public tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbMesas item)
        {


            string sql = ScriptsBaseDeDatos.Mesa_Editar;

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                
               parametro.Add("@Mes_Id", item.Mes_Id);

                parametro.Add("@Mes_Jurado", item.Mes_Jurado);
                parametro.Add("@Mes_Custodio1 ", item.Mes_Custodio1);

                parametro.Add("@Mes_Custodio2 ", item.Mes_Custodio2);
                parametro.Add("@Mes_UsuarioModificacion ", item.Mes_UsuarioModificacion);
                parametro.Add("@Mes_FechaModificacion ", item.Mes_FechaModificacion);

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }





        }
    }
}
