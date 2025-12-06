using Microsoft.AspNetCore.Mvc;
using Ordenes.Dto;
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
            return resultado ? Ok(new {mensaje: "Orden confirmada exitosamente."}) : BadRequest(new {mensaje: "No se pudo confirmar la orden."});
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al confirmar la orden: {ex.Message}");
        }
    }
}
