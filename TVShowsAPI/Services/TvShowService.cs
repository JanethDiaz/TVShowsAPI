using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using TVShowsAPI.DTOs;
using TVShowsAPI.Models;

namespace TVShowsAPI.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        private const string CacheKey = "TvShowsList";

        public TvShowService(IMemoryCache cache, IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;

            if (!_cache.TryGetValue(CacheKey, out List<TvShow> _))
            {
                var initialTvShows = new List<TvShow>
                {
                    new TvShow { Id = 1, Name = "Breaking Bad", Favorite = true },
                    new TvShow { Id = 2, Name = "Stranger Things", Favorite = false }
                };
                _cache.Set(CacheKey, initialTvShows);
            }
        }

        public List<TvShow> GetAllTvShows() => _cache.Get<List<TvShow>>(CacheKey);

        public TvShow GetTvShowById(int id) => GetAllTvShows().FirstOrDefault(t => t.Id == id);

        public TvShowServiceResult<TvShowDto> AddTvShow(CreateTvShowDto tvShowDto)
        {
            var tvShows = GetAllTvShows();

            if (tvShows.Any(t => t.Name.Equals(tvShowDto.Name, StringComparison.OrdinalIgnoreCase)))
                return new TvShowServiceResult<TvShowDto>("Este TV show ya está guardado.");

            var newTvShow = new TvShow
            {
                Id = tvShows.Any() ? tvShows.Max(t => t.Id) + 1 : 1,
                Name = tvShowDto.Name,
                Favorite = tvShowDto.Favorite
            };

            tvShows.Add(newTvShow);
            _cache.Set(CacheKey, tvShows);

            return new TvShowServiceResult<TvShowDto>(_mapper.Map<TvShowDto>(newTvShow), "TV show guardado correctamente.");
        }

        public TvShowServiceResult<string> UpdateTvShow(int id, UpdateTvShowDto tvShowDto)
        {
            var tvShows = GetAllTvShows();
            var existingTvShow = tvShows.FirstOrDefault(t => t.Id == id);

            if (existingTvShow == null)
                return new TvShowServiceResult<string>("TV show no encontrado para actualizar.");

            existingTvShow.Name = tvShowDto.Name;
            existingTvShow.Favorite = tvShowDto.Favorite;
            _cache.Set(CacheKey, tvShows);

            return new TvShowServiceResult<string>(null, "TV show actualizado correctamente.");
        }

        public TvShowServiceResult<string> DeleteTvShow(int id)
        {
            var tvShows = GetAllTvShows();
            var tvShowToRemove = tvShows.FirstOrDefault(t => t.Id == id);

            if (tvShowToRemove == null)
                return new TvShowServiceResult<string>("TV show no encontrado para eliminar.");

            tvShows.Remove(tvShowToRemove);
            _cache.Set(CacheKey, tvShows);

            return new TvShowServiceResult<string>(null, "TV show eliminado correctamente.");
        }
    }
}
