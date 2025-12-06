using Ordenes.Dto;
using Ordenes.Entidad;
using Ordenes.repositorios;
using System.Net.Http.Json;

namespace Ordenes.servicios;


public interface IOrdenesServicio
{
    Task<bool> ConfirmarOrden(MenuCliente menuCliente);
}
public class OrdenesServicio : IOrdenesServicio
{
    private IOrdenesRepositorio _ordenesRepositorio;
    private HttpClient _http;
    public OrdenesServicio(IOrdenesRepositorio ordenesRepositorio, IHttpClientFactory httpFactory)
    {
        this._ordenesRepositorio = ordenesRepositorio;
        this._http = httpFactory.CreateClient("ApiGateway");
    }
    public async Task<bool> ConfirmarOrden(MenuCliente menuCliente)
    {
        ClienteDto? cliente = await this._http.GetFromJsonAsync<ClienteDto>($"/usuarios/cliente/{menuCliente.IdUsuario}");

        MenuDto? menu = await this._http.GetFromJsonAsync<MenuDto>($"/menus/{menuCliente.IdMenu}");

        if(cliente == null || menu == null) return false;

        Orden orden = new Orden
        {
            IdUsuario = cliente.IdCliente,
            IdMenu = menu.Id,
            NombreCliente = cliente.Nombre,
            EmailCliente = cliente.Email,
            PrecioAPagar = menu.Precio,
            Estado = "pendiente",
            Direccion = cliente.Direccion,
            FechaOrden = DateTime.UtcNow
        };
        return await this._ordenesRepositorio.ConfirmarOrden(orden);
    }
}
