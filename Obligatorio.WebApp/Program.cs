<<<<<<< HEAD
using Obligatorio.Infraestructura.AccesoDatos.EF;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.CasosDeUso.Login;


namespace Obligatorio.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            #region Inyecciones de dependencias

            #region Interfaces de Casos de Uso

            #region Usuario
            builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
            builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
            builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
            builder.Services.AddScoped<IGetByEmail<UsuarioListadoDTO>, GetByEmailUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUsuario>();
            builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();
            #endregion

            #region Login
            builder.Services.AddScoped<ILoginUsuario, LoginUsuarios>();
            #endregion

            #endregion

            #region Repositorios

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            #endregion

            #region Context

            builder.Services.AddDbContext<ObligatorioContext>();

            #endregion

            #endregion

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
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
=======
using Infraestructura.AccesoDatos.EF;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.Infraestructura.AccesoDatos.EF;
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

            #region Inyecciones de dependencias

            #region Interfaces de Casos de Uso

            #region Usuario
            builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
            builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
            builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUsuario>();
            builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();
            #endregion

            #endregion

            #region Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<SeedData>();

            #endregion

            #region Context

            builder.Services.AddDbContext<ObligatorioContext>();

            #endregion

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Configurar precarga para entorno de desarrollo
            if (app.Environment.IsDevelopment())

                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    //var context = services.GetRequiredService<LibreriaContext>();
                    //context.Database.Migrate(); // o EnsureCreated() según tu caso
                    var seeder = services.GetRequiredService<SeedData>();
                    seeder.Run();
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
>>>>>>> origin/main
