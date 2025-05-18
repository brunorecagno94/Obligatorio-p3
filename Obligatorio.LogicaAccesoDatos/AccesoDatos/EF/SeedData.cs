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
            if (!_context.Usuarios.Any()) PrecargaDatos();
        }

        private void PrecargaDatos()
        {
            #region Administradores (10)
            _context.Usuarios.Add(new Administrador(0, new Nombre("Julieta"), new Apellido("Preliasco"), new Contrasena("bananita-bb"), new Telefono("099123456"), new Email("preliascojulieta@gmail.com"), new Cedula("42399123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(0, new Nombre("Bruno"), new Apellido("Recagno"), new Contrasena("#chorizardo"), new Telefono("099234567"), new Email("brunorecagno@gmail.com"), new Cedula("42399123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(0, new Nombre("Luis"), new Apellido("Dentone"), new Contrasena("luisd+"), new Telefono("099345678"), new Email("luisdentone@mail.com"), new Cedula("42399123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(1, new Nombre("Andrea"), new Apellido("Giménez"), new Contrasena("andrea1+"), new Telefono("098112233"), new Email("andrea.gimenez@mail.com"), new Cedula("45299123"), "Administrador"));
            _context.Usuarios.Add(new Administrador(2, new Nombre("Marcos"), new Apellido("Pereyra"), new Contrasena("marcos9#"), new Telefono("091223344"), new Email("marcos.p@mail.com"), new Cedula("41388521"), "Administrador"));
            _context.Usuarios.Add(new Administrador(3, new Nombre("Sofía"), new Apellido("Rodríguez"), new Contrasena("sofiA7+"), new Telefono("092334455"), new Email("sofia.r@mail.com"), new Cedula("43219876"), "Administrador"));
            _context.Usuarios.Add(new Administrador(4, new Nombre("Javier"), new Apellido("Silva"), new Contrasena("jav123#"), new Telefono("093445566"), new Email("javier.s@mail.com"), new Cedula("44123987"), "Administrador"));
            _context.Usuarios.Add(new Administrador(5, new Nombre("Valentina"), new Apellido("López"), new Contrasena("valen8+"), new Telefono("097556677"), new Email("valentina.l@mail.com"), new Cedula("40112345"), "Administrador"));
            _context.Usuarios.Add(new Administrador(6, new Nombre("Carlos"), new Apellido("Martínez"), new Contrasena("carl0s#"), new Telefono("096667788"), new Email("carlos.m@mail.com"), new Cedula("42255678"), "Administrador"));
            _context.Usuarios.Add(new Administrador(7, new Nombre("Lucía"), new Apellido("Fernández"), new Contrasena("lucia9."), new Telefono("094778899"), new Email("lucia.f@mail.com"), new Cedula("41223456"), "Administrador"));

            #endregion

            #region Funcionarios (10)
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Juan"), new Apellido("Gómez"), new Contrasena("juancho1#"), new Telefono("099123456"), new Email("juancho@mail.com"), new Cedula("42399123"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Ana María"), new Apellido("Fernández"), new Contrasena("anafer9+"), new Telefono("099324623"), new Email("anamafer@mail.com"), new Cedula("42924124"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Ana María"), new Apellido("René"), new Contrasena("anitare7."), new Telefono("099324623"), new Email("anarene@mail.com"), new Cedula("51234192"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Mauro"), new Apellido("Alonso"), new Contrasena("mauro8+#"), new Telefono("099123456"), new Email("mauroalonso@mail.com"), new Cedula("48011223"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Sofía"), new Apellido("Cornu"), new Contrasena("sofic0r.#"), new Telefono("099654321"), new Email("soficornu@mail.com"), new Cedula("49567890"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Gabriel"), new Apellido("Schultz"), new Contrasena("gabu12+."), new Telefono("098112233"), new Email("gabuschultz@mail.com"), new Cedula("48123456"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Alejandro"), new Apellido("Turnes"), new Contrasena("aleturn1#"), new Telefono("097987654"), new Email("aleturnes@mail.com"), new Cedula("49098765"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Fiorella"), new Apellido("Sosa"), new Contrasena("fio9so+."), new Telefono("096135791"), new Email("fiososa@mail.com"), new Cedula("49345678"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Martín"), new Apellido("Rechimuzzi"), new Contrasena("marti#88"), new Telefono("095246810"), new Email("martirechi@mail.com"), new Cedula("49211234"), "Funcionario"));
            _context.Usuarios.Add(new Funcionario(0, new Nombre("Lucía"), new Apellido("Colombo"), new Contrasena("luchi.7+"), new Telefono("094123789"), new Email("luchicolo@mail.com"), new Cedula("49123456"), "Funcionario"));
            #endregion

            #region Clientes (20)
            _context.Usuarios.Add(new Cliente(0, new Nombre("Federico"), new Apellido("López"), new Contrasena("fede9#+p"), new Telefono("099123456"), new Email("federicolopez@mail.com"), new Cedula("49111222"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Mariana"), new Apellido("Torres"), new Contrasena("marito#7"), new Telefono("098234567"), new Email("marianatorres@mail.com"), new Cedula("49222333"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Luciano"), new Apellido("Pereyra"), new Contrasena("luci9.p+"), new Telefono("097345678"), new Email("lucianopereyra@mail.com"), new Cedula("49333444"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Paula"), new Apellido("Sánchez"), new Contrasena("pausa#88"), new Telefono("096456789"), new Email("paulasanchez@mail.com"), new Cedula("49444555"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Matías"), new Apellido("Ramírez"), new Contrasena("mati.77+"), new Telefono("095567890"), new Email("matiasramirez@mail.com"), new Cedula("49555666"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Carolina"), new Apellido("Vega"), new Contrasena("caro.123#"), new Telefono("094678901"), new Email("carolinavega@mail.com"), new Cedula("49666777"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Gonzalo"), new Apellido("Gómez"), new Contrasena("gonzo7+#"), new Telefono("093789012"), new Email("gonzalogomez@mail.com"), new Cedula("49777888"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Valeria"), new Apellido("Silva"), new Contrasena("vale+8#."), new Telefono("092890123"), new Email("valeriasilva@mail.com"), new Cedula("49888999"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Facundo"), new Apellido("Morales"), new Contrasena("facu9+.#"), new Telefono("091901234"), new Email("facundomorales@mail.com"), new Cedula("49990011"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Agustina"), new Apellido("Reyes"), new Contrasena("agurey+1"), new Telefono("090112345"), new Email("agustinareyes@mail.com"), new Cedula("49011222"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Tomás"), new Apellido("Herrera"), new Contrasena("tomh+12#"), new Telefono("099223456"), new Email("tomasherrera@mail.com"), new Cedula("49122333"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Florencia"), new Apellido("Medina"), new Contrasena("flor.m+#"), new Telefono("098334567"), new Email("flormedina@mail.com"), new Cedula("49233444"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Martín"), new Apellido("Paz"), new Contrasena("mart+pz1"), new Telefono("097445678"), new Email("martinpaz@mail.com"), new Cedula("49344555"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Andrea"), new Apellido("Rojas"), new Contrasena("androj+1"), new Telefono("096556789"), new Email("andrearojas@mail.com"), new Cedula("49455666"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Sebastián"), new Apellido("Luna"), new Contrasena("seba#88."), new Telefono("095667890"), new Email("sebastianluna@mail.com"), new Cedula("49566777"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Verónica"), new Apellido("Carrizo"), new Contrasena("vero#12+"), new Telefono("094778901"), new Email("veronicacarrizo@mail.com"), new Cedula("49677888"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Nicolás"), new Apellido("Cabrera"), new Contrasena("nico+34#"), new Telefono("093889012"), new Email("nicolascabrera@mail.com"), new Cedula("49788999"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Camila"), new Apellido("Méndez"), new Contrasena("cami.m9+"), new Telefono("092990123"), new Email("camilamendez@mail.com"), new Cedula("49899011"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Juan"), new Apellido("Paredes"), new Contrasena("juanpa1#"), new Telefono("091101234"), new Email("juanparedes@mail.com"), new Cedula("49910122"), "Cliente"));
            _context.Usuarios.Add(new Cliente(0, new Nombre("Milagros"), new Apellido("Domínguez"), new Contrasena("mila+3#."), new Telefono("090212345"), new Email("milagrosdominguez@mail.com"), new Cedula("49021233"), "Cliente"));
            #endregion

            #region Agencias (10)
            _context.Agencias.Add(new Agencia(0, new Nombre("DAC"), new Direccion("Canelones", "1122", "11100"), new Ubicacion(-34.905f, -56.191f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("UES"), new Direccion("Av. Uruguay", "2391", "11100"), new Ubicacion(-34.425f, -56.481f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Correo Uruguayo"), new Direccion("Av. 18 de Julio", "1122", "11100"), new Ubicacion(-34.1115f, -56.155f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("DAC Tres Cruces"), new Direccion("Av. Bv. Artigas", "1825", "11200"), new Ubicacion(-34.8948f, -56.1632f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Ues Ciudad Vieja"), new Direccion("Calle Cerrito", "550", "11000"), new Ubicacion(-34.9069f, -56.2086f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Turil Terminal Salto"), new Direccion("Calle Brasil", "1482", "50000"), new Ubicacion(-31.3893f, -57.9686f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Correo Punta del Este"), new Direccion("Calle 27 Los Aromos", "885", "20100"), new Ubicacion(-34.9626f, -54.9457f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("DAC Terminal Paysandú"), new Direccion("Av. Salto", "1123", "60000"), new Ubicacion(-32.3205f, -58.0756f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Ues Las Piedras"), new Direccion("Av. Artigas", "1200", "90200"), new Ubicacion(-34.7302f, -56.2203f)));
            _context.Agencias.Add(new Agencia(0, new Nombre("Correo Rivera"), new Direccion("Av. Sarandí", "1025", "40000"), new Ubicacion(-30.9057f, -55.5518f)));
            #endregion

            _context.SaveChanges();

            #region Envios Comunes (10)
            _context.Envios.Add(new EnvioComun(0, 3, 10, 21, new PesoPaquete(2.5f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 1, 11, 22, new PesoPaquete(5.0f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 2, 12, 23, new PesoPaquete(3.2f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 3, 13, 24, new PesoPaquete(1.8f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 4, 14, 25, new PesoPaquete(4.4f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 5, 15, 26, new PesoPaquete(0.9f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 6, 16, 27, new PesoPaquete(6.7f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 7, 17, 28, new PesoPaquete(3.0f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 8, 18, 29, new PesoPaquete(2.2f), "EnvioComun"));
            _context.Envios.Add(new EnvioComun(0, 9, 19, 30, new PesoPaquete(4.9f), "EnvioComun"));
            #endregion

            #region Envios Urgentes (10)
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Canelones", "1122", "11100"), 10, 21, new PesoPaquete(2.0f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. Uruguay", "2391", "11100"), 11, 22, new PesoPaquete(1.5f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. 18 de Julio", "1122", "11100"), 12, 23, new PesoPaquete(3.1f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. Bv. Artigas", "1825", "11200"), 13, 24, new PesoPaquete(0.8f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Calle Cerrito", "550", "11000"), 14, 25, new PesoPaquete(4.2f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Calle Brasil", "1482", "50000"), 15, 26, new PesoPaquete(2.7f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Calle 27 Los Aromos", "885", "20100"), 16, 27, new PesoPaquete(5.5f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. Salto", "1123", "60000"), 17, 28, new PesoPaquete(1.1f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. Artigas", "1200", "90200"), 18, 29, new PesoPaquete(2.9f), "EnvioUrgente"));
            _context.Envios.Add(new EnvioUrgente(0, new Direccion("Av. Sarandí", "1025", "40000"), 19, 30, new PesoPaquete(6.0f), "EnvioUrgente"));

            #endregion

            _context.SaveChanges();
        }
    }
}
