using System;
using System.Collections.Generic;

namespace UESAN.Shopping.Core.Entities;

public partial class Orders
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
