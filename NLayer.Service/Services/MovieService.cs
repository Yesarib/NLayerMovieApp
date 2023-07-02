using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class MovieService : Service<Movies>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movies> repository, IUnitOfWork unitOfWork, IMapper mapper, IMovieRepository movieRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<CustomResponseDto<List<MovieWithCategoryDto>>> GetMovieWithCategory()
        {
            var movies = await _movieRepository.GetMovieWithCategory();
            var moviesDto = _mapper.Map<List<MovieWithCategoryDto>>(movies);
            return CustomResponseDto<List<MovieWithCategoryDto>>.Success(200,moviesDto);

        }
    }
}
