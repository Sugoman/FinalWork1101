using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderComposition { get; set; } = null!;

    public int OrderCount { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int OrderPickupPointId { get; set; }

    public string? OrderClientSurname { get; set; }

    public string? OrderClientFirstName { get; set; }

    public string? OrderClientPatronymic { get; set; }

    public int OrderCode { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual PickupPoint OrderPickupPoint { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Product> ProductArticleNumbers { get; set; } = new List<Product>();
}
