using AutoMapper;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class EstadoCivilController : Controller
    {
        public EstadoCivilServices _estadoCivilServices;
        private readonly IMapper _mapper;

        public EstadoCivilController(EstadoCivilServices estadoCivilServices)
        {
            _estadoCivilServices = estadoCivilServices;
        }
        [HttpGet("EstadoCivil/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<EstadoCivilViewModel>();
                var list = await _estadoCivilServices.ObtenerEstadoCivilList();
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
        public async Task<IActionResult> Create(EstadoCivilViewModel item)
        {
            try
            {
                item.EsC_UsuarioCreacion = 1;
                item.EsC_FechaCreacion = DateTime.Now;
                item.EsC_Estado = true;
                var list = await _estadoCivilServices.CrearEstadoCivil(item);
                return RedirectToAction("Index");
                //return View(new List<EstadoCivilViewModel> { (EstadoCivilViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }


        [HttpGet("EstadoCivil/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _estadoCivilServices.ObtenerEstadoCivil();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("EstadoCivil/Edit")]
        public async Task<IActionResult> Edit(EstadoCivilViewModel item, int id, string Descripcion)
        {
            try
            {
                item.EsC_Id = id;
                item.EsC_Descripcion = Descripcion;
                item.EsC_UsuarioCreacion = 1;
                item.EsC_FechaCreacion = DateTime.Now;
                var result = await _estadoCivilServices.EditarEstadoCivil(item);
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

        [HttpPost("/EstadoCivil/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _estadoCivilServices.EliminarEstadoCivil(id);
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
                var listd = await _estadoCivilServices.ObtenerEstadoCivilMindy(EsC_Id);
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
