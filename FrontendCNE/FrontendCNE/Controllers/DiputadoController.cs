using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class DiputadoController : Controller
    {
        public DiputadoService _diputadoService;
        public PersonasServices _personService;
        private readonly IWebHostEnvironment _hostingEnviroment;
        public DiputadoController(DiputadoService diputadoService, PersonasServices personasServices, IWebHostEnvironment hostingEnviroment)
        {
            _diputadoService = diputadoService;
            _hostingEnviroment = hostingEnviroment;

            _personService = personasServices;
        }
        [HttpGet("Diputado/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var prueba = await _personService.ObtenerPersonasList();
                if (prueba.Success)
                {
                    var person = prueba.Data as List<PersonasViewModel>;
                    var personList = person.Select(x => new SelectListItem { Text = x.Per_Nombre, Value = x.Per_Id.ToString() }).ToList();
                    personList.Insert(0, new SelectListItem { Text = "Opcion", Value = "" });
                    ViewBag.Personas = personList;
                }

                var model = new List<DiputadoViewModel>();
                var list = await _diputadoService.DiputadoList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }







        public async Task<IActionResult> Create()
        {
            var prueba = await _personService.ObtenerPersonasList();
            if (prueba.Success)
            {
                var person = prueba.Data as List<PersonasViewModel>;
                var personList = person.Select(x => new SelectListItem { Text = x.Per_Nombre, Value = x.Per_Id.ToString() }).ToList();
                personList.Insert(0, new SelectListItem { Text = "Opcion", Value = "" });
                ViewBag.Personas = personList;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiputadoViewModel item)
        {
            try
            {
                string folder = "images/";
                if (item.FotoP != null)
                {

                    folder += Guid.NewGuid().ToString() + "_" + item.FotoP.FileName;

                    string serverFolder = Path.Combine(_hostingEnviroment.WebRootPath, folder);

                    await item.FotoP.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }


                item.Dip_Id = int.Parse(item.Per_Id);
                item.Dip_ImgUrl = folder;
                item.Dip_UsuarioCreacion = 1;
                item.Dip_FechaCreacion = DateTime.Now;
                item.Dip_Estado = true;
                var list = await _diputadoService.CrearDiputado(item);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Diputado/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _diputadoService.ObtenerDiputado();
                TempData["Exito"] = "La accion se realizo con exito";

                return Json(model.Data);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }
        }

        [HttpPost("Diputado/Edit")]
        public async Task<IActionResult> Edit(DiputadoViewModel item, int id, string img, int par)
        {
            try
            {
                string folder = "images/";
                if (item.FotoP != null)
                {

                    folder += Guid.NewGuid().ToString() + "_" + item.FotoP.FileName;

                    string serverFolder = Path.Combine(_hostingEnviroment.WebRootPath, folder);

                    await item.FotoP.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }


                item.Dip_Id = id;
                item.Dip_ImgUrl = folder;
                item.Par_id = par;
                item.Dip_UsuarioModificacion = 1;
                item.Dip_FechaModificacion = DateTime.Now;
                var result = await _diputadoService.EditarDiputado(item);
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

        [HttpPost("/Diputado/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            try
            {

                var result = await _diputadoService.EliminarDiputado(id);
                if (result.Success)
                {
                    TempData["Exito"] = "La accion se realizo con exito";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Error al realizar la accion.";


                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> Details(int Dip_Id)
        {
            try
            {
                var listd = await _diputadoService.ObtenerDiputadoMindy(Dip_Id);
                if (listd == null)
                {
                    return NotFound();
                }
                TempData["Exito"] = "La accion se realizo con exito";

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
