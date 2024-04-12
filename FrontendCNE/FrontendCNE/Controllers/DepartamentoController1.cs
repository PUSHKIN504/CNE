using AutoMapper;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class DepartamentoController1 : Controller
    {
        public DepartamentoService _departamentoServicios;
        private readonly IMapper _mapper;

        public DepartamentoController1(DepartamentoService departamentoServicios)
        {
            _departamentoServicios = departamentoServicios;
        }

        [HttpGet("Departamento/DepartamentoCiudades")]
        public async Task<IActionResult> ListDespartamentoCiudades()
        {
            var response = await _departamentoServicios.DepartamentoCiudadesList();
            return Json(response);

        }

        [HttpGet("Departamento/")]
       
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<DepartamentoViewModel>();
                var list = await _departamentoServicios.ObtenerDepartamentoList();
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
        public async Task<IActionResult> Create(DepartamentoViewModel item)
        {
            try
            {
                item.Dep_UsuarioCreacion = 1;
                item.Dep_FechaCreacion = DateTime.Now;
                item.Depar_Estado = true;
                var list = await _departamentoServicios.CrearDepartamento(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }


        [HttpGet("Departamento/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _departamentoServicios.ObtenerDepartamento();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("Departamento/Edit")]
        public async Task<IActionResult> Edit(DepartamentoViewModel item, string id, string Descripcion)
        {
            try
            {
                item.Dep_Id = id;
                item.Dep_Descripcion = Descripcion;
                item.Dep_UsuarioCreacion = 1;
                item.Dep_FechaCreacion = DateTime.Now;
                var result = await _departamentoServicios.EditarDepartamento(item);
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

        [HttpPost("/Departamento/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _departamentoServicios.EliminarDepartamento(id);
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

        //public async Task<IActionResult> Details(string Esta_Id)
        //{
        //    try
        //    {
        //        var list = await _departamentoServicios.DetallesDepartamento(Esta_Id);
        //        return View(list.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}



        //[HttpGet("Departamento/Details/{id}")]
        //public async Task<IActionResult> Details(string id)
        //{
        //    try
        //    {
        //        var model = await _departamentoServicios.ObtenerDepartamento(id);
        //        return Json(model.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}


        //[HttpGet("/Departamento/Details/{id}")]
        public async Task<IActionResult> Details(string Dep_Id)
        {
            try
            {
                var listd = await _departamentoServicios.ObtenerDepartamentoMindy(Dep_Id);
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
    

