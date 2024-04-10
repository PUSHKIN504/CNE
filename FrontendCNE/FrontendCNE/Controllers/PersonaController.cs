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
    public class PersonaController : Controller
    {
        public PersonasServices _personasServices;
        private readonly IMapper _mapper;

        public PersonaController(PersonasServices personasServices )
        {
            _personasServices = personasServices;
        }
        [HttpGet("Persona/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<PersonasViewModel>();
                var list = await _personasServices.ObtenerPersonasList();
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
        public async Task<IActionResult> Create(PersonasViewModel item)
        {
            try
            {
                item.Per_UsuarioCreacion = 1;
                item.Per_FechaCreacion = DateTime.Now;
                item.Per_Estado = true;
                var list = await _personasServices.CrearPersona(item);
                return RedirectToAction("Index");
                //return View(new List<PersonasViewModel> { (PersonasViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }


        [HttpGet("Persona/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _personasServices.ObtenerPersona();
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("Persona/Edit")]
        public async Task<IActionResult> Edit(PersonasViewModel item, int id, string Identidad, string Nombre, string Apellido, DateTime Nacimiento , string Sexo, string direcc, string mun
            , string telefo, int mesa, int idmes, int estadadoC)
        {
            try
            {
                item.Per_Id = id;
                item.EsC_Id = estadadoC;
                item.Per_CedulaIdentidad = Identidad;
                item.Per_Nombre = Nombre;
                item.Per_Apellido = Apellido;
                item.Per_FechaNacimiento = Nacimiento;
                item.Per_Sexo = Sexo;
                item.Per_Direccion = direcc;
                item.Mun_Id = mun;
                item.Per_Telefono = telefo;
                item.Mes_Mesa = mesa;
                item.Mes_Id = idmes;
                item.Per_UsuarioModificacion = 1;
                item.Per_FechaModificacion = DateTime.Now;
                var result = await _personasServices.EditarPersona(item);
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

        [HttpPost("/Persona/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _personasServices.EliminarPersona(id);
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


        public async Task<IActionResult> Details(int Per_Id)
        {
            try
            {
                var listd = await _personasServices.ObtenerPersonaMindy(Per_Id);
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
