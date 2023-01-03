        using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;   
namespace Infrastructure.Services
{
    public class MovieService
    {



    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MovieService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<MovieDto>>> GetMovies()
    {
        var list = await _context.Movies.Select(x => new MovieDto()
        {
            MovieId = x.MovieId,

            Title = x.Title,
            MovieYear = x.MovieYear,
            CategoryId = x.CategoryId
        }).ToListAsync();

        return new Response<List<MovieDto>>(list);
    }

    public async Task<Response<MovieDto>> AddAlbum(MovieDto album)
    {
        var newAlbum = _mapper.Map<Movie>(album);
        _context.Movies.Add(newAlbum);
        await _context.SaveChangesAsync();
        return new Response<MovieDto>(album);
    }

    public async Task<Response<MovieDto>> UpdateAlbum(MovieDto album)
    {
        var find = await _context.Movies.FindAsync(album.MovieId);
        find.Title = album.Title;
        find.MovieYear = album.MovieYear;
        find.CategoryId = album.CategoryId;

        await _context.SaveChangesAsync();
        return new Response<MovieDto>(album);
    }

    public async Task<Response<string>> DeleteAlbum(int id)
    {
        var find = await _context.Movies.FindAsync(id);
        _context.Movies.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }
     public async Task<Response<List<MovieDto>>> GetMovieByName(string name)
    {
            var find = await (from e in _context.Movies
            where e.Title.Equals(name)
            select new MovieDto()
            {
                     MovieId = e.MovieId,
                MovieYear = e.MovieYear,
                CategoryId = e.CategoryId,
                Title = e.Title
            }).ToListAsync();

            return new Response<List<MovieDto>>(find);
    }
}

    }
