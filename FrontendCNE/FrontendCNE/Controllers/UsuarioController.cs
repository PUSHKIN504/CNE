using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService, RolService rolService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("Usuario/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<UsuarioViewModel>();
                var list = await _usuarioService.UsuarioList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}
