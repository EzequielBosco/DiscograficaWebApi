using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Usuario;

namespace DiscograficaWebApi.BLL.Services.Implements
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UsuarioService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UsuarioResponseDto> Create(UsuarioCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("Se inicia el metodo de Create Usuario");

                var existingUser = await _unitOfWork.UsuarioRepository.GetByUserName(request.UserName);
                if (existingUser != null)
                {
                    _logger.LogWarning("El nombre de usuario ya existe");
                    throw new Exception("El nombre de usuario ya existe");
                }

                var usuario = _mapper.Map<Usuario>(request);
                await _unitOfWork.UsuarioRepository.Add(usuario);

                var result = await _unitOfWork.Save();
                if (result == 0)
                {
                    _logger.LogError("Error al guardar el nuevo usuario");
                    throw new Exception("No se pudo guardar el nuevo usuario");
                }

                var usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);

                _logger.LogInformation($"Usuario creado exitosamente. Id: {usuario.Id}");
                return usuarioResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioResponseDto> GetUsuarioByUserName(string username)
        {
            try
            {
                _logger.LogInformation("Se inicia el método GetUsuarioByUserName");

                var usuario = await _unitOfWork.UsuarioRepository.GetByUserName(username);
                if (usuario == null)
                {
                    _logger.LogWarning("No se encontró el usuario");
                    throw new Exception("No se encontró el usuario");
                }

                var usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);

                _logger.LogInformation($"Usuario encontrado. Id: {usuario.Id}");
                return usuarioResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar usuario");
                throw new Exception(ex.Message);
            }
        }
    }
}
