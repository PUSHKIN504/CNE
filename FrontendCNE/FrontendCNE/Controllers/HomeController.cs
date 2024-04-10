﻿using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontendCNE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, UsuarioService usuarioService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string Usuario, string Contrasenia)
        {
            string usuario = "";
            int? idrol = 0;

            if (Usuario != null && Contrasenia != null)
            {
                int x = 0;

                int? rol;

                List<string> pantallasPorRol = new List<string>();
                var Claim = new List<Claim>();
                var list = await _usuarioService.Login(Usuario, Contrasenia);
                var lista = list.Data as IEnumerable<UsuarioViewModel>;
                var datos = lista.ToList();
                if (datos.Count > 0)
                {
                    var loginlist = datos.FirstOrDefault();

                    foreach (var item in datos)
                    {
                        HttpContext.Session.SetString("Usua_Id", item.Usuar_Id.ToString());
                        HttpContext.Session.SetString("rolesssss", item.Roles_Id.ToString());
                        HttpContext.Session.SetString("Usuario", item.Usua_Nombre.ToString());
                        pantallasPorRol.Add(item.Pant_Descripcion);
                        if (item.Pant_Descripcion != null)
                        {
                            Claim.Add(new Claim(ClaimTypes.Role, item.Pant_Descripcion));
                        }
                        else
                        {
                            Claim.Add(new Claim(ClaimTypes.Role, "Ninguna Pantalla"));
                        }
                        rol = item.Roles_Id;
                    }

                    if (loginlist.Usuar_Admin == true)
                    {
                        pantallasPorRol.Add("Admin");
                        Claim.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }

                    var ClaimsIdentity = new ClaimsIdentity(Claim, CookieAuthenticationDefaults.AuthenticationScheme);


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                    var pantallasJson = JsonSerializer.Serialize(pantallasPorRol);
                    HttpContext.Session.SetString("Pantallas", pantallasJson);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public async Task<IActionResult> ValidarUsuario(string Usuario)
        {
            var list = await _usuarioService.ValidarUsuario(Usuario);

            return Ok(list.Data);
        }

        public async Task<IActionResult> ValidarClave(string Contrasenia)
        {
            var list = await _usuarioService.ValidarClave(Contrasenia);

            return Ok(list.Data);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}