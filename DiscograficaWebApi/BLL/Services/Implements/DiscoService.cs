using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Disco;
using Serilog;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class DiscoService : IDiscoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DiscoService> _logger;

    public DiscoService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DiscoService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscoResponseDto> Create(DiscoCreateRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de Create Disco");

            var artista = await _unitOfWork.ArtistaRepository.GetById(request.ArtistaId);
            if (artista == null)
            {
                _logger.LogWarning($"No se encontró el artista con Id: {request.ArtistaId}");
                throw new Exception($"No se encontró el artista con Id: {request.ArtistaId}");
            }

            var disco = _mapper.Map<Disco>(request);
            await _unitOfWork.DiscoRepository.Add(disco);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al guardar el nuevo disco");
                throw new Exception("No se pudo guardar el nuevo disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            _logger.LogInformation($"Disco creado exitosamente. Id: {disco.Id}");
            return discoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al crear disco");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoResponseDto>> GetAll()
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de GetAll Discos");

            var discos = await _unitOfWork.DiscoRepository.GetAll();
            if (discos.Count == 0)
            {
                _logger.LogWarning("No se encontraron discos");
                throw new Exception("No hay discos");
            }

            var discosResponse = _mapper.Map<List<DiscoResponseDto>>(discos);

            _logger.LogInformation("Discos obtenidos con éxito");
            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al obtener los discos");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoResponseDto>> GetAllWithCanciones()
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de GetAll Discos");

            var discos = await _unitOfWork.DiscoRepository.GetAllWithCanciones();
            if (discos.Count == 0)
            {
                _logger.LogWarning("No se encontraron discos");
                throw new Exception("No hay discos");
            }

            var discosResponse = _mapper.Map<List<DiscoResponseDto>>(discos);

            _logger.LogInformation("Discos obtenidos con éxito");
            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al obtener los discos");
            throw new Exception(ex.Message);
        }
    }

    public async Task<DiscoResponseDto> GetById(int id)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de GeById Disco");

            var disco = await _unitOfWork.DiscoRepository.GetById(id);
            if (disco == null)
            {
                _logger.LogError($"Error, el disco con id: {id} no existe");
                throw new Exception("El disco no existe");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            _logger.LogInformation($"Disco obtenido con éxito. Id: {id}");
            return discoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al otener el disco con Id {id}");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByMasVendidos()
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de GetByMasVendidos Discos");

            var discos = await _unitOfWork.DiscoRepository.GetTop5MasVendidos();
            if (discos.Count == 0)
            {
                _logger.LogError("Error, no hay discos vendidos");
                throw new Exception("No hay discos vendidos");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            _logger.LogInformation($"Discos mas vendidos obtenidos con éxito");
            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al obtener los discos mas vendidos");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByFilter(DiscoFilterRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de GetByFilter Discos");

            var discos = await _unitOfWork.DiscoRepository.GetByFilter(request);
            if (discos.Count == 0)
            {
                _logger.LogWarning("No se encontraron discos con los filtros seleccionados");
                throw new Exception("No se encontraron discos con los filtros seleccionados");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            _logger.LogInformation($"Discos filtrados obtenidos con éxito");
            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al guardar el nuevo disco");
            throw new Exception(ex.Message);
        }
    }


    public async Task<DiscoResponseDto> Update(string SKU, DiscoUpdateRequestDto request)
    {
        try
        {
            _logger.LogInformation("Se inicia el metodo de Update Disco");

            var disco = await _unitOfWork.DiscoRepository.GetBySKU(SKU);
            if (disco == null)
            {
                _logger.LogError("Error, el disco no existe");
                throw new Exception("El disco no existe");
            }

            var artista = await _unitOfWork.ArtistaRepository.GetById(request.ArtistaId);
            if (artista == null)
            {
                _logger.LogError($"Error, el artista con id: {request.ArtistaId} no existe");
                throw new Exception("El artista no existe");
            }

            _mapper.Map(request, disco);

            _unitOfWork.DiscoRepository.Edit(disco);
            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al actualizar el disco");
                throw new Exception("No se pudo actualizar el disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            _logger.LogInformation($"Disco actualizado con éxito. Nombre: {request.Nombre}");
            return discoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al actualizar el disco");
            throw new Exception(ex.Message);
        }
    }
}
