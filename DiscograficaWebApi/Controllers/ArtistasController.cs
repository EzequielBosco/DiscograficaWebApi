using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Artista;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly ILogger<ArtistasController> _logger;
        private readonly IArtistaService _artistaService;

        public ArtistasController(ILogger<ArtistasController> logger, IArtistaService artistaService)
        {
            _logger = logger;
            _artistaService = artistaService;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<ArtistaResponseDto>> Create([FromBody] ArtistaCreateRequestDto artistaRequestDto)
        {
            try
            {
                _logger.LogInformation("CreateArtista");

                var artista = await _artistaService.Create(artistaRequestDto);
                return Ok(artista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el artista");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el artista");
            }
        }
    }
}
