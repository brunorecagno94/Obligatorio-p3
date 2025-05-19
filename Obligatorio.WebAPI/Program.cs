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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Usuarios
builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
builder.Services.AddScoped<IGetByEmail<UsuarioListadoDTO>, GetByEmailUsuario>();
builder.Services.AddScoped<IRemove, RemoveUsuario>();
builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();

//Envios
builder.Services.AddScoped<IAdd<EnvioDTO>, AddEnvioComun>();
builder.Services.AddScoped<IAdd<EnvioDTO>, AddEnvioUrgente>();
builder.Services.AddScoped<IGetAll<EnvioListadoDTO>, GetAllEnvios>();
builder.Services.AddScoped<IGetByNumeroTracking<EnvioListadoDTO>, GetByNumeroTracking>();

//Agencias
builder.Services.AddScoped<IGetAll<AgenciaListadaDTO>, GetAllAgencias>();

//Login
builder.Services.AddScoped<ILoginUsuario, LoginUsuarios>();

//LogCrud
builder.Services.AddScoped<IAdd<LogCrudDTO>, AddLogCrud>();

//Repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<SeedData>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
builder.Services.AddScoped<IRepositorioLogCrud, RepositorioLogCrud>();

//Context
builder.Services.AddDbContext<ObligatorioContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        //var context = services.GetRequiredService<LibreriaContext>();
        //context.Database.Migrate(); // o EnsureCreated() según tu caso
        var seeder = services.GetRequiredService<SeedData>();
        seeder.Run();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
