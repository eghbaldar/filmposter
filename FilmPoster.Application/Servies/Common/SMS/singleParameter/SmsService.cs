using FilmPoster.Application.Interfaces.Contexts;
using Filmposter.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmposter.Common.Constants;
using RestSharp;

namespace FilmPoster.Application.Servies.Common.SMS.singleParameter
{
public class SmsService
    {
        private readonly IDataBaseContext _context;
        public SmsService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestSmsServiceDto req)
        {
            if (string.IsNullOrEmpty(req.Phone))
            {
                Dictionary<string, string>? nameAndPhone = CheckUser((Guid)req.UserId);
                if (nameAndPhone?.Count > 0)
                {
                    try
                    {
                        var result = await SendSmsAsync(nameAndPhone.ElementAt(0).Value, req.Pattern, nameAndPhone.ElementAt(0).Key);
                        return result;
                    }
                    catch (Exception ex)
                    {
                        return new ResultDto { IsSuccess = false, Message = ex.Message };
                    }
                }
                return new ResultDto { IsSuccess = false };
            }
            else
            {
                try
                {
                    var result = await SendSmsAsync(req.Phone, req.Pattern, req.ValidationCode);
                    return result;
                }
                catch (Exception ex)
                {
                    return new ResultDto { IsSuccess = false, Message = ex.Message };
                }
            }
        }
        public async Task<ResultDto> SendSmsAsync(string toPhone, string pattern, string nameOrValidationCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(toPhone))
                {
                    System.Threading.Thread.Sleep(500);
                    var client = new RestClient(SmsConstants.RestAPI);
                    var request = new RestRequest { Method = Method.Post };

                    request.AddHeader("Content-Type", "application/json");

                    string body = $"{{ \"op\": \"pattern\", \"user\": \"{SmsConstants.Username}\", \"pass\": \"{SmsConstants.Password}\", \"fromNum\": \"{SmsConstants.NumberHamkaran}\", \"toNum\": \"{toPhone.Trim()}\", \"patternCode\": \"{pattern.Trim()}\", \"inputData\": [{{ \"name\": \"{nameOrValidationCode}\" }}] }}";

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
        private Dictionary<string, string>? CheckUser(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return null;
            else return new Dictionary<string, string> { { user.Fullname, user.Phone } };
        }
    }
}
