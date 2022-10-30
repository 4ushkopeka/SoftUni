using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDTO
{
    public class MailDTO
    {
        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }
        [Required]
        [JsonProperty(nameof(Sender))]
        public string Sender { get; set; }
        [Required]
        [JsonProperty(nameof(Address))]
        public string Address { get; set; }
    }
}
