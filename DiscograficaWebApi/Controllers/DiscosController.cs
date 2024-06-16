using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Disco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscosController : ControllerBase
    {
        private readonly ILogger<DiscosController> _logger;
        private readonly IDiscoService _discoService;

        public DiscosController(ILogger<DiscosController> logger, IDiscoService discoService)
        {
            _logger = logger;
            _discoService = discoService;
        }

        //[HttpGet("GetAll")]
        //public async Task<ActionResult<List<DiscoResponseDto>>> GetAll()
        //{
        //    try
        //    {
        //        _logger.LogInformation("GetAllDiscos");

        //        var discos = await _discoService.GetAll();
        //        if (discos.Count == 0)
        //        {
        //            _logger.LogWarning("No se encontraron discos");
        //            return NotFound("No se encontraron discos");
        //        }

        //        return Ok(discos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error al obtener los discos");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los discos");
        //    }
        //}

        [HttpGet("GetAllWithCanciones")]
        public async Task<ActionResult<List<DiscoResponseDto>>> GetAllWithCanciones()
        {
            try
            {
                _logger.LogInformation("GetAllDiscos");

                var discos = await _discoService.GetAllWithCanciones();
                if (discos.Count == 0)
                {
                    _logger.LogWarning("No se encontraron discos");
                    return NotFound("No se encontraron discos");
                }

                return Ok(discos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los discos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los discos");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<DiscoResponseDto>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdDisco");

                var disco = await _discoService.GetById(id);
                if (disco == null)
                {
                    _logger.LogWarning("No se encontró el disco");
                    return NotFound("No se encontró el disco");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener disco");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener disco");
            }
        }

        [HttpGet("GetTop5MasVendidos")]
        public async Task<ActionResult<DiscoResponseDto>> GetTop5MasVendidos()
        {
            try
            {
                _logger.LogInformation("GetTop5MasVendidos");

                var disco = await _discoService.GetByMasVendidos();
                if (disco == null)
                {
                    _logger.LogWarning("No se encontraron discos");
                    return BadRequest("No se encontraron discos");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los discos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los discos");
            }
        }

        [HttpGet("GetByFilter")]
        public async Task<ActionResult<List<DiscoFilterResponseDto>>> GetByFilter([FromQuery] DiscoFilterRequestDto request)
        {
            try
            {
                _logger.LogInformation("GetByFilter");

                var disco = await _discoService.GetByFilter(request);
                if (disco == null)
                {
                    _logger.LogWarning("No se encontraron discos con los filtros seleccionados");
                    return BadRequest("No se encontraron discos con los filtros seleccionados");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, so se encontraron discos con los filtros seleccionados");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, no se encontraron discos con los filtros seleccionados");
            }
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<DiscoResponseDto>> Create(DiscoCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("CreateDisco");

                var disco = await _discoService.Create(request);
                if (disco == null)
                {
                    _logger.LogWarning("No se pudo crear el disco");
                    return BadRequest("No se pudo crear el disco");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear disco");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear disco");
            }
        }

        [Authorize]
        [HttpPut("Update/{SKU}")]
        public async Task<ActionResult<DiscoResponseDto>> Update(string SKU, DiscoUpdateRequestDto request)
        {
            try
            {
                _logger.LogInformation("UpdateDisco");

                var disco = await _discoService.Update(SKU, request);
                if (disco == null)
                {
                    _logger.LogWarning("No se pudo actualizar el disco");
                    return BadRequest("No se pudo actualizar el disco");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar disco");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar disco");
            }
        }
    }
}
