using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class VotacionController : Controller
    {
        public VotacionesService _VotacionesServicios;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VotacionController(VotacionesService VotacionesServicios, IHttpContextAccessor httpContextAccessor)
        {
            _VotacionesServicios = VotacionesServicios;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Graficas()
        {
            return View("~/Views/Votacion/Graficas.cshtml");
        }
        [HttpPost]
        public void AlgunaAccion(string id)
        {
            HttpContext.Session.SetString("DNI", id);
        }


        [HttpGet("Votaciones/InfoVotante/{DNI}")]
        public async Task<IActionResult> YaVoto(string DNI)
        {
            try
            {
                var model = await _VotacionesServicios.ObtenerYaVoto(DNI);
                var session = _httpContextAccessor.HttpContext.Session;
                session.SetString("DNI", DNI);
                var coso = session.GetString("DNI");
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(VotoViewModel item)
        {
            try
            {

                var list = await _VotacionesServicios.CrearVoto(item/*, listaEnteros*/);
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
