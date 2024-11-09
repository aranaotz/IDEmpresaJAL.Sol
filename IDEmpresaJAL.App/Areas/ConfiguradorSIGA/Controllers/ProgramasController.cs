using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.ConfiguradorSIGA.Controllers
{
    [Area("ConfiguradorSIGA")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class ProgramasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProgramasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //obtener el usuario id para saber a que direccion pertenece
            ClaimsPrincipal claimUser = HttpContext.User;
            string usuarioId = "";
            if (claimUser.Identity.IsAuthenticated)
            {
                usuarioId = claimUser.Claims
               .Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();
            }

            TUsuarioGenerales usuarioGenerales = new TUsuarioGenerales();
            usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(x => x.UsuarioId == Guid.Parse(usuarioId));

            var direccionGeneralId = usuarioGenerales.DireccionGeneralId;
            VMProgramas programasvm = new VMProgramas()
            {
                Programas = new IDEmpresaJAL.Entity.Models.TProgramas(),
                ListaTipoPrograma = _contenedorTrabajo.CTipoPrograma.GetTipoPrograma(),
                ListaDireccionesGenerales = _contenedorTrabajo.CDireccionGeneral.GetListaDireccionesPrograma(direccionGeneralId),
                ListaBanca = _contenedorTrabajo.CBanca.GetListaBanca()
            };

            return View(programasvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMProgramas programaCreado)
        {
            if(ModelState.IsValid)
            {
                TempData["msg"] = "Registro guardado correctamente";

              
                

                programaCreado.Programas.Id = Guid.NewGuid();
                programaCreado.Programas.SistemaId = 1;
                programaCreado.Programas.Anio= DateTime.Now.Year.ToString();
                programaCreado.Programas.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                programaCreado.Programas.EstatusProgramaId = 1;

                _contenedorTrabajo.TProgramas.Add(programaCreado.Programas);

                _contenedorTrabajo.Save();
               

                return RedirectToAction("Index");
            }
            else
            {
                return View(programaCreado);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            //obtener el usuario id para saber a que direccion pertenece
            ClaimsPrincipal claimUser = HttpContext.User;
            string usuarioId = "";
            if (claimUser.Identity.IsAuthenticated)
            {
                usuarioId = claimUser.Claims
               .Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();
            }

            TUsuarioGenerales usuarioGenerales = new TUsuarioGenerales();
            usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(x => x.UsuarioId == Guid.Parse(usuarioId));

            var direccionGeneralId = usuarioGenerales.DireccionGeneralId;

            VMProgramas programavm = new VMProgramas()
            {
                Programas = new IDEmpresaJAL.Entity.Models.TProgramas(),
                ListaTipoPrograma = _contenedorTrabajo.CTipoPrograma.GetTipoPrograma(),
                ListaDireccionesGenerales = _contenedorTrabajo.CDireccionGeneral.GetListaDireccionesPrograma(direccionGeneralId),
                ListaBanca = _contenedorTrabajo.CBanca.GetListaBanca()
            };

            if (id != null)
            {
                programavm.Programas = _contenedorTrabajo.TProgramas.GetFirstOrDefault(x=> x.Id == id);

                switch(programavm.Programas.EstatusProgramaId)
                {
                    case 2:
                        TempData["errEdit"] = "err";
                        return RedirectToAction("Index");
                    case 4:
                        TempData["errAprob"] = "err";
                        return RedirectToAction("Index");

                }
               
            }

            return View(programavm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMProgramas model)
        {
            if(ModelState.IsValid)
            {
              
                TempData["msg"] = "Registro exitoso";
                model.Programas.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                _contenedorTrabajo.TProgramas.Update(model.Programas);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Componentes(Guid id)
        {
            TProgramas programas = _contenedorTrabajo.TProgramas.GetFirstOrDefault(x => x.Id == id);
            switch (programas.EstatusProgramaId)
            {
                case 2:
                    TempData["errEdit"] = "err";
                    return RedirectToAction("Index");
                case 4:
                    TempData["errAprob"] = "err";
                    return RedirectToAction("Index");

            }
            TempData["pId"] = id;
            return View();

        }

        [HttpGet]
        public IActionResult AddComponente(Guid id)
        {
            TempData["pId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComponente(TProgramasPartidas componenteCreado)
        {
            if (ModelState.IsValid)
            {
                //guardar en bbdd
                componenteCreado.Id = Guid.NewGuid();
                componenteCreado.MontoDisponible = componenteCreado.Monto;
                _contenedorTrabajo.TProgramasPartidas.Add(componenteCreado);
                _contenedorTrabajo.Save();
                return RedirectToAction("Componentes", new { id = componenteCreado.ProgramaId });
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditComponente(Guid id)
        {
            TProgramasPartidas partidas = new TProgramasPartidas();
            partidas= _contenedorTrabajo.TProgramasPartidas.GetByGuid(id);
            TempData["pId"] = partidas.ProgramaId;
            return View(partidas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditComponente(TProgramasPartidas model)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.TProgramasPartidas.Update(model);
                _contenedorTrabajo.Save();
                return RedirectToAction("Componentes", new { id = model.ProgramaId });
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult VoBoArea(Guid id)
        {

            var objFromDb = _contenedorTrabajo.TProgramas.GetByGuid(id);
            if (objFromDb != null)
            {
                objFromDb.VoBoArea = true;
                objFromDb.EstatusProgramaId = 2;
                _contenedorTrabajo.TProgramas.UpdateVoBo(objFromDb);
                _contenedorTrabajo.Save();
            }
            return Json(new { success = true, message = "OK" });
        }

        [HttpGet]
        public IActionResult VoBoPlaneacion()
        {
            return View();
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            //obtener el usuario id para saber a que direccion pertenece
            ClaimsPrincipal claimUser = HttpContext.User;
            string usuarioId = "";
            if (claimUser.Identity.IsAuthenticated)
            {
                usuarioId = claimUser.Claims
               .Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();
            }

            TUsuarioGenerales usuarioGenerales = new TUsuarioGenerales();
            usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(x => x.UsuarioId == Guid.Parse(usuarioId));

            var direccionGeneralId = usuarioGenerales.DireccionGeneralId;
            return Json(new { data = _contenedorTrabajo.TProgramas.GetAll().Where(x=> x.DireccionGeneralId == direccionGeneralId ) });
        }


        [HttpGet]
        public IActionResult GetAllComponentes(Guid id)
        {
            return Json(new { data = _contenedorTrabajo.TProgramasPartidas.GetAll().Where( x=> x.ProgramaId == id) });
        }

        [HttpGet]
        public IActionResult GetAllVobo()
        {
            //obtener el usuario id para saber a que direccion pertenece
            ClaimsPrincipal claimUser = HttpContext.User;
            string usuarioId = "";
            if (claimUser.Identity.IsAuthenticated)
            {
                usuarioId = claimUser.Claims
               .Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();
            }

            RUsuarioRol rol = new RUsuarioRol();
            rol = _contenedorTrabajo.UsuarioRol.GetFirstOrDefault(x => x.UsuarioId == Guid.Parse(usuarioId));
            if(rol.RolId == 1)
            {

                return Json(new { data = _contenedorTrabajo.TProgramas.GetAll().Where(x => x.EstatusProgramaId == 2 || x.EstatusProgramaId ==4 ) });
            }
            
            return NotFound();
           
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.CRol.GetById(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }

            _contenedorTrabajo.CRol.UpdateDelete(objFromDb);

            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Registro borrado correctamente" });

        }

        [HttpDelete]
        public IActionResult DeleteComponente(Guid id)
        {
            var objFromDb = _contenedorTrabajo.TProgramasPartidas.GetByGuid(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }
            _contenedorTrabajo.TProgramasPartidas.RemoveByEntity(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Registro borrado correctamente" });
        }


        #endregion

    }
}
