using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class AlcaldeController : Controller
    {
        public AlcaldeService _alcaldeService;
        public AlcaldeController(AlcaldeService alcaldeService)
        {
            _alcaldeService = alcaldeService;
        }
        [HttpGet("Alcalde/")]

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<AlcaldeViewModel>();
                var list = await _alcaldeService.AlcaldeList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
