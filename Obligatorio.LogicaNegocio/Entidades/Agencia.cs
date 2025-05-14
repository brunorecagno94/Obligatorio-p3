
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia: IEntity, IEquatable<Agencia>
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public Direccion Direccion { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public Agencia() { }
        public Agencia(Nombre nombre, Direccion direccion, Ubicacion ubicacion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Ubicacion = ubicacion;
        }

        public bool Equals(Agencia? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }
    }
}
