using AutoMapper;
using DiscograficaWebApi.BLL.Utils;
using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;
using DiscograficaWebApi.DTOs.Cancion;
using DiscograficaWebApi.DTOs.Disco;
using DiscograficaWebApi.DTOs.Discografica;
using DiscograficaWebApi.DTOs.Usuario;

namespace DiscograficaWebApi.BLL;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        // Artista
        CreateMap<Artista, ArtistaResponseDto>()
            .ForMember(dest => dest.FechaNacimiento,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaNacimiento)));
        CreateMap<ArtistaCreateRequestDto, Artista>();
        // Discografica
        CreateMap<Discografica, DiscograficaResponseDto>()
            .ForMember(dest => dest.FechaFundacion,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaFundacion)));
        CreateMap<DiscograficaCreateRequestDto, Discografica>();
        // Disco
        CreateMap<Disco, DiscoResponseDto>()
            .ForMember(dest => dest.FechaLanzamiento,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaLanzamiento)));
        CreateMap<DiscoCreateRequestDto, Disco>();
        CreateMap<DiscoUpdateRequestDto, Disco>();
        CreateMap<DiscoFilterRequestDto, Disco>();
        CreateMap<Disco, DiscoFilterResponseDto>()
            .ForMember(dest => dest.CantidadCanciones,
                    opt => opt.MapFrom(src => src.Cancions.Count))
            .ForMember(dest => dest.FechaLanzamiento,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaLanzamiento)));
        // Cancion
        CreateMap<Cancion, CancionResponseDto>()
            .ForMember(dest => dest.FechaLanzamiento,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaLanzamiento)));
        CreateMap<CancionCreateRequestDto, Cancion>();
        CreateMap<CancionFilterRequestDto, Cancion>();
        CreateMap<Cancion, CancionFilterResponseDto>()
            .ForMember(dest => dest.FechaLanzamiento,
                    opt => opt.MapFrom(src => FormatearFechaUtils.FormatearFecha(src.FechaLanzamiento)));
        // Usuario
        CreateMap<Usuario, UsuarioResponseDto>();
        CreateMap<UsuarioCreateRequestDto, Usuario>();
    }
}
