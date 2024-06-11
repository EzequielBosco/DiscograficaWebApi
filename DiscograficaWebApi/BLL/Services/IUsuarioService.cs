using DiscograficaWebApi.DTOs.Usuario;

namespace DiscograficaWebApi.BLL.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDto> Create(UsuarioCreateRequestDto request);
        Task<UsuarioResponseDto> GetUsuarioByUserName(string username);
        Task<UsuarioResponseDto> Login(UsuarioLoginRequestDto request);
    }
}
