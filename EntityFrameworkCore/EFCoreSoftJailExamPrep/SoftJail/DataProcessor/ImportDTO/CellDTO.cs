using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDTO
{
    public class CellDTO
    {
        [Required]
        [Range(1, 1000)]
        [JsonProperty(nameof(CellNumber))]
        public int CellNumber { get; set; }
        [Required]
        [JsonProperty(nameof(HasWindow))]
        public bool HasWindow { get; set; }
    }
}
