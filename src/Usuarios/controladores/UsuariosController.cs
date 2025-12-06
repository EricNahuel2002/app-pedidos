using Microsoft.AspNetCore.Mvc;
using Usuarios.Entidad;
using Usuarios.modelview;
using Usuarios.repositorio;
using Usuarios.servicios;

namespace Usuarios.controladores;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController: Controller
{
    private IUsuarioServicio _usuarioServicio;

    public UsuariosController(IUsuarioServicio usuarioServicio)
    {
        _usuarioServicio = usuarioServicio;
    }


    [HttpPost("crear-cliente")]
    public async Task<IActionResult> CrearUsuario([FromBody] UsuarioModelView request)
    {
        var resultado = await _usuarioServicio.crearUsuario(request.Nombre, request.Email,request.Contrasenia,request.Direccion, request?.Telefono);
        if (resultado)
        {
            return Ok(new { mensaje = "Usuario creado exitosamente" });
        }
        else
        {
            return StatusCode(500, new { mensaje = "Error al crear el usuario" });
        }
    }

    [HttpPost("iniciar-sesion")]
    public async Task<IActionResult> IniciarSesion([FromBody] UsuarioInicioSesionModelView request){
            var resultado = await _usuarioServicio.IniciarSesion(request.Email,request.Contrasenia);
            if (resultado != null)
            {
                return Ok(resultado.IdCliente);
            }
            else
            {
                return StatusCode(404, new { mensaje = "Error al iniciar sesion" });
            }
    }

    [HttpGet("validarSesion/{id}")]
    public async Task<IActionResult> ValidarSesion(int id)
    {
        bool existe = await _usuarioServicio.validarSesion(id);
        if (existe)
        {
            return Ok(true);
        }
        else
        {
            return StatusCode(404, new { mensaje = "Id no encontrado" });
        }
    }

    [HttpGet("cliente/{id}")]
    public async Task<IActionResult> ObtenerCliente(int id)
    {
        Cliente cliente = await _usuarioServicio.ObtenerClientePorId(id);
        if (cliente != null)
        {
            return Ok(cliente);
        }
        else
        {
            return NotFound(new { mensaje = "Cliente no encontrado" });
        }
    }


}