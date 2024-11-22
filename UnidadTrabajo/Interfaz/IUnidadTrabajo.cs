using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadTrabajo.Interfaz
{
    public interface IUnidadTrabajo
    {
        Task SaveChanges(CancellationToken token = default);
    }
}
