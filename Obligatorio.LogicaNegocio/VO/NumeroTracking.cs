
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record NumeroTracking
    {
        public int Value { get; }
        private static int UltimoNumeroTracking = 1000;

        public NumeroTracking()
        {
            Value = UltimoNumeroTracking++;            
            //Validar();
        }

        public void Validar()
        {
            //if (string.IsNullOrEmpty(Value)) throw new
            //NumeroTrackingException("Numero de tracking inválido");
        }
    }
}
