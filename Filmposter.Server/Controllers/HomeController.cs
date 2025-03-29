using Microsoft.AspNetCore.Mvc;

namespace Filmposter.Server.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(); 
        }
    }
}
