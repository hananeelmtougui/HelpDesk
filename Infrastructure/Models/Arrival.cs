using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Arrival
{
    public int IdArrivals { get; set; }

    public DateTime DateArrival { get; set; }

    public int Quantity { get; set; }
   
    public virtual ICollection<Product> IdProducts { get; } = new List<Product>();
}
