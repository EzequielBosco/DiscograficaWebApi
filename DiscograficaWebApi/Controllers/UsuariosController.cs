﻿using DiscograficaWebApi.BLL.Services;
using DiscograficaWebApi.DTOs.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(ILogger<UsuariosController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UsuarioResponseDto>> Create([FromBody] UsuarioCreateRequestDto usuarioRequestDto)
        {
            try
            {
                _logger.LogInformation("CreateUsuario");

                var usuario = await _usuarioService.Create(usuarioRequestDto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioResponseDto>> Login([FromBody] UsuarioLoginRequestDto usuarioLoginRequestDto)
        {
            try
            {
                _logger.LogInformation("LoginUsuario");

                var usuario = await _usuarioService.Login(usuarioLoginRequestDto);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al loguear el usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al loguear el usuario");
            }
        }
    }
}
