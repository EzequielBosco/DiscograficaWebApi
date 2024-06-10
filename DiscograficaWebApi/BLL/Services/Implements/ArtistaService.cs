using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class ArtistaService : IArtistaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ArtistaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ArtistaResponseDto> Create(ArtistaCreateRequestDto request)
    {
        try
        {
            var nombreArtistico = await _unitOfWork.ArtistaRepository.GetByNombreArtistico(request.NombreArtistico);
            if (nombreArtistico != null)
            {
                throw new Exception("El artista ya existe");
            }

            var artista = _mapper.Map<Artista>(request);
            await _unitOfWork.ArtistaRepository.Add(artista);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                throw new Exception("No se pudo guardar el nuevo artista");
            }

            var artistaResponse = _mapper.Map<ArtistaResponseDto>(artista);

            return artistaResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
