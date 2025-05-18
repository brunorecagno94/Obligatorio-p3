using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filters
{
    public class EmpleadoAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("Rol") != "Administrador" &&
               context.HttpContext.Session.GetString("Rol") != "Funcionario")
            {
                context.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}
