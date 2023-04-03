using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AppUser
{
    public int IdUser { get; set; }

    public string NameUser { get; set; } = null!;

    public string DepartementUser { get; set; } = null!;

    public string PosteUser { get; set; } = null!;
}
