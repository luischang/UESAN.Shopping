using System;
using System.Collections.Generic;

namespace UESAN.Shopping.Core.Entities;

public partial class ProductDetail
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }
}
