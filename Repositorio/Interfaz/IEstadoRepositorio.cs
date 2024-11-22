using Dominio.Entidades;

namespace Repositorio.Interfaz
{
    public interface IEstadoRepositorio
    {
        Task<Estado> ConsultarEstado(int idEstado);
    }
}
