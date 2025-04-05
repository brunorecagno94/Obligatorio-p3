using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comentario : IEntity
    {
        public int Id { get; set; }
        public Fecha Fecha { get; set; }
        public TextoComentario TextoComentario { get; set; }
        public Usuario Empleado { get; set; }
        public string Envio { get; set; } // TODO: Cambiar cuando esté la clase Envio

        public Comentario(int id,
                          Fecha fecha,
                          TextoComentario textoComentario,
                          Usuario empleado,
                          string envio)
        {
            Id = id;
            Fecha = fecha;
            TextoComentario = textoComentario;
            Empleado = empleado;
            Envio = envio;
        }
    }
}
