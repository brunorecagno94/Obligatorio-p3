using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

public class AddComentario : IAddComentario
{
    private readonly IRepositorioEnvio _repo;

    public AddComentario(IRepositorioEnvio repo)
    {
        _repo = repo;
    }

    public void Execute(string textoComentario, int empleadoId, int envioId)
    {
        Envio envio = _repo.GetById(envioId) ?? throw new NotFoundException("Envío no encontrado");
        envio.AgregarComentario(textoComentario, empleadoId, envioId);
        _repo.Update(envioId, envio);
    }
}