using System;
using System.Collections.Generic;

namespace _2.AdsWeb.Entities.Entities;

public partial class Product
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Url { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public long CategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public ulong? IsDelete { get; set; }

    public virtual Category Category { get; set; } = null!;
}
