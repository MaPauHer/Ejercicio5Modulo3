using Ejercicio5Modulo3.Domain.Entities.GetUsuarios;
using Ejercicio5Modulo3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5Modulo3.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> GetUsuariosAsync([FromQuery] GetUsuariosQueryParameters parameters)
        {
            var usuarios = await _usuarioService.GetUsuariosAsync(parameters);
            return Ok(usuarios);
        }


        [HttpPost("AddUsuarios")]
        public async Task<IActionResult> AddUsuariosAsync()
        {
            await _usuarioService.AddUsuariosAsync();
            return Ok("Usuarios agregados exitosamente.");
        }

    }
}