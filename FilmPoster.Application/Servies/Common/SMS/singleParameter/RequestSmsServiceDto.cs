using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Servies.Common.SMS.singleParameter
{
    public class RequestSmsServiceDto
    {
        public Guid? UserId { get; set; } // آیدی کاربری که قرار است که پیام را دریافت کند گرگفته شود که آیا موجودی دریافت اس ام اس دارد یا خیر
        public string Pattern { get; set; }

        // دو پروپرتی زیر وقتی استفاده میشود که فقط بخواهیم کد امنیتی را ارسال کنیم
        public string? Phone { get; set; }
        public string? ValidationCode { get; set; }
    }
}
