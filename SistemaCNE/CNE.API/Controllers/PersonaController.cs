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
    public class PersonaController : Controller
    {
        private readonly GeneralServices _generalServices;

        private readonly IMapper _mapper;
        public PersonaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _generalServices.Listadopersona();
            return Ok(list);
        }






        [HttpPost("Create")]
        public IActionResult Insert(PersonaViewModel item)
        {
            var model = _mapper.Map<tbPersonas>(item);
            var modelo = new tbPersonas()
            {
                Per_CedulaIdentidad = item.Per_CedulaIdentidad,
                Per_Nombre = item.Per_Nombre,
                Per_Apellido = item.Per_Apellido,
                Per_FechaNacimiento = item.Per_FechaNacimiento,
                Per_Sexo = item.Per_Sexo,
                Per_Direccion = item.Per_Direccion,
                Mun_Id = item.Mun_Id,
                Per_Telefono = item.Per_Telefono,
                Mes_Id =item.Mes_Id,


                EsC_Id = item.EsC_Id,
                Per_UsuarioCreacion = 1,
                Per_FechaCreacion = DateTime.Now
           
        };
            var list = _generalServices.Insertarpersona(modelo);
            return Ok(list);
        }



        [HttpGet("Fill/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _generalServices.Listpersona(id);
            return Json(list);
        }


        [HttpPut("Edit")]
        public IActionResult Update(PersonaViewModel item)
        {
            _mapper.Map<tbPersonas>(item);
            var modelo = new tbPersonas()
            {
                Per_CedulaIdentidad = item.Per_CedulaIdentidad,
                Per_Nombre = item.Per_Nombre,
                Per_Apellido = item.Per_Apellido,
                Per_FechaNacimiento = item.Per_FechaNacimiento,
                Per_Sexo = item.Per_Sexo,
                Per_Direccion = item.Per_Direccion,
                Mun_Id = item.Mun_Id,
                Per_Telefono = item.Per_Telefono,
                Mes_Mesa = item.Mes_Mesa,
                Mes_Id = item.Mes_Id,

                EsC_Id = item.EsC_Id,
                Per_UsuarioModificacion = 1,
                Per_FechaModificacion = DateTime.Now
            };
            var list = _generalServices.Editarpersona(modelo);
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Per_Id)
        {
            var list = _generalServices.EliminarPersona(Per_Id);
            return Ok(list);
        }













    }
}
