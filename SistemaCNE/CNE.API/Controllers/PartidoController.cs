using AutoMapper;
using CNE.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNE.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class PartidoController : Controller
    {
        private readonly VotacionesServices _votacionesServices;

        private readonly IMapper _mapper;
        public PartidoController(VotacionesServices votacionesServices, IMapper mapper)
        {
            _votacionesServices = votacionesServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _votacionesServices.ListadoPartido();
            return Ok(list);
        }
    }
}
