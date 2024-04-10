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
    public class DepartamentoController : Controller
    {


        private readonly GeneralServices _generalServices;

        private readonly IMapper _mapper;
        public DepartamentoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _generalServices.ListadoDepartamentos();
            return Ok(list);
        }






        [HttpPost("Create")]
        public IActionResult Insert(DepartamentoViewModel item)
        {
            var model = _mapper.Map<tbDepartamentos>(item);
            var modelo = new tbDepartamentos()
            {
                Dep_Id = item.Dep_Id,
                Dep_Descripcion = item.Dep_Descripcion,
                Dep_UsuarioCreacion = item.Dep_UsuarioCreacion,
                Dep_FechaCreacion = item.Dep_FechaCreacion,
            };
            var list = _generalServices.InsertarDepto(modelo);
            return Ok(list);
        }



        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(string id)
        {

            var list = _generalServices.ListDepto(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(DepartamentoViewModel item)
        {
            _mapper.Map<tbDepartamentos>(item);
            var modelo = new tbDepartamentos()
            {
                Dep_Id = item.Dep_Id,
                Dep_Descripcion = item.Dep_Descripcion,
                Dep_UsuarioModificacion = 1,
                Dep_FechaModificacion = DateTime.Now
            };
            var list = _generalServices.EditarDepto(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string Dep_Id)
        {
            var list = _generalServices.EliminarDepto(Dep_Id);
            return Ok(list);
        }




    }
}

