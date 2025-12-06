using Ordenes.Context;
using Ordenes.Entidad;
using System.Threading.Tasks;

namespace Ordenes.repositorios;

public interface IOrdenesRepositorio
{
    Task<bool> ConfirmarOrden(Orden orden);
}
public class OrdenesRepositorio : IOrdenesRepositorio
{
    private OrdenesDbContext _context;
    public OrdenesRepositorio(OrdenesDbContext context)
    {
        _context = context;
    }


    public async Task<bool> ConfirmarOrden(Orden orden)
    {
        _context.Ordenes.Add(orden);
        var filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;

    }
}
