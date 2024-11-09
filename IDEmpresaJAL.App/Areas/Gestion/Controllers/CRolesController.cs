using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDEmpresaJAL.App.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class CRolesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CRolesController(IContenedorTrabajo contenedorTrabajo)
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


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CRoles croles)
        {

            if (ModelState.IsValid)
            {
                //validar que no se repita el rol
                CRoles rolExiste = new CRoles();
                rolExiste = _contenedorTrabajo.CRol.GetFirstOrDefault(r=> r.Rol == croles.Rol);
                if(rolExiste == null)
                {
                   
                    //logica para guardar en bbdd
                    TempData["msg"] = "Registro exitoso";
                    croles.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    croles.Activo = true;

                    _contenedorTrabajo.CRol.Add(croles);

                    _contenedorTrabajo.Save();
                    return RedirectToAction("Edit", new { croles.Id });
                }
                else
                {
                    TempData["err"] = "error";
                    return View(croles);
                }
                
            }

            return View(croles);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            VMRecurso vmRecursos = new VMRecurso()
            {
                RolesEntity = new IDEmpresaJAL.Entity.Models.CRoles(),
                ListaRecursos = _contenedorTrabajo.CRol.ListaRecursos(id.GetValueOrDefault()),
                RRolRecurso = new IDEmpresaJAL.Entity.Models.RRolRecurso(),

            };

            if (id != null)
            {
                vmRecursos.RolesEntity = _contenedorTrabajo.CRol.GetById(id.GetValueOrDefault());
            }



            return View(vmRecursos);
        }

      


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMRecurso model)
        {

            if (ModelState.IsValid)
            {
                var rol = _contenedorTrabajo.CRol.GetById(model.RolesEntity.Id);
                TempData["msg"] = "Registro exitoso";
                //actualizar rol
                model.RolesEntity.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.RolesEntity.Activo = true;

                _contenedorTrabajo.CRol.Update(model.RolesEntity);

                //actualizar rrolrecurso




                foreach (var item in model.ListaRecursos)
                {

                    int rol_id = model.RolesEntity.Id;
                    int recurso_id = item.Id;


                    if (item.Seleccionado == true)
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                        var rolDesdeDB = _contenedorTrabajo.RolRecurso.GetFirstOrDefault(x => x.RolId == rol_id && x.RecursoId == recurso_id);
                        if (rolDesdeDB == null)
                        {
                            RRolRecurso rRolRecurso = new RRolRecurso();

                            rRolRecurso.RolId = rol_id;
                            rRolRecurso.RecursoId = recurso_id;

                            if (rolDesdeDB == null)
                            {
                                _contenedorTrabajo.RolRecurso.Add(rRolRecurso);
                            }

                        }

                    }
                    else
                    {
                        //validar que ya este en la base de datos
                        //si esta entonces se elimina por completo el registro
                        RRolRecurso rRolRecurso = new RRolRecurso();

                       
                        var rolDesdeDB = _contenedorTrabajo.RolRecurso.GetFirstOrDefault(x => x.RolId == rol_id && x.RecursoId == recurso_id);
                        if (rolDesdeDB != null)
                        {
                            _contenedorTrabajo.RolRecurso.RemoveByEntity(rolDesdeDB);
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
            return Json(new { data = _contenedorTrabajo.CRol.GetAll().Where(c => c.Activo == true) });
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
