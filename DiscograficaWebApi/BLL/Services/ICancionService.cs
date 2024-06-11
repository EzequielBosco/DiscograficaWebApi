using DiscograficaWebApi.DTOs.Cancion;

namespace DiscograficaWebApi.BLL.Services;

public interface ICancionService
{
    Task<CancionResponseDto> Create(CancionCreateRequestDto request);
    Task<List<CancionResponseDto>> GetAll();
    Task<CancionResponseDto> GetById(long id);
    Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request);
    Task<CancionResponseDto> Update(long id, CancionUpdateRequestDto request);
}
