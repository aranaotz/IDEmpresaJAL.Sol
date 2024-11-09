using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.ConfiguradorSIGA.Controllers
{
    [Area("ConfiguradorSIGA")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
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
            VMCategoriaSolicitante categoriaSolicitantevm = new VMCategoriaSolicitante()
            {
                CategoriaEntity = new IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA(),
                CategoriaSolicitanteEntity = new IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA_TipoSolicitantes(),
                ListaSolicitante = _contenedorTrabajo.CCategorias.ListaSolicitantes(Guid.Empty)

            };

            return View(categoriaSolicitantevm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMCategoriaSolicitante categoriaCreada)
        {
            if (ModelState.IsValid) 
            {
                TempData["msg"] = "Registro exitoso";
                //guardar la categoria
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

                categoriaCreada.CategoriaEntity.Id= Guid.NewGuid(); 
                categoriaCreada.CategoriaEntity.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                categoriaCreada.CategoriaEntity.Activo = true;
                categoriaCreada.CategoriaEntity.DireccionId = direccionGeneralId;
                _contenedorTrabajo.CCategorias.Add(categoriaCreada.CategoriaEntity);

                foreach (var item in categoriaCreada.ListaSolicitante) 
                {
                    Guid solicitanteId = item.Id;
                    Guid categoriaId = categoriaCreada.CategoriaEntity.Id;
                    if(item.Seleccionado == true)
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                        var categoriaExiste = _contenedorTrabajo.CCategoriasTipoSolicitante.GetFirstOrDefault(x=> x.TipoSolicitanteId == solicitanteId && x.CategoriaId == categoriaId);
                        if(categoriaExiste == null)
                        {
                            CCategoriasApoyoSIGA_TipoSolicitantes catsolicitante =  new CCategoriasApoyoSIGA_TipoSolicitantes();
                            catsolicitante.TipoSolicitanteId = solicitanteId;
                            catsolicitante.CategoriaId = categoriaId;
                            _contenedorTrabajo.CCategoriasTipoSolicitante.Add(catsolicitante);
                        }
                    }
                    else
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                        var categoriaExiste = _contenedorTrabajo.CCategoriasTipoSolicitante.GetFirstOrDefault(x => x.TipoSolicitanteId == solicitanteId && x.CategoriaId == categoriaId);
                        if(categoriaExiste != null)
                        {
                            _contenedorTrabajo.CCategoriasTipoSolicitante.RemoveByEntity(categoriaExiste);
                        }
                    }
                }

                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(categoriaCreada);   
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            VMCategoriaSolicitante categoriavm = new VMCategoriaSolicitante() 
            { 
                CategoriaEntity = new IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA(),
                CategoriaSolicitanteEntity = new IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA_TipoSolicitantes(),
                ListaSolicitante = _contenedorTrabajo.CCategorias.ListaSolicitantes(id)
            
            };
            categoriavm.CategoriaEntity = _contenedorTrabajo.CCategorias.GetFirstOrDefault(c => c.Id == id);


            return View(categoriavm);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMCategoriaSolicitante model)
        {
            if(ModelState.IsValid)
            {
                var categoria = _contenedorTrabajo.CCategorias.GetFirstOrDefault(x=> x.Id == model.CategoriaEntity.Id);
                model.CategoriaEntity.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                if(model.CategoriaEntity.TieneEmpleados==false)
                {
                    model.CategoriaEntity.EmpleadosMin = 0;
                    model.CategoriaEntity.EmpleadosMax = 0;
                    model.CategoriaEntity.TieneEmpleados = false;
                }
                _contenedorTrabajo.CCategorias.Update(model.CategoriaEntity);

                foreach(var item in model.ListaSolicitante)
                {
                    Guid solicitanteId = item.Id;
                    Guid categoriaId = model.CategoriaEntity.Id;
                    if (item.Seleccionado == true)
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                        var categoriaExiste = _contenedorTrabajo.CCategoriasTipoSolicitante.GetFirstOrDefault(x => x.TipoSolicitanteId == solicitanteId && x.CategoriaId == categoriaId);
                        if (categoriaExiste == null)
                        {
                            CCategoriasApoyoSIGA_TipoSolicitantes catsolicitante = new CCategoriasApoyoSIGA_TipoSolicitantes();
                            catsolicitante.TipoSolicitanteId = solicitanteId;
                            catsolicitante.CategoriaId = categoriaId;
                            _contenedorTrabajo.CCategoriasTipoSolicitante.Add(catsolicitante);
                        }
                    }
                    else
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                        var categoriaExiste = _contenedorTrabajo.CCategoriasTipoSolicitante.GetFirstOrDefault(x => x.TipoSolicitanteId == solicitanteId && x.CategoriaId == categoriaId);
                        if (categoriaExiste != null)
                        {
                            _contenedorTrabajo.CCategoriasTipoSolicitante.RemoveByEntity(categoriaExiste);
                        }
                    }
                }
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.CCategorias.GetAll().Where(c => c.Activo == true) });
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
        #endregion

    }
}
