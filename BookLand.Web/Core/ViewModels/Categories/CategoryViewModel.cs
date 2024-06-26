﻿namespace BookLand.Web.Core.ViewModels.Categories;

public class CategoryViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public bool IsDeleted { get; set; }
}
