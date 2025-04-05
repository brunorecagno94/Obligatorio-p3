using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comentario : IEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TextoComentario TextoComentario { get; set; }
        public Usuario Empleado { get; set; }
        public Envio Envio { get; set; }

        public Comentario(int id,
                          DateTime fecha,
                          TextoComentario textoComentario,
                          Usuario empleado,
                          Envio envio)
        {
            Id = id;
            Fecha = fecha;
            TextoComentario = textoComentario;
            Empleado = empleado;
            Envio = envio;
        }
    }
}
