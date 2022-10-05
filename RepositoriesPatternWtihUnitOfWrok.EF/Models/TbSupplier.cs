﻿using System;
using System.Collections.Generic;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Models
{
    public partial class TbSupplier
    {
        public TbSupplier()
        {
            TbPurchaseInvoices = new HashSet<TbPurchaseInvoice>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<TbPurchaseInvoice> TbPurchaseInvoices { get; set; }
    }
}
