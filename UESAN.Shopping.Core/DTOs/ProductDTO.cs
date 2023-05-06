using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Shopping.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? Stock { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public int? CategoryId { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ProductDescriptionDTO 
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class ProductInsertDTO 
    {
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? Stock { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ProductUpdateDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? Stock { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public int? CategoryId { get; set; }

        public bool? IsActive { get; set; }
    }
}
