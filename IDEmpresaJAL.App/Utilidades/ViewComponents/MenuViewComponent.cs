using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using IDEmpresaJAL.Entity.ViewModel;
using IDEmpresaJAL.IoC.IRepository;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IDEmpresaJAL.App.Utilidades.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public MenuViewComponent(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

           

            if (claimUser.Identity.IsAuthenticated) 
            {
                string usuarioId = claimUser.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).SingleOrDefault();

                VMMenu menuvm = new VMMenu()
                {
                    ListaMenu = _contenedorTrabajo.UsuarioRol.ListaMenu(Guid.Parse(usuarioId)),
                   
                };

               
                return View(menuvm);
            }

            return View();
            
        }
    }
}
