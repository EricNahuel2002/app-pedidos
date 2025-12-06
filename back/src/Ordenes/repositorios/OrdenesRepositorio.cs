using Microsoft.EntityFrameworkCore;
using Ordenes.Context;
using Ordenes.Entidad;

using System.Threading.Tasks;

namespace Ordenes.repositorios;

public interface IOrdenesRepositorio
{
    Task<bool> CancelarOrden(Orden orden);
    Task<bool> ConfirmarOrden(Orden orden);
    Task<Orden?> ObtenerOrdenDelCliente(int idCliente, int idOrden);
    Task<List<Orden>> ObtenerOrdenesDeCliente(int id);
}
public class OrdenesRepositorio : IOrdenesRepositorio
{
    private OrdenesDbContext _context;
    public OrdenesRepositorio(OrdenesDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CancelarOrden(Orden orden)
    {
        this._context.Ordenes.Update(orden);
        var filasAfectadas = await _context.SaveChangesAsync();
        return filasAfectadas > 0;
    }

    public async Task<bool> ConfirmarOrden(Orden orden)
    {
        _context.Ordenes.Add(orden);
        var filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;

    }

    public async Task<Orden?> ObtenerOrdenDelCliente(int idCliente, int idOrden)
    {
        return await this._context.Ordenes.FirstOrDefaultAsync(o => o.IdOrden == idOrden && o.IdUsuario == idCliente);
    }

    public async Task<List<Orden>> ObtenerOrdenesDeCliente(int id)
    {
        return await this._context.Ordenes
            .Where(o => o.IdUsuario == id)
            .ToListAsync();
    }
}
