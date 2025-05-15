using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class LogCrud : IEntity
    {
        public int Id { get; set; }
        public string AccionRealizada { get; set; }
        public DateTime FechaOperacion { get; set; }
        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }

        public LogCrud() { }

        public LogCrud(int id, string accionRealizada, DateTime fechaOperacion, int usuarioId)
        {
            Id = id;
            AccionRealizada = accionRealizada;
            FechaOperacion = fechaOperacion;
            UsuarioId = usuarioId;
        }
    }
}
