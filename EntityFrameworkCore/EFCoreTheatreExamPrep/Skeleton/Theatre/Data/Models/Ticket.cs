﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }
        [ForeignKey(nameof(Play))]
        [Required]
        public int PlayId { get; set; }
        public Play Play { get; set; }
        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}
