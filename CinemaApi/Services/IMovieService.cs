﻿using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;

namespace CinemaApi.Services
{
    public interface IMovieService
    {
        int Create(CreateMovieDto dto);
        void DeleteAll();
        void DeleteById(int movieId);
        List<MovieDto> GetAll();
        MovieDto GetById(int movieId);
        void Update(int movieId, CreateMovieDto dto);
    }
}