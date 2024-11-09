using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class CDireccionesGeneralesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CDireccionesGeneralesController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(CDireccionGeneral direccionGeneral)
        {
            if (ModelState.IsValid)
            {
                //validar que no se repitan los nombres de las direcciones
                direccionGeneral = _contenedorTrabajo.CDireccionGeneral.GetFirstOrDefault(d=> d.NombreDireccion == direccionGeneral.NombreDireccion);
                if(direccionGeneral == null)
                {
                    TempData["msg"] = "Registro guardado correctamente";
                    //logica para guardar en bbdd
                    direccionGeneral.Id = Guid.NewGuid();
                    direccionGeneral.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    direccionGeneral.Activo = true;
                    _contenedorTrabajo.CDireccionGeneral.Add(direccionGeneral);

                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["err"] = "error";
                    return View(direccionGeneral);
                }
            }


            return View(direccionGeneral);
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            CDireccionGeneral direccion = new CDireccionGeneral();
            direccion = _contenedorTrabajo.CDireccionGeneral.GetByGuid(id);

            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CDireccionGeneral direccion)
        {
            if (ModelState.IsValid)
            {
                //logica para actualizar en bbdd
                TempData["msg"] = "Registro actualizado correctamente";
                _contenedorTrabajo.CDireccionGeneral.Update(direccion);

                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }


            return View(direccion);
        }



        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.CDireccionGeneral.GetAll().Where(c => c.Activo == true).OrderBy(o=> o.FechaCreacion ) });
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var objFromDb = _contenedorTrabajo.CDireccionGeneral.GetByGuid(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }

            _contenedorTrabajo.CDireccionGeneral.RemoveByEntity(objFromDb);

            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Registro borrado correctamente" });

        }
        #endregion
    }
}
