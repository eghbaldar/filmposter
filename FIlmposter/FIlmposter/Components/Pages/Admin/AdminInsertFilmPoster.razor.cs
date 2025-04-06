using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FIlmposter.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace FIlmposter.Components.Pages.Admin
{
    public partial class AdminInsertFilmPoster
    {
        [Parameter]
        public string? Category { get; set; }
        public string? CategoryName { get; set; }
        [CascadingParameter]
        public SingleLayout ParentLayout { get; set; }  // The CascadingParameter of the parent layout

        protected override async Task OnInitializedAsync()
        {
            if (ParentLayout != null)
            {
                // Update subTitle of the parent layout
                switch (Category)
                {
                    case "adminInsertNationalFilmPosters":
                        CategoryName = "درج پوستر فیلم ایرانی";
                        ParentLayout.UpdateTitle(CategoryName);
                        break;
                    case "adminInsertForeignFilmPosters":
                        CategoryName = "درج پوستر فیلم‌ خارجی";
                        ParentLayout.UpdateTitle(CategoryName);
                        break;
                }
            }
        }
        private RequestPostFilmPosterServiceDto filmPoster = new();
        private string? responseMessage;

        private IBrowserFile selectedFile;

        private void HandleFileSelected(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
        }

        private async Task SubmitForm()
        {
            try
            {
                if (filmPoster == null) return;

                var multipart = new MultipartFormDataContent();

                // Add all fields as key-value pairs
                multipart.Add(new StringContent(filmPoster.TitleFa ?? ""), "TitleFa");
                multipart.Add(new StringContent(filmPoster.TitleEn ?? ""), "TitleEn");
                multipart.Add(new StringContent(filmPoster.Director ?? ""), "Director");
                multipart.Add(new StringContent(filmPoster.Producer ?? ""), "Producer");
                multipart.Add(new StringContent(filmPoster.Summary ?? ""), "Summary");
                multipart.Add(new StringContent(filmPoster.ProductionDate.ToString("yyyy-MM-dd")), "ProductionDate");
                multipart.Add(new StringContent(filmPoster.Foreign.ToString()), "Foreign");
                multipart.Add(new StringContent(filmPoster.Worth.ToString()), "Worth");
                multipart.Add(new StringContent(filmPoster.ShortFeature.ToString()), "ShortFeature");
                multipart.Add(new StringContent(filmPoster.Style.ToString()), "Style");
                multipart.Add(new StringContent(filmPoster.Validation.ToString()), "Validation");
                multipart.Add(new StringContent("1250000"), "maxSize");

                // Add the file if selected
                if (selectedFile != null)
                {
                    var fileStreamContent = new StreamContent(selectedFile.OpenReadStream(25 * 1024 * 1024));
                    fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(selectedFile.ContentType);
                    multipart.Add(fileStreamContent, "File", selectedFile.Name); // Name must match DTO property
                }

                var response = await _http.PostAsync("/api/FilmPosters", multipart);

                if (response.IsSuccessStatusCode)
                {
                    // Success logic
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Upload failed: {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
}
