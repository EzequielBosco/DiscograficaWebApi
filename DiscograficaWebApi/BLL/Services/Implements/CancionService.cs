using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class CancionService : ICancionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CancionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CancionResponseDto> Create(CancionCreateRequestDto request)
    {
        try
        {
            var cancion = _mapper.Map<Cancion>(request);
            await _unitOfWork.CancionRepository.Add(cancion);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                throw new Exception("No se pudo guardar la nueva cancion");
            }

            var cancionResponse = _mapper.Map<CancionResponseDto>(cancion);

            return cancionResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<CancionResponseDto>> GetAll()
    {
        try
        {
            var canciones = await _unitOfWork.CancionRepository.GetAll();
            if (canciones.Count == 0)
            {
                throw new Exception("No hay canciones");
            }

            var cancionesResponse = _mapper.Map<List<CancionResponseDto>>(canciones);

            return cancionesResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CancionResponseDto> GetById(int id)
    {
        try
        {
            var cancion = await _unitOfWork.CancionRepository.GetById(id);
            if (cancion == null)
            {
                throw new Exception("No se encontro la cancion");
            }

            var cancionResponse = _mapper.Map<CancionResponseDto>(cancion);

            return cancionResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request)
    {
        try
        {
            var canciones = await _unitOfWork.CancionRepository.GetByFilter(request);
            if (canciones.Count == 0)
            {
                throw new Exception("No se encontraron canciones");
            }

            var cancionesResponse = _mapper.Map<List<CancionFilterResponseDto>>(canciones);

            return cancionesResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
