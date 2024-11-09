using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace IDEmpresaJAL.App.Utilidades.ViewComponents
{
    public class MenuUsuarioViewComponent : ViewComponent
    {

        //crear un metodo que viene implementado con el view component

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            string nombreUsuario = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimUser.Claims
                    .Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            return View();

        }
    }
}
