using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDEmpresaJAL.App.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class CTipoSolicitantesController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CTipoSolicitantesController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(CTipoSolicitante c_TipoSolicitante)
        {

            if (ModelState.IsValid)
            {
                //validar que no se repita el nombre del tipo de solicitante
                c_TipoSolicitante = _contenedorTrabajo.CTipoSolicitante.GetFirstOrDefault(s=> s.TipoSolicitante == c_TipoSolicitante.TipoSolicitante);
                if(c_TipoSolicitante == null)
                {
                    TempData["msg"] = "Registro guardado correctamente";
                    //logica para guardar en bbdd
                    c_TipoSolicitante.Id = Guid.NewGuid();
                    c_TipoSolicitante.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    c_TipoSolicitante.Activo = true;
                    _contenedorTrabajo.CTipoSolicitante.Add(c_TipoSolicitante);

                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["err"] = "error";
                    return View(c_TipoSolicitante);
                }
                
            }


            return View(c_TipoSolicitante);
        }

        [HttpGet]

        public IActionResult Edit(Guid id)
        {


            CTipoSolicitante cTipoSolicitante = new CTipoSolicitante();
            cTipoSolicitante = _contenedorTrabajo.CTipoSolicitante.GetFirstOrDefault(s => s.Id == id);

            if (cTipoSolicitante == null)
            {
                return NotFound();
            }

            return View(cTipoSolicitante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CTipoSolicitante cTipoSolicitante)
        {
            if (ModelState.IsValid)
            {
                //actualiza
                TempData["msg"] = "Registro actualizado correctamente";
                cTipoSolicitante.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                _contenedorTrabajo.CTipoSolicitante.Update(cTipoSolicitante);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["err"] = "No se pudo editar el registro";
                return View(cTipoSolicitante);
            }


        }



        #region Llamadas a la API (para datables)

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.CTipoSolicitante.GetAll().Where(s => s.Activo == true).OrderBy(s => s.FechaCreacion) });
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var objFromDb = _contenedorTrabajo.CTipoSolicitante.GetByGuid(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }

            _contenedorTrabajo.CTipoSolicitante.RemoveByEntity(objFromDb);

            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Tipo de solicitante borrado correctamente" });

        }


        #endregion

    }
}
