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
            if (Latitud < -90 || Latitud > 90)
                throw new LatitudException("La latitud debe estar entre -90 y 90 grados.");
            if (Longitud < -180 || Longitud > 180)
                throw new LongitudException("La longitud debe estar entre -180 y 180 grados.");
        }
    }
}
