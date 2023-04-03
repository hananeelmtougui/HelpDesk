using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Caracteristic
{
    public int IdCaracteristic { get; set; }

    public string NameCaracteristic { get; set; } = null!;

    public virtual ICollection<ProductCaracteristic> ProductCaracteristics { get; } = new List<ProductCaracteristic>();
}
