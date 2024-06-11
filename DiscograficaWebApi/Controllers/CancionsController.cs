using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Cancion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionsController : ControllerBase
    {
        private readonly ILogger<CancionsController> _logger;
        private readonly ICancionService _cancionService;

        public CancionsController(ILogger<CancionsController> logger, ICancionService cancionService)
        {
            _logger = logger;
            _cancionService = cancionService;
        }

        //[HttpGet("GetAll")]
        //public async Task<ActionResult<List<CancionResponseDto>>> GetAll()
        //{
        //    try
        //    {
        //        _logger.LogInformation("GetAllCanciones");

        //        var canciones = await _cancionService.GetAll();
        //        if (canciones.Count == 0)
        //        {
        //            _logger.LogWarning("No se encontraron canciones");
        //            return NotFound("No se encontraron canciones");
        //        }

        //        return Ok(canciones);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error al obtener las canciones");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las canciones");
        //    }
        //}

        [HttpGet("GetByFilter")]
        public async Task<ActionResult<List<CancionFilterResponseDto>>> GetByFilter([FromQuery] CancionFilterRequestDto request)
        {
            try
            {
                _logger.LogInformation("GetByFilterCanciones");

                var canciones = await _cancionService.GetByFilter(request);
                if (canciones.Count == 0)
                {
                    _logger.LogWarning("No se encontraron canciones");
                    return NotFound("No se encontraron canciones");
                }

                return Ok(canciones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las canciones");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las canciones");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CancionResponseDto>> Create([FromBody] CancionCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("CreateCancion");

                var cancion = await _cancionService.Create(request);

                return Ok(cancion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la canción");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la canción");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<CancionResponseDto>> Update(long id, CancionUpdateRequestDto request)
        {
            try
            {
                _logger.LogInformation("UpdateCancion");

                var cancion = await _cancionService.Update(id, request);

                return Ok(cancion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la canción");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la canción");
            }
        }
    }
}
