﻿using System;
using System.Collections.Generic;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Models
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbItemDiscounts = new HashSet<TbItemDiscount>();
            TbItemImages = new HashSet<TbItemImage>();
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
            Customers = new HashSet<TbCustomer>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int CategoryId { get; set; }
        public string? ImageName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public int CurrentState { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? Gpu { get; set; }
        public string? HardDisk { get; set; }
        public int? ItemTypeId { get; set; }
        public string? Processor { get; set; }
        public int? RamSize { get; set; }
        public string? ScreenReslution { get; set; }
        public string? ScreenSize { get; set; }
        public string? Weight { get; set; }
        public int? OsId { get; set; }

        public virtual TbCategory Category { get; set; } = null!;
        public virtual TbItemType? ItemType { get; set; }
        public virtual TbO? Os { get; set; }
        public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; }
        public virtual ICollection<TbItemImage> TbItemImages { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }

        public virtual ICollection<TbCustomer> Customers { get; set; }
    }
}
