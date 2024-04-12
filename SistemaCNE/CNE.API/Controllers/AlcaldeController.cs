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
    public class AlcaldeController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public AlcaldeController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoAlcalde();
            return Ok(list);
        }





        [HttpPost("Create")]

        public IActionResult Insert(AlcaldeViewModel item)
        {
            var model = _mapper.Map<tbAlcaldes>(item);
            var modelo = new tbAlcaldes()
            {
                Alc_Id = item.Alc_Id,
                Alc_ImgUrl = item.Alc_ImgUrl,
                Alc_UsuarioCreacion = item.Alc_UsuarioCreacion,
                Alc_FechaCreacion = item.Alc_FechaCreacion,
                Par_id = item.Par_id


            };
            var list = _votacionesServices.CrearAlcalde(modelo);
            return Ok(list);
        }




        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _votacionesServices.ListAlcalde(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(AlcaldeViewModel item)
        {
            _mapper.Map<tbAlcaldes>(item);
            var modelo = new tbAlcaldes()
            {
                Alc_Id= item.Alc_Id,
                Alc_ImgUrl = item.Alc_ImgUrl,
                Par_id = item.Par_id,
                Alc_UsuarioModificacion = 1,
                Alc_FechaModificacion = DateTime.Now
            };
            var list = _votacionesServices.EditarAlcaldel(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Alc_Id)
        {
            var list = _votacionesServices.EliminarAlcalde(Alc_Id);
            return Ok(list);
        }
        [HttpGet("ListCh")]
                public IActionResult listC()
                {
                    var list = _votacionesServices.ListAlcChart();
                    return Ok(list);
                }







    }
}
