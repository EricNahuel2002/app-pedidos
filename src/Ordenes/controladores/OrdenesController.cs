using Microsoft.AspNetCore.Mvc;
using Ordenes.Dto;
using Ordenes.Entidad;
using Ordenes.servicios;
using System.Threading.Tasks;

namespace Ordenes.controladores;

[ApiController]
[Route("api/ordenes")]
public class OrdenesController : Controller
{

    private IOrdenesServicio _ordenesServicio;

    public OrdenesController(IOrdenesServicio ordenesServicio)
    {
        this._ordenesServicio = ordenesServicio;
    }

    [HttpPost("confirmarOrden")]
    public async Task<IActionResult> ConfirmarOrden([FromBody] MenuCliente orden)
    {
        try
        {
            bool resultado = await this._ordenesServicio.ConfirmarOrden(orden);
            return resultado ? Ok("Orden confirmada exitosamente.") : BadRequest("No se pudo confirmar la orden.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al confirmar la orden: {ex.Message}");
        }
    }

    [HttpGet("cliente/{id}")]
    public async Task<IActionResult> ObtenerOrdenesDeCliente(int id){
        try{
            List<Orden> ordenes = await this._ordenesServicio.ObtenerOrdenesDeCliente(id);
            return ordenes.Count > 0 ? Ok(ordenes) : NotFound("No se encontraron ordenes para el cliente especificado.");
        }
        catch(Exception ex){
            return StatusCode(500, $"Error al traer ordenes del usuario: {ex.Message}");
        }
    }
}
