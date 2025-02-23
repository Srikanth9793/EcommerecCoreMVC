﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Product
    {
        public int ProductId {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string ImageUrl { get; set; } = "https://via.placeholder.com/50";

        [ValidateNever]
        public Category? Category { get; set; }

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; }
    }
}