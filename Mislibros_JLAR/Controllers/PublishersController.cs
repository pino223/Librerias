using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mislibros_JLAR.Data.Services;
using Mislibros_JLAR.Data.ViewModels;

namespace Mislibros_JLAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }
    }
}
