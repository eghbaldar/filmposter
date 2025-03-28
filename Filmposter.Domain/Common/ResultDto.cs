﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Domain.Common
{
    public class ResultDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class ResultDto<T>
    {
        public T Date { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
