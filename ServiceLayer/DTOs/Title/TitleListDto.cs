﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Title
{
    public class TitleListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
