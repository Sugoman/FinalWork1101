using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public int PickupPointIndex { get; set; }

    public string PickupPointCity { get; set; } = null!;

    public string PickupPointStreet { get; set; } = null!;

    public int PickupPointHouse { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
