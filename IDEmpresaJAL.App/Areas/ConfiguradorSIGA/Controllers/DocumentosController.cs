using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Areas.ConfiguradorSIGA.Controllers
{
    [Area("ConfiguradorSIGA")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class DocumentosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public DocumentosController(IContenedorTrabajo contenedorTrabajo)
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
            usuarioGenerales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(x=> x.UsuarioId == Guid.Parse(usuarioId));

            var direccionGeneralId = usuarioGenerales.DireccionGeneralId;

            CDireccionGeneral cDireccionGeneral = new CDireccionGeneral();
            cDireccionGeneral = _contenedorTrabajo.CDireccionGeneral.GetFirstOrDefault(x=> x.Id == direccionGeneralId);


            //**convertir el guid a string y extraer los ultimos 12 caracteres para compararlo
            var convert = direccionGeneralId.ToString();
            string substring = convert[^12..];

            bool tiene_programas;

            switch(substring.ToUpper())
            {
                case "0B4B2C55D3B1" or "BD4100A5AF6D":
                    //direccion juridica y planeacion
                    tiene_programas =false;
                    break;
                default:
                    //direcciones con programas a cargo
                    tiene_programas=true;
                    break;
            }


            VMCDocumentos documentosvm = new VMCDocumentos()
            {
                Documentos = new IDEmpresaJAL.Entity.Models.CDocumentos(),
               
                DireccionGeneralId = cDireccionGeneral.Id,
                ListaTipoDocumento = _contenedorTrabajo.CDocumentosTipo.GetListaTipoDocumento(tiene_programas),
                ListaTipoCarga = _contenedorTrabajo.CDocumentosTipoCarga.GetListaTipoCarga()
                
            };


            return View(documentosvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMCDocumentos documentoCreado)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bbdd
                TempData["msg"] = "Ok";

                VMCDocumentos vMCDocumentos = new VMCDocumentos()
                {
                    DireccionGeneralId = documentoCreado.DireccionGeneralId
                };

                documentoCreado.Documentos.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                documentoCreado.Documentos.Activo = true; 
                documentoCreado.Documentos.DireccionId = vMCDocumentos.DireccionGeneralId;
                documentoCreado.Documentos.Obligoatorio = true;

                if (documentoCreado.Documentos.TipoDocumentoId != 4)
                {
                    documentoCreado.Documentos.Nacional = true;
                }
                else
                {
                    string nacional = Request.Form["Nacional"].ToString();
                    if(nacional=="0")
                    {
                        documentoCreado.Documentos.Nacional = true;
                    }
                    else
                    {
                        documentoCreado.Documentos.Nacional = false;
                    }
                }
                _contenedorTrabajo.CDocumentos.Add(documentoCreado.Documentos);
                _contenedorTrabajo.Save();
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                id = (Guid)TempData["docId"];
            }

            CDocumentos documentos = new CDocumentos();

            documentos = _contenedorTrabajo.CDocumentos.GetFirstOrDefault(x => x.Id == id);

            var direccionId = documentos.DireccionId;

            CDireccionGeneral direccion = new CDireccionGeneral();
            direccion = _contenedorTrabajo.CDireccionGeneral.GetFirstOrDefault(x => x.Id == direccionId);

            bool tiene_programas = direccion.TieneProgramas;


            VMCDocumentos documentosvm = new VMCDocumentos()
            {
                Documentos = documentos,
                ListaTipoCarga = _contenedorTrabajo.CDocumentosTipoCarga.GetListaTipoCarga(),
                ListaTipoDocumento = _contenedorTrabajo.CDocumentosTipo.GetListaTipoDocumento(tiene_programas),
                DireccionGeneralId = direccionId
            };

            if (documentos == null) 
            {
                return NotFound();
            }
            TempData["docId"] = id;
            return View(documentosvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMCDocumentos model)
        {
            if (ModelState.IsValid)
            {
                var documento = _contenedorTrabajo.CDocumentos.GetByGuid(model.Documentos.Id);
                TempData["msg"] = "Registro exitoso";
                model.Documentos.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.Documentos.Id = documento.Id;

                if(model.Documentos.TipoDocumentoId==4)
                {
                    string nacional = Request.Form["Nacional"].ToString();
                    if (nacional == "0")
                    {
                        model.Documentos.Nacional = true;
                    }
                    else
                    {
                        model.Documentos.Nacional = false;
                    }
                }
                _contenedorTrabajo.CDocumentos.Update(model.Documentos);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddRequisitos(Guid id)
        {
            TempData["docId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRequisitos(CDocumentosRequisitos requisitoCreado)
        {
           
            if (ModelState.IsValid)
            {

                //logica para guardar en bbdd
                requisitoCreado.Id = Guid.NewGuid();
                
                requisitoCreado.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                requisitoCreado.Activo = true;
                
                _contenedorTrabajo.CDocumentosRequisitos.Add(requisitoCreado);
                _contenedorTrabajo.Save();
                return RedirectToAction("Edit", new { id= requisitoCreado.DocumentoId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditRequisitos(Guid id)
        {
            CDocumentosRequisitos requisitos = new CDocumentosRequisitos();
            requisitos= _contenedorTrabajo.CDocumentosRequisitos.GetByGuid(id);
            if(requisitos==null)
            {
                return NotFound();
            }
            TempData["docId"] = id;
            return View(requisitos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRequisitos(CDocumentosRequisitos requisitoEditar)
        {
            if (ModelState.IsValid)
            {
                TempData["msg"] = "Registro actualizado correctamente";
                requisitoEditar.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                _contenedorTrabajo.CDocumentosRequisitos.Update(requisitoEditar);
                _contenedorTrabajo.Save();
                return RedirectToAction("Edit", new { id= requisitoEditar.DocumentoId });
            }
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
            return Json(new { data = _contenedorTrabajo.CDocumentos.ListaDocumentos(direccionGeneralId) });
        }
        [HttpGet]
        public IActionResult GetRequisitos(Guid id)
        {
            
            return Json(new { data = _contenedorTrabajo.CDocumentosRequisitos.GetAll().Where(c => c.Activo == true && c.DocumentoId == id ) });
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var objFromDb = _contenedorTrabajo.CDocumentos.GetByGuid(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }

            _contenedorTrabajo.CDocumentos.UpdateDelete(objFromDb);

            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Registro borrado correctamente" });

        }

        [HttpDelete]
        public IActionResult DeleteRequisito(Guid id)
        {
            var objFromDb = _contenedorTrabajo.CDocumentosRequisitos.GetByGuid(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando tipo solicitante" });
            }

            _contenedorTrabajo.CDocumentosRequisitos.UpdateDelete(objFromDb);

            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Registro borrado correctamente" });

        }
        #endregion


    }



}
