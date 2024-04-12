using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.DataAccess
{
    public class ScriptsBaseDeDatos
    {
        #region Departamentos
        public static string Departamento_Insertar = "Gral.sp_Departamentos_insertar";
        public static string Departamento_Listar = "Gral.sp_Departamentos_listar";
        public static string Depa_Llenar = "Gral.sp_Departamentos_buscar";
        public static string Depa_Editar = "Gral.sp_Departamentos_actualizar";
        public static string Depa_Eliminar = "Gral.sp_Departamentos_eliminar";
        public static string Estad_ListaDepartamentoCiudades = "[Gral].[sp_DeparCiudades_listar]";


        #endregion



        #region EstadoCivil
        public static string EstadoCivil_Insertar = "Gral.sp_EstadosCiviles_insertar";
        public static string EstadoCivil_Listar = "Gral.sp_EstadosCiviles_listar";
        public static string EstadoCivil_Llenar = "Gral.sp_EstadosCiviles_buscar";
        public static string EstadoCivil_Editar = "Gral.sp_EstadosCiviles_actualizar";
        public static string EstadoCivil_Eliminar = "Gral.sp_EstadosCiviles_eliminar";

        #endregion

        #region Votaciones
        public static string ObtenerYaVoto = "Vota.sp_Personas_ObtenerSiVoto";

        #endregion


        #region Municipios
        public static string Municipio_Insertar = "Gral.sp_Municipios_insertar";
        public static string Municipio_Listar = "Gral.sp_Municipios_listar";
        public static string Municipio_Llenar = "Gral.sp_Municipios_buscar";
        public static string Municipio_Editar = "Gral.sp_Municipios_actualizar";
        public static string Municipio_Eliminar = "Gral.sp_Municipios_eliminar";

        #endregion

        #region Personas
        public static string personas_Listar = "Gral.sp_Personas_listar";
        public static string personas_Insertar = "Gral.sp_Personas_insertar";
        public static string personas_Llenar = "Gral.sp_Personas_buscar";
        public static string personas_Editar = "Gral.sp_Personas_actualizar";
        public static string personas_Eliminar = "Gral.sp_Personas_eliminar";

        #endregion



        #region Mesa
        public static string Mesa_Listar = "Vota.sp_Mesas_listar";
        public static string Mesa_Insertar = "Vota.sp_Mesas_insertar";
        public static string Mesa_Llenar = "Vota.sp_Mesas_buscar";
        public static string Mesa_Editar = "Vota.sp_Mesas_actualizar";
        public static string Mesa_Eliminar = "Vota.sp_Mesas_eliminar";

        #endregion






        #region CentroVotaciones
        public static string CentroVotaciones_Listar = "Vota.sp_CentroVotaciones_listar";
        public static string CentroVotaciones_Insertar = "Vota.sp_CentrosVotaciones_insertar";
        public static string CentroVotaciones_Llenar = "Vota.sp_CentrosVotaciones_buscar";
        public static string CentroVotaciones_Editar = "Vota.sp_CentrosVotaciones_actualizar";
        public static string CentroVotaciones_Eliminar = "Vota.sp_CentrosVotaciones_eliminar";

        #endregion



        #region Empleados
        public static string Empleados_Listar = "Vota.sp_Empleados_listar";
        public static string Empleados_Insertar = "Vota.sp_Empleados_insertar";
        public static string Empleados_Llenar = "Vota.sp_Empleados_buscar";
        public static string Empleados_Editar = "Vota.sp_Empleados_actualizar";
        public static string Empleados_Eliminar = "Vota.sp_Empleados_eliminar";

        #endregion





        #region Pantallas
        public static string pantalla_Listar = "Vota.sp_Pantallas_listar";

        #endregion






        #region Usuarios
        public static string Usuarios_Listar = "Acce.sp_Usuarios_listar";
        public static string Usua_Login = "Acce.sp_Usuarios_iniciosesion1";
        public static string Usua_usuario = "Acce.sp_Usuarios_validarusuario";
        public static string Usua_clave = "Acce.sp_Usuarios_validarclave";
        public static string Usua_Eliminar = "Acce.sp_Usuarios_eliminar";
        public static string Actualizarc = "Acce.sp_Usuarios_Restablecer_Contra";
        public static string Usuario_Llenar = "Gral.sp_Usuario_buscar";
        public static string Actualizar = "Acce.sp_Usuarios_actualizar";

        


        #endregion




        #region Roles
        public static string Rol_Listar = "Acce.sp_Roles_listar";
        public static string Rol_Eliminar = "Acce.sp_Roles_eliminar";
        public static string Papro_Buscar = "[Acce].[sp_PantallasPorRol_buscar]";
        public static string Papro_Eliminar = "[Acce].[sp_PantallasPorRol_eliminar]";
        public static string Rol_Obtener = "[Acce].[sp_Roles_obtener]";
        public static string Roles_Actualizar = "[Acce].[sp_Roles_actualizar]";
        public static string Rol_ObtenerId = "Acce.sp_Roles_obtenerid";





        #endregion







        #region Partido
        public static string Partido_Listar = "Vota.sp_Partidos_listar";
        public static string Partido_Insertar = "[Vota].[sp_Partidos_insertar]";
        public static string Partido_Lenar = "Vota.sp_Partidos_buscar";
        public static string Partido_Eliminar = "Vota.sp_Partido_eliminar";
        public static string Partido_Editar = "Vota.sp_Partidos_actualizar";




        #endregion


        #region Alcalde
        public static string Alcalde_Listar = "Vota.sp_Alcaldes_listar";
        public static string Alcalde_Llenar = "Vota.sp_Alcaldes_buscar";
        public static string Alcalde_eliminar = "Vota.sp_Alcaldes_eliminar";
        public static string Alcalde_editar = "Vota.sp_Alcaldes_actualizar";



        #endregion


        #region Diputados
        public static string Diputados_Listar = "Vota.sp_Diputados_listarMindy";
        public static string Diputado_Llenar = "Vota.sp_Diputados_buscar";
        public static string Diputado_eliminar = "Vota.sp_Diputados_eliminar";
        public static string Diputado_editar = "Vota.sp_Diputados_actualizar]";

        #endregion



        #region Presidentes
        public static string Presidentes_Listar = "Vota.sp_Presidentes_listar";
        public static string Presidente_Llenar = "Vota.sp_Presidente_buscar";
        public static string Presi_eliminar = "Vota.sp_Presidente_eliminar";
        public static string Presi_editar = "Vota.sp_Presidente_actualizar";
        #endregion









    }
}
