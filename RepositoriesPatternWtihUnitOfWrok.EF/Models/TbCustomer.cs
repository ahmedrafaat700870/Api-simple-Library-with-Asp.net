using System;
using System.Collections.Generic;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Models
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            Items = new HashSet<TbItem>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

        public virtual TbBusinessInfo? TbBusinessInfo { get; set; }

        public virtual ICollection<TbItem> Items { get; set; }
    }
}
