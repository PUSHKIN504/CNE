using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class DiputadoController : Controller
    {
        public DiputadoService _diputadoService;
        public DiputadoController(DiputadoService diputadoService)
        {
            _diputadoService = diputadoService;
        }
        [HttpGet("Diputado/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<DiputadoViewModel>();
                var list = await _diputadoService.DiputadoList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
