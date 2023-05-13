using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.DTOs
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }

    public class FavoriteListDTO
    {
        public int Id { get; set; }
        public ProductCategoryDTO Product { get; set; }

    }

    public class FavoriteInsertDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
