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
    public class PantallaController : Controller
    {
        private readonly AccesoServices _AccesoServices;

        private readonly IMapper _mapper;
        public PantallaController(AccesoServices AccesoServices, IMapper mapper)
        {
            _AccesoServices = AccesoServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _AccesoServices.ListadoPatalla();
            return Ok(list);
        }

    }
}
