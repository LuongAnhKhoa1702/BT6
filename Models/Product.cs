﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace BT6.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã sản phẩm")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc"), StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [Range(1.000, 1000000.000, ErrorMessage = "Giá sản phẩm phải nằm trong khoảng từ 1.000 đến 1000000.000")]
        [DisplayName("Giá bán")]
        public decimal Price { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Hình ảnh")]
        public string? ImageUrl { get; set; }

        public List<ProductImage>? Images { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Mã danh mục")]
        public int CategoryId { get; set; }

        [DisplayName("Danh mục")]
        public Category? Category { get; set; }
    }
}
