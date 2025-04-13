using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Common.Constants
{
    public abstract class DesignTariffConstants
    {
        public const byte Still = 0; // طراحی پوستر با استفاده از تصاویر فیلم و یا تصاویر خارجی
        public const byte Paint = 1; // طراحی پوستر بصورت نقاشی دیجیتال
        public const byte ThreeD = 2; // طراحی پوستر بصورت 3دی
        public const byte Photography = 3; // طراحی پوستر با استفاده از عکاسی توسط طراح
        public const byte Objective = 3; // طراحی پوستر با استفاده از ساخت مجسه و یا شی ای توسط طراح مانند گِل
        public const byte Mixed = 4; // تلفیقی
    }
}
