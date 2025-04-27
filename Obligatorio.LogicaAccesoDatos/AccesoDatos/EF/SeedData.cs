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
            // Administradores
            _context.Usuarios.Add(new Administrador(1, new Nombre("Julieta"), new Apellido("Preliasco"), new Contrasena("bananitabb"), new Telefono("099123456"), new Email("preliascojulieta@gmail.com"), new Cedula("42399123")));
            _context.Usuarios.Add(new Administrador(2, new Nombre("Bruno"), new Apellido("Recagno"), new Contrasena("chorizardo"), new Telefono("099234567"), new Email("brunorecagno@gmail.com"), new Cedula("42399123")));
            _context.Usuarios.Add(new Administrador(3, new Nombre("Luis"), new Apellido("Dentone"), new Contrasena("luisd"), new Telefono("099345678"), new Email("luisdentone@mail.com"), new Cedula("42399123")));

            // Funcionarios
            _context.Usuarios.Add(new Funcionario(4, new Nombre("Juan"), new Apellido("Gómez"), new Contrasena("juancho123"), new Telefono("099123456"), new Email("juancho@mail.com"), new Cedula("42399123")));
            _context.Usuarios.Add(new Funcionario(5, new Nombre("Ana María"), new Apellido("Reneboldi"), new Contrasena("anitareno"), new Telefono("099324623"), new Email("anarene@mail.com"), new Cedula("49220192")));
            _context.Usuarios.Add(new Funcionario(6, new Nombre("Ana María"), new Apellido("Reneboldi"), new Contrasena("anitareno"), new Telefono("099324623"), new Email("anarene@mail.com"), new Cedula("49220192")));
            _context.Usuarios.Add(new Funcionario(7, new Nombre("Mauro"), new Apellido("Alonso"), new Contrasena("maurochano"), new Telefono("099123456"), new Email("mauroalonso@mail.com"), new Cedula("48011223")));
            _context.Usuarios.Add(new Funcionario(8, new Nombre("Sofía"), new Apellido("Cornu"), new Contrasena("soficornu"), new Telefono("099654321"), new Email("soficornu@mail.com"), new Cedula("49567890")));
            _context.Usuarios.Add(new Funcionario(9, new Nombre("Gabriel"), new Apellido("Schultz"), new Contrasena("gabuschu"), new Telefono("098112233"), new Email("gabuschultz@mail.com"), new Cedula("48123456")));
            _context.Usuarios.Add(new Funcionario(10, new Nombre("Alejandro"), new Apellido("Turnes"), new Contrasena("aleturno"), new Telefono("097987654"), new Email("aleturnes@mail.com"), new Cedula("49098765")));
            _context.Usuarios.Add(new Funcionario(11, new Nombre("Fiorella"), new Apellido("Sosa"), new Contrasena("fiososa"), new Telefono("096135791"), new Email("fiososa@mail.com"), new Cedula("49345678")));
            _context.Usuarios.Add(new Funcionario(12, new Nombre("Martín"), new Apellido("Rechimuzzi"), new Contrasena("martirechi"), new Telefono("095246810"), new Email("martirechi@mail.com"), new Cedula("49211234")));
            _context.Usuarios.Add(new Funcionario(13, new Nombre("Lucía"), new Apellido("Colombo"), new Contrasena("luchicolo"), new Telefono("094123789"), new Email("luchicolo@mail.com"), new Cedula("49123456")));
            _context.Usuarios.Add(new Funcionario(14, new Nombre("Santiago"), new Apellido("Calori"), new Contrasena("santicalo"), new Telefono("093321456"), new Email("santicalo@mail.com"), new Cedula("49067890")));
            _context.Usuarios.Add(new Funcionario(15, new Nombre("Paula"), new Apellido("Paredes"), new Contrasena("pauparedes"), new Telefono("092654987"), new Email("pauparedes@mail.com"), new Cedula("49321234")));
            _context.Usuarios.Add(new Funcionario(16, new Nombre("Federico"), new Apellido("Molinari"), new Contrasena("fedomoli"), new Telefono("091987321"), new Email("fedomoli@mail.com"), new Cedula("49543210")));

            // Clientes
            _context.Usuarios.Add(new Funcionario(17, new Nombre("Federico"), new Apellido("López"), new Contrasena("fedelopez"), new Telefono("099123456"), new Email("federicolopez@mail.com"), new Cedula("49111222")));
            _context.Usuarios.Add(new Funcionario(18, new Nombre("Mariana"), new Apellido("Torres"), new Contrasena("maritorres"), new Telefono("098234567"), new Email("marianatorres@mail.com"), new Cedula("49222333")));
            _context.Usuarios.Add(new Funcionario(19, new Nombre("Luciano"), new Apellido("Pereyra"), new Contrasena("lucipereyra"), new Telefono("097345678"), new Email("lucianopereyra@mail.com"), new Cedula("49333444")));
            _context.Usuarios.Add(new Funcionario(20, new Nombre("Paula"), new Apellido("Sánchez"), new Contrasena("pausanchez"), new Telefono("096456789"), new Email("paulasanchez@mail.com"), new Cedula("49444555")));
            _context.Usuarios.Add(new Funcionario(21, new Nombre("Matías"), new Apellido("Ramírez"), new Contrasena("matiramirez"), new Telefono("095567890"), new Email("matiasramirez@mail.com"), new Cedula("49555666")));
            _context.Usuarios.Add(new Funcionario(22, new Nombre("Carolina"), new Apellido("Vega"), new Contrasena("carovega"), new Telefono("094678901"), new Email("carolinavega@mail.com"), new Cedula("49666777")));
            _context.Usuarios.Add(new Funcionario(23, new Nombre("Gonzalo"), new Apellido("Gómez"), new Contrasena("gongomez"), new Telefono("093789012"), new Email("gonzalogomez@mail.com"), new Cedula("49777888")));
            _context.Usuarios.Add(new Funcionario(24, new Nombre("Valeria"), new Apellido("Silva"), new Contrasena("valesilva"), new Telefono("092890123"), new Email("valeriasilva@mail.com"), new Cedula("49888999")));
            _context.Usuarios.Add(new Funcionario(25, new Nombre("Facundo"), new Apellido("Morales"), new Contrasena("facumorales"), new Telefono("091901234"), new Email("facundomorales@mail.com"), new Cedula("49990011")));
            _context.Usuarios.Add(new Funcionario(26, new Nombre("Agustina"), new Apellido("Reyes"), new Contrasena("agureyes"), new Telefono("090112345"), new Email("agustinareyes@mail.com"), new Cedula("49011222")));
            _context.Usuarios.Add(new Funcionario(27, new Nombre("Tomás"), new Apellido("Herrera"), new Contrasena("tomherrera"), new Telefono("099223456"), new Email("tomasherrera@mail.com"), new Cedula("49122333")));
            _context.Usuarios.Add(new Funcionario(28, new Nombre("Florencia"), new Apellido("Medina"), new Contrasena("flormedina"), new Telefono("098334567"), new Email("flormedina@mail.com"), new Cedula("49233444")));
            _context.Usuarios.Add(new Funcionario(29, new Nombre("Martín"), new Apellido("Paz"), new Contrasena("martinpaz"), new Telefono("097445678"), new Email("martinpaz@mail.com"), new Cedula("49344555")));
            _context.Usuarios.Add(new Funcionario(30, new Nombre("Andrea"), new Apellido("Rojas"), new Contrasena("andrearojas"), new Telefono("096556789"), new Email("andrearojas@mail.com"), new Cedula("49455666")));
            _context.Usuarios.Add(new Funcionario(31, new Nombre("Sebastián"), new Apellido("Luna"), new Contrasena("sebaluna"), new Telefono("095667890"), new Email("sebastianluna@mail.com"), new Cedula("49566777")));
            _context.Usuarios.Add(new Funcionario(32, new Nombre("Verónica"), new Apellido("Carrizo"), new Contrasena("verocarrizo"), new Telefono("094778901"), new Email("veronicacarrizo@mail.com"), new Cedula("49677888")));
            _context.Usuarios.Add(new Funcionario(33, new Nombre("Nicolás"), new Apellido("Cabrera"), new Contrasena("nicocabrera"), new Telefono("093889012"), new Email("nicolascabrera@mail.com"), new Cedula("49788999")));
            _context.Usuarios.Add(new Funcionario(34, new Nombre("Camila"), new Apellido("Méndez"), new Contrasena("camimendez"), new Telefono("092990123"), new Email("camilamendez@mail.com"), new Cedula("49899011")));
            _context.Usuarios.Add(new Funcionario(35, new Nombre("Juan"), new Apellido("Paredes"), new Contrasena("juanparedes"), new Telefono("091101234"), new Email("juanparedes@mail.com"), new Cedula("49910122")));
            _context.Usuarios.Add(new Funcionario(36, new Nombre("Milagros"), new Apellido("Domínguez"), new Contrasena("miladomi"), new Telefono("090212345"), new Email("milagrosdominguez@mail.com"), new Cedula("49021233")));



            _context.SaveChanges();
        }
    }
}
