namespace ToursApi.Dtos
{
    public class MovieCreateDto : MovieDto
    {
        public MovieCreateDto() : base() { }
        public IFormFile Poster { get; set; }
    }
}
