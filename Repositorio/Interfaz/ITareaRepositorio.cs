using Dominio.Entidades;

namespace Repositorio.Interfaz
{
    public interface ITareaRepositorio
    {
        Task<Tarea> ConsultarTarea(int idTarea);
        Task CrearTarea(Tarea datos);
        Task<int> ModificarTarea(Tarea datos);
        Task<List<Tarea>> ObtenerTareas();
    }
}
