using AutoMapper;
using Dominio.Entidades;
using Repositorio.Implementacion;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace UnidadTrabajo.Implementacion
{
    public class UnidadTrabajo : IDisposable, IUnidadTrabajo
    {
        private ITareaRepositorio _tareRepo { get; set; }
        private readonly PruebaDbContext _context;

        public UnidadTrabajo(PruebaDbContext context)
        {
            _context = context;
            _tareRepo = new TareaRepositorio(context);
        }

        public async Task SaveChanges(CancellationToken token = default) 
        {
            using var transaccion = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync(token);
                await transaccion.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync();
                throw new Exception("Error al guardar los datos.",ex);
            }
        }

        //Cerrar la conexion
        public void Dispose() 
        { 
            _context.Dispose();
        }
    }
}
