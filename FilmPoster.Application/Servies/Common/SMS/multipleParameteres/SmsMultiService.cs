using FilmPoster.Application.Interfaces.Contexts;
using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using Filmposter.Common.Constants;

namespace FilmPoster.Application.Servies.Common.SMS.multipleParameteres
{
    public class SmsMultiService : ISmsMultiService
    {
        private readonly IDataBaseContext _context;
        public SmsMultiService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestSmsMultiServiceDto req)
        {
            string? phone = GetUserPhone((Guid)req.UserId);
            var result = await SendSmsAsync(phone, req.Pattern, req.Arguments_Parameters);
            return result;
        }
        public async Task<ResultDto> SendSmsAsync(string toPhone, string pattern, List<Dictionary<string, string>> inputData)
        {
            try
            {
                if (!string.IsNullOrEmpty(toPhone))
                {
                    var client = new RestClient(SmsConstants.RestAPI);
                    var request = new RestRequest { Method = Method.Post };

                    request.AddHeader("Content-Type", "application/json");

                    string inputDataJson = JsonSerializer.Serialize(inputData);

                    string body = $"{{ \"op\": \"pattern\", \"user\": \"{SmsConstants.Username}\", \"pass\": \"{SmsConstants.Password}\", \"fromNum\": \"{SmsConstants.NumberHamkaran}\", \"toNum\": \"{toPhone.Trim()}\", \"patternCode\": \"{pattern.Trim()}\",  \"inputData\": {inputDataJson} }}";
                    request.AddParameter("application/json", body, ParameterType.RequestBody);

                    var response = await client.ExecuteAsync(request);

                    return new ResultDto
                    {
                        IsSuccess = response.IsSuccessful,
                        Message = response.Content
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                };
            }
        }
        private string? GetUserPhone(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return null;
            else return user.Phone;
        }
    }
}
