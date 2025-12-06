using Microsoft.EntityFrameworkCore;
using Ordenes.Context;
using Ordenes.Entidad;
using System.Threading.Tasks;

namespace Ordenes.repositorios;

public interface IOrdenesRepositorio
{
    Task<bool> ConfirmarOrden(Orden orden);
    Task<List<Orden>> ObtenerOrdenesDeCliente(int id);
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

    public async Task<List<Orden>> ObtenerOrdenesDeCliente(int id)
    {
        return await this._context.Ordenes
            .Where(o => o.IdUsuario == id)
            .ToListAsync();
    }
}
