using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using Microsoft.AspNetCore.Mvc;

namespace Filmposter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Correct route definition
    public class FilmPostersController : Controller
    {
        // Injection Section
        private readonly IFilmPostersFacade _filmPostersFacade;
        public FilmPostersController(IFilmPostersFacade filmPostersFacade)
        {
            _filmPostersFacade = filmPostersFacade;
        }
        // End of Injection Section

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_filmPostersFacade.GetFilmPostersService.Execute());
        }
        [HttpPost]
        public IActionResult Post(RequestPostFilmPosterServiceDto req)
        {
            return Json(_filmPostersFacade.PostFilmPosterService.Execute(req));
        }
    }
}
