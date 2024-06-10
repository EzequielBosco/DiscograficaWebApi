using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class CancionService : ICancionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CancionService> _logger;

    public CancionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CancionService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CancionResponseDto> Create(CancionCreateRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de Create Cancion");

            var cancion = _mapper.Map<Cancion>(request);
            await _unitOfWork.CancionRepository.Add(cancion);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al guardar la nueva canción");
                throw new Exception("No se pudo guardar la nueva cancion");
            }

            var cancionResponse = _mapper.Map<CancionResponseDto>(cancion);

            _logger.LogInformation($"Canción creada exitosamente. Id: {cancion.Id}");
            return cancionResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear canción");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<CancionResponseDto>> GetAll()
    {
        try
        {
            _logger.LogInformation("Se inicia el método GetAll Canciones");

            var canciones = await _unitOfWork.CancionRepository.GetAll();
            if (canciones.Count == 0)
            {
                _logger.LogWarning("No se encontraron canciones");
                throw new Exception("No hay canciones");
            }

            var cancionesResponse = _mapper.Map<List<CancionResponseDto>>(canciones);

            _logger.LogInformation("Se han obtenido todas las canciones correctamente");
            return cancionesResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las canciones");
            throw new Exception(ex.Message);
        }
    }

    public async Task<CancionResponseDto> GetById(int id)
    {
        try
        {
            _logger.LogInformation($"Se inicia el método GetById Cancion con Id: {id}");

            var cancion = await _unitOfWork.CancionRepository.GetById(id);
            if (cancion == null)
            {
                _logger.LogWarning($"No se encontró la canción con Id: {id}");
                throw new Exception("No se encontro la cancion");
            }

            var cancionResponse = _mapper.Map<CancionResponseDto>(cancion);

            _logger.LogInformation($"Se obtuvo la canción con Id: {id} correctamente");
            return cancionResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener la canción con Id: {id}");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el método GetByFilter Canciones");

            var canciones = await _unitOfWork.CancionRepository.GetByFilter(request);
            if (canciones.Count == 0)
            {
                _logger.LogWarning("No se encontraron canciones con los criterios de búsqueda proporcionados");
                throw new Exception("No se encontraron canciones");
            }

            var cancionesResponse = _mapper.Map<List<CancionFilterResponseDto>>(canciones);

            _logger.LogInformation("Se encontraron canciones con éxito");
            return cancionesResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener las canciones por filtro");
            throw new Exception(ex.Message);
        }
    }
}
