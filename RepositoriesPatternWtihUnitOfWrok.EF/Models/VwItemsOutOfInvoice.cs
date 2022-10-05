﻿using System;
using System.Collections.Generic;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Models
{
    public partial class VwItemsOutOfInvoice
    {
        public string? ItemName { get; set; }
        public string CategoryName { get; set; } = null!;
        public decimal? InvoicePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
    }
}
