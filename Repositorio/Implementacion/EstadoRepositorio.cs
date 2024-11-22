using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implementacion
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly PruebaDbContext _context;

        public EstadoRepositorio(PruebaDbContext context)
        {
            _context = context;
        }

        public async Task<Estado> ConsultarEstado(int idEstado)
        {
            return await _context.Estados.FirstOrDefaultAsync(e => e.Id == idEstado);
        }
    }
}
