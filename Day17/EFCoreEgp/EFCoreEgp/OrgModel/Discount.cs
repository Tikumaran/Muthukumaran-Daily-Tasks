﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreEgp.OrgModel
{
    public partial class Discount
    {
        public string Discounttype { get; set; }
        public string StorId { get; set; }
        public short? Lowqty { get; set; }
        public short? Highqty { get; set; }
        public decimal Discount1 { get; set; }

        public virtual Store Stor { get; set; }
    }
}
