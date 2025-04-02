using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Common.Constants
{
    public sealed class BankStatusConstants
    {
        public const byte Generated = 0; // فاکتور ایجاد اولیه شده است
        public const byte Sent = 1; // فاکتور به سمت بانک رفته است
        public const byte Failed = 2;
        public const byte Succeed = 3;
    }
}
