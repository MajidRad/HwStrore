using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Specification
{
    public class SpecificationDto_Base:BaseDto
    {
        public string? SpecLabel { get; set; }
        public string? SpecValue { get; set; }

    }
}
