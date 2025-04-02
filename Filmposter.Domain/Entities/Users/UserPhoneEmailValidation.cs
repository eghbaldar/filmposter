using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Users
{
    public class UserPhoneEmailValidation : BaseEntityGuid
    {        // هر کاربر میتواند هر تعداد میخواهد درخواست تائید بدهد
             // ولی فقط یکی از آنها تائید خواهد شد
             // و در صورت درخواست مجدد بقیه باید غیر فعال شوند
        public string? Phone { get; set; }
        public string? PhoneValidationCode { get; set; } // کُدی رندوم اس ام اس میشود
        public string? Email { get; set; }
        public string? EmailValidationCode { get; set; }  // کُدی رندوم ایمیل میشود
        public bool Validate { get; set; }
    }
}
