using Microsoft.EntityFrameworkCore;

namespace ToursApi.Models
{
    public class ApplecationDbContext :DbContext
    {
        public ApplecationDbContext(DbContextOptions<ApplecationDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Genra> Genras { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
