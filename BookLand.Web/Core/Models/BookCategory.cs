﻿namespace BookLand.Web.Core.Models;

public class BookCategory
{
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }

    public Book? Book { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
