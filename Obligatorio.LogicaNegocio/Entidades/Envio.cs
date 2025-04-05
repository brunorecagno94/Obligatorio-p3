
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Envio: IEntity, IEquatable<Envio>
    {
        public int Id { get; set; }
        public string Empleado { get; set; } //TODO: Actualizar con Empleado
        public string Cliente { get; set; } //TODO: Actualizar con Cliente
        public PesoPaquete PesoPaquete { get; set; }
        public NumeroTracking NumeroTracking { get; set; }
        public List<string> ListaComentario { get; set; } // TODO: Actualizar con Comentario

        public Envio(string empleado, string cliente, PesoPaquete pesoPaquete, NumeroTracking numeroTracking, List<string> listaComentario)
        {
            Empleado = empleado;
            Cliente = cliente;
            PesoPaquete = pesoPaquete;
            NumeroTracking = numeroTracking;
            ListaComentario = listaComentario;
        }

        public bool Equals(Envio? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }
    }
}
