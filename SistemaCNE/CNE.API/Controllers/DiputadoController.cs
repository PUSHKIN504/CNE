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
    public class DiputadoController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public DiputadoController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoDiputado();
            return Ok(list);
        }



        [HttpPost("Create")]

        public IActionResult Insert(DiputadoViewModel item)
        {
            var model = _mapper.Map<tbDiputados>(item);
            var modelo = new tbDiputados()
            {
                Dip_Id = item.Dip_Id,

                Dip_ImgUrl = item.Dip_ImgUrl,
                Dip_UsuarioCreacion = item.Dip_UsuarioCreacion,
                Dip_FechaCreacion = item.Dip_FechaCreacion,
                Par_id = item.Par_id

            };
            var list = _votacionesServices.CrearDiputado(modelo);
            return Ok(list);
        }




        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _votacionesServices.ListDiputado(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(DiputadoViewModel item)
        {
            _mapper.Map<tbDiputados>(item);
            var modelo = new tbDiputados()
            {
                Dip_Id = item.Dip_Id,
                Dip_ImgUrl = item.Dip_ImgUrl,
                Par_id = item.Par_id,
                Dip_UsuarioModificacion = 1,
                Dip_FechaModificacion = DateTime.Now
            };
            var list = _votacionesServices.EditarDiputadol(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Dip_Id)
        {
            var list = _votacionesServices.EliminarAlcalde(Dip_Id);
            return Ok(list);
        }





    }
}
