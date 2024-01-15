﻿using System.ComponentModel.DataAnnotations;

namespace ImSuperSir.GameStore.API.DTOs;


public record GameDtov1
(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record GameDtov2
(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    decimal PriceRetail,
    DateTime ReleaseDate,
    string ImageUri
);


public record CreateGameDto
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);

public record UpdateGameDto
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);