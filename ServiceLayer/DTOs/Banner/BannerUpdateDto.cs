﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Banner
{
    public class BannerUpdateDto
    {
        public byte[]? Image { get; set; }

        public string? Title { get; set; }
    }
}