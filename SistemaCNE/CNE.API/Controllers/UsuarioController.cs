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


        //[HttpPost("Login")]

        //public IActionResult Login(string usuario, string contraseña)
        //{
        //    var list = _AccesoServices.login(usuario, contraseña);
        //    return Ok(list);
        //}






    }
}
