using Filmposter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Entities.Financial
{
    public class DesignTariff:BaseEntityGuid
    {
        public byte Type { get; set; } // DesignTariffConstants.cs
        public string StaticTariff { get; set; } // هزینه ثابت
        public string LogoTypeTariff { get; set; } // این گزینه برای کاربر میتواند انتخابی باشد
        public string TwoVersion { get; set; } // این گزینه یعنی اینکه اگر کاربر درخواست دو ورژن کرد یعنی بغیر از فارسی انگلیسی خواتس و یا بغیر فارسی هم خواست
    }
}
