using IDEmpresaJAL.BLL.IRepository;
using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDEmpresaJAL.App.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize] // es para que solo usuario con sesion puedan ingesar
    public class UsuarioInternoController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IUtilidadesRepository _utilidadesRepository;

        public UsuarioInternoController(IContenedorTrabajo contenedorTrabajo, IUtilidadesRepository utilidadesRepository)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _utilidadesRepository = utilidadesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {

            VMUsuarioInterno usuarioInternovm = new VMUsuarioInterno()
            {
                Usuario = new IDEmpresaJAL.Entity.Models.TUsuario(),
                Generales = new IDEmpresaJAL.Entity.Models.TUsuarioGenerales(),
                ListaDirecciones = _contenedorTrabajo.CDireccionGeneral.GetListaDirecciones()
            };

            return View(usuarioInternovm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMUsuarioInterno usuarioCreado)
        {
            if (ModelState.IsValid)
            {
                VMUsuarioInterno vmUsuarioInterno = new VMUsuarioInterno()
                {
                    Usuario = new IDEmpresaJAL.Entity.Models.TUsuario(),
                    Generales = new IDEmpresaJAL.Entity.Models.TUsuarioGenerales(),

                    ListaDirecciones = _contenedorTrabajo.CDireccionGeneral.GetListaDirecciones()
                };

                //validar que nombre de usuario no se repita
                var verificaUserName = new TUsuarioGenerales();

                verificaUserName = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(gu=> gu.RFC == usuarioCreado.Generales.RFC);
                if (verificaUserName != null)
                {
                    TempData["errusuario"] = "error";
                    return View(vmUsuarioInterno);
                }
                else
                {
                    //validar que el correo no se repita
                    var VerificaCorreo = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(cu=> cu.CorreoElectronico == usuarioCreado.Generales.CorreoElectronico);
                    if(VerificaCorreo != null)
                    {
                        TempData["errcorreo"] = "error";
                        return View(vmUsuarioInterno);
                    }
                    else
                    {
                        TempData["msg"] = "Registro guardado correctamente";
                        //logica para guardar en bbdd


                        //agregar a la tabla de usuarios
                        TUsuario usuario = new TUsuario();
                        usuario.Usuario = usuarioCreado.Generales.RFC;
                        usuario.Activo = false;
                        _contenedorTrabajo.TUsuario.Add(usuario);

                        var usuarioID = usuario.Id;

                        //agregar a la tabla de usuario generales
                        usuarioCreado.Generales.UsuarioId = usuarioID;
                        usuarioCreado.Generales.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        _contenedorTrabajo.TUsuarioGenerales.Add(usuarioCreado.Generales);

                        //agregar a la tabla de usuarioseguridadsolicitud
                        TUsuarioSeguridadSolicitud usuarioSeguridad = new TUsuarioSeguridadSolicitud();

                        usuarioSeguridad.UsuarioId = usuarioID;
                        var request = _utilidadesRepository.ConvertirSha256(usuarioCreado.Generales.RFC + usuarioCreado.Generales.CorreoElectronico);
                        usuarioSeguridad.Request = request;
                        usuarioSeguridad.FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        DateTime fechaCaducidad = new DateTime();
                        fechaCaducidad = DateTime.Now;
                        usuarioSeguridad.FechaCaducidad = fechaCaducidad.AddHours(5).ToString("yyyy-MM-dd hh:mm:ss");
                        usuarioSeguridad.Funcion = 1;
                        _contenedorTrabajo.TUsuarioSeguridadSolicitud.Add(usuarioSeguridad);

                        _contenedorTrabajo.Save();
                        return RedirectToAction(nameof(Index));
                    }
                }
                
               
            }

            //si hay error regresa la vista del modelo
            usuarioCreado.ListaDirecciones = _contenedorTrabajo.CDireccionGeneral.GetListaDirecciones();
            return View(usuarioCreado);
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            VMUsuarioInterno vmUsuarioInterno = new VMUsuarioInterno()
            {
                Usuario = new IDEmpresaJAL.Entity.Models.TUsuario(),
                Generales = new IDEmpresaJAL.Entity.Models.TUsuarioGenerales(),
                ListaDirecciones = _contenedorTrabajo.CDireccionGeneral.GetListaDirecciones(),
                ListaRoles = _contenedorTrabajo.TUsuarioGenerales.ListaRoles(id)
                
            };

            if(id != null)
            {
                vmUsuarioInterno.Generales = _contenedorTrabajo.TUsuarioGenerales.GetFirstOrDefault(g=> g.UsuarioId == id);
            }
            

          return View(vmUsuarioInterno);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMUsuarioInterno model)
        {
            if(ModelState.IsValid)
            {

                var usuario = _contenedorTrabajo.TUsuario.GetByGuid(model.Generales.UsuarioId);
               
                TempData["msg"] = "Registro exitoso";
                model.Generales.FechaCreacion= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                _contenedorTrabajo.TUsuarioGenerales.Update(model.Generales);

              
                //actualiza el rol del usuario

                foreach (var item in model.ListaRoles)
                {
                    int rol_id = item.Id;
                    Guid usuario_id = model.Generales.UsuarioId;
                   

                    if (item.Seleccionado == true)
                    {
                        //validar que ya este en la base de datos
                        //si no esta entonces guarda
                       
                        var usuarioRolDesdeDB = _contenedorTrabajo.UsuarioRol.GetFirstOrDefault(ur => ur.UsuarioId == usuario_id && ur.RolId == rol_id);
                        if (usuarioRolDesdeDB == null)
                        {

                            RUsuarioRol rUsuarioRol = new RUsuarioRol();
                            rUsuarioRol.UsuarioId = usuario_id;
                            rUsuarioRol.RolId = rol_id;

                            if (usuarioRolDesdeDB == null)
                            {
                                _contenedorTrabajo.UsuarioRol.Add(rUsuarioRol);
                            }

                        }

                    }
                    else
                    {
                        //validar que ya este en la base de datos
                        //si esta entonces se elimina por completo el registro
                        RUsuarioRol rUsuarioRol = new RUsuarioRol();

                        var usuarioRolDesdeDB = _contenedorTrabajo.UsuarioRol.GetFirstOrDefault(ur => ur.UsuarioId == usuario_id && ur.RolId == rol_id);
                        
                        if (usuarioRolDesdeDB != null)
                        {
                            _contenedorTrabajo.UsuarioRol.RemoveByID(usuarioRolDesdeDB.Id);
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
            return Json(new { data = _contenedorTrabajo.TUsuarioGenerales.ListaUsuarios()});
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
