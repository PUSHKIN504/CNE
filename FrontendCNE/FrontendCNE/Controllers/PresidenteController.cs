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
    public class PresidenteController : Controller
    {
        
        public PresidenteService _presidenteServicios;
        public VotacionesService _VotacionesService;
        public PersonasServices _personService;
        private readonly IWebHostEnvironment _hostingEnviroment;


        public PresidenteController(PresidenteService presidenteServicios, PersonasServices personasServices, IWebHostEnvironment hostingEnviroment, VotacionesService votacionesService)
        {
            _hostingEnviroment = hostingEnviroment;

            _presidenteServicios = presidenteServicios;
            _VotacionesService = votacionesService;
            _personService = personasServices;


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
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
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
        public async Task<IActionResult> Create(PresidenteVIewModel item)
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


                item.Pre_Id = int.Parse(item.Per_Id);
                item.Pre_ImgUrl = folder;
                item.Pre_UsuarioCreacion = 1;
                item.Pre_FechaCreacion = DateTime.Now;
                item.Pre_Estado = true;
                var list = await _presidenteServicios.CrearPresidente(item); 
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Presidente/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _presidenteServicios.ObtenerPresidente();
                TempData["Exito"] = "La accion se realizo con exito";

                return Json(model.Data);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }
        }

        [HttpPost("Presidente/Edit")]
        public async Task<IActionResult> Edit(PresidenteVIewModel item, int id, string img, int par)
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


                item.Pre_Id = id;
                item.Pre_ImgUrl = folder;
                item.Par_id = par;
                item.Pre_UsuarioModificacion = 1;
                item.Pre_FechaModificacion = DateTime.Now;
                var result = await _presidenteServicios.EditarPresidente(item);
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

        [HttpPost("/Presidente/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            try
            {

                var result = await _presidenteServicios.EliminarPresidente(id);
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
                var listd = await _presidenteServicios.ObtenerPresidenteMindy(Dip_Id);
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
