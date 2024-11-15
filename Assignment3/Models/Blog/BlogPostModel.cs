using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Assignment3
{ 
    public class BlogPostModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = "";

        [Required]
        public string Author { get; set; } = "";

    }
}