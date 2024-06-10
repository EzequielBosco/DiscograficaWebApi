using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Disco;

namespace DiscograficaWebApi.BLL.Services.Implements;

public class DiscoService : IDiscoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DiscoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DiscoResponseDto> Create(DiscoCreateRequestDto request)
    {
        try
        {
            var disco = _mapper.Map<Disco>(request);
            await _unitOfWork.DiscoRepository.Add(disco);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                throw new Exception("No se pudo guardar el nuevo disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            return discoResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoResponseDto>> GetAll()
    {
        try
        {
            var discos = await _unitOfWork.DiscoRepository.GetAll();
            if (discos.Count == 0)
            {
                throw new Exception("No hay discos");
            }

            var discosResponse = _mapper.Map<List<DiscoResponseDto>>(discos);

            return discosResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<DiscoResponseDto> GetById(int id)
    {
        try
        {
            var disco = await _unitOfWork.DiscoRepository.GetById(id);
            if (disco == null)
            {
                throw new Exception("El disco no existe");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            return discoResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByMasVendidos()
    {
        try
        {
            var discos = await _unitOfWork.DiscoRepository.GetTop5MasVendidos();
            if (discos.Count == 0)
            {
                throw new Exception("No hay discos vendidos");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            return discosResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByFilter(DiscoFilterRequestDto request)
    {
        try
        {
            var discos = await _unitOfWork.DiscoRepository.GetByFilter(request);
            if (discos.Count == 0)
            {
                throw new Exception("No se encontraron discos con los filtros seleccionados");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            return discosResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public async Task<DiscoResponseDto> Update(string SKU, DiscoUpdateRequestDto request)
    {
        try
        {
            var disco = await _unitOfWork.DiscoRepository.GetBySKU(SKU);
            if (disco == null)
            {
                throw new Exception("El disco no existe");
            }

            _mapper.Map(request, disco);

            await _unitOfWork.DiscoRepository.Update(disco);
            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                throw new Exception("No se pudo actualizar el disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);
            return discoResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
