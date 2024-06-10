﻿using DiscograficaWebApi.DAL.Models;
using DiscograficaWebApi.DTOs.Artista;

namespace DiscograficaWebApi.DTOs.Disco;

public class DiscoFilterRequestDto
{
    public string? Nombre { get; set; }
    public GeneroMusical? GeneroMusical { get; set; }
    public int? UnidadesVendidas { get; set; }
    public ArtistaResponseDto? Artista { get; set; }
}