using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;

namespace Filmposter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Correct route definition
    public class NationFilmPostersController : Controller
    {
        // Injection Section
        private readonly INationFilmPostersFacade _nationFilmPostersFacade;
        public NationFilmPostersController(INationFilmPostersFacade nationFilmPostersFacade)
        {
            _nationFilmPostersFacade = nationFilmPostersFacade;
        }
        // End of Injection Section

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_nationFilmPostersFacade.GetNationFilmPostersService.Execute());
        }
    }
}
