using DiscograficaWebApi.DTOs.Disco;

namespace DiscograficaWebApi.BLL.Services;

public interface IDiscoService
{
    Task<DiscoResponseDto> Create(DiscoCreateRequestDto request);
    Task<List<DiscoResponseDto>> GetAll();
    Task<DiscoResponseDto> GetById(int id);
    Task<List<DiscoFilterResponseDto>> GetByMasVendidos();
    Task<List<DiscoFilterResponseDto>> GetByFilter(DiscoFilterRequestDto request);
    Task<DiscoResponseDto> Update(string SKU, DiscoUpdateRequestDto request);
}
