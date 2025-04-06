using FilmPoster.Application.Servies.FilmPosters.Commands.PostFilmPoster;
using FIlmposter.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.JSInterop;

namespace FIlmposter.Components.Pages.Admin
{
    public partial class AdminInsertFilmPoster
    {
        #region Properties
        [Parameter]
        public string? Category { get; set; } // get dynamic parameter of url to recognize with part should be loaded
        public string? CategoryName { get; set; } // get dynamic parameter of url to recognize with part should be named
        [CascadingParameter]
        public SingleLayout ParentLayout { get; set; }  // The CascadingParameter of the parent layout to change the value in SingleLayou
        private RequestPostFilmPosterServiceDto filmPoster = new(); // the Request Dto to Post the values of fields
        private string? responseMessage;
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
            filmPoster.Filename = selectedFile.Name;
            editContext?.NotifyFieldChanged(editContext.Field(nameof(filmPoster.Filename)));
            editContext?.NotifyValidationStateChanged();
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
            if (!fileValidation)
            {
                invalidElements.Add(summaryInput); // I used again from "summaryInput" becase I can't set "ref" attribute on <InputFile>
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
            await JS.InvokeVoidAsync("Swal.fire", new
            {
                title = "موفق",
                text = "اطلاعات با موفقیت ثبت شد",
                icon = "success",
                confirmButtonText = "ادامه"
            });
        }
        #endregion

        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(filmPoster);
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
        private async Task SubmitForm()
        {
            // check validation
            if (!editContext.Validate() || !fileValidation) await CheckValidation();
            else
            {
                // process ...
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
                    multipart.Add(new StringContent(filmPoster.Filename.ToString()), "Filename");
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
                // the process is done successfully
                await Succeed();
            }
        }
    }
}
