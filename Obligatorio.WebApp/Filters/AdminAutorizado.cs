using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filters
{
    public class AdminAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("Rol") != "Administrador")
            {
                if (context.HttpContext.Session.GetString("Id") != null)
                {
                    context.Result = new RedirectResult("/Home/Index");
                }
                else
                {
                    context.Result = new RedirectResult("/Login/Index");
                }
            }
        }
    }
}
