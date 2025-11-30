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
        Usuario usuario = new Usuario
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Name = nombre,
            Email = email,
            Phone = telefono
        };
        return await _usuarioRepo.crearUsuario(usuario);
    }
}
