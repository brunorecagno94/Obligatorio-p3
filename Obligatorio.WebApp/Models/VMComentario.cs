namespace Obligatorio.WebApp.Models
{
    public class VMComentario
    {
        
        public string TextoComentario { get; set; }
        public int EmpleadoId { get; set; }
        public int EnvioId { get; set; }
        public DateTime Fecha { get; set; }

        public VMComentario(string textoComentario, int empleadoId, int envioId, DateTime fecha)
        {
            TextoComentario = textoComentario;
            EmpleadoId = empleadoId;
            EnvioId = envioId;
            Fecha = fecha;
        }

    }
}
