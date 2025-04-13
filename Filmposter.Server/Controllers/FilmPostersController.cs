using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterFile;
using FilmPoster.Application.Servies.FilmPosters.Commands.UpdateFilmPosterInformation;
using FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById;
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
        [HttpGet]
        [Route("GetById/{posterId}")]
        //https://www.binaryintellect.net/articles/9db02aa1-c193-421e-94d0-926e440ed297.aspx
        public IActionResult GetById(Guid posterId)
        {
            return Json(_filmPostersFacade.GetFilmPosterByIdService.Execute(new RequestGetFilmPosterByIdDto
            {
                PosterId = posterId
            }));
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] RequestPostFilmPosterServiceDto model)
        {
            if (model == null) return BadRequest("Form data is missing");

            var result = await _filmPostersFacade.PostFilmPosterService.Execute(model);
            return Json(result);
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put([FromForm] RequestUpdateFilmPosterInformationServiceDto model)
        {
            if (model == null) return BadRequest("Form data is missing");

            var result = await _filmPostersFacade.UpdateFilmPosterInformationService.Execute(model);
            return Json(result);
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        [Route("PutFile/{posterId}")]
        public async Task<IActionResult> Put([FromForm] RequestUpdateFilmPosterFileServiceDto model,string posterId)
        {
            if (model == null) return BadRequest("Form data is missing");
            model.PosterId = Guid.Parse(posterId);
            var result = await _filmPostersFacade.UpdateFilmPosterFileService.Execute(model);
            return Json(result);
        }
    }
}