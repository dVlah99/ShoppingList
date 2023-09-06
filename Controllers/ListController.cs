using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Services;

namespace test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly MongoDBService _context;

        public ListController(MongoDBService context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<List<GList>> GetLists()
        {
            return await _context.GetAsync();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostList([FromBody] GList _list) {
            foreach (var item in _list.Items) {
                var enumValidation = EnumValidator.IsEnumValueValid<Measurement>(item.Measurement.ToUpper());
                if(!enumValidation)
                {
                    return NoContent();
                }
            }
            await _context.CreateAsync(_list);
            return CreatedAtAction(nameof(GetLists), new {id = _list.Id, storeName = _list.StoreName, _list});
        }

        public static bool IsEnumValueValid<TEnum>(string value) where TEnum : struct, Enum
        {
            return Enum.TryParse(value, out TEnum result);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList(string id, [FromBody] Item item)
        {
            await _context.AddToListAsync(id, item);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditItem(string id, string itemName ,[FromBody] Item item)
        {
            await _context.EditItemAsync(id, itemName, item);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CheckItem(string id, string itemName)
        {
            await _context.CheckItemAsync(id, itemName);
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(string id)
        {
            await _context.DeleteAsync(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllItems(string id)
        {
            await _context.DeleteAllItemsAsync(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id, string itemName)
        {
            await _context.DeleteItemAsync(id, itemName);

            return NoContent();
        }
    } 
}
