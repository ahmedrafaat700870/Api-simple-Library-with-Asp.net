namespace ToursApi.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        [MaxLength(250)]
        public string StoreLine { get; set; }
     
        public byte GenraId { get; set; }
    }
}
