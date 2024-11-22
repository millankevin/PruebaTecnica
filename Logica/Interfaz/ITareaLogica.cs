using Dominio.Dto;
using Dominio.Utilidades;

namespace Logica.Interfaz
{
    public interface ITareaLogica
    {
        Task<Respuesta<TareaDto>> ConsultarTarea(int idTarea);
        Task<Respuesta<string>> CrearTarea(CrearTareaDto tareaNueva);
        Task<Respuesta<string>> EliminaTarea(int idTarea);
        Task<Respuesta<string>> ModificarTarea(CrearTareaDto tareaEditar);
        Task<Respuesta<List<TareaDto>>> ObtenerTareas();
    }
}
