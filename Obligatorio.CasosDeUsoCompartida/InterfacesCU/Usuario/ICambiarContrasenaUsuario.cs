using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

public interface ICambiarContrasenaUsuario
{
    void Execute(int id, CambiarContrasenaDTO dto);
}