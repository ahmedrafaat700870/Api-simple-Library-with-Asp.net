namespace ToursApi.Services
{
    public class CslMovies : IGenraicMovies
    {
        private readonly ApplecationDbContext _Context;

        public CslMovies(ApplecationDbContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<Movie>> GetAll(int id = 0) =>
            await _Context.Movies.Include(x => x.Genra)
                .OrderByDescending(x => x.Rate)
                .ToListAsync();

        public async Task<Movie> GetById(int id) => await _Context.Movies
                .Include(x => x.Genra)
                .FirstOrDefaultAsync(m => m.MovieId == id);

        public async Task<Movie> Delete(Movie movie)
        {
            _Context.Remove(movie);
            _Context.SaveChanges();
            return movie;
        }
        public async Task<Movie> Update(Movie movie)
        {
            _Context.Update(movie);
            await _Context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenreId(byte id) =>
           await _Context.Movies
                 .Include(I => I.Genra)
                 .Where(x => x.GenraId == id)
                 .OrderBy(o => o.Rate)
                 .ToListAsync();
        public async Task<Movie> Create(Movie movie)
        {
            _Context.Add(movie);
            await  _Context.SaveChangesAsync();
            return movie;
        }
    }
}
