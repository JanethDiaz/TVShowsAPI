using System.Collections.Generic;
using TVShowsAPI.DTOs;
using TVShowsAPI.Models;

namespace TVShowsAPI.Services
{
    /// <summary>
    ///  Interfaz que define los métodos disponibles para manejar los TV shows.
    /// </summary>
    public interface ITvShowService
    {
        List<TvShow> GetAllTvShows(); 
        TvShow GetTvShowById(int id); 
        TvShowServiceResult<TvShowDto> AddTvShow(CreateTvShowDto tvShowDto); 
        TvShowServiceResult<string> UpdateTvShow(int id, UpdateTvShowDto tvShowDto); 
        TvShowServiceResult<string> DeleteTvShow(int id);
    }
}
