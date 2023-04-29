using System;
using System.Collections.Generic;

namespace UESAN.Shopping.Core.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public int? Discount { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorite { get; set; } = new List<Favorite>();

    public virtual ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductDetail> ProductDetail { get; set; } = new List<ProductDetail>();
}
