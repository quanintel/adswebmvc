using System;
using System.Collections.Generic;

namespace _2.AdsWeb.Entities.Entities;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public ulong? IsDelete { get; set; }
}
