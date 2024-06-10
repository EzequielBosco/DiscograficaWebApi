using DiscograficaWebApi.DTOs.Discografica;

namespace DiscograficaWebApi.BLL.Services;

public interface IDiscograficaService
{
    Task<DiscograficaResponseDto> Create(DiscograficaCreateRequestDto request);
}
