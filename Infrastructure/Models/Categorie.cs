using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Categorie
{
    public int IdCategorie { get; set; }

    public string NameCategorie { get; set; } = null!;

    public virtual ICollection<SubCategorie> SubCategories { get; } = new List<SubCategorie>();
}
