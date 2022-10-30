using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDTO
{
    [XmlType("Officer")]
    public class OfficerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Money")]
        public decimal Money { get; set; }
        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }
        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }
        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }
        [XmlArray("Prisoners")]
        public List<OffiPrisonersDTO> Prisoners { get; set; }
    }
}
