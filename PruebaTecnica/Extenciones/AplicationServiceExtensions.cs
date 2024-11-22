using Dominio.Entidades;
using Logica.Implementacion;
using Logica.Interfaz;
using Microsoft.EntityFrameworkCore;
using Repositorio.Implementacion;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace PruebaTecnica.Extenciones
{
    public static class AplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<PruebaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddScoped<ITareaRepositorio, TareaRepositorio>();
            services.AddScoped<ITareaLogica, TareaLogica>();   
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<IUnidadTrabajo, UnidadTrabajo.Implementacion.UnidadTrabajo>();
            return services;
        }
    }
}
