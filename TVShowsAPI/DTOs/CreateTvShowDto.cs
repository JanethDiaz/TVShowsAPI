using System.ComponentModel.DataAnnotations;

namespace TVShowsAPI.DTOs
{
    public class CreateTvShowDto
    {
        [Required]
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
