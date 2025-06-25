using Infraestructura.AccesoDatos.EF;
using Libreria.WebApi.Services;
using Libreria.WepApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Shayne Boyer",
            Email = string.Empty,
            Url = new Uri("https://twitter.com/spboyer"),
        },

    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en este formato: Bearer {token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                    {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                    }

                            },
                            new string[] { }

                        }
                    });
});


//Usuarios
builder.Services.AddScoped<IAdd<UsuarioDTO>, AddUsuario>();
builder.Services.AddScoped<IGetAll<UsuarioListadoDTO>, GetAllUsuarios>();
builder.Services.AddScoped<IGetById<UsuarioListadoDTO>, GetByIdUsuario>();
builder.Services.AddScoped<IGetByEmail<UsuarioListadoDTO>, GetByEmailUsuario>();
builder.Services.AddScoped<IRemove, RemoveUsuario>();
builder.Services.AddScoped<IUpdate<UsuarioDTO>, UpdateUsuario>();
builder.Services.AddScoped<ICambiarContrasenaUsuario, CambiarContrasenaUsuario>();


//Envios
builder.Services.AddScoped<IAdd<EnvioDTO>, AddEnvio>();
builder.Services.AddScoped<IGetAll<EnvioListadoDTO>, GetAllEnvios>();
builder.Services.AddScoped<IGetByNumeroTracking<EnvioCompletoListado>, GetByNumeroTracking>();
builder.Services.AddScoped<IGetAllById<EnvioCompletoListado>, GetAllById>();
builder.Services.AddScoped<IBuscarEnviosPorComentario<EnvioCompletoListado>, BuscarEnviosPorComentario>();

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

// Agrega generacion de token con JWT
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

// Obtener configuración JWT desde appsettings
var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false; // En producción: true
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   // ValidateIssuer = true,
                   // ValidIssuer = jwtConfig["Issuer"],
                   // ValidateAudience = true,
                   // ValidAudience = jwtConfig["Audience"],
                   ValidateIssuer = false,
                   ValidateAudience = false,
               };
           });

builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
