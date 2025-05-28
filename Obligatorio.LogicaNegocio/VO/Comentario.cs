using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Comentario
    {
        public DateTime Fecha { get; }
        public string TextoComentario { get; }
        public int IdEmpleado { get; }
        public int IdEnvio { get; }

        public Comentario(string textoComentario,
                          int idEmpleado,
                          int idEnvio)
        {
            Fecha = DateTime.Now;
            TextoComentario = textoComentario;
            IdEmpleado = idEmpleado;
            IdEnvio = idEnvio;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(TextoComentario)) throw new TextoComentarioException("Apellido inválido");
        }
    }
}
