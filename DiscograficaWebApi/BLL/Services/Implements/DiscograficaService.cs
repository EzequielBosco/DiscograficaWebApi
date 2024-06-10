using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Discografica;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class DiscograficaService : IDiscograficaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DiscograficaService> _logger;

    public DiscograficaService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DiscograficaService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscograficaResponseDto> Create(DiscograficaCreateRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de Create Discografia");

            var nombreDiscografica = await _unitOfWork.DiscograficaRepository.GetByNombre(request.Nombre);
            if (nombreDiscografica != null)
            {
                _logger.LogError($"Error, la discografica con el nombre: {request.Nombre} ya existe");
                throw new Exception("La discografica ya existe");
            }

            var discografica = _mapper.Map<Discografica>(request);
            await _unitOfWork.DiscograficaRepository.Add(discografica);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError($"Error al guardar la nueva discografica");
                throw new Exception("No se pudo guardar la nueva discografica");
            }

            var discograficaResponse = _mapper.Map<DiscograficaResponseDto>(discografica);

            _logger.LogInformation("Se han obtenido todas las canciones correctamente");
            return discograficaResponse;
        } catch (Exception ex)
        {
            _logger.LogError($"Error al crear discografica");
            throw new Exception(ex.Message);
        }
    }
}
