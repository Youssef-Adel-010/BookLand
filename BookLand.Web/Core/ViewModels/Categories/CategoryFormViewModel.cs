﻿namespace BookLand.Web.Core.ViewModels.Categories;

public class CategoryFormViewModel
{
    public int Id { get; set; }

    [MaxLength(20, ErrorMessage = "The maximum length is 100 characters")]
    [Remote("IsAllowedRecord", "Categories", AdditionalFields = nameof(Id), ErrorMessage = "This name is already exists")]
    public string Name { get; set; } = null!;
}
