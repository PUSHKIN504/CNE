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
    public class AlcaldeController : Controller
    {
        public AlcaldeService _alcaldeService;
        public PersonasServices _personService;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public AlcaldeController(AlcaldeService alcaldeService,PersonasServices personasServices, IWebHostEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;

            _alcaldeService = alcaldeService;
            _personService = personasServices;
        }
        [HttpGet("Alcalde/")]

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

                var model = new List<AlcaldeViewModel>();
                var list = await _alcaldeService.AlcaldeList();
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
        public async Task<IActionResult> Create(AlcaldeViewModel item)
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

             
                item.Alc_Id = int.Parse(item.Per_Id);
                item.Alc_ImgUrl = folder;
                item.Alc_UsuarioCreacion = 1;
                item.Alc_FechaCreacion = DateTime.Now;
                item.Alc_Estado = true;
                var list = await _alcaldeService.CrearAlcalde(item);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Alcalde/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _alcaldeService.ObtenerAlcalde();
                TempData["Exito"] = "La accion se realizo con exito";

                return Json(model.Data);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }
        }

        [HttpPost("Alcalde/Edit")]
        public async Task<IActionResult> Edit(AlcaldeViewModel item, int id, string img, int par)
        {
            try
            {

                item.Alc_Id = id;
                item.Alc_ImgUrl = img;
                item.Par_id = par;
                item.Alc_UsuarioModificacion = 1;
                item.Alc_FechaModificacion = DateTime.Now;
                var result = await _alcaldeService.EditarAlcalde(item);
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

        [HttpPost("/Alcalde/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            try
            {

                var result = await _alcaldeService.EliminarAlcalde(id);
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


        public async Task<IActionResult> Details(int Alc_Id)
        {
            try
            {
                var listd = await _alcaldeService.ObtenerAlcaldeMindy(Alc_Id);
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
