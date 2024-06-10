﻿using DiscograficaWebApi.DAL.Models;

namespace DiscograficaWebApi.DTOs.Artista;

public class ArtistaCreateRequestDto
{
    public string Nombre { get; set; }
    public string? Apellido { get; set; }
    public string NombreArtistico { get; set; }
    public GeneroMusical? Genero { get; set; }
    public string Email { get; set; }
    public string? Telefono { get; set; }
    public string? Biografia { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public long? DiscograficaId { get; set; }
}
