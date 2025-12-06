using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Usuarios.Context;
using Usuarios.Entidad;

namespace Usuarios.repositorio;

public interface IUsuarioRepositorio
{
    Task<bool> crearUsuario(Cliente usuario);
    Task<Cliente> ObtenerUsuarioPorEmail(string email);
    Task<Cliente> obtenerUsuarioPorId(int id);
}
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private UsuariosDbContext _context;
    public UsuarioRepositorio(UsuariosDbContext context)
    {
        _context = context;
    }
    public async Task<bool> crearUsuario(Cliente usuario)
    {
        _context.Clientes.Add(usuario);
        var filasAfectadas = await _context.SaveChangesAsync();
        return filasAfectadas > 0;
    }

    public async Task<Cliente> ObtenerUsuarioPorEmail(string email)
    {
        return await _context.Clientes.Where(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<Cliente> obtenerUsuarioPorId(int id)
    {
        return await _context.Clientes.Where(u => u.IdCliente == id).FirstOrDefaultAsync();
    }
}
