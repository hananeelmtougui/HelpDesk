using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int? IdSubCategorie { get; set; }

    public string Categorie { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Marque { get; set; } = null!;

    public byte[]? Picture { get; set; }

    [JsonIgnore]
    public virtual SubCategorie? IdSubCategorieNavigation { get; set; }

    public virtual ICollection<ProductCaracteristic> ProductCaracteristics { get; } = new List<ProductCaracteristic>();
    [JsonIgnore]
    public virtual ICollection<ProductSerial> ProductSerials { get; } = new List<ProductSerial>();
    [JsonIgnore]
    public virtual ICollection<Arrival> IdArrivals { get; } = new List<Arrival>();
}
