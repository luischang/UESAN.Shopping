using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.DTOs
{
    public class OrdersDTO
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? UserId { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();

        public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();

        public virtual User? User { get; set; }
    }

    public class OrdersInsertDTO 
    {
        public int? UserId { get; set; }
        public IEnumerable<OrderDetailInsertDTO> OrderDetail { get; set; }

    }
}
