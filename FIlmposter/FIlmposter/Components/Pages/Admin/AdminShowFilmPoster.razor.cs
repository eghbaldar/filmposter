using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using FIlmposter.Layout;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

namespace FIlmposter.Components.Pages.Admin
{
    public partial class AdminShowFilmPoster
    {
        [Parameter]
        public string? Category { get; set; }
        public string? CategoryName { get; set; }
        [CascadingParameter]
        public SingleLayout ParentLayout { get; set; }  // The CascadingParameter of the parent layout

        // fethc the first records

    private ResultGetFilmPostersServiceDto? filmposters;

        protected override async Task OnInitializedAsync()
        {
            // Update subTitle of the parent layou
            if (Category == "adminNationalFilmPosters")
            {
                CategoryName = "پوستر فیلم‌های‌ ایرانی";
                if (ParentLayout != null) ParentLayout.UpdateTitle(CategoryName);
            }
            else if (Category == "adminForeignFilmPosters")
            {
                CategoryName = "پوستر فیلم‌های‌ خارجی";
                if (ParentLayout != null) ParentLayout.UpdateTitle(CategoryName);
            }
            // fethc the first records
            try
            {
                filmposters = await _http.GetFromJsonAsync<ResultGetFilmPostersServiceDto>("/api/FilmPosters");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                // Handle error (show to user, etc.)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex}");
            }
        }
    }
}
