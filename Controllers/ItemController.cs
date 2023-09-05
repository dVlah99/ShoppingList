//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using test.Models;
//using test.Services;

//namespace test.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [Controller]
//    public class ItemController : Controller
//    {
//        private readonly MongoDBService _context;

//        public ItemController(MongoDBService context)
//        {
//            _context = context;
//        }

//        // Create/Edit
//        [HttpPost]
//        public JsonResult CreateItem(Item item)
//        {

//        }

//        //Get
//        [HttpGet]
//        public JsonResult GetItem(int id)
//        {

//        }

//        //Delete
//        [HttpDelete]
//        public JsonResult Delete(int id)
//        {
//        }

//        //Get All
//        [HttpGet("/GetAll")]
//        public JsonResult GetAll()
//        {

//        }
//    }
//}
