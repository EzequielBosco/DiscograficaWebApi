using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Discografica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscograficasController : ControllerBase
    {
        private readonly ILogger<DiscograficasController> _logger;
        private readonly IDiscograficaService _discograficaService;

        public DiscograficasController(ILogger<DiscograficasController> logger, IDiscograficaService discograficaService)
        {
            _logger = logger;
            _discograficaService = discograficaService;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<DiscograficaResponseDto>> Create(DiscograficaCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("CreateDiscografica");
                var discografica = await _discograficaService.Create(request);

                if (discografica == null)
                {
                    _logger.LogWarning("No se pudo crear la discográfica");
                    return BadRequest("No se pudo crear la discográfica");
                }

                return Ok(discografica);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la discográfica");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la discográfica");
            }
        }
    }
}
