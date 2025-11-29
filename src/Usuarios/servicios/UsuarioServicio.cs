using Microsoft.AspNetCore.Mvc;

namespace Usuarios.servicios;


public interface IUsuarioServicio
{
    void crearUsuario(string nombre, string email);
}
public class UsuarioServicio : IUsuarioServicio
{
    public void crearUsuario(string nombre, string email)
    {
        throw new NotImplementedException();
    }
}
