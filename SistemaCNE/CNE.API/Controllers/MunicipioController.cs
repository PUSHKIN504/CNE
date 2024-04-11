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
    public class MunicipioController : Controller
    {
        private readonly GeneralServices _generalServices;

        private readonly IMapper _mapper;
        public MunicipioController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _generalServices.ListadoMunicipio();
            return Ok(list);
        }






        [HttpPost("Create")]
        public IActionResult Insert(MunicipioViewModel item)
        {
            var model = _mapper.Map<tbMunicipios>(item);
            var modelo = new tbMunicipios()
            {
                Mun_Id = item.Mun_Id,
                Mun_Descripcion = item.Mun_Descripcion,
                Dep_Id = item.Dep_Id,
                Mun_UsuarioCreacion = item.Mun_UsuarioCreacion,
                Mun_FechaCreacion = item.Mun_FechaCreacion,
            };
            var list = _generalServices.InsertarMunicipio(modelo);
            return Ok(list);
        }



        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(String id)
        {

            var list = _generalServices.ListMunicipio(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(MunicipioViewModel item)
        {
            _mapper.Map<tbMunicipios>(item);
            var modelo = new tbMunicipios()
            {
                Mun_Id = item.Mun_Id,
                Mun_Descripcion = item.Mun_Descripcion,
                Dep_Id = item.Dep_Id,
                Mun_UsuarioModificacion = 1,
                Mun_FechaModificacion = DateTime.Now
            };
            var list = _generalServices.EditarMunicipio(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string Mun_Id)
        {
            var list = _generalServices.EliminarMunicipio(Mun_Id);
            return Ok(list);
        }




        [HttpGet("Depto")]
        public async Task<IActionResult> ListaDepto()
        {
            var result = await _generalServices.ObtenerDepto();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(500, new { message = result.Message });
            }
        }









    }
}
