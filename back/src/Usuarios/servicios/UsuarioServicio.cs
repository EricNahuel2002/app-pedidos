using Microsoft.AspNetCore.Mvc;
using Usuarios.Entidad;
using Usuarios.repositorio;

namespace Usuarios.servicios;


public interface IUsuarioServicio
{
    Task<bool> crearUsuario(string nombre, string email,string contrasenia,string direccion, string? telefono);
    Task<Cliente> IniciarSesion(string email, string contrasenia);
    Task<Cliente> ObtenerClientePorId(int id);
    Task<bool> validarSesion(int id);
}
public class UsuarioServicio : IUsuarioServicio
{
    private IUsuarioRepositorio _usuarioRepo;
    private HttpClient _httpClient;

    public UsuarioServicio(IUsuarioRepositorio repo,HttpClient httpClient)
    {
        _usuarioRepo = repo;
        _httpClient = httpClient;
    }
    public async Task<bool> crearUsuario(string nombre, string email,string contrasenia,string direccion, string? telefono)
    {
        Cliente usuario = new Cliente
        {
            FechaCreacion = DateTime.UtcNow,
            Nombre = nombre,
            Email = email,
            Contrasenia = contrasenia,
            Direccion = direccion,
            Telefono = telefono
        };
        return await _usuarioRepo.crearUsuario(usuario);
    }

    public async Task<Cliente> IniciarSesion(string email, string contrasenia)
    {
        Cliente cliente = await _usuarioRepo.ObtenerUsuarioPorEmail(email);

        if (cliente != null && cliente.Contrasenia == contrasenia)
        {
            return cliente;
        }
        return null;
    }

    public async Task<Cliente> ObtenerClientePorId(int id)
    {
        Cliente cliente = await this._usuarioRepo.obtenerUsuarioPorId(id);
        return cliente;
    }

    public async Task<bool> validarSesion(int id)
    {
        Cliente cliente =  await _usuarioRepo.obtenerUsuarioPorId(id);
        return cliente != null;
    }
}
