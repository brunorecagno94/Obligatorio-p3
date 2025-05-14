using Obligatorio.Infraestructura.AccesoDatos.EF;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;

namespace Infraestructura.AccesoDatos.EF
{
    public class SeedData
    {

        private ObligatorioContext _context;

        public SeedData(ObligatorioContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.Usuarios.Any()) PrecargaUsuarios();
        }

        private void PrecargaUsuarios()
        {
            #region Administradores
            _context.Usuarios.Add(new Administrador(0, new Nombre("Julieta"), new Apellido("Preliasco"), new Contrasena("bananitabb"), new Telefono("099123456"), new Email("preliascojulieta@gmail.com"), new Cedula("42399123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(0, new Nombre("Bruno"), new Apellido("Recagno"), new Contrasena("chorizardo"), new Telefono("099234567"), new Email("brunorecagno@gmail.com"), new Cedula("42399123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(0, new Nombre("Luis"), new Apellido("Dentone"), new Contrasena("luisd"), new Telefono("099345678"), new Email("luisdentone@mail.com"), new Cedula("42399123"), "Administrador"));
            #endregion

            #region Funcionarios
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Juan"), new Apellido("Gómez"), new Contrasena("juancho123"), new Telefono("099123456"), new Email("juancho@mail.com"), new Cedula("42399123"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Ana María"), new Apellido("Fernández"), new Contrasena("anafer"), new Telefono("099324623"), new Email("anamafer@mail.com"), new Cedula("42924124"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Ana María"), new Apellido("René"), new Contrasena("anitareno"), new Telefono("099324623"), new Email("anarene@mail.com"), new Cedula("51234192"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Mauro"), new Apellido("Alonso"), new Contrasena("maurochano"), new Telefono("099123456"), new Email("mauroalonso@mail.com"), new Cedula("48011223"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Sofía"), new Apellido("Cornu"), new Contrasena("soficornu"), new Telefono("099654321"), new Email("soficornu@mail.com"), new Cedula("49567890"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Gabriel"), new Apellido("Schultz"), new Contrasena("gabuschu"), new Telefono("098112233"), new Email("gabuschultz@mail.com"), new Cedula("48123456"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Alejandro"), new Apellido("Turnes"), new Contrasena("aleturno"), new Telefono("097987654"), new Email("aleturnes@mail.com"), new Cedula("49098765"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Fiorella"), new Apellido("Sosa"), new Contrasena("fiososa"), new Telefono("096135791"), new Email("fiososa@mail.com"), new Cedula("49345678"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Martín"), new Apellido("Rechimuzzi"), new Contrasena("martirechi"), new Telefono("095246810"), new Email("martirechi@mail.com"), new Cedula("49211234"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Lucía"), new Apellido("Colombo"), new Contrasena("luchicolo"), new Telefono("094123789"), new Email("luchicolo@mail.com"), new Cedula("49123456"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Santiago"), new Apellido("Calori"), new Contrasena("santicalo"), new Telefono("093321456"), new Email("santicalo@mail.com"), new Cedula("49067890"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Paula"), new Apellido("Paredes"), new Contrasena("pauparedes"), new Telefono("0926540987"), new Email("pauparedes@mail.com"), new Cedula("49321234"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Federico"), new Apellido("Molinari"), new Contrasena("fedomoli"), new Telefono("091987321"), new Email("fedomoli@mail.com"), new Cedula("49543210"), "Funcionario"));
            #endregion

            #region Clientes
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Federico"), new Apellido("López"), new Contrasena("fedelopez"), new Telefono("099123456"), new Email("federicolopez@mail.com"), new Cedula("49111222"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Mariana"), new Apellido("Torres"), new Contrasena("maritorres"), new Telefono("098234567"), new Email("marianatorres@mail.com"), new Cedula("49222333"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Luciano"), new Apellido("Pereyra"), new Contrasena("lucipereyra"), new Telefono("097345678"), new Email("lucianopereyra@mail.com"), new Cedula("49333444"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Paula"), new Apellido("Sánchez"), new Contrasena("pausanchez"), new Telefono("096456789"), new Email("paulasanchez@mail.com"), new Cedula("49444555"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Matías"), new Apellido("Ramírez"), new Contrasena("matiramirez"), new Telefono("095567890"), new Email("matiasramirez@mail.com"), new Cedula("49555666"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Carolina"), new Apellido("Vega"), new Contrasena("carovega"), new Telefono("094678901"), new Email("carolinavega@mail.com"), new Cedula("49666777"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Gonzalo"), new Apellido("Gómez"), new Contrasena("gongomez"), new Telefono("093789012"), new Email("gonzalogomez@mail.com"), new Cedula("49777888"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Valeria"), new Apellido("Silva"), new Contrasena("valesilva"), new Telefono("092890123"), new Email("valeriasilva@mail.com"), new Cedula("49888999"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Facundo"), new Apellido("Morales"), new Contrasena("facumorales"), new Telefono("091901234"), new Email("facundomorales@mail.com"), new Cedula("49990011"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Agustina"), new Apellido("Reyes"), new Contrasena("agureyes"), new Telefono("090112345"), new Email("agustinareyes@mail.com"), new Cedula("49011222"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Tomás"), new Apellido("Herrera"), new Contrasena("tomherrera"), new Telefono("099223456"), new Email("tomasherrera@mail.com"), new Cedula("49122333"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Florencia"), new Apellido("Medina"), new Contrasena("flormedina"), new Telefono("098334567"), new Email("flormedina@mail.com"), new Cedula("49233444"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Martín"), new Apellido("Paz"), new Contrasena("martinpaz"), new Telefono("097445678"), new Email("martinpaz@mail.com"), new Cedula("49344555"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Andrea"), new Apellido("Rojas"), new Contrasena("andrearojas"), new Telefono("096556789"), new Email("andrearojas@mail.com"), new Cedula("49455666"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Sebastián"), new Apellido("Luna"), new Contrasena("sebaluna"), new Telefono("095667890"), new Email("sebastianluna@mail.com"), new Cedula("49566777"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Verónica"), new Apellido("Carrizo"), new Contrasena("verocarrizo"), new Telefono("094778901"), new Email("veronicacarrizo@mail.com"), new Cedula("49677888"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Nicolás"), new Apellido("Cabrera"), new Contrasena("nicocabrera"), new Telefono("093889012"), new Email("nicolascabrera@mail.com"), new Cedula("49788999"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Camila"), new Apellido("Méndez"), new Contrasena("camimendez"), new Telefono("092990123"), new Email("camilamendez@mail.com"), new Cedula("49899011"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Juan"), new Apellido("Paredes"), new Contrasena("juanparedes"), new Telefono("091101234"), new Email("juanparedes@mail.com"), new Cedula("49910122"), "Cliente"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Milagros"), new Apellido("Domínguez"), new Contrasena("miladomi"), new Telefono("090212345"), new Email("milagrosdominguez@mail.com"), new Cedula("49021233"), "Cliente"));
            #endregion

            #region Agencias
            _context.Agencias.Add(new Agencia(new Nombre("DAC"), new Direccion("Canelones", "1122", "11100"), new Ubicacion(-34.905f, -56.191f)));
            _context.Agencias.Add(new Agencia(new Nombre("UES"), new Direccion("Av. Uruguay", "2391", "11100"), new Ubicacion(-34.425f, -56.481f)));
            _context.Agencias.Add(new Agencia(new Nombre("Correo Uruguayo"), new Direccion("Av. 18 de Julio", "1122", "11100"), new Ubicacion(-34.1115f, -56.155f)));

            #endregion
            _context.SaveChanges();
        }
    }
}
