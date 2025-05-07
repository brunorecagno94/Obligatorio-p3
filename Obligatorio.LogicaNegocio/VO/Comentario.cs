using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Comentario
    {
        public DateTime Fecha { get; set; }
        public string TextoComentario { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEnvio { get; set; }

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
