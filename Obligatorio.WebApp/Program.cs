using Infraestructura.AccesoDatos.EF;
using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.LogsCrud;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.EF;
using Obligatorio.LogicaAplicacion.CasosDeUso.Agencias;
using Obligatorio.LogicaAplicacion.CasosDeUso.Envios;
using Obligatorio.LogicaAplicacion.CasosDeUso.Login;
using Obligatorio.LogicaAplicacion.CasosDeUso.LogsCrud;
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
            builder.Services.AddSession();

            //Inyecciones de dependencias

            builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
            builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
            builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
            builder.Services.AddScoped<IGetByEmail<UsuarioListadoDTO>, GetByEmailUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUsuario>();
            builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();

            builder.Services.AddScoped<IAdd<EnvioDTO>, AddEnvio>();
            builder.Services.AddScoped<IGetAll<EnvioListadoDTO>, GetAllEnvios>();
            builder.Services.AddScoped<IAddComentario, AddComentario>();
            builder.Services.AddScoped<IGetById<EnvioListadoDTO>, GetByIdEnvio>();
            builder.Services.AddScoped<IGetAllComentarios<ComentarioDTO>, GetAllComentarios>();
            builder.Services.AddScoped<IFinalizarEnvio, FinalizarEnvio>();
            builder.Services.AddScoped<IGetByNumeroTracking<EnvioListadoDTO>, GetByNumeroTracking>();

            builder.Services.AddScoped<IGetAll<AgenciaListadaDTO>, GetAllAgencias>();

            builder.Services.AddScoped<ILoginUsuario, LoginUsuarios>();

            builder.Services.AddScoped<IAdd<LogCrudDTO>, AddLogCrud>();

            // Inyecciones repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<SeedData>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioLogCrud, RepositorioLogCrud>();


            builder.Services.AddDbContext<ObligatorioContext>();

            var app = builder.Build();

            //builder.Services.AddDbContext<ObligatorioContext>(
            //    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ObligatorioDb"))
            //);

            // Leer el archivo de configuracion de json
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("parametros.json")
            //    .Build();

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
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
