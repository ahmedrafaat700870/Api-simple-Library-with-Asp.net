namespace ToursApi.Services
{
    public interface IGenraicMovies
    {
        Task<IEnumerable<Movie>> GetAll (int id = 0 );
        Task<Movie> GetById (int id);
        Task<Movie> Delete(Movie movie);
        Task<Movie> Update(Movie movie);
        Task<IEnumerable<Movie>> GetMovieByGenreId(byte id);
        Task<Movie> Create(Movie movie);
    }
}
