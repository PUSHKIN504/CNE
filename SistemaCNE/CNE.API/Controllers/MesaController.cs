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
    public class MesaController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public MesaController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoMesas();
            return Ok(list);
        }






        [HttpPost("Create")]
        public IActionResult Insert(MesaViewModel item)
        {
            var model = _mapper.Map<tbMesas>(item);
            var modelo = new tbMesas()
            {
                Mes_Jurado = item.Mes_Jurado,
                Mes_Custodio1 = item.Mes_Custodio1,
                Mes_Custodio2 = item.Mes_Custodio2,
                Mes_UsuarioCreacion = item.Mes_UsuarioCreacion,
                Mes_FechaCreacion = item.Mes_FechaCreacion,


            };
            var list = _votacionesServices.InsertarMesa(modelo);
            return Ok(list);
        }



        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _votacionesServices.ListMesa(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(MesaViewModel item)
        {
            _mapper.Map<tbMesas>(item);
            var modelo = new tbMesas()
            {
                Mes_Id = item.Mes_Id,
                Mes_Jurado = item.Mes_Jurado,
                Mes_Custodio1 = item.Mes_Custodio1,

                Mes_Custodio2 = item.Mes_Custodio2,
                Mes_UsuarioModificacion = 1,
                Mes_FechaModificacion = DateTime.Now
            };
            var list = _votacionesServices.EditarMesa(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int CeV_Id)
        {
            var list = _votacionesServices.EliminarMesa(CeV_Id);
            return Ok(list);
        }











    }
}
