﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }

    }
}
