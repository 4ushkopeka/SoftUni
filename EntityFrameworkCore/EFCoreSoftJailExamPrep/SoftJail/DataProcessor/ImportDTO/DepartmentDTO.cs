using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SoftJail.DataProcessor.ImportDTO
{
    [JsonObject]
    public class DepartmentDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        [JsonProperty(nameof(Cells))]
        public ICollection<CellDTO> Cells { get; set; }
    }
}
