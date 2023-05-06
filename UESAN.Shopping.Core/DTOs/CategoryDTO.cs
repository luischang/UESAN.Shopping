using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Shopping.Core.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CategoryDescriptionDTO 
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryInsertDTO 
    {
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }


}
