using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class PresidenteController : Controller
    {
        
        public PresidenteService _presidenteServicios;
        public VotacionesService _VotacionesService;
        public PresidenteController(PresidenteService presidenteServicios, VotacionesService votacionesService)
        {
            _presidenteServicios = presidenteServicios;
            _VotacionesService = votacionesService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Votacion/Presidentes.cshtml");
        }

        [HttpGet("Presidentes/List")]
        public async Task<IActionResult> PreList()
        {
            try
            {
                var model = await _presidenteServicios.PresList();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VotoViewModel item)
        {
            try
            {
                
                var list = await _VotacionesService.CrearVoto(item);
                return RedirectToAction("Index", "Votacion");
                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }
    }
}
