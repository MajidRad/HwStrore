﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Basket
{
    public class BasketItemDto_Upsert
    {
        public int Quantity { get; set; }

        public ProductDto_Base? Product { get; set; }
    }
}