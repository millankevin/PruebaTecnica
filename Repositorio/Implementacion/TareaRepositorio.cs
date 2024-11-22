using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly PruebaDbContext _context;

        public TareaRepositorio(PruebaDbContext context)
        {
            _context = context;
        }
        public async Task CrearTarea(Tarea datos) 
        {
            _context.Tareas.AddAsync(datos);
        }

        public async Task<int> ModificarTarea(Tarea datos)
        {
            var setTarea = await _context.Tareas.FindAsync(datos.Id);
            setTarea.Descripcion = datos.Descripcion;
            setTarea.Titulo = datos.Titulo;
            setTarea.FkIdEstado = datos.FkIdEstado;

            return setTarea.Id;
        }

        public async Task<List<Tarea>> ObtenerTareas()
        {
            return await _context.Tareas
                .Include(e => e.Estado)
                .Where(e => e.FkIdEstado == 1)
                .ToListAsync();
        }

        public async Task<Tarea> ConsultarTarea(int idTarea)
        {
            return await _context.Tareas
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(t=>t.Id == idTarea);
        }
    }
}
