using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Ubicacion
    { 
        public float Latitud { get; }
        public float Longitud { get; }

        public Ubicacion(float latitud, float longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        public void Validar()
        {
            if (Latitud > 0)
                throw new LatitudException("Latitud inválida");
            if (Longitud > 0)
                throw new LongitudException("Longitud inválida");
        }
    }
}
