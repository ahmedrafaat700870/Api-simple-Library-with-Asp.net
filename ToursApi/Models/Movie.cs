namespace ToursApi.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        [MaxLength(250)]
        public string StoreLine { get; set; }
        public byte[] Poster { get; set; }
        public byte GenraId { get; set; }
        public Genra Genra { get; set; }
    }
}
