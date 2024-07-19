using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2301B2TempEmbedding.Models;

public partial class Category
{
    [Key]
    public int CatId { get; set; }

    public string CatName { get; set; } = null!;

    public string CatDescription { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
