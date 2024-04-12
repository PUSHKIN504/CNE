using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService, RolService rolService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("Usuario/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<UsuarioViewModel>();
                var list = await _usuarioService.UsuarioList();
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
        public async Task<IActionResult> Create(UsuarioViewModel item)
        {
            try
            {

                item.Usuar_UsuarioCreacion = 1;
                item.Usuar_FechaCreacion = DateTime.Now;
                item.Usuar_Estado = true;
                var list = await _usuarioService.CrearUsuario(item);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return View(item);
            }
        }


        [HttpGet("Usuario/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _usuarioService.ObtenerUsuario();
                TempData["Exito"] = "La accion se realizo con exito";

                return Json(model.Data);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }
        }

        [HttpPost("Usuario/Edit")]
        public async Task<IActionResult> Edit(UsuarioViewModel item, int Usuar_Id, string Usuar_Usuario, int Roles_Id)
        {
            try
            {
                item.Usuar_Id = Usuar_Id;
                item.Usuar_Usuario = Usuar_Usuario;
                item.Roles_Id = Roles_Id;

                item.Usuar_UsuarioCreacion = 1;
                item.Usuar_FechaCreacion = DateTime.Now;
                var result = await _usuarioService.EditarUsuario(item);
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










        [HttpPost("Usuario/EditC")]
        public async Task<IActionResult> EditC(UsuarioViewModel item, int Usuar_Id, string Usuar_Contrasena)
        {
            try
            {
                item.Usuar_Id = Usuar_Id;
                item.Usuar_Contrasena = Usuar_Contrasena;

                var result = await _usuarioService.EditarUsuarioC(item);
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


        [HttpPost("/Usuario/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            try
            {

                var result = await _usuarioService.EliminarUsuario(id);
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


        public async Task<IActionResult> Details(int Usuar_Id)
        {
            try
            {
                var listd = await _usuarioService.ObtenerUsuarioMindy(Usuar_Id);
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
