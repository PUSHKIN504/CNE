using CNE.DataAccess.Repository;
using CNE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.BusinessLogic.Services
{
     public class AccesoServices
    {


        private readonly PantallaRepository _pantallaRepository;
        private readonly RolRepository _rolRepository;
        private readonly UsuarioRepository _usuarioRepository;



        public AccesoServices(PantallaRepository pantallaRepository, RolRepository rolRepository, UsuarioRepository usuarioRepository)
        {
            _pantallaRepository = pantallaRepository;
            _rolRepository = rolRepository;
            _usuarioRepository = usuarioRepository;
        }



        public IEnumerable<tbPantallasPorRoles> ObtenerPantallasPorRol(int id)
        {
            try
            {

                return _rolRepository.BuscarPantallasPorRol(id);
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<tbPantallasPorRoles>();
            }
        }



        public ServiceResult ObtenerRol(int Rol_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolRepository.ObtenerRol(Rol_Id);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }






        public ServiceResult ActualizarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #region Pantalla

        public ServiceResult ListadoPatalla()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallaRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }




        public ServiceResult EliminarPantallaPorRol(int PaRo_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolRepository.EliminarPantallaPorRol(PaRo_Id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }




        #endregion

        #region Rol

        public ServiceResult ListadoRol()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ObtenerId(string Rol, int usuario_creacion, DateTime fecha_creacion)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolRepository.findObtenerId(Rol, usuario_creacion, fecha_creacion);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public string InsertarRol(tbRoles item)
        {
            string error = "";

            //var result = new ServiceResult();
          

                //var list = _rolRepository.Insert(item);
                try
                {
                 int   result = _rolRepository.Insert(item);
                    if (result == -1)
                        error = "el codigo no es valido";
                    else error = result.ToString();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
                return error;
                //    return id;
                //    //if (list.CodeStatus > 0)
                //    //{
                //    //    return result.Ok(list);
                //    //}
                //    //else
                //    //{
                //    //    return result.Error(list);
                //    //}
                //}
                //catch (Exception ex)
                //{
                //    return (0) ;
            
            //}
        }


        public ServiceResult InsertarPantaRol(tbPantallasPorRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.Insertpan(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }




        public ServiceResult EliminarRol(int Roles_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.Delete(Roles_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }





        #endregion



        #region Pantalla

        public ServiceResult ListadoPatallaXRol()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallaRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }


        #endregion

        #region Usuario

        public ServiceResult ListadoUsuario()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }







        public ServiceResult Login(string Usuario, string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.Login(Usuario, Contra);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarUsuario(string Usuario)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.ValidarUsuario(Usuario);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarClave(string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.ValidarClave(Contra);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        //public ServiceResult login2(string Usua_Usuario, string Usua_Clave)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var list = _usuarioRepository.Login(Usua_Usuario, Usua_Clave);
        //        return result.Ok(list);
        //    }

        //    catch (Exception ex)
        //    {

        //        return result.Error(ex.Message);
        //    }
        //}











        #endregion
    }
}
