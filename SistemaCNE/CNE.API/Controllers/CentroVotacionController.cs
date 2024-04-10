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
        public class CentroVotacionController : Controller
        {
            private readonly VotacionesServices _votacionesServices;

            private readonly IMapper _mapper;
            public CentroVotacionController(VotacionesServices  votacionesServices, IMapper mapper)
            {
            _votacionesServices = votacionesServices;
                _mapper = mapper;
            }

            [HttpGet("List")]
            public IActionResult Index()
            {
                var list = _votacionesServices.ListadoCentroVotacion();
                return Ok(list);
            }






            [HttpPost("Create")]
            public IActionResult Insert(CentroVotacionesViewModels item)
            {
                var model = _mapper.Map<tbCentrosVotaciones>(item);
                var modelo = new tbCentrosVotaciones()
                {
                    Mun_Id = item.Mun_Id,
                    CeV_Nombre = item.CeV_Nombre,
                    CeV_UsuarioCreacion = item.CeV_UsuarioCreacion,
                    CeV_FechaCreacion = item.CeV_FechaCreacion,


                };
                var list = _votacionesServices.InsertarCentroVotacion(modelo);
                return Ok(list);
            }



            [HttpGet("Fill/{id}")]

            public IActionResult Llenar(int id)
            {

                var list = _votacionesServices.ListCentroVotacion(id);
                return Json(list);
            }


            [HttpPut("Edit")]
            public IActionResult Update(CentroVotacionesViewModels item)
            {
                _mapper.Map<tbCentrosVotaciones>(item);
                var modelo = new tbCentrosVotaciones()
                {
                    CeV_Id = item.CeV_Id,
                    Mun_Id = item.Mun_Id,
                    CeV_Nombre = item.CeV_Nombre,
                    CeV_UsuarioModificacion = 1,
                    CeV_FechaModificacion = DateTime.Now
                };
                var list = _votacionesServices.EditarCentroVotacion(modelo);
                return Ok(list);
            }

            [HttpDelete("Delete")]
            public IActionResult Delete(int CeV_Id)
            {
                var list = _votacionesServices.EliminarCentroVotacion(CeV_Id);
                return Ok(list);
            }











        }
    }
