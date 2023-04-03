using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class SubCategorie
{
    public int IdSubCategorie { get; set; }

    public string NameSubCategorie { get; set; } = null!;

    public int IdCategorie { get; set; }

    public virtual Categorie IdCategorieNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
