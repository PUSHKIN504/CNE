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
    public class PresidenteController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public PresidenteController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoPresi();
            return Ok(list);
        }










        [HttpPost("Create")]

        public IActionResult Insert(PresidenteViewModel item)
        {
            var model = _mapper.Map<tbPresidentes>(item);
            var modelo = new tbPresidentes()
            {
                Pre_Id = item.Pre_Id,

                Pre_ImgUrl = item.Pre_ImgUrl,
                Pre_UsuarioCreacion = item.Pre_UsuarioCreacion,
                Pre_FechaCreacion = item.Pre_FechaCreacion,
                Par_id = item.Par_id

            };
            var list = _votacionesServices.CrearPresi(modelo);
            return Ok(list);
        }




        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _votacionesServices.ListAlcalde(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(PresidenteViewModel item)
        {
            _mapper.Map<tbPresidentes>(item);
            var modelo = new tbPresidentes()
            {
                Pre_Id = item.Pre_Id,
                Pre_ImgUrl = item.Pre_ImgUrl,
                Par_id = item.Par_id,
                Pre_UsuarioModificacion = 1,
                Pre_FechaModificacion = DateTime.Now
            };
            var list = _votacionesServices.EditarPresi(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Pre_Id)
        {
            var list = _votacionesServices.EliminarPresi(Pre_Id);
            return Ok(list);
        }




    }
}
