using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string? ReasonContent { get; set; }
        public string? TypeOrder { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ShipAddress { get; set; } = null!;

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
