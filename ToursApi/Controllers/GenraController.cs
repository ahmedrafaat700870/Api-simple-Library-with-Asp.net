namespace ToursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenraController : ControllerBase
    {
        private readonly IGenre _Genre;


        public GenraController(IGenre genre)
        {
            _Genre = genre;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _Genre.GetAll());
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenraDto dto)
        {
            Genra oGenra = new Genra
            {
                Name = dto.Name
            };
            await _Genre.Create(oGenra);
            return Ok(oGenra.Name);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(byte id , [FromBody] GenraDto dto)
        {
            var oGerna = await _Genre.GetById(id);
            if (oGerna is null)
                return BadRequest($"not found genre with id :{id}") ;
            oGerna.Name = dto.Name;
            await _Genre.Update(oGerna);
            return Ok(oGerna);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id )
        {
            var Genre = await _Genre.GetById(id);
            if (Genre is null)
                return NotFound($"not found genre with id :{id}");
            await _Genre.Delete(Genre);
            return Ok(Genre);
        }
    }
}
