using AutoMapper;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Utilidades;
using Logica.Interfaz;
using Logica.Utilidades;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace Logica.Implementacion
{
    public class TareaLogica : ITareaLogica
    {
        private readonly ITareaRepositorio _repositorio;
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IEstadoRepositorio _estadoRepo;

        public TareaLogica(ITareaRepositorio repositorio, IUnidadTrabajo unidadTrabajo, IEstadoRepositorio estadoRepo)
        {
            _repositorio = repositorio;
            _unidadTrabajo = unidadTrabajo;
            _estadoRepo = estadoRepo;
        }

        public async Task<Respuesta<List<TareaDto>>> ObtenerTareas() 
        {
            List<TareaDto> tareasRespuesta = new();
            var tareas = await _repositorio.ObtenerTareas();
            foreach (Tarea tarea in tareas)
            {
                tareasRespuesta.Add(new TareaDto()
                {
                    Id = tarea.Id,
                    Titulo = tarea.Titulo,
                    Descripcion = tarea.Descripcion,
                    FkIdEstado = tarea.Estado.Nombre
                });
            }
            return tareas.Count > 0 ? RespuestaError.RespuestaOkay(tareasRespuesta) :
               RespuestaError.RespuestaSinRegistros<List<TareaDto>>("No hay registros");

        }

        public async Task<Respuesta<TareaDto>> ConsultarTarea(int idTarea)
        {
            TareaDto tareaRespuesta = new();
            var tarea = await _repositorio.ConsultarTarea(idTarea);
            if (tarea is not null) {
                tareaRespuesta.Id = tarea.Id;
                tareaRespuesta.Titulo = tarea.Titulo;
                tareaRespuesta.Descripcion = tarea.Descripcion;
                tareaRespuesta.FkIdEstado = tarea.Estado.Nombre;
            }

            return tarea is not null? RespuestaError.RespuestaOkay(tareaRespuesta) :
               RespuestaError.RespuestaSinRegistros<TareaDto>("No hay registros");
        }

        public async Task<Respuesta<string>> CrearTarea(CrearTareaDto tareaNueva)
        {
            try
            {
                string validador = ValidadorTarea.ValidarCrearTarea(tareaNueva);
                if (!string.IsNullOrEmpty(validador))
                    return RespuestaError.RespuestaOkay(validador);

                Tarea tarea = new();
                tarea.Titulo = tareaNueva.Titulo;
                tarea.Descripcion = tareaNueva.Descripcion;
                tarea.FkIdEstado = tareaNueva.FkIdEstado;
                await _repositorio.CrearTarea(tarea);
                await _unidadTrabajo.SaveChanges();

                return RespuestaError.RespuestaOkay("Tarea creada con éxito");
            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorIntRespuesta<string>(ex.Message);
            }
            
        }

        public async Task<Respuesta<string>> ModificarTarea(CrearTareaDto tareaEditar)
        {
            var respuesta = await _repositorio.ConsultarTarea(tareaEditar.Id);
            if (respuesta is null)
                return RespuestaError.ErrorIntRespuesta<string>("Tarea no existe.");
            else
            {
                try
                {
                    Tarea tarea = new();
                    tarea.Id = respuesta.Id;
                    tarea.Titulo = tareaEditar.Titulo;
                    tarea.Descripcion = tareaEditar.Descripcion;
                    tarea.FkIdEstado = tareaEditar.FkIdEstado;
                    await _repositorio.ModificarTarea(tarea);
                    await _unidadTrabajo.SaveChanges();

                    return RespuestaError.RespuestaOkay("Tarea modificada con éxito");
                }
                catch (Exception ex)
                {
                    return RespuestaError.ErrorIntRespuesta<string>(ex.Message);
                }
            }          

        }

        public async Task<Respuesta<string>> EliminaTarea(int idTarea)
        {
            var respuesta = await _repositorio.ConsultarTarea(idTarea);
            if (respuesta is null)
                return RespuestaError.ErrorIntRespuesta<string>("Tarea no existe.");
            else
            {
                try
                {
                    Tarea tarea = new();
                    tarea.Id = respuesta.Id;
                    tarea.Titulo = respuesta.Titulo;
                    tarea.Descripcion = respuesta.Descripcion;
                    tarea.FkIdEstado = 2;
                    await _repositorio.ModificarTarea(tarea);
                    await _unidadTrabajo.SaveChanges();

                    return RespuestaError.RespuestaOkay("Tarea eliminada con éxito");
                }
                catch (Exception ex)
                {
                    return RespuestaError.ErrorIntRespuesta<string>(ex.Message);
                }
            }

        }
    }
}
