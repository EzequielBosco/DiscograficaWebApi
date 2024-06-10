using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Discografica;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class DiscograficaService : IDiscograficaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DiscograficaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DiscograficaResponseDto> Create(DiscograficaCreateRequestDto request)
    {
        try
        {
            var nombreDiscografica = await _unitOfWork.DiscograficaRepository.GetByNombre(request.Nombre);
            if (nombreDiscografica != null)
            {
                throw new Exception("La discografica ya existe");
            }

            var discografica = _mapper.Map<Discografica>(request);
            await _unitOfWork.DiscograficaRepository.Add(discografica);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                throw new Exception("No se pudo guardar la nueva discografica");
            }

            var discograficaResponse = _mapper.Map<DiscograficaResponseDto>(discografica);

            return discograficaResponse;
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
