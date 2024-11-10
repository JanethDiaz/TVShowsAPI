using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.DTOs;
using TVShowsAPI.Services;

namespace TVShowsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;

        public TvShowsController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        [HttpGet]
        public IActionResult GetAllTvShows()
        {
            var tvShows = _tvShowService.GetAllTvShows();
            return Ok(tvShows);
        }

        [HttpGet("{id}")]
        public IActionResult GetTvShowById(int id)
        {
            var tvShow = _tvShowService.GetTvShowById(id);
            if (tvShow == null)
                return NotFound(new { message = "TV show no encontrado." });
            return Ok(tvShow);
        }

        [HttpPost]
        public IActionResult AddTvShow([FromBody] CreateTvShowDto tvShowDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _tvShowService.AddTvShow(tvShowDto);
            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return CreatedAtAction(nameof(GetTvShowById), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTvShow(int id, [FromBody] UpdateTvShowDto tvShowDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _tvShowService.UpdateTvShow(id, tvShowDto);
            if (!result.Success)
                return NotFound(new { message = result.Message });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTvShow(int id)
        {
            var result = _tvShowService.DeleteTvShow(id);
            if (!result.Success)
                return NotFound(new { message = result.Message });

            return NoContent();
        }
    }
}
