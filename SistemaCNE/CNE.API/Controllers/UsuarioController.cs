using AutoMapper;
using CNE.BusinessLogic.Services;
using CNE.Common.Models;
using CNE.Entities.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace CNE.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AccesoServices _AccesoServices;

        private readonly IMapper _mapper;
        public UsuarioController(AccesoServices AccesoServices, IMapper mapper)
        {
            _AccesoServices = AccesoServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _AccesoServices.ListadoUsuario();
            return Ok(list);
        }



        [HttpGet("LoginHome")]
        public IActionResult Login(string Usuario, string Contra)
        {
            var usuario = _AccesoServices.ValidarUsuario(Usuario);
            var clave = _AccesoServices.ValidarClave(Contra);
            var list = _AccesoServices.Login(Usuario, Contra);

            return Ok(list);
        }

        [HttpPost("ValidarUsuarioHome")]
        public IActionResult ValidarUsuario(string Usuario)
        {
            var usuario = _AccesoServices.ValidarUsuario(Usuario);
            return Ok(usuario);
        }
        [HttpPost("ValidarClaveHome")]
        public IActionResult ValidarClave(string Contra)
        {
            var clave = _AccesoServices.ValidarClave(Contra);
            return Ok(clave);
        }


        [HttpPost("Create")]
        public IActionResult Insert(UsuarioViewModel item)
        {
            var model = _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usuar_Usuario = item.Usuar_Usuario,
                Usuar_Contrasena = item.Usuar_Contrasena,
                Per_Id = 1,
                Roles_Id = item.Roles_Id,
                Usuar_UsuarioCreacion = 1,
                Usuar_FechaCreacion = item.Usuar_FechaCreacion
            };
            var list = _AccesoServices.InsertarUsuario(modelo);
            return Ok(list);
        }




        [HttpDelete("Delete")]
        public IActionResult Delete(int Usuar_Id)
        {
            var list = _AccesoServices.EliminarUsuario(Usuar_Id);
            return Ok(list);
        }




        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _AccesoServices.ListUsuario(id);
            return Json(list);
        }


        [HttpPut("EditC")]

        public IActionResult UpdateC(UsuarioViewModel item)
        {
            _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usuar_Id = item.Usuar_Id,
                Usua_Contrasenia = item.Usua_Contrasenia,
                Usuar_UsuarioModificacion = 1,
                Usuar_FechaModificacion = DateTime.Now
            };
            var list = _AccesoServices.cotra(modelo);
            return Ok(list);
        }




        [HttpPut("Edit")]

        public IActionResult Update(UsuarioViewModel item)
        {
            _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usuar_Id = item.Usuar_Id,
                Usuar_Usuario = item.Usuar_Usuario,

                Per_Id = item.Per_Id,
                Roles_Id = item.Roles_Id,
                Usuar_UsuarioModificacion = 1,
                Usuar_FechaModificacion = DateTime.Now
            };
            var list = _AccesoServices.Editar(modelo);
            return Ok(list);
        }

    }
    }
