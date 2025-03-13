﻿using System.ComponentModel.DataAnnotations;

namespace _2280605191_HoQuocCuong.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
