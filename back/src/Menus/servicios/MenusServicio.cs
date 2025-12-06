using Menus.Entidad;
using Menus.ModelView;
using Menus.repositorio;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Menus.servicios;

public interface IMenusServicio
{
    Task<bool> CrearMenu(MenuModelView menu);
    Task<MenuModelView> ObtenerMenu(int idMenu);
    Task<List<MenuModelView>> ObtenerMenus();
}

public class MenusServicio : IMenusServicio
{
    private IMenusRepositorio _MenuRepo;

    public MenusServicio(IMenusRepositorio menuRepo)
    {
        _MenuRepo = menuRepo;
    }

    public async Task<bool> CrearMenu(MenuModelView menu)
    {
        Menu m = new Menu
        {
            Nombre = menu.Nombre,
            Descripcion = menu.Descripcion,
            Precio = menu.Precio,
            Imagen = menu.Imagen
        };
        int filasActualizadas = await this._MenuRepo.CrearMenu(m);
        return filasActualizadas > 0;
    }

    public async Task<MenuModelView> ObtenerMenu(int idMenu)
    {
        Menu m = await _MenuRepo.ObtenerMenu(idMenu);
        return new MenuModelView(m.Id, m.Nombre, m.Descripcion, m.Precio, m.Imagen);
    }

    public async Task<List<MenuModelView>> ObtenerMenus()
    {
        List<Menu> menus = await _MenuRepo.ObtenerMenus();
        List<MenuModelView> menusModelViews = new List<MenuModelView>();
        this.Metodo(menus,menusModelViews);
        return menusModelViews;
    }

    private void Metodo(List<Menu> menus,List<MenuModelView> menusModelView)
    {
        foreach (Menu m in menus) 
        { 
            MenuModelView menuModelView = new MenuModelView (m.Id,m.Nombre,m.Descripcion,m.Precio, m.Imagen);
            menusModelView.Add(menuModelView);
        }
    }
}
