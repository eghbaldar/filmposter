using Filmposter.Domain.Entities.Articles;
using Filmposter.Domain.Entities.FilmPosters;
using FilmPoster.Application.Servies.Common.SMS.singleParameter;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using FIlmposter.Layout;
using FIlmposter.Utilities.Helpers;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace FIlmposter.Components.Pages.Admin
{
    public partial class AdminShowFilmPoster
    {
        [Parameter]
        public string? Category { get; set; }
        public string? CategoryName { get; set; }
        [CascadingParameter]
        public SingleLayout ParentLayout { get; set; }  // The CascadingParameter of the parent layout        
        protected ResultGetFilmPostersServiceDto? filmposters;
        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                isLoading = true;
                StateHasChanged();
                await Task.Delay(3000);
                filmposters = await _http.GetFromJsonAsync<ResultGetFilmPostersServiceDto>("/api/FilmPosters");
                isLoading = false;
                StateHasChanged();
            }
        }
    }
}
