using JMusick.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JMusick.Data.Contratos
{
    public interface IOrdenesRepositorio: IRepositorioGenerico<Orden>
    {
        Task<IEnumerable<Orden>> ObtenerTodosConDetallesAsync();
        Task<Orden> ObtenerConDetallesAsync(int id);
    }
}
