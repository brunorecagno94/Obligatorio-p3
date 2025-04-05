using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Direccion
    {
        public string Calle { get; }
        public string Numero { get; }
        public string CodigoPostal { get; }

        public Direccion(string calle, string numero, string codigoPostal)
        {
            Calle = calle;
            Numero = numero;
            CodigoPostal = codigoPostal;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle))
                throw new CalleException("Calle inválida");
            if (string.IsNullOrEmpty(Numero))
                throw new NumeroException("Número inválido");
            if (string.IsNullOrEmpty(CodigoPostal))
                throw new CodigoPostalException("Código postal inválido");
        }
    }
}
