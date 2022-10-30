using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class CastDTO
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [XmlAttribute("FullName")]
        public string FullName { get; set; }
        [Required]
        [XmlAttribute("MainCharacter")]
        public string IsMainCharacter { get; set; }
    }
}
