using Obligatorio.CasosDeUsoCompartida.DTOs.LogsCrud;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class LogCrudMapper
    {
        public static LogCrud FromDTO(LogCrudDTO logCrud)
        {
            return new LogCrud(logCrud.Id,
                                  logCrud.AccionRealizada,
                                  logCrud.FechaOperacion,
                                  logCrud.UsuarioId);
        }
    }
}
