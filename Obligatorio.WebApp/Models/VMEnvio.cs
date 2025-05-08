namespace Obligatorio.WebApp.Models
{
    public class VMEnvio
    {
        public bool EsUrgente { get; set; }
        public string EmailCliente { get; set; }
        public string? CalleDireccion { get; set; }
        public string? NumeroDireccion { get; set; }
        public string? CodigoPostalDireccion{ get; set; }
        public int? IdAgencia { get; set; }
        public float PesoPaquete { get; set; }
    }
}
