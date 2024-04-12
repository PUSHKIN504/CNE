using AutoMapper;
using CNE.BusinessLogic.Services;
using CNE.Common.Models;
using CNE.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using sistemaCapacitaciones.WebUI.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNE.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class RolController : Controller
    {
        private readonly AccesoServices _AccesoServices;

        private readonly IMapper _mapper;
        public RolController(AccesoServices AccesoServices, IMapper mapper)
        {
            _AccesoServices = AccesoServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _AccesoServices.ListadoRol();
            return Ok(list);
        }


        [HttpGet("ListPXR")]
        public IActionResult ListPXR()
        {
            var list = _AccesoServices.ListRxP();
            return Ok(list);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] FormData formData)
        {
            string txtRol = formData.txtRol;
            List<int> pantallasSeleccionadas = formData.pantallasSeleccionadas;

            if (string.IsNullOrEmpty(formData.txtRol))
            {
                ModelState.AddModelError("txtRol", "El nombre del rol es requerido.");
            }

            if (!ModelState.IsValid)
            {
            }

            var modelo = new tbRoles()
            {
                Roles_Descripcion = txtRol,
                Roles_UsuarioCreacion = 1, 
                Roles_FechaCreacion = DateTime.Now
            };

            var mensaje = _AccesoServices.InsertarRol(modelo);

            var idRol = mensaje;

            foreach (var pantalla in pantallasSeleccionadas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    Panta_Id = pantalla,
                    Roles_Id =int.Parse( idRol),
                    Papro_UsuarioCreacion = 1,
                    Papro_FechaCreacion = DateTime.Now
                };

                var msj = _AccesoServices.InsertarPantaRol(modelo2);
            }


            return Json(1);
            

        }


        [HttpGet("UpdateRol")]
        public IActionResult Update(int Roles_id)
        {
            var PantallasPorRol = _AccesoServices.ObtenerPantallasPorRol(Roles_id);
            var Pantallas = _AccesoServices.ListadoPatalla();
            var ObtenerRol = _AccesoServices.ObtenerRol(Roles_id);

            int rolid = 0;
            string NombreRol = "";

            var Rol = ObtenerRol.Data;

            foreach (var item in Rol)
            {
                rolid = item.Roles_Id;
                NombreRol = item.Roles_Descripcion;
            }

            var pantallasSeleccionadas = PantallasPorRol.Select(p => (int)p.Panta_Id).ToList();

            var panta = Pantallas.Data as IEnumerable<tbPantallas>;

            var pantallasViewModel = _mapper.Map<List<PantallaViewModel>>(panta);

            var rolViewModel = new RolViewModel
            {
                Roles_Id = rolid,
                Roles_Descripcion = NombreRol,
                PantallasID = pantallasSeleccionadas,
                pantallas = (List<PantallaViewModel>)pantallasViewModel,
            };
            return Ok(rolViewModel);
        }







        [HttpPost("UpdateRol")]
        public JsonResult Edit([FromBody] FormData formData)
        {
            if (string.IsNullOrEmpty(formData.txtRol))
            {
                ModelState.AddModelError("txtRol", "El nombre del rol es requerido.");
            }

            var rol = new tbRoles()
            {
                Roles_Id = formData.Rol_Id,
                Roles_Descripcion = formData.txtRol,
                Roles_UsuarioModificacion = 1,
                Roles_FechaModificacion = DateTime.Now,

            };

            var id = _AccesoServices.ObtenerId((int)rol.Roles_UsuarioModificacion, (DateTime)rol.Roles_FechaModificacion);
            var role = id.Data as IEnumerable<tbRoles>;

            var Rol = new tbRoles()
            {
                Roles_Id = formData.Rol_Id,
                Roles_Descripcion = formData.txtRol,
                Roles_UsuarioModificacion = 1,
                Roles_FechaModificacion = DateTime.Now,

            };

            _AccesoServices.ActualizarRol(Rol);
            _AccesoServices.EliminarPantallaPorRol(formData.Rol_Id);


            foreach (var pantalla in formData.pantallasSeleccionadas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    Panta_Id = pantalla,
                    Roles_Id = formData.Rol_Id,
                    Papro_UsuarioCreacion = 1,
                    Papro_FechaCreacion = DateTime.Now
                };

                var msj = _AccesoServices.InsertarPantaRol(modelo2);
            }

            return Json(1);
        }



    


        [HttpDelete("DeleteRol")]
        public IActionResult Delete(int Rol_id)
        {
            _AccesoServices.EliminarPantallaPorRol(Rol_id);
            var list = _AccesoServices.EliminarRol(Rol_id);
            return Ok(list);
        }









    }
}
