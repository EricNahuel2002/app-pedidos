using Microsoft.AspNetCore.Mvc;
using Usuarios.modelview;
using Usuarios.repositorio;
using Usuarios.servicios;

namespace Usuarios.controladores
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController: Controller
    {
        private IUsuarioServicio _usuarioServicio;

        public UsuariosController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpPost("crear")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioModelView request)
        {
            var resultado = await _usuarioServicio.crearUsuario(request.Name, request.Email, request?.Phone);
            if (resultado)
            {
                return Ok(new { mensaje = "Usuario creado exitosamente" });
            }
            else
            {
                return StatusCode(500, new { mensaje = "Error al crear el usuario" });
            }
        }
    }
}
