﻿using DiscograficaWebApi.DAL.Models.Enums;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoFilterResponseDto
{
    public string Nombre { get; set; }
    public GeneroMusical GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int UnidadesVendidas { get; set; }
    public ArtistaResponseDto Artista { get; set; }
    public int CantidadCanciones { get; set; }
}
