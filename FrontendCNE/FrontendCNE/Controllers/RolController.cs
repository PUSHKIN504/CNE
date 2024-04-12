using AutoMapper;
using CNE.Common.Models;
using FrontendCNE.Clases;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class RolController : Controller
    {
        public RolService _RolService;
      
        public RolController( RolService rolService)
        {
            _RolService = rolService;
        }
        [HttpGet("Rol/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<RolViewModel>();
                var list = await _RolService.RolList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }





        [HttpGet("/Rol/Crear")]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = new List<PantallaViewModel>();
                var list = await _RolService.PantallaList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }



       [HttpPost("/Rol/Crear")]
      public async Task<IActionResult> Create([FromBody] FormData formData )
       {

            try
            {
               
                var list = await _RolService.CrearPantallaporRol(formData);
                TempData["Exito"] = "La accion se realizo con exito";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Index");
            }


        
      }






        //[HttpGet("Rol/Actualizar/{id}")]
        //public IActionResult Update(string id)
        //{
        //    var PantallasPorRol = _RolService.RolesPantallaList(id);

        //    var Pantallas = _RolService.PantallaList();

        //    var NombreRol = PantallasPorRol.FirstOrDefault()?.Roles_Descripcion;
        //    var pantallasSeleccionadas = PantallasPorRol.Select(p => (int)p.Pant_Id).ToList();

        //    var rolViewModel = new RolViewModel
        //    {
        //        Roles_Id = Int32.Parse(id),
        //        Roles_Descripcion = NombreRol,
        //        PantallasID = pantallasSeleccionadas,
        //        pantallas = (List<tbPantallas>)Pantallas
        //    };
        //    return View(rolViewModel);

        //}




        //[HttpPost("/Rol/Actualizar")]
        //public JsonResult Edit([FromBody] FormData formData)
        //{
        //    if (string.IsNullOrEmpty(formData.txtRol))
        //    {
        //        ModelState.AddModelError("txtRol", "El nombre del rol es requerido.");
        //    }

        //    var rol = new tbRoles()
        //    {
        //        Rol_Descripcion = formData.txtRol,
        //        Rol_Modificacion = 1,//debe ir el usuario que lo modifico con una sesion
        //        Rol_FechaModificacion = DateTime.Now
        //    };
        //    _acceService.ActualizarRol(rol);
        //    _acceService.EliminarPantallaPorRol(formData.Rol_Id);


        //    foreach (var pantalla in formData.pantallasSeleccionadas)
        //    {
        //        var modelo2 = new tbPantallasPorRol()
        //        {
        //            Pant_Id = pantalla,
        //            Rol_Id = formData.Rol_Id,
        //            PaRo_Modificacion = 1,
        //            PaRo_FechaModificacion = DateTime.Now
        //        };

        //        string msj = _acceService.InsertarPantallasPorRol(modelo2);
        //    }

        //    TempData["Exito"] = "el registro se ha realizado con exito";

        //    return Json(1);
        //    //RedirectToAction("Index");

        //}





        [HttpPost("/Rol/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            try
            {

                var result = await _RolService.EliminarRol(id);
                if (result.Success)
                {
                    TempData["Exito"] = "No se puede eliminar el rol por que tiene dependencias";
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






        [HttpGet("UpdateRol")]
        public async Task<IActionResult> Edit(int Roles_Id)
        {
            try
            {
                var apiUrl = "https://localhost:44377/API/Rol/UpdateRol?Roles_Id=" + Roles_Id; 
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var rolData = JsonConvert.DeserializeObject<RolViewModel>(content);

                        TempData["Exito"] = "Accion exitosa";
                        return View(rolData);
                    }
                    else
                    {
                       
                        return RedirectToAction("Error", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al realizar la accion.";

                return RedirectToAction("Error", "Home");
            }
        }






    }
}
