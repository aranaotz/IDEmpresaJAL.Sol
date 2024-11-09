using IDEmpresaJAL.App.Models;
using IDEmpresaJAL.Entity.TempData;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Salir()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Acceso", new { area = "Acceso" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("~/Gestion/Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
           if(statusCode == 404)
            {

            }

           return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
