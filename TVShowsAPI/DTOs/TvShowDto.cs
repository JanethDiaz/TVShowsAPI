using System.ComponentModel.DataAnnotations;

namespace TVShowsAPI.DTOs
{
    public class TvShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
