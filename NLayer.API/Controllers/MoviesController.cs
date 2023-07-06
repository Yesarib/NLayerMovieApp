using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class MoviesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _service;

        public MoviesController(IService<Movies> service, IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _service = movieService;
        }

        [HttpGet("GetMoviesWithCategory")]
        public async Task<IActionResult> GetMoviesWithCategory()
        {
            return CreateActionResult(await _service.GetMovieWithCategory());
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _service.GetAllAsync();
            var moviesDtos = _mapper.Map<List<MovieDto>>(movies.ToList());

            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Movies>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movies = await _service.GetByIdAsync(id);
            var moviesDtos = _mapper.Map<MovieDto>(movies);

            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, moviesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var movies = await _service.AddAsync(_mapper.Map<Movies>(movieDto));
            var moviesDtos = _mapper.Map<MovieDto>(movies);

            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, moviesDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
            await _service.UpdateAsync(_mapper.Map<Movies>(movieDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(MovieUpdateDto movieDto)
        //{
        //    await _service.UpdateAsync(_mapper.Map<Movies>(movieDto));

        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var movie =await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movie);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
