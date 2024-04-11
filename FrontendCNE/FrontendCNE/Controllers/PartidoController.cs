using CNE.Common.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class PartidoController : Controller
    {
        public PartidoService _partidoService;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public PartidoController(PartidoService partidoService, IWebHostEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;

            _partidoService = partidoService;
        }


    



        //[HttpPost]
        //public async Task<IActionResult> SubirImagen(IFormCollection formData, IFormFile imagen)
        //{
        //    try
        //    {
        //        if (imagen != null && imagen.Length > 0)
        //        {
        //            var Par_Id = formData["Par_Id"];
        //            var extensionDeLaImagen = imagen.FileName.Split('.')[1];
        //            var nombreDeLaImagen = $"Partido_{Par_Id}.{extensionDeLaImagen}";
        //            var rutaCarpeta = Path.Combine(_hostingEnviroment.WebRootPath, "assets", "partidos");
        //            var rutaImagen = Path.Combine(rutaCarpeta, nombreDeLaImagen);
        //            using (var fileStream = new FileStream(rutaImagen, FileMode.Create))
        //            {
        //                await imagen.CopyToAsync(fileStream);
        //            }
        //            var result = await _partidoService.SubirImagen(rutaImagen);
        //            if (System.IO.File.Exists(rutaImagen))
        //            {
        //                System.IO.File.Delete(rutaImagen);
        //            }
        //            return Json(new { message = result.Message, urlImagen = result.Data });
        //        }
        //        else
        //        {
        //            return Json(new { message = "No se recibió ninguna imagen" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { message = "Error al subir la imagen" });
        //    }






        [HttpGet("Partido/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<PartidosViewModel>();
                var list = await _partidoService.PartidoList();
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
        public async Task<IActionResult> Create(PartidosViewModel item)
        {
            try

            {  
                string folder = "images/";
                if(item.FotoP != null) { 
             
                folder +=Guid.NewGuid().ToString()+ "_" + item.FotoP.FileName;

                string serverFolder = Path.Combine(_hostingEnviroment.WebRootPath,folder);

                    await item.FotoP.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                item.Par_ImgUrl = folder;
                item.Par_UsuarioCreacion = 1;
                item.Par_FechaCreacion = DateTime.Now;
                item.Par_Estado = true;
                var list = await _partidoService.CrearPartido(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }
    }
}
