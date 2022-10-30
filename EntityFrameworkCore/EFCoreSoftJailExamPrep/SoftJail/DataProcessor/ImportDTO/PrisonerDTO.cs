using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SoftJail.DataProcessor.ImportDTO
{
    public class PrisonerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; }
        [Required]
        [JsonProperty(nameof(Nickname))]
        public string Nickname { get; set; }
        [Required]
        [Range(18, 65)]
        [JsonProperty(nameof(Age))]
        public int Age { get; set; }
        [Required]
        [JsonProperty(nameof(IncarcerationDate))]
        public string IncarcerationDate { get; set; }
        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; }
        [JsonProperty(nameof(Bail))]
        public decimal? Bail { get; set; }
        [JsonProperty(nameof(CellId))]
        public int? CellId { get; set; }
        [JsonProperty(nameof(Mails))]
        public ICollection<MailDTO> Mails { get; set; }
    }
}
