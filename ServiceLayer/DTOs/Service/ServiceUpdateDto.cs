﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Service
{
    public class ServiceUpdateDto
    {
        public byte[]? Image { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}