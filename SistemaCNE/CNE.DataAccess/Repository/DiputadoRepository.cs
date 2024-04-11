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
            const string sql = "[Gral].[sp_Departamentos_insertar]";



            using (var db = new SqlConnection(CNEContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                //parametro.Add("@Dep_Id", item.Dep_Id);
                //parametro.Add("@Dep_Descripcion", item.Dep_Descripcion);
                //parametro.Add("@Dep_UsuarioCreacion", item.Dep_UsuarioCreacion);
                //parametro.Add("@Dep_FechaCreacion", item.Dep_FechaCreacion);


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

        //        List<tbDiputados> result = new List<tbDiputados>();

        //        using (var db = new SqlConnection(CNEContext.ConnectionString))
        //        {
        //            result = db.Query<tbDiputados>(sql, commandType: CommandType.Text).ToList();

        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción aquí, puedes registrarla o lanzarla nuevamente si es necesario
        //        Console.WriteLine("Error al obtener datos de la base de datos: " + ex.Message);
        //        throw; // Lanza la excepción nuevamente para que sea manejada en el código que llama a este método
        //    }
        //    //throw new NotImplementedException();
        //}



        public RequestStatus Delete(tbDiputados item)
        {
            throw new NotImplementedException();
        }

        public tbDiputados Details(int? id)
        {
            throw new NotImplementedException();
        }



        public tbDiputados find(int? id)
        {
            throw new NotImplementedException();
        }



        RequestStatus IRepository<tbDiputados>.Update(tbDiputados item)
        {
            throw new NotImplementedException();
        }
    }
}
