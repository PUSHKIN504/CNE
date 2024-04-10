using AutoMapper;
using CNE.BusinessLogic.Services;
using CNE.Common.Models;
using CNE.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNE.API.Controllers
{

    public class VotacionesController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly VotacionesServices _votacionesServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMapper _mapper;
        public VotacionesController(GeneralServices generalServices, IMapper mapper, VotacionesServices votacionesServices, IHttpContextAccessor httpContextAccessor)
        {
            _generalServices = generalServices;
            _votacionesServices = votacionesServices;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("InfoVotante/{DNI}")]
        public IActionResult List(string DNI)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("DNI", DNI);
            var list = _generalServices.YaVoto(DNI);
            return Json(list);
        }
        [HttpGet("Diputados/List")]
        public IActionResult ListDip()
        {
            var list = _votacionesServices.ListDip();
            return Json(list);
        }
        [HttpGet("Presidentes/List")]
        public IActionResult PreList()
        {
            var list = _votacionesServices.ListadoPresi();
            return Json(list);
        }
        [HttpGet("Alcaldes/List/{DNI}")]
        public IActionResult AlList(string DNI)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("DNI", DNI);
            var list = _votacionesServices.ListAlc(session.GetString("DNI"));
            return Json(list);
        }
        [HttpPost("Voto/Create")]
        public IActionResult Insert(VotoViewModel item,List<int> listaEnteros)
        {
            var model = _mapper.Map<tbVotos>(item);
            var modelo = new tbVotos()
            {
                dni = item.dni,
                Pre_Id = item.Pre_Id,
                Mes_Id = item.Mes_Id,
                Alc_Id = item.Alc_Id,
            };
            var list = _votacionesServices.InsertarVoto(modelo);

            GuardarDiputados(listaEnteros);
            return Ok(list);
        }

        [HttpPost("Diputados/Create")]
        public void GuardarDiputados(List<int> diputadosSeleccionados)
        {
            // Aquí puedes acceder a los IDs de los diputados seleccionados
            // Realiza el procesamiento necesario con los diputados seleccionados
            // por ejemplo:
            
            foreach (var id in diputadosSeleccionados)
            {
                 var list = _votacionesServices.InsertarVotoD(id);
            }

            // Devolver una respuesta (por ejemplo, un mensaje de éxito)
        }
    }
}
