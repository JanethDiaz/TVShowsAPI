using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.Models;
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
        public ActionResult<IEnumerable<TvShow>> GetTvShows()
        {
            return Ok(_tvShowService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TvShow> GetTvShow(int id)
        {
            var tvShow = _tvShowService.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return Ok(tvShow);
        }

        [HttpPost]
        public ActionResult<TvShow> PostTvShow([FromBody] TvShow tvShow)
        {
            _tvShowService.Add(tvShow);
            return CreatedAtAction(nameof(GetTvShow), new { id = tvShow.Id }, tvShow);
        }

        [HttpPut("{id}")]
        public IActionResult PutTvShow(int id, [FromBody] TvShow tvShow)
        {
            _tvShowService.Update(id, tvShow);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTvShow(int id)
        {
            _tvShowService.Delete(id);
            return NoContent();
        }
    }
}
