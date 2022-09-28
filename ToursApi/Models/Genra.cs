



namespace ToursApi.Models
{
    public class Genra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
