using TVShowsAPI.Models;

namespace TVShowsAPI.Services
{
    public interface ITvShowService
    {
        IEnumerable<TvShow> GetAll();
        TvShow GetById(int id);
        void Add(TvShow tvShow);
        void Update(int id, TvShow tvShow);
        void Delete(int id);
    }
}
