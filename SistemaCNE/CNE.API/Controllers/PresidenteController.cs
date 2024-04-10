using AutoMapper;
using CNE.BusinessLogic.Services;
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
    }
}
