using Microsoft.AspNetCore.Mvc;
using Menus.servicios;
using Menus.ModelView;

namespace Menus.controladores
{
    [ApiController]
    [Route("api/menus")]
    public class MenusController : Controller
    {
        private IMenusServicio _menuServicio;

        public MenusController(IMenusServicio menuServicio)
        {
            this._menuServicio = menuServicio;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ListarMenu(int id) {

            try
            {
                MenuModelView menu = await this._menuServicio.ObtenerMenu(id);
                if(menu == null)
                    return NotFound("Menu no encontrado, id:" + id);
                return Ok(menu);
            }
            catch (Exception ex) 
            { 
                return BadRequest("SE GENERO UN ERROR INESPERADO: " + ex.Message);
            }
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearMenu([FromBody] MenuModelView menu) {
            try
            {
                await this._menuServicio.CrearMenu(menu);
                return Ok();
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

    }
}
