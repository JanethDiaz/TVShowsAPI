using TVShowsAPI.Models;

namespace TVShowsAPI.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly List<TvShow> _tvShows = new();

        public TvShowService()
        {
            // Carga de datos iniciales
            _tvShows.Add(new TvShow { Id = 1, Name = "Breaking Bad", Favorite = true });
            _tvShows.Add(new TvShow { Id = 2, Name = "Game of Thrones", Favorite = false });
            _tvShows.Add(new TvShow { Id = 3, Name = "Stranger Things", Favorite = true });
        }

        public IEnumerable<TvShow> GetAll() => _tvShows;

        public TvShow GetById(int id) => _tvShows.FirstOrDefault(tv => tv.Id == id);

        public void Add(TvShow tvShow)
        {
            tvShow.Id = _tvShows.Max(tv => tv.Id) + 1; 
            _tvShows.Add(tvShow);
        }

        public void Update(int id, TvShow tvShow)
        {
            var existingTvShow = _tvShows.FirstOrDefault(tv => tv.Id == id);
            if (existingTvShow != null)
            {
                existingTvShow.Name = tvShow.Name;
                existingTvShow.Favorite = tvShow.Favorite;
            }
        }

        public void Delete(int id)
        {
            var tvShow = _tvShows.FirstOrDefault(tv => tv.Id == id);
            if (tvShow != null)
            {
                _tvShows.Remove(tvShow);
            }
        }
    }
}
