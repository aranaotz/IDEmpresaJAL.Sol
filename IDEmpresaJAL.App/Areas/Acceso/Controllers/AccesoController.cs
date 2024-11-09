using Azure.Core;
using IDEmpresaJAL.BLL.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.Acceso.Controllers
{
    [Area("Acceso")]
    public class AccesoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IUtilidadesRepository _utilidadesRepository;

        public AccesoController(IContenedorTrabajo contenedorTrabajo, IUtilidadesRepository utilidadesRepository)
        {
            _contenedorTrabajo = contenedorTrabajo;   
            _utilidadesRepository = utilidadesRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(VMLogin model)
        {
            if(ModelState.IsValid)
            {
                
                var usuarioLogin = model.usuario;
                var password_encriptado = _utilidadesRepository.ConvertirSha256(model.password);
                

                TUsuarioGenerales usuarioGenerales = new TUsuarioGenerales();

                usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(g=> g.RFC == usuarioLogin);

                //verificar si el correo esta registrado
                if(usuarioGenerales!=null)
                {
                    var usuarioID = usuarioGenerales.UsuarioId;

                    TUsuarioSeguridad usuarioSeguridad = new TUsuarioSeguridad();
                    usuarioSeguridad = _contenedorTrabajo.TUsuarioSeguridad.GetFirstOrDefault(s => s.UsuarioId == usuarioID);

                    if (usuarioSeguridad.Password == password_encriptado)
                    {
                        //cuando el usuario se ha encontrado
                        ViewData["mensaje"]=null;

                        

                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name,usuarioLogin),
                            new Claim(ClaimTypes.NameIdentifier,usuarioID.ToString()),
                           
                            //new Claim(ClaimTypes.Role,usuarioID.ToString()) //falta asignar roles
                            
                        };

                        ////****ESTA SECCION ESTA COMENTADA POR QUE LOS ROLES SE LEEN DESDE UN VIEWCOMPONENT*****////
                        ///var roles = _contenedorTrabajo.UsuarioRol.GetAll(r => r.UsuarioId == usuarioID);
                        //foreach (var role in roles)
                        //{
                        //    var claim = new Claim(ClaimTypes.Role, role.RolId.ToString());

                        //    claims.Add(claim);
                        //}


                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            AllowRefresh = true, //permite refrescar la pagina sin perder sesion
                           // IsPersistent =true // se utiliza en caso que exista el checkbox de mantener sesion
                        };

                        //registrar todos lo datos de acceso y loggeo
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                        return RedirectToAction("Index", "Home", new { area = "Gestion" });
                    }
                    else
                    {
                        TempData["pass"] = "1";
                    }
                }

                else
                {
                    TempData["user"] = "2";
                }

                


            }
            return View();
        }

        [Route("/acceso/acceso/caducado")]
        [HttpGet]
        public IActionResult Caducado()
        {
            return View();
        }



        [HttpGet]
        [Route("/acceso/acceso/credenciales/{request}")]
        public IActionResult Credenciales(string request)
        {
            
            TUsuarioSeguridadSolicitud usuarioSeguridadSolicitud = new TUsuarioSeguridadSolicitud();

            usuarioSeguridadSolicitud= _contenedorTrabajo.TUsuarioSeguridadSolicitud.GetFirstOrDefault(x=> x.Request == request);

            var usuarioID = usuarioSeguridadSolicitud.UsuarioId;

            var fechaCaducidad = usuarioSeguridadSolicitud.FechaCaducidad;

           if (fechaCaducidad !=null)
            {
                DateTime fechaCaducidadDate = DateTime.ParseExact(fechaCaducidad, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                DateTime fechaActual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                if (fechaActual > fechaCaducidadDate) 
                {
                    return View(nameof(Caducado));
                }
            }

           if(usuarioSeguridadSolicitud.Usada==true)
            {
                return View(nameof(Caducado));
            }

            VMCredenciales vmCredencialesCreadas = new VMCredenciales()
            {
                
                request = request
            };


            return View(vmCredencialesCreadas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Credenciales(VMCredenciales credenciales)
        {
            if(ModelState.IsValid)
            {
                VMCredenciales credencialesCreadas = new VMCredenciales()
                {
                    Password = credenciales.Password,
                    ConfirmPassword = credenciales.ConfirmPassword,
                   
                    request = credenciales.request

                };

                TempData["creado"] = 1;

                TUsuarioSeguridadSolicitud usuarioSeguridadSolicitud = new TUsuarioSeguridadSolicitud();

                usuarioSeguridadSolicitud = _contenedorTrabajo.TUsuarioSeguridadSolicitud.GetFirstOrDefault(x => x.Request == credenciales.request);
                //actualizar el campo usado en TUsuarioSeguridadSolicitud
                usuarioSeguridadSolicitud.Usada = true;
                _contenedorTrabajo.TUsuarioSeguridadSolicitud.Update(usuarioSeguridadSolicitud);


                //logica para guardar password encriptado
                TUsuarioSeguridad usuarioSeguridad = new TUsuarioSeguridad();

                usuarioSeguridad.UsuarioId = usuarioSeguridadSolicitud.UsuarioId;
                var password = _utilidadesRepository.ConvertirSha256(credenciales.Password);
                usuarioSeguridad.Password = password;
                usuarioSeguridad.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                if (usuarioSeguridadSolicitud.Funcion == 1)
                {
                    _contenedorTrabajo.TUsuarioSeguridad.Add(usuarioSeguridad);
                    
                }
                else
                {
                    _contenedorTrabajo.TUsuarioSeguridad.Update(usuarioSeguridad);
                }
                

               TUsuario usuario = new TUsuario();
                
                usuario = _contenedorTrabajo.TUsuario.GetFirstOrDefault(x => x.Id == usuarioSeguridadSolicitud.UsuarioId);

                _contenedorTrabajo.TUsuario.Update(usuario);

                _contenedorTrabajo.Save();

               

                return View(nameof(Login));
            }

            return View(credenciales);
        }

        [HttpGet]
        public IActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recuperar(string usuario)
        {
            if(ModelState.IsValid)
            {
                TUsuarioGenerales usuarioGenerales = new TUsuarioGenerales();
                usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(u=> u.RFC == usuario);
                if (usuarioGenerales != null)
                {
                    var usuarioID = usuarioGenerales.UsuarioId;

                    TUsuarioSeguridadSolicitud usuarioSeguridadSolicitud = new TUsuarioSeguridadSolicitud();
                    usuarioSeguridadSolicitud = _contenedorTrabajo.TUsuarioSeguridadSolicitud.GetFirstOrDefault(s => s.UsuarioId == usuarioID);
                    var request = _utilidadesRepository.ConvertirSha256(usuarioGenerales.RFC + usuarioGenerales.CorreoElectronico);
                    usuarioSeguridadSolicitud.Request = request;
                    usuarioSeguridadSolicitud.FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    DateTime fechaCaducidad = new DateTime();
                    fechaCaducidad = DateTime.Now;
                    usuarioSeguridadSolicitud.FechaCaducidad = fechaCaducidad.AddHours(5).ToString("yyyy-MM-dd hh:mm:ss");
                    usuarioSeguridadSolicitud.Usada = false;
                    usuarioSeguridadSolicitud.Funcion = 2;
                    _contenedorTrabajo.TUsuarioSeguridadSolicitud.Update(usuarioSeguridadSolicitud);
                    _contenedorTrabajo.Save();
                    TempData["recu_ok"] = "ok";
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    TempData["recu_usr"] = "error de usuario";
                }
            }
            TempData["recu_err"] = "modelo no valido";
            return View();
        }

        [Route("/Acceso/Acceso/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode) 
            {
                case 404:
                    ViewBag.ErrorTitle = "Error 404";
                    ViewBag.ErrorMessage = "Lo sentimos, la página a la que deseas acceder no existe";
                    break;
                case 405:
                    ViewBag.ErrorTitle = "No autorizado";
                    ViewBag.ErrorMessage = "Lo sentimos, esta acción no esta permitida.";
                    break;

                default:
                    ViewBag.ErrorTitle = "Error";
                    ViewBag.ErrorMessage = "Lo sentimos, ocurrió un error al procesar la información, favor de contactar al administrador del sistema.";
                    break;
            }
            return View();
        }
    }
}
