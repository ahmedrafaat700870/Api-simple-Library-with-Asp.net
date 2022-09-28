using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using ToursApi.Dtos;
using ToursApi.Services;

namespace ToursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private List<string> _AllowanceExtentions = new List<string> { ".jpg", ".png" };
        private readonly long _MaxSize = 1048576;
        private readonly IGenraicMovies _Movies;
        private readonly IGenre _Genre;
        public MovieController(IGenraicMovies movies, IGenre genre = null)
        {
            _Movies = movies;
            _Genre = genre;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var DataMovie =await _Movies.GetAll();
            return Ok(DataMovie);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var movieData =await _Movies.GetById(id);
            if (movieData is null)
                return NotFound("not found this Genre!");
            MovieDetails dto = new MovieDetails
            {
                MovieId = movieData.MovieId,
                GenraName = movieData.Genra.Name,
                Rate = movieData.Rate,
                StoreLine = movieData.StoreLine,
                Title = movieData.Title,
                Year = movieData.Year
            };
            return Ok(dto);
        }
        [HttpGet("GetByGenraId")]
        public async Task<IActionResult> GetByGenraId (byte GernaId)
        {
            var Data = await _Movies.GetMovieByGenreId(GernaId);
            if (Data.Count()  < 1)
                return NotFound("Not found Genre with this id");
            return Ok(Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MovieCreateDto dto)
        {
            if (!_AllowanceExtentions.Contains(Path.GetExtension(dto.Poster.FileName.ToLower())))
                return BadRequest("not allowed extension!");
            if (dto.Poster.Length > _MaxSize)
                return BadRequest("Max Size is 1mb");
            var isAllowed = await _Genre.isAllowed(dto.GenraId);
            if (!isAllowed)
                return BadRequest("Genra not Contains this id");
        using var DataSteam = new MemoryStream() ;
           await dto.Poster.CopyToAsync(DataSteam);
            Movie movie = new Movie
            {
                GenraId = dto.GenraId,
                Rate = dto.Rate,
                StoreLine = dto.StoreLine,
                Year = dto.Year,
                Title = dto.Title,
                Poster = DataSteam.ToArray(),
            };
            await _Movies.Create(movie);
            return Ok(movie);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var Data = await _Movies.GetById(id);
            if (Data is null)
                return NotFound($"no Data Founded by this id {id}");
            await _Movies.Delete(Data);
            return Ok(Data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, [FromForm] MovieUpdaeDto dto )
        {
            var Data = await _Movies.GetById(id);

            // check from id
            if (Data is null)
                return NotFound($"on Movie with id {id}");
           // check from body Contains Poster
           if (dto.Poster is not null)
            {
                // check from allowance Extensions
                if (!_AllowanceExtentions.Contains(Path.GetExtension(dto.Poster.FileName.ToLower())))
                    return BadRequest("allowance Extensions is jpg and png");
                // check from size 
                if (dto.Poster.Length > _MaxSize)
                    return BadRequest("The max size is 1mp");
                var isAllowed = await _Genre.isAllowed(dto.GenraId);
                if (!isAllowed)
                    return BadRequest("Genre not Contains this id");

                using var DataSteam = new MemoryStream();
                await dto.Poster.CopyToAsync(DataSteam);

                Data.Poster = DataSteam.ToArray();
            }
            Data.Year = dto.Year;
            Data.StoreLine = dto.StoreLine;
            Data.Rate = dto.Rate;
            Data.Title = dto.Title;
            Data.GenraId = dto.GenraId;

            await _Movies.Update(Data);

            return Ok(Data);
        }
    }
}
