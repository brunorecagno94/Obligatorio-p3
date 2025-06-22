using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Libreria.WebApp.Filter
{
    public class Token : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.Write(context);
            Console.Write(context.HttpContext.Request.Headers);

            var headers = context.HttpContext.Request.Headers;
            //var token = headers["token"].ToString();
            //Console.WriteLine(headers);


            //var firma = headers["Firma"].ToString();

            if (headers.ContainsKey("Authorization"))
            {
                var token1 = headers["Authorization"].ToString();
                Console.WriteLine("Token recibido: " + token1);
            }

            ////  else
            ////  {
            //Console.WriteLine("No se encontró el header Authorization.");
            ////  }



        }
    }
}
