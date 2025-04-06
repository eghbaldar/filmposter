using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Filmposter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmPostersController : Controller
    {
        private readonly IFilmPostersFacade _filmPostersFacade;
        public FilmPostersController(IFilmPostersFacade filmPostersFacade)
        {
            _filmPostersFacade = filmPostersFacade;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_filmPostersFacade.GetFilmPostersService.Execute());
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] RequestPostFilmPosterServiceDto model)
        {
            if (model == null) return BadRequest("Form data is missing");

            var result = _filmPostersFacade.PostFilmPosterService.Execute(model);
            return Json(result);
        }

    }
}