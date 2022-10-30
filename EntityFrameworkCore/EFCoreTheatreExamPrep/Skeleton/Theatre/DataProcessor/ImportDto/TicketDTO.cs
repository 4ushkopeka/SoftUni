﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketDTO
    {
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }
        [Required]
        public int PlayId { get; set; }
    }
}
