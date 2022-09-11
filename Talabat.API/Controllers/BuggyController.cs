using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.DAL;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.products.Find(1000);
            if(product == null) return NotFound(new ApiResponse(404));
            return Ok();
        }  
        [HttpGet("servererror")]
        public ActionResult GetserverError()
        {
            var product = _context.products.Find(1000);
            var productToReturn = product.ToString(); //exception [nullreferenceException]
            return Ok();
        }  
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
           return BadRequest( new ApiResponse(400));
        } 
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id) // validation error
        {
           return BadRequest();
        }

    }
}
