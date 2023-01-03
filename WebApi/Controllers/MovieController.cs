namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

[ApiController]
[Route("controller")]


public class MovieController
{
    private readonly MovieService _MovieService;

    public MovieController(MovieService _movieService)
    {
        _MovieService = _movieService;
    }

    [HttpGet("GetMovie")]
    public async Task<Response<List<MovieDto>>> Getmovie(string name)
    {
        return await _MovieService.GetMovieByName(name);
    }

}
