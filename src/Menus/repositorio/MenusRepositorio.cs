using Menus.Context;
using Menus.Entidad;
using Menus.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Menus.repositorio;

public interface IMenusRepositorio
{
    Task<int> CrearMenu(Menu m);
    Task<Menu> ObtenerMenu(int idMenu);
}
public class MenusRepositorio : IMenusRepositorio
{
    private MenuDbContext _context;

    public MenusRepositorio(MenuDbContext context)
    {
        this._context = context;
    }

    public Task<int> CrearMenu(Menu m)
    {
        this._context.Menus.AddAsync(m);
        var filasActualizadas =  this._context.SaveChangesAsync();
        return filasActualizadas;
    }

    public async Task<Menu> ObtenerMenu(int idMenu)
    {
        return await this._context.Menus.Where(m => m.Id == idMenu).FirstOrDefaultAsync();
    }
}
