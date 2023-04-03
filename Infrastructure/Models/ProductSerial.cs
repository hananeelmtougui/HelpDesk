using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class ProductSerial
{
    public int IdNumProduct { get; set; }

    public string NumMatricule { get; set; } = null!;

    public string NumSerie { get; set; } = null!;

    public int IdProduct { get; set; }

   
    public virtual Product IdProductNavigation { get; set; } = null!;
}
