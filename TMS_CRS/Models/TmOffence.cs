﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmOffence
    {
        public int OffenceId { get; set; }
        public string OffenceType { get; set; }
        public string VehType { get; set; }
        public int Penalty { get; set; }
    }
}
