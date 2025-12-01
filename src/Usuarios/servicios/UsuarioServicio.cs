using Microsoft.AspNetCore.Mvc;
using Usuarios.Entidad;
using Usuarios.repositorio;

namespace Usuarios.servicios;


public interface IUsuarioServicio
{
    Task<bool> crearUsuario(string nombre, string email, string? telefono);
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
    public async Task<bool> crearUsuario(string nombre, string email, string? telefono)
    {
        Cliente usuario = new Cliente
        {
            FechaCreacion = DateTime.UtcNow,
            Nombre = nombre,
            Email = email,
            Telefono = telefono
        };
        return await _usuarioRepo.crearUsuario(usuario);
    }
}
