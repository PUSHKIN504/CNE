using AutoMapper;
using CNE.BusinessLogic.Services;
using CNE.Common.Models;
using CNE.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNE.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class PartidoController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public PartidoController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoPartido();
            return Ok(list);
        }





        [HttpPost("Create")]
      
        public IActionResult Insert(PartidosViewModel item)
        {
            var model = _mapper.Map<tbPartidos>(item);
            var modelo = new tbPartidos()
            {
                Par_id = item.Par_id,
                Par_Nombre = item.Par_Nombre,
                Par_UsuarioCreacion = item.Par_UsuarioCreacion,
                Par_FechaCreacion = item.Par_FechaCreacion,
                Par_ImgUrl = item.Par_ImgUrl
            };
            var list = _votacionesServices.CrearPartido(modelo);
            return Ok(list);
        }







        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _votacionesServices.ListPartido(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(PartidosViewModel item)
        {
            _mapper.Map<tbAlcaldes>(item);
            var modelo = new tbPartidos()
            {
                Par_id = item.Par_id,
                Par_Nombre = item.Par_Nombre,
                Par_UsuarioModificacion = 1,
                Par_FechaModificacion = DateTime.Now,
                Par_ImgUrl = item.Par_ImgUrl

            };
            var list = _votacionesServices.EditarPartido(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Par_Id)
        {
            var list = _votacionesServices.EliminarPartidos(Par_Id);
            return Ok(list);
        }



    }
}
