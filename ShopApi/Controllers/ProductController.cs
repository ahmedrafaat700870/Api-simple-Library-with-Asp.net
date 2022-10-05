
using System.Reflection.Metadata.Ecma335;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepsitories<TbItem> _repsitories;

        public ProductController(IRepsitories<TbItem> repsitories)
        {
            _repsitories = repsitories;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _repsitories.GetById(x =>x.ItemId == id , new string[] {ClsIncludes.TbItemImages});
            if (data is null)
                return NotFound($"Data no founded by this id {id}");
            return Ok(data);
        }
        [HttpGet("GetByIdAsync/{id}")]
        public async Task< IActionResult> GetByIdAsync(int id)
        {
            var data = await _repsitories.GetByIdAsync(id, x => x.ItemId == id);
            if (data is null)
                return NotFound($"Data no founded by this id {id}");
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() =>
           Ok(_repsitories.GetAll().Take(10));
        [HttpGet("GetRelatedItems/{id}")]
        public IActionResult GetRealatedItems(int id)
        {
            var item = _repsitories.GetById(x=>x.ItemId == id);
            if (item is null)
                return NotFound($"no data by this id {id}");
            var relatedItems = _repsitories.GetRelatedItems(x => x.SalesPrice <= x.SalesPrice + 50 && x.SalesPrice >= x.SalesPrice - 50).Take(10);
            return Ok(relatedItems);
        }
        [HttpGet("GetAllAsync")]
        public async Task< IActionResult> GetAllAsync() =>
            Ok(await _repsitories.GetAllAsync());

        [HttpPost("AddItem")]
        public IActionResult AddItem([FromForm] TbItem item)
        {
            var data = _repsitories.Add(item);
            if (data is null)
                return BadRequest("data not complied");
            return Ok(data);
        }
        [HttpPost("AddItemAsync")]
        public async Task< IActionResult> AddItemAsync([FromForm] TbItem item)
        {
            var data = await _repsitories.AddAsync(item);
            if (data is null)
                return BadRequest("data not complied");
            return Ok(data);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update (int id , [FromForm] TbItem item)
        {
            if (id != item.ItemId)
                return BadRequest();
            var data = _repsitories.Update(item);
            return Ok(data);
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] TbItem item)
        {
            if (id != item.ItemId)
                return BadRequest();
            var data =await  _repsitories.UpdateAsync(item);
            return Ok(data);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _repsitories.GetById(x => x.ItemId == id);
            if (data is null)
                return BadRequest();
            _repsitories.Delete(data);
            return Ok(data);
        }
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _repsitories.GetByIdAsync(id , x =>x.ItemId == id);
            if (data is null)
                return BadRequest();
            await _repsitories.DeleteAsync(data);
            return Ok(data);
        }
    }
}
