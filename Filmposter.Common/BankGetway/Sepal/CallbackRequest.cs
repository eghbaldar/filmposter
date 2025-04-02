using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Common.BankGetway.Sepal
{
    internal class CallbackRequest
    {
        public int Status { get; set; }
        public string? PaymentNumber { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}
