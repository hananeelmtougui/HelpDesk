using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class ProductCaracteristic
{
    public int IdCaracteristic { get; set; }

    public int IdProduct { get; set; }

    public string? Value { get; set; }
   
    public virtual Caracteristic IdCaracteristicNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Product IdProductNavigation { get; set; } = null!;
}
