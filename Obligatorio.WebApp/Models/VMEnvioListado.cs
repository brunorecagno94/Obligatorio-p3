namespace Obligatorio.WebApp.Models
{
    public class VMEnvioListado
    {
        public int NumeroTracking { get; set; }
        public bool EsUrgente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Estado { get; set; }

        public VMEnvioListado(int numeroTracking, bool esUrgente, string emailCliente, DateTime dateTime, string estado)
        {
            NumeroTracking = numeroTracking;
            EsUrgente = esUrgente;
            EmailCliente = emailCliente;
            FechaSalida = dateTime;
            Estado = estado;
        }

    }
}
