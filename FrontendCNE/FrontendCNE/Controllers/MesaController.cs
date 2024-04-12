using AutoMapper;
using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class MesaController : Controller
    {
        public MesaService _mesaService;
        private readonly IMapper _mapper;

        public MesaController(MesaService mesaService)
        {
            _mesaService = mesaService;
        }
        [HttpGet("Mesa/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<MesaViewModel>();
                var list = await _mesaService.ObtenerMesaList();
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

        // POST: DepartamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MesaViewModel item)
        {
            try
            {
                item.Mes_UsuarioCreacion = 1;
                item.Mes_FechaCreacion = DateTime.Now;
                item.Mes_Estado = true;
                var list = await _mesaService.CrearMesa(item);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Mesa/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _mesaService.ObtenerMesa();
                TempData["Exito"] = "La accion se realizo con exito";

                return Json(model.Data);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }
        }

        [HttpPost("Mesa/Edit")]
        public async Task<IActionResult> Edit(MesaViewModel item, int Mes_Jurado, int Mes_Custodio1, int Mes_Custodio2)
        {
            try
            {
                item.Mes_Jurado = Mes_Jurado;
                item.Mes_Custodio1 = Mes_Custodio1;
                item.Mes_Custodio2 = Mes_Custodio2;
                item.Mes_UsuarioCreacion = 1;
                item.Mes_FechaCreacion = DateTime.Now;
                var result = await _mesaService.EditarMesa(item);
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

        [HttpPost("/Mesa/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _mesaService.EliminarMesa(id);
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


        public async Task<IActionResult> Details(int Mes_Id)
        {
            try
            {
                var listd = await _mesaService.ObtenerMesaMindy(Mes_Id);
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
