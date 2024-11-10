using System.ComponentModel.DataAnnotations;

namespace TVShowsAPI.DTOs
{
    public class UpdateTvShowDto
    {
        [Required]
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
