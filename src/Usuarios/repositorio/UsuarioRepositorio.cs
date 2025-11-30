using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Usuarios.Context;
using Usuarios.Entidad;

namespace Usuarios.repositorio;

public interface IUsuarioRepositorio
{
    Task<bool> crearUsuario(Usuario usuario);
}
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private UsuariosDbContext _context;
    public UsuarioRepositorio(UsuariosDbContext context)
    {
        _context = context;
    }
    public async Task<bool> crearUsuario(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        catch (DbUpdateException ex)
        {
            return false;
        }
    }
}
