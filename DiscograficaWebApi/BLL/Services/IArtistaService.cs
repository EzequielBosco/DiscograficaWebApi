using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.BLL.Services;

public interface IArtistaService
{
    Task<ArtistaResponseDto> Create(ArtistaCreateRequestDto request);
}
