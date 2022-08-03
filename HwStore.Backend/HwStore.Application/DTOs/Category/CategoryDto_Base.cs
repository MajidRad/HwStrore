using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Category
{
    public class CategoryDto_Base:BaseDto
    {
        public string? Name { get; set; }
        public int ParentCategoryId { get; set; }
        
    }
}
