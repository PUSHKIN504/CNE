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
    public class MunicipioController : Controller
    {
        public MunicipioService _municipioService;
        private readonly IMapper _mapper;

        public MunicipioController(MunicipioService municipioService)
        {
            _municipioService = municipioService;
        }
        [HttpGet("Municipio/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<MunicipioViewModel>();
                var list = await _municipioService.MunicipioList();
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
        public async Task<IActionResult> Create(MunicipioViewModel item)
        {
            try
            {
                item.Mun_UsuarioCreacion = 1;
                item.Mun_FechaCreacion = DateTime.Now;
                item.Mun_Estado = true;
                var list = await _municipioService.CrearMunucipio(item);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
                //return View(new List<MunicipioViewModel> { (MunicipioViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Municipio/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _municipioService.ObtenerMunicipio();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("Municipio/Edit")]
        public async Task<IActionResult> Edit(MunicipioViewModel item, string id, string Descripcion, string idDep)
        {
            try
            {
               
                item.Mun_Id = id;
                item.Mun_Descripcion = Descripcion;
                item.Dep_Id = idDep;
                item.Mun_UsuarioCreacion = 1;
                item.Mun_FechaCreacion = DateTime.Now;
                var result = await _municipioService.EditarMunicipio(item);
                if (result.Success)
                {
                    TempData["Exito"] = "La accion se realizo con exito";

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index", item);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
                throw;
            }
        }

        [HttpPost("/Municipio/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _municipioService.EliminarMunicpio(id);
                if (result.Success)
                {
                    TempData["Exito"] = "La accion se realizo con exito";

                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction(nameof(Index));
            }
        }

  
        public async Task<IActionResult> Details(string Mun_Id)
        {
            try
            {
                var listd = await _municipioService.ObtenerMunicipioMindy(Mun_Id);
                if (listd == null)
                {
                    return NotFound();
                }
                return View(listd.Data);

            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index", "Home");
            }




        }
    }
}
