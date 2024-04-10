using AutoMapper;
using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class CentroVotacionController : Controller
    {
        public CentroVotacionService _centroVotacionService;
        private readonly IMapper _mapper;

        public CentroVotacionController(CentroVotacionService centroVotacionService )
        {
            _centroVotacionService = centroVotacionService;
        }
        [HttpGet("CentroVotacion/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<CentroVotacionesViewModels>();
                var list = await _centroVotacionService.ObtenerCentroVotacionList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CentroVotacionesViewModels item)
        {
            try
            {
                item.CeV_UsuarioCreacion = 1;
                item.CeV_FechaCreacion = DateTime.Now;
                item.CeV_Estado = true;
                var list = await _centroVotacionService.CrearCentroVotacion(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }


        [HttpGet("CentroVotacion/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _centroVotacionService.ObtenerCentroVotacion();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("CentroVotacion/Edit")]
        public async Task<IActionResult> Edit(CentroVotacionesViewModels item, int id, string Descripcion, string MunId)
        {
            try
            {
                item.CeV_Id = id;
                item.CeV_Nombre = Descripcion;
                item.Mun_Id = MunId;
                item.CeV_UsuarioModificacion = 1;
                item.CeV_FechaModificacion= DateTime.Now;
                var result = await _centroVotacionService.EditarCentroVotacion(item);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index", item);
                }
            }
            catch (Exception ex)
            {
                return View(item);
                throw;
            }
        }

        [HttpPost("/CentroVotacion/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _centroVotacionService.EliminarCentroVotacion(id);
                if (result.Success)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> Details(int EsC_Id)
        {
            try
            {
                var listd = await _centroVotacionService.ObtenerCentroVotacionMindy(EsC_Id);
                if (listd == null)
                {
                    return NotFound();
                }
                return View(listd.Data);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }




        }
    }
}
