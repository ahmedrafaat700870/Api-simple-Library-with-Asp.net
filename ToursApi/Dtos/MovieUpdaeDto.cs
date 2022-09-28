namespace ToursApi.Dtos
{
    public class MovieUpdaeDto : MovieDto
    {
        public MovieUpdaeDto() : base() { }
        public IFormFile? Poster { get; set; }
    }
}
