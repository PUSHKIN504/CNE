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
    public class EstadoCivilController : Controller
    {
        private readonly GeneralServices _generalServices;

        private readonly IMapper _mapper;
        public EstadoCivilController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _generalServices.ListadoEstadoCivil();
            return Ok(list);
        }



        [HttpPost("Create")]
        public IActionResult Insert(EstadoCivilViewModel item)
        {
            var model = _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                EsC_Id  = item.EsC_Id ,
                EsC_Descripcion = item.EsC_Descripcion,
                EsC_UsuarioCreacion = item.EsC_UsuarioCreacion,
                EsC_FechaCreacion = item.EsC_FechaCreacion,
            };
            var list = _generalServices.InsertarEstadoCivil(modelo);
            return Ok(list);
        }



        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _generalServices.ListEstadoCivil(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(EstadoCivilViewModel item)
        {
            _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                EsC_Id = item.EsC_Id,
                EsC_Descripcion = item.EsC_Descripcion,
                EsC_UsuarioModificacion = 1,
                EsC_FechaModificacion = DateTime.Now
            };
            var list = _generalServices.EditarEstadoCivil(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var list = _generalServices.EliminarEstadoCivil(id);
            return Ok(list);
        }













    }
}
