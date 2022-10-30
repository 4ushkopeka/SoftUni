using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDTO
{
    [XmlType("Prisoner")]
    public class OffiPrisonersDTO
    {
        [XmlAttribute("id")]
        public int PrisonerId { get; set; }
    }
}
