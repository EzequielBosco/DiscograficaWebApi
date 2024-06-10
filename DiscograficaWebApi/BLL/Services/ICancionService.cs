using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.BLL.Services;

public interface ICancionService
{
    Task<CancionResponseDto> Create(CancionCreateRequestDto request);
    Task<List<CancionResponseDto>> GetAll();
    Task<CancionResponseDto> GetById(int id);
    Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request);
}
