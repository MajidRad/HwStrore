using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Detail
{
    public class DetailDto_Base:BaseDto
    {
        public string? PropertyName { get; set; }
        public string? PropertyValue { get; set; }

    }
}
