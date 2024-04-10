using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class PartidoController : Controller
    {
        public PartidoService _partidoService;
        public PartidoController(PartidoService partidoService )
        {
            _partidoService = partidoService;
        }
        [HttpGet("Partido/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<PartidosViewModel>();
                var list = await _partidoService.PartidoList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
