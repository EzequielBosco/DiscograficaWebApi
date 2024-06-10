using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class ArtistaService : IArtistaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ArtistaService> _logger;

    public ArtistaService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ArtistaService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ArtistaResponseDto> Create(ArtistaCreateRequestDto request)
    {
        try
        {
            _logger.LogInformation($"Se ejecuta el metodo Create Artista: {request.NombreArtistico}");

            var nombreArtistico = await _unitOfWork.ArtistaRepository.GetByNombreArtistico(request.NombreArtistico);
            if (nombreArtistico != null)
            {
                _logger.LogError($"Ya existe un artista con el nombre artístico: {request.NombreArtistico}");
                throw new Exception("El artista ya existe");
            }

            var artista = _mapper.Map<Artista>(request);
            await _unitOfWork.ArtistaRepository.Add(artista);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al guardar el nuevo artista");
                throw new Exception("No se pudo guardar el nuevo artista");
            }

            var artistaResponse = _mapper.Map<ArtistaResponseDto>(artista);

            _logger.LogInformation($"Artista creado exitosamente. Id: {artista.Id}");
            return artistaResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear artista");
            throw new Exception(ex.Message);
        }
    }
}
