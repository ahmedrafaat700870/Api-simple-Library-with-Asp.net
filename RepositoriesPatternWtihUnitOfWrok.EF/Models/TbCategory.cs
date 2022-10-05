using System;
using System.Collections.Generic;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbItems = new HashSet<TbItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int CurrentState { get; set; }
        public string ImageName { get; set; } = null!;
        public bool? ShowInHomePage { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}
