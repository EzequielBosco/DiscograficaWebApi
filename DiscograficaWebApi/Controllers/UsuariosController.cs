using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(ILogger<UsuariosController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UsuarioResponseDto>> Create([FromBody] UsuarioCreateRequestDto usuarioRequestDto)
        {
            try
            {
                _logger.LogInformation("CreateUsuario");

                var usuario = await _usuarioService.Create(usuarioRequestDto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario");
            }
        }
    }
}
