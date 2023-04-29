using System;
using System.Collections.Generic;

namespace UESAN.Shopping.Core.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Favorite> Favorite { get; set; } = new List<Favorite>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
