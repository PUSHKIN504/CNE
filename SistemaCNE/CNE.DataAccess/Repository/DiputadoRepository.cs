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
    public class DiputadoRepository : IRepository<tbDiputados>
    {

        public RequestStatus Insert(tbDiputados item)
        {

            const string sql = "Vota.sp_Diputados_insertar";




            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {


                var parametro = new DynamicParameters();
                parametro.Add("@Dip_Id", item.Dip_Id);
                parametro.Add("@Dip_ImgUrl", item.Dip_ImgUrl);
                parametro.Add("@Alc_UsuarioCreacion ", 1);
                parametro.Add("@Alc_FechaCreacion", item.Dip_FechaCreacion);
                parametro.Add("@Par_id", item.Par_id);



                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }


        public IEnumerable<tbDiputados> List()
        {
            const string sql = "[Vota].[sp_Diputados_listar]";

            List<tbDiputados> result = new List<tbDiputados>();

            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                result = db.Query<tbDiputados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }
        //public IEnumerable<tbDiputados> ListA(string dni)
        //{


     



        public tbDiputados List(int id)
        {
            tbDiputados result = new tbDiputados();
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Dip_Id", id);
                result = db.QueryFirst<tbDiputados>(ScriptsBaseDeDatos.Diputado_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        //    //string sql = $"Vota.sp_Alcalde_listar {dni}";


        //    //List<tbDiputados> result = new List<tbDiputados>();

        //    //using (var db = new SqlConnection(CNEContext.ConnectionString))
        //    //{
        //    //    result = db.Query<tbDiputados>(sql, commandType: CommandType.Text).ToList();

        //    //    return result;
        //    //}

        //    try
        //    {
        //        string sql = $"Vota.sp_Alcalde_listar '{dni}'";


        public RequestStatus Delete(int Dip_Id)
        {
            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Dip_Id", Dip_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Diputado_eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }




        public tbAlcaldes Details(int id)

        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbDiputados item)
        {


            string sql = ScriptsBaseDeDatos.Diputado_editar;


            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Dip_Id", item.Dip_Id);
                parameter.Add("@Dip_ImgUrl", item.Dip_ImgUrl);
                parameter.Add("@Dip_UsuarioModificacion ", item.Dip_UsuarioModificacion);
                parameter.Add("@Dip_FechaModificacion ", item.Dip_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }



        public RequestStatus Delete(tbDiputados item)
        {
            throw new NotImplementedException();
        }


        public tbDiputados find(int? id)

        {
            throw new NotImplementedException();
        }



        
    }
}
