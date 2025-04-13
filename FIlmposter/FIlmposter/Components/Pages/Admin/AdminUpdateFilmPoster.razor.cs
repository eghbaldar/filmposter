using Filmposter.Domain.Entities.FilmPosters;
using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FilmPoster.Application.Servies.FilmPosters.Queries.GetFilmPosterById;
using FilmPoster.Application.Servies.NationFilmPosters.Queries.GetNationFilmPosters;
using FIlmposter.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FIlmposter.Components.Pages.Admin
{
    public partial class AdminUpdateFilmPoster
    {
        #region Properties
        [Parameter]
        public string id { get; set; } // get dynamic parameter of url to recognize with part should be loaded
        public string? posterTitle { get; set; } // get poster title
        [CascadingParameter]
        public SingleLayout ParentLayout { get; set; }  // The CascadingParameter of the parent layout to change the value in SingleLayou
        private GetFilmPosterByIdServiceDto? filmPoster = new(); // the Request Dto to Post the values of fields
        private string? responseMessage;
        private bool isLoading = true;
        private bool shouldReInitDatePicker; // I use this proerpty to remain the Shamsidate after being changed!

        #endregion

        #region FileControl
        private IBrowserFile selectedFile;
        private bool fileValidation;
        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            fileValidation = true; // clear previous error
            if (selectedFile == null)
            {
                fileValidation = false;
                return;
            }
            // upload a new poster
            var multipart = new MultipartFormDataContent();
            multipart.Add(new StringContent("1250000"), "maxSize");            
            if (selectedFile != null) // Add the file if selected
            {
                var fileStreamContent = new StreamContent(selectedFile.OpenReadStream(25 * 1024 * 1024));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(selectedFile.ContentType);
                multipart.Add(fileStreamContent, "File", selectedFile.Name); // Name must match DTO property
            }
            var response = await _http.PutAsync($"/api/FilmPosters/PutFile/{filmPoster.Id}", multipart);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var root = JsonDocument.Parse(jsonString).RootElement;
                if (root.TryGetProperty("isSuccess", out var isSuccessProp) && isSuccessProp.GetBoolean())
                {
                    await JS.InvokeVoidAsync("KingSweetAlertTopRightTimer", new
                    {
                        message = "پوستر با موفقیت تغییر کرد.",
                        icon = "success",
                    });
                    await JS.InvokeVoidAsync("ChangeTheNewPoster", $"/UploadedStuff/admin/images/admin-filmposter/{root.GetProperty("message")}-thumb.jpg");
                }
                else
                {
                    await JS.InvokeVoidAsync("KingSweetAlertTopRightTimer", new
                    {
                        message = root.GetProperty("message"),
                        icon = "warning",
                    });
                }
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Process failed by APi: {error}");
            }
        }
        private async Task TriggerFileInput()
        {
            await JS.InvokeVoidAsync("openFileBrowser");
        }
        #endregion

        #region Validation        
        public EditContext editContext;
        public ElementReference titleFaInput;
        public ElementReference dierctorInput;
        public ElementReference producerInput;
        public ElementReference summaryInput;
        private string GetFieldClass(string fieldName)
        {
            if (editContext == null)
                return "";

            var field = editContext.Field(fieldName);
            return editContext.GetValidationMessages(field).Any() ? "is-invalid" : "";
        }
        private async Task CheckValidation()
        {
            // Call JavaScript to scroll to the first invalid field
            // Create an array of ElementReferences for invalid fields
            var invalidElements = new List<ElementReference>();

            if (editContext.GetValidationMessages(editContext.Field(nameof(filmPoster.TitleFa))).Any())
            {
                invalidElements.Add(titleFaInput);
            }
            if (editContext.GetValidationMessages(editContext.Field(nameof(filmPoster.Director))).Any())
            {
                invalidElements.Add(dierctorInput);
            }
            if (editContext.GetValidationMessages(editContext.Field(nameof(filmPoster.Producer))).Any())
            {
                invalidElements.Add(producerInput);
            }
            if (editContext.GetValidationMessages(editContext.Field(nameof(filmPoster.Summary))).Any())
            {
                invalidElements.Add(summaryInput);
            }
            // Pass the array of invalid ElementReferences to JavaScript for scrolling
            if (invalidElements.Any())
            {
                await JS.InvokeVoidAsync("scrollToElements", invalidElements.ToArray());
                // Show SweetAlert for invalid form
                await JS.InvokeVoidAsync("Swal.fire", new
                {
                    title = "خطا",
                    text = "لطفاً تمام فیلدهای اجباری را پر کنید",
                    icon = "warning",
                    confirmButtonText = "باشه"
                });
            }
            return;
        }
        private async Task Succeed()
        {
            await JS.InvokeVoidAsync("KingSweetAlertTopRightTimer", new
            {
                message = "ویرایش با موفقیت انجام شد.",
                icon = "info",
            });
        }
        private void ValidateField()
        {
            editContext.Validate(); // Manually trigger field validation
        }
        #endregion

        protected override async Task OnInitializedAsync()
        {
            if (ParentLayout != null) ParentLayout.UpdateTitle(posterTitle);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {                
                isLoading = true;
                StateHasChanged();
                //TODO: delete the following line
                await Task.Delay(500);
                // fetch the data
                //TODO: send the userId to check whether s/she is a right person to modify this filmposter or not (is it owner?)
                //TODO: of course, the ADMINs are exceptional for this action!
                var result = await _http.GetFromJsonAsync<ResultGetFilmPosterByIdServiceDto>($"/api/FilmPosters/GetById/{id}");
                if (result.Result.IsSuccess)
                {
                    GetFilmPosterByIdServiceDto _filmPoster = result.Result.Date;
                    filmPoster = _filmPoster;
                }
                else
                {
                    filmPoster = null;
                }                
                isLoading = false;                
                editContext = new EditContext(filmPoster);                
                StateHasChanged();
                // the following line must be added at the end of the process                
                await JS.InvokeVoidAsync("initializePersianDatePicker");
            }
            else
            {
                if (shouldReInitDatePicker)
                {
                    await JS.InvokeVoidAsync("setShamsiProductionDate", filmPoster.ProductionDate.ToString("yyyy-MM-dd"));
                    shouldReInitDatePicker = false;
                }
            }
        }
        private async Task SubmitForm(string posterId)
        {
            // check validation
            if (!editContext.Validate()) await CheckValidation();
            else
            {
                // process ...
                try
                {
                    if (filmPoster == null) return;

                    var multipart = new MultipartFormDataContent();

                    // Add all fields as key-value pairs
                    multipart.Add(new StringContent(posterId.ToString() ?? ""), "PosterId");
                    multipart.Add(new StringContent(filmPoster.TitleFa ?? ""), "TitleFa");
                    multipart.Add(new StringContent(filmPoster.TitleEn ?? ""), "TitleEn");
                    multipart.Add(new StringContent(filmPoster.Director ?? ""), "Director");
                    multipart.Add(new StringContent(filmPoster.Producer ?? ""), "Producer");
                    multipart.Add(new StringContent(filmPoster.Summary ?? ""), "Summary");
                    multipart.Add(new StringContent(filmPoster.Worth.ToString()), "Worth");
                    multipart.Add(new StringContent(filmPoster.ShortFeature.ToString()), "ShortFeature");
                    multipart.Add(new StringContent(filmPoster.Style.ToString()), "Style");
                    multipart.Add(new StringContent(filmPoster.Validation.ToString()), "Validation");
                    multipart.Add(new StringContent(filmPoster.FilmPoster.ToString()), "FilmPoster");
                    

                    var gregorianDateStr = await JS.InvokeAsync<string>("getGregorianProductionDate");
                    filmPoster.ProductionDate = DateOnly.ParseExact(gregorianDateStr, "yyyy-MM-dd");
                    multipart.Add(new StringContent(filmPoster.ProductionDate.ToString("yyyy-MM-dd")), "ProductionDate");



                    var response = await _http.PutAsync("/api/FilmPosters", multipart);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var root = JsonDocument.Parse(jsonString).RootElement;
                        if (root.TryGetProperty("isSuccess", out var isSuccessProp) && isSuccessProp.GetBoolean())
                        {
                            await JS.InvokeVoidAsync("KingSweetAlertTopRightTimer", new
                            {
                                message = "اطلاعات با موفقیت تغییر کرد.",
                                icon = "success",
                            });
                        }
                        else
                        {
                            await JS.InvokeVoidAsync("KingSweetAlertTopRightTimer", new
                            {
                                message = root.GetProperty("message"),
                                icon = "warning",
                            });
                        }
                        shouldReInitDatePicker = true;
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Process failed by APi: {error}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                // the process is done successfully
                await Succeed();
            }
        }
    }
}
