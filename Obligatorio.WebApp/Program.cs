
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.Infraestructura.EF;
using Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            
            builder.Services.AddDbContext<ObligatorioContext>();

            //Inyecciones para repositorios

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //Inyecciones para los casos de uso usuario

            builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
            builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
            builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
            builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUsuario>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
