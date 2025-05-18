namespace Obligatorio.WebApp.Models
{
    public class VMEnvioListado
    {
        public int Id { get; set; }
        public int NumeroTracking { get; set; }
        public bool EsUrgente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Estado { get; set; }

        public VMEnvioListado(int id, int numeroTracking, bool esUrgente, string emailCliente, DateTime dateTime, string estado)
        {
            Id = id;
            NumeroTracking = numeroTracking;
            EsUrgente = esUrgente;
            EmailCliente = emailCliente;
            FechaSalida = dateTime;
            Estado = estado;
        }

    }
}
